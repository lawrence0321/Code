using Common;
using Common.DTO;
using Common.Enums;
using Common.Extension;
using Controller.Interface;
using Service.DataBase.Interface;
using Service.CSV;
using Service.CSV.Interface;
using Service.Device.Enums;
using Service.Device.Interface;
using Service.MES.Interface;
using System;
using System.Threading;

namespace Controller.Implement
{
    internal class DeviceController :AbstractDisposable, IDeviceController
    {
        public bool IsConnectPLC1 => DeviceService.IsConnect_PLC1;
        public bool IsConnectPLC2 => DeviceService.IsConnect_PLC2;

        ILoadController LoadController => AutofacConfig.Resolve<ILoadController>();
        IMESController MESController => AutofacConfig.Resolve<IMESController>();

        IDeviceService DeviceService => ControllerConfig.GetService<IDeviceService>();

        IMESService MESService => ControllerConfig.GetService<IMESService>();

        IAlarmLogService AlarmLogService => ControllerConfig.GetService<IAlarmLogService>();
        IThermostatLogService ThermostatLogService => ControllerConfig.GetService<IThermostatLogService>();
        IRectifierLogService RectifierLogService => ControllerConfig.GetService<IRectifierLogService>();
        IUnLoadService UnLoadService => ControllerConfig.GetService<IUnLoadService>();
        IModbus31LogService Modbus31LogService => ControllerConfig.GetService<IModbus31LogService>();
        IModbus32LogService Modbus32LogService => ControllerConfig.GetService<IModbus32LogService>();
        IModbus33LogService Modbus33LogService => ControllerConfig.GetService<IModbus33LogService>();
        IWashDeviceLogService WashDeviceLogService => ControllerConfig.GetService<IWashDeviceLogService>();


        ICSVLoadDataService CSVLoadDataService => ControllerConfig.GetService<ICSVLoadDataService>();
        ICSVUnLoadDataService CSVUnLoadDataService => ControllerConfig.GetService<ICSVUnLoadDataService>();
        ICSVAlarmLogService CSVAlarmLogService => ControllerConfig.GetService<ICSVAlarmLogService>();
        ICSVModbus31LogService CSVModbus31LogService => ControllerConfig.GetService<ICSVModbus31LogService>();
        ICSVModbus32LogService CSVModbus32LogService => ControllerConfig.GetService<ICSVModbus32LogService>();
        ICSVModbus33LogService CSVModbus33LogService => ControllerConfig.GetService<ICSVModbus33LogService>();

        AlarmTypePackage NowAlarmTypePackage;
        bool Enabled = false;

        LoadDataDTO AlreadyMoveInLoadData;

        public DeviceController()
        {
            ThreadPool.QueueUserWorkItem(ImpMonitor);
            ThreadPool.QueueUserWorkItem(LogMonitor);

            NowAlarmTypePackage = new AlarmTypePackage();
        }

        bool AlreadyBackup = false;

        void ImpMonitor(object state)
        {
            while (!this.Enabled)
            {
                try
                {
                    Thread.Sleep(250);

                    var now = DateTime.Now.Ticks;

                    if (!(DeviceService.IsConnect_PLC1)) continue;

                    var nowPLCSstatus = DeviceService.GetNowPLCStatuses();
                    var nowPCSstatus = DeviceService.GetNowPCStatuses();

                    if (nowPCSstatus.Result && nowPLCSstatus.Result)
                    {
                        var isUnLoadNotify = (nowPLCSstatus.Value & PLCStatuses.UnLoadNotify) == PLCStatuses.UnLoadNotify;
                        var isReplyUnLoad = (nowPCSstatus.Value & PCStatuses.ReplyUnLoad) == PCStatuses.ReplyUnLoad;

                        var isAskLoadData = (nowPLCSstatus.Value & PLCStatuses.AskLoadData) == PLCStatuses.AskLoadData;
                        var isReplyAskLoadData = (nowPCSstatus.Value & PCStatuses.ReplyAskLoadData) == PCStatuses.ReplyAskLoadData;

                        var isAutoRuntNotify = (nowPLCSstatus.Value & PLCStatuses.ProduceNotify) == PLCStatuses.ProduceNotify;
                        var isReplyAutoRun = (nowPCSstatus.Value & PCStatuses.ReplyProduce) == PCStatuses.ReplyProduce;

                        //var isBackupMod = false;
                        var isBackupMod = (nowPLCSstatus.Value & PLCStatuses.BackupMod) == PLCStatuses.BackupMod;
                        var isBackupDataReady = (nowPLCSstatus.Value & PLCStatuses.BackupDataReady) == PLCStatuses.BackupDataReady;

                        if (isBackupMod == false && isBackupDataReady == false) AlreadyBackup = false;

                        if (isBackupMod)
                        {
                            if (!isBackupDataReady) continue;
                            if (AlreadyBackup) continue;

                            DeviceService.UpdatePCStatuses(PCStatuses.BackupUnloading, true);

                            var r1 = DeviceService.GeBackuptUnLoadDatas();
                            if (r1.Result)
                            {
                                foreach (var value in r1.Value)
                                {
                                    var r2 = UnLoadService.Insert(value);
                                    var r3 = CSVUnLoadDataService.Log(value);
                                }
                            }
                            DeviceService.UpdatePCStatuses(PCStatuses.BackupUnloading, false);
                            DeviceService.UpdatePCStatuses(PCStatuses.BackupUnloadFinish, true);

                            AlreadyBackup = true;
                        }
                        else
                        {
                            //通知可接收UnloadData, 且PC尚未通知PLC 有接收完成
                            if (isUnLoadNotify && !isReplyUnLoad)
                            {
                                var r1 = DeviceService.GetUnLoadData(1);
                                var r2 = DeviceService.GetUnLoadData(2);
                                if (r1.Result && r2.Result)
                                {
                                    UnLoadService.Insert(r1.Value);
                                    UnLoadService.Insert(r2.Value);
                                    DeviceService.UpdatePCStatuses(PCStatuses.ReplyUnLoad, true);

                                    var r3 = CSVUnLoadDataService.Log(r1.Value);
                                    var r4 = CSVUnLoadDataService.Log(r2.Value);
                                }
                            }
                            //通知可接收UnloadData, 且PC尚未通知PLC 有接收完成
                            else if (!isUnLoadNotify && isReplyUnLoad)
                                DeviceService.UpdatePCStatuses(PCStatuses.ReplyUnLoad, false);

                            //生產中模式 
                            if (LoadController.StatusType == StatusTypes.Auto)
                            {
                                var r0 = LoadController.GetPrepList();

                                if (!r0.Result) continue;
                                if (r0.Value.Count == 0) continue;
                                AlreadyMoveInLoadData = r0.Value[0];

                                DeviceService.LightLen(1, AlreadyMoveInLoadData.First_IsEmpty);
                                DeviceService.LightLen(2, AlreadyMoveInLoadData.Second_IsEmpty);


                                //通知要求LoadData, 且PC尚未回覆PLC 以傳送完成
                                if (isAskLoadData && !isReplyAskLoadData)
                                {
                                    var r1 = DeviceService.SendLoadDatas(AlreadyMoveInLoadData);
                                    if (r1.Result)
                                    {
                                        DeviceService.UpdatePCStatuses(PCStatuses.ReplyAskLoadData, true);

                                        if (AlreadyMoveInLoadData.First_LotCode != LoadController.DummyLotCode || AlreadyMoveInLoadData.Second_LotCode != LoadController.DummyLotCode)
                                        {
                                            var lotcode = AlreadyMoveInLoadData.First_LotCode == LoadController.DummyLotCode ? AlreadyMoveInLoadData.Second_LotCode : AlreadyMoveInLoadData.First_LotCode;
                                            var recipecode = AlreadyMoveInLoadData.First_RecipeCode == LoadController.DummyLotCode ? AlreadyMoveInLoadData.Second_RecipeCode : AlreadyMoveInLoadData.First_RecipeCode;
                                            ThreadPool.QueueUserWorkItem(p => MESController.SendATC(lotcode, recipecode));
                                        }
                                        // 作業中比對
                                    }
                                }
                                else if (!isAskLoadData && isReplyAskLoadData)
                                {
                                    var r1 = LoadController.Finish(AlreadyMoveInLoadData.ID);

                                    if (r1.Result)
                                    {
                                        var r1_1 = LoadController.Get(AlreadyMoveInLoadData.ID);
                                        if (r1_1.Result) CSVLoadDataService.Log(r1_1.Value);
                                    }

                                    DeviceService.UpdatePCStatuses(PCStatuses.ReplyAskLoadData, false);
                                    AlreadyMoveInLoadData = null;
                                }

                                //通知可接收UnloadData, 且PC尚未通知PLC 有接收完成
                                if (isAutoRuntNotify && !isReplyAutoRun)
                                {
                                    var r1 = DeviceService.ReSetLoadData();
                                    if (r1.Result)
                                        DeviceService.UpdatePCStatuses(PCStatuses.ReplyProduce, true);
                                }
                                //通知可接收UnloadData, 且PC尚未通知PLC 有接收完成
                                else if (!isAutoRuntNotify && isReplyAutoRun)
                                    DeviceService.UpdatePCStatuses(PCStatuses.ReplyProduce, false);
                            }
                        }
                    }
                }
                catch (Exception Ex)
                {
                }
            }
        }
        
        void LogMonitor(object state)
        {
            while (!this.Enabled)
            {
                try
                {
                    Thread.Sleep(1000);

                    var now = DateTime.Now.Ticks;

                    if (!(DeviceService.IsConnect_PLC1 && DeviceService.IsConnect_PLC2)) continue;

                    #region 監控Alarm
                    var r11 = DeviceService.GetNowAlarmTypePackage();
                    if (r11.Result)
                    {
                        var nowAlarmPart01 = r11.Value.Part01;
                        var nowAlarmPart02 = r11.Value.Part02;
                        var nowAlarmPart03 = r11.Value.Part03;
                        var nowAlarmPart04 = r11.Value.Part04;
                        var nowAlarmPart05 = r11.Value.Part05;
                        var nowAlarmPart06 = r11.Value.Part06;
                        var nowAlarmPart07 = r11.Value.Part07;
                        var nowAlarmPart08 = r11.Value.Part08;

                        var newPart01 = (NowAlarmTypePackage.Part01 & nowAlarmPart01) ^ nowAlarmPart01;
                        var mesPart01 = (nowAlarmPart01 ^ newPart01) ^ NowAlarmTypePackage.Part01;

                        var newPart02 = (NowAlarmTypePackage.Part02 & nowAlarmPart02) ^ nowAlarmPart02;
                        var mesPart02 = (nowAlarmPart02 ^ newPart02) ^ NowAlarmTypePackage.Part02;

                        var newPart03 = (NowAlarmTypePackage.Part03 & nowAlarmPart03) ^ nowAlarmPart03;
                        var mesPart03 = (nowAlarmPart03 ^ newPart03) ^ NowAlarmTypePackage.Part03;

                        var newPart04 = (NowAlarmTypePackage.Part04 & nowAlarmPart04) ^ nowAlarmPart04;
                        var mesPart04 = (nowAlarmPart04 ^ newPart04) ^ NowAlarmTypePackage.Part04;

                        var newPart05 = (NowAlarmTypePackage.Part05 & nowAlarmPart05) ^ nowAlarmPart05;
                        var mesPart05 = (nowAlarmPart05 ^ newPart05) ^ NowAlarmTypePackage.Part05;

                        var newPart06 = (NowAlarmTypePackage.Part06 & nowAlarmPart06) ^ nowAlarmPart06;
                        var mesPart06 = (nowAlarmPart06 ^ newPart06) ^ NowAlarmTypePackage.Part06;

                        var newPart07 = (NowAlarmTypePackage.Part07 & nowAlarmPart07) ^ nowAlarmPart07;
                        var mesPart07 = (nowAlarmPart07 ^ newPart07) ^ NowAlarmTypePackage.Part07;

                        var newPart08 = (NowAlarmTypePackage.Part08 & nowAlarmPart08) ^ nowAlarmPart08;
                        var mesPart08 = (nowAlarmPart08 ^ newPart08) ^ NowAlarmTypePackage.Part08;

                        if (NowAlarmTypePackage.Part01 != nowAlarmPart01)
                        {
                            foreach (AlarmTypes_Part01 value in Enum.GetValues(typeof(AlarmTypes_Part01)))
                            {
                                if (value == AlarmTypes_Part01.None) continue;

                                if ((newPart01 & value) == value)
                                {
                                    AlarmLogService.Start(value);
                                    MESService.SendAlarmNotify(value.GetInfo().Code);
                                    CSVAlarmLogService.HappenLog(value.GetInfo().Code);
                                }
                                if ((mesPart01 & value) == value)
                                {
                                    AlarmLogService.Finish(value);
                                    CSVAlarmLogService.DisMissLog(value.GetInfo().Code);
                                }
                            }
                        }

                        if (NowAlarmTypePackage.Part02 != nowAlarmPart02)
                        {
                            foreach (AlarmTypes_Part02 value in Enum.GetValues(typeof(AlarmTypes_Part02)))
                            {
                                if (value == AlarmTypes_Part02.None) continue;

                                if ((newPart02 & value) == value)
                                {
                                    AlarmLogService.Start(value);
                                    ThreadPool.QueueUserWorkItem(p => MESService.SendAlarmNotify(value.GetInfo().Code)); ;
                                    CSVAlarmLogService.HappenLog(value.GetInfo().Code);
                                }
                                if ((mesPart02 & value) == value)
                                {
                                    AlarmLogService.Finish(value);
                                    CSVAlarmLogService.DisMissLog(value.GetInfo().Code);
                                }
                            }
                        }

                        if (NowAlarmTypePackage.Part03 != nowAlarmPart03)
                        {
                            foreach (AlarmTypes_Part03 value in Enum.GetValues(typeof(AlarmTypes_Part03)))
                            {
                                if (value == AlarmTypes_Part03.None) continue;

                                if ((newPart03 & value) == value)
                                {
                                    AlarmLogService.Start(value);
                                    ThreadPool.QueueUserWorkItem(p => MESService.SendAlarmNotify(value.GetInfo().Code));
                                    CSVAlarmLogService.HappenLog(value.GetInfo().Code);
                                }
                                if ((mesPart03 & value) == value)
                                {
                                    AlarmLogService.Finish(value);
                                    CSVAlarmLogService.DisMissLog(value.GetInfo().Code);
                                }
                            }
                        }
                        if (NowAlarmTypePackage.Part04 != nowAlarmPart04)
                        {
                            foreach (AlarmTypes_Part04 value in Enum.GetValues(typeof(AlarmTypes_Part04)))
                            {
                                if (value == AlarmTypes_Part04.None) continue;

                                if ((newPart04 & value) == value)
                                {
                                    AlarmLogService.Start(value);
                                    ThreadPool.QueueUserWorkItem(p => MESService.SendAlarmNotify(value.GetInfo().Code));
                                    CSVAlarmLogService.HappenLog(value.GetInfo().Code);
                                }
                                if ((mesPart04 & value) == value)
                                {
                                    AlarmLogService.Finish(value);
                                    CSVAlarmLogService.DisMissLog(value.GetInfo().Code);
                                }
                            }
                        }
                        if (NowAlarmTypePackage.Part05 != nowAlarmPart05)
                        {
                            foreach (AlarmTypes_Part05 value in Enum.GetValues(typeof(AlarmTypes_Part05)))
                            {
                                if (value == AlarmTypes_Part05.None) continue;

                                if ((newPart05 & value) == value)
                                {
                                    AlarmLogService.Start(value);
                                    ThreadPool.QueueUserWorkItem(p => MESService.SendAlarmNotify(value.GetInfo().Code));
                                    CSVAlarmLogService.HappenLog(value.GetInfo().Code);
                                }
                                if ((mesPart05 & value) == value)
                                {
                                    AlarmLogService.Finish(value);
                                    CSVAlarmLogService.DisMissLog(value.GetInfo().Code);
                                }
                            }
                        }
                        if (NowAlarmTypePackage.Part06 != nowAlarmPart06)
                        {
                            foreach (AlarmTypes_Part06 value in Enum.GetValues(typeof(AlarmTypes_Part06)))
                            {
                                if (value == AlarmTypes_Part06.None) continue;

                                if ((newPart06 & value) == value)
                                {
                                    AlarmLogService.Start(value);
                                    ThreadPool.QueueUserWorkItem(p => MESService.SendAlarmNotify(value.GetInfo().Code));
                                    CSVAlarmLogService.HappenLog(value.GetInfo().Code);
                                }
                                if ((mesPart06 & value) == value)
                                {
                                    AlarmLogService.Finish(value);
                                    CSVAlarmLogService.DisMissLog(value.GetInfo().Code);
                                }
                            }
                        }

                        if (NowAlarmTypePackage.Part07 != nowAlarmPart07)
                        {
                            foreach (AlarmTypes_Part07 value in Enum.GetValues(typeof(AlarmTypes_Part07)))
                            {
                                if (value == AlarmTypes_Part07.None) continue;

                                if ((newPart07 & value) == value)
                                {
                                    AlarmLogService.Start(value);
                                    ThreadPool.QueueUserWorkItem(p => MESService.SendAlarmNotify(value.GetInfo().Code));
                                    CSVAlarmLogService.HappenLog(value.GetInfo().Code);
                                }
                                if ((mesPart07 & value) == value)
                                {
                                    AlarmLogService.Finish(value);
                                    CSVAlarmLogService.DisMissLog(value.GetInfo().Code);
                                }
                            }
                        }
                        if (NowAlarmTypePackage.Part08 != nowAlarmPart08)
                        {
                            foreach (AlarmTypes_Part08 value in Enum.GetValues(typeof(AlarmTypes_Part08)))
                            {
                                if (value == AlarmTypes_Part08.None) continue;

                                if ((newPart08 & value) == value)
                                {
                                    AlarmLogService.Start(value);
                                    ThreadPool.QueueUserWorkItem(p => MESService.SendAlarmNotify(value.GetInfo().Code));
                                    CSVAlarmLogService.HappenLog(value.GetInfo().Code);
                                }
                                if ((mesPart08 & value) == value)
                                {
                                    AlarmLogService.Finish(value);
                                    CSVAlarmLogService.DisMissLog(value.GetInfo().Code);
                                }
                            }
                        }
                        this.NowAlarmTypePackage = r11.Value;
                    }
                    #endregion

                    #region 監控整連器
                    var r21 = DeviceService.GetThermostatLog();
                    if (r21.Result)
                    {
                        ThermostatLogService.Insert(r21.Value);
                    }
                    #endregion

                    #region 監控溫控器
                    var r31 = DeviceService.GetRectifierLog();
                    if (r31.Result)
                    {
                        RectifierLogService.Insert(r31.Value);
                    }

                    #endregion

                    #region 紀錄 Modbus至CSV

                    var m1 = Modbus31LogService.Get();
                    if (m1.Result)
                        CSVModbus31LogService.Log(m1.Value);
                    var m2 = Modbus32LogService.Get();
                    if (m2.Result)
                        CSVModbus32LogService.Log(m2.Value);
                    var m3 = Modbus33LogService.Get();
                    if (m3.Result)
                        CSVModbus33LogService.Log(m3.Value);
                    #endregion
                }
                catch (Exception Ex)
                {
                }
            }
        }

        public ActResult<Modbus31LogDTO> GetNowModbus31Log()
            => Modbus31LogService.Get();

        public ActResult<Modbus32LogDTO> GetNowModbus32Log()
            => Modbus32LogService.Get();

        public ActResult<Modbus33LogDTO> GetNowModbus33Log()
            => Modbus33LogService.Get();

        public ActResult<WashDeviceLogDTO> GetNowWashDeviceLog()
            => WashDeviceLogService.Get();

        public ActResult<RectifierLogDTO> GetNowRectifierLog() 
            => RectifierLogService.Get();

        public ActResult<ThermostatLogDTO> GetNowThermostatLog()
            => ThermostatLogService.Get();


        public ActResult Clear()
        {
            var r3 = Modbus31LogService.Clear();
            var r4 = Modbus32LogService.Clear();
            var r5 = Modbus33LogService.Clear();
            var r6 = WashDeviceLogService.Clear();
            var exmsg = String.Empty;

            if (!r3.Result)
                exmsg += r3.Exception.Message;
            if (!r4.Result)
                exmsg += r4.Exception.Message;
            if (!r5.Result)
                exmsg += r5.Exception.Message;
            if (!r6.Result)
                exmsg += r6.Exception.Message;

            if (!r3.Result || !r4.Result || !r5.Result || !r6.Result)
                return new ActResult(new Exception(exmsg));
            else
                return new ActResult(true);
        }

        protected override void DisposeManagedObject()
        {
            Enabled = true;
        }
    }
}

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
        ICSVExceptionService CSVExceptionService => ControllerConfig.GetService<ICSVExceptionService>();

        IDeviceService DeviceService => ControllerConfig.GetService<IDeviceService>();

        IMESService MESService => ControllerConfig.GetService<IMESService>();

        IAlarmLogService AlarmLogService => ControllerConfig.GetService<IAlarmLogService>();
        IThermostatLogService ThermostatLogService => ControllerConfig.GetService<IThermostatLogService>();
        IRectifierLogService RectifierLogService => ControllerConfig.GetService<IRectifierLogService>();
        IUnLoadService UnLoadService => ControllerConfig.GetService<IUnLoadService>();
        ILoadDataService LoadDataService = ControllerConfig.GetService<ILoadDataService>();
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
        ICSVDeviceService CSVDeviceService => ControllerConfig.GetService<ICSVDeviceService>();

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
            var lastPLCStatus = PLCStatuses.none;
            var lastPCStatus = PCStatuses.none;

            CSVDeviceService.Log(DeviceLogSourceTypes.PLC, "22008", false, "程式第一次啟動，狀態歸零");
            CSVDeviceService.Log(DeviceLogSourceTypes.PLC, "22000", false, "程式第一次啟動，狀態歸零");

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
                        //22008.08
                        var isUnLoadNotify = (nowPLCSstatus.Value & PLCStatuses.UnLoadNotify) == PLCStatuses.UnLoadNotify;
                        //22000.08
                        var isReplyUnLoad = (nowPCSstatus.Value & PCStatuses.ReplyUnLoad) == PCStatuses.ReplyUnLoad;
                        //22008.04
                        var isAskLoadData = (nowPLCSstatus.Value & PLCStatuses.AskLoadData) == PLCStatuses.AskLoadData;
                        //22000.04
                        var isReplyAskLoadData = (nowPCSstatus.Value & PCStatuses.ReplyAskLoadData) == PCStatuses.ReplyAskLoadData;
                        //22008.05
                        var isAutoRuntNotify = (nowPLCSstatus.Value & PLCStatuses.ProduceNotify) == PLCStatuses.ProduceNotify;
                        //22000.05
                        var isReplyAutoRun = (nowPCSstatus.Value & PCStatuses.ReplyProduce) == PCStatuses.ReplyProduce;
                        //22008.12
                        var isBackupMod = (nowPLCSstatus.Value & PLCStatuses.BackupMod) == PLCStatuses.BackupMod;
                        //22008.13
                        var isBackupDataReady = (nowPLCSstatus.Value & PLCStatuses.BackupDataReady) == PLCStatuses.BackupDataReady;
                        //22000.12
                        var isBackupUnloading = (nowPCSstatus.Value & PCStatuses.BackupUnloading) == PCStatuses.BackupUnloading;
                        //22000.13
                        var isBackupUnloadFinish = (nowPCSstatus.Value & PCStatuses.BackupUnloadFinish) == PCStatuses.BackupUnloadFinish;


                        //22008.08
                        var lastisUnLoadNotify = (lastPLCStatus & PLCStatuses.UnLoadNotify) == PLCStatuses.UnLoadNotify;
                        //22000.08
                        var lastisReplyUnLoad = (lastPCStatus & PCStatuses.ReplyUnLoad) == PCStatuses.ReplyUnLoad;
                        //22008.04
                        var lastisAskLoadData = (lastPLCStatus & PLCStatuses.AskLoadData) == PLCStatuses.AskLoadData;
                        //22000.04
                        var lastisReplyAskLoadData = (lastPCStatus & PCStatuses.ReplyAskLoadData) == PCStatuses.ReplyAskLoadData;
                        //22008.05
                        var lastisAutoRuntNotify = (lastPLCStatus & PLCStatuses.ProduceNotify) == PLCStatuses.ProduceNotify;
                        //22000.05
                        var lastisReplyAutoRun = (lastPCStatus & PCStatuses.ReplyProduce) == PCStatuses.ReplyProduce;
                        //22008.12
                        var lastisBackupMod = (lastPLCStatus & PLCStatuses.BackupMod) == PLCStatuses.BackupMod;
                        //22008.13
                        var lastisBackupDataReady = (lastPLCStatus & PLCStatuses.BackupDataReady) == PLCStatuses.BackupDataReady;
                        //22000.12
                        var lastisBackupUnloading = (lastPCStatus & PCStatuses.BackupUnloading) == PCStatuses.BackupUnloading;
                        //22000.13
                        var lastisBackupUnloadFinish = (lastPCStatus & PCStatuses.BackupUnloadFinish) == PCStatuses.BackupUnloadFinish;


                        if (isUnLoadNotify != lastisUnLoadNotify)
                            CSVDeviceService.Log(DeviceLogSourceTypes.PLC, "R22008.08", isUnLoadNotify, isUnLoadNotify?"通知下載下料資料":"");
                        if (isReplyUnLoad != lastisReplyUnLoad)
                            CSVDeviceService.Log(DeviceLogSourceTypes.PC, "R22000.08", isReplyUnLoad, isReplyUnLoad ? "回復完成下載下料資料" : "");
                        if (isAskLoadData != lastisAskLoadData)
                            CSVDeviceService.Log(DeviceLogSourceTypes.PLC, "R22008.04", isAskLoadData, isAskLoadData?"要求上傳上料資料":"");
                        if (isReplyAskLoadData != lastisReplyAskLoadData)
                            CSVDeviceService.Log(DeviceLogSourceTypes.PC, "R22000.04", isReplyAskLoadData, isReplyAskLoadData? "回覆完成傳上料資料":"");
                        if (isAutoRuntNotify != lastisAutoRuntNotify)
                            CSVDeviceService.Log(DeviceLogSourceTypes.PLC, "R22008.05", isAutoRuntNotify, isAutoRuntNotify? "請求清空LoadData" : "");
                        if (isReplyAutoRun != lastisReplyAutoRun)
                            CSVDeviceService.Log(DeviceLogSourceTypes.PC, "R22000.05", isReplyAutoRun, isReplyAutoRun? "回覆完成清空LoadData" : "");
                        if (isBackupMod != lastisBackupMod)
                            CSVDeviceService.Log(DeviceLogSourceTypes.PLC, "R22008.12", isBackupMod, isBackupMod ? "通知當前為清線備份模式" : "");
                        if (isBackupDataReady != lastisBackupDataReady)
                            CSVDeviceService.Log(DeviceLogSourceTypes.PLC, "R22008.13", isBackupDataReady, isBackupDataReady ? "通知下載下料資料備份" : "");
                        if (isBackupUnloading != lastisBackupUnloading)
                            CSVDeviceService.Log(DeviceLogSourceTypes.PC, "R22000.12", isBackupDataReady, isBackupDataReady ? "通知開始下載備份資料" : "");
                        if (isBackupUnloadFinish != lastisBackupUnloadFinish)
                            CSVDeviceService.Log(DeviceLogSourceTypes.PC, "R22000.13", isBackupDataReady, isBackupDataReady ? "通知完成下載備份資料" : "PLC主動清除該記憶點位");


                        lastPLCStatus = nowPLCSstatus.Value;
                        lastPCStatus = nowPCSstatus.Value;




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
                                var unloadData01ActResult = DeviceService.GetUnLoadData(1);
                                var unloadData02ActResult = DeviceService.GetUnLoadData(2);
                                if (unloadData01ActResult.Result && unloadData02ActResult.Result)
                                {
                                    UnLoadService.Insert(unloadData01ActResult.Value);
                                    UnLoadService.Insert(unloadData02ActResult.Value);
                                    DeviceService.UpdatePCStatuses(PCStatuses.ReplyUnLoad, true);

                                    var r3 = CSVUnLoadDataService.Log(unloadData01ActResult.Value);
                                    var r4 = CSVUnLoadDataService.Log(unloadData02ActResult.Value);


                                    #region 下料LotNo比對 
                                    var newUnloadLotNo = (unloadData01ActResult.Value.LotNo != LoadController.DummyLotCode) ? unloadData01ActResult.Value.LotNo : unloadData02ActResult.Value.LotNo;
                                    var lastLotNoResult = UnLoadService.GetLastLotNo();
                                    if (lastLotNoResult.Result)
                                    {
                                        var lastUnloadLotNo = lastLotNoResult.Value;
                                        if (lastUnloadLotNo != newUnloadLotNo)
                                        {
                                            DeviceService.UpdatePCStatuses(PCStatuses.ChangeLotNotify, true);
                                            //如果前次lotNo == DummyLotCode 不做總數比對判斷
                                            if (lastUnloadLotNo != LoadController.DummyLotCode)
                                            {
                                                var getLoadDataCountResult = LoadDataService.GetLotCount(lastUnloadLotNo);
                                                var getUnLoadDataCountResult = UnLoadService.GetLotCount(lastUnloadLotNo);

                                                if (getLoadDataCountResult.Result && getUnLoadDataCountResult.Result)
                                                {
                                                    var loadDataCount = getLoadDataCountResult.Value;
                                                    var unLoadDataCount = getUnLoadDataCountResult.Value;

                                                    if (loadDataCount != unLoadDataCount)
                                                    {
                                                        DeviceService.UpdatePCStatuses(PCStatuses.DataCountError, true);

                                                        var alarmCode = AlarmTypes_Part02.M719.GetInfo().Code;
                                                        ThreadPool.QueueUserWorkItem(p => MESService.SendAlarmNotify(String.Format("AL501^{0}", lastUnloadLotNo)));
                                                        CSVAlarmLogService.HappenLog(alarmCode);
                                                        CSVAlarmLogService.DisMissLog(alarmCode);
                                                    }
                                                }//判斷取得該LotNo LoadData及UnLoadData 數量是否成功
                                                else
                                                {
                                                }
                                            }
                                        }//判斷本次LotNo 是否與前次LotNo 是否不一致
                                    }//判斷取得lastunloadlotNo是否成功判斷
                                    else
                                    {
                                    }
                                    #endregion

                                }
                                else
                                {
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


                                        if (AlreadyMoveInLoadData.First_LotCode != LoadController.DummyLotCode)
                                        {
                                            var lotcode = AlreadyMoveInLoadData.First_LotCode;
                                            var recipecode = AlreadyMoveInLoadData.First_RecipeCode;
                                            ThreadPool.QueueUserWorkItem(p => MESController.SendATC(lotcode, recipecode));
                                        }
                                        else if (AlreadyMoveInLoadData.Second_LotCode != LoadController.DummyLotCode)
                                        {
                                            var lotcode = AlreadyMoveInLoadData.Second_LotCode;
                                            var recipecode = AlreadyMoveInLoadData.Second_LotCode;
                                            ThreadPool.QueueUserWorkItem(p => MESController.SendATC(lotcode, recipecode));
                                        }
                                        else
                                        {
                                            var lotcode = LoadController.DummyLotCode;
                                            var recipecode = "Dummy";
                                            ThreadPool.QueueUserWorkItem(p => MESController.SendATC(lotcode, recipecode));
                                        }

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

                                //通知可清除LoadData, 且PC尚未通知PLC 有接收完成
                                if (isAutoRuntNotify && !isReplyAutoRun)
                                {
                                    var r1 = DeviceService.ReSetLoadData();
                                    if (r1.Result)
                                        DeviceService.UpdatePCStatuses(PCStatuses.ReplyProduce, true);
                                }
                                else if (!isAutoRuntNotify && isReplyAutoRun)
                                    DeviceService.UpdatePCStatuses(PCStatuses.ReplyProduce, false);
                            }
                        }
                    }
                }
                catch (Exception Ex)
                {
                    CSVExceptionService.Log(Ex.Message, nameof(this.ImpMonitor));
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
                        var nowPart01 = (nowAlarmPart01 ^ newPart01) ^ NowAlarmTypePackage.Part01;

                        var newPart02 = (NowAlarmTypePackage.Part02 & nowAlarmPart02) ^ nowAlarmPart02;
                        var nowPart02 = (nowAlarmPart02 ^ newPart02) ^ NowAlarmTypePackage.Part02;

                        var newPart03 = (NowAlarmTypePackage.Part03 & nowAlarmPart03) ^ nowAlarmPart03;
                        var nowPart03 = (nowAlarmPart03 ^ newPart03) ^ NowAlarmTypePackage.Part03;

                        var newPart04 = (NowAlarmTypePackage.Part04 & nowAlarmPart04) ^ nowAlarmPart04;
                        var nowPart04 = (nowAlarmPart04 ^ newPart04) ^ NowAlarmTypePackage.Part04;

                        var newPart05 = (NowAlarmTypePackage.Part05 & nowAlarmPart05) ^ nowAlarmPart05;
                        var nowPart05 = (nowAlarmPart05 ^ newPart05) ^ NowAlarmTypePackage.Part05;

                        var newPart06 = (NowAlarmTypePackage.Part06 & nowAlarmPart06) ^ nowAlarmPart06;
                        var nowPart06 = (nowAlarmPart06 ^ newPart06) ^ NowAlarmTypePackage.Part06;

                        var newPart07 = (NowAlarmTypePackage.Part07 & nowAlarmPart07) ^ nowAlarmPart07;
                        var nowPart07 = (nowAlarmPart07 ^ newPart07) ^ NowAlarmTypePackage.Part07;

                        var newPart08 = (NowAlarmTypePackage.Part08 & nowAlarmPart08) ^ nowAlarmPart08;
                        var nowPart08 = (nowAlarmPart08 ^ newPart08) ^ NowAlarmTypePackage.Part08;

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
                                if ((nowPart01 & value) == value)
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
                                if ((nowPart02 & value) == value)
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
                                if ((nowPart03 & value) == value)
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
                                if ((nowPart04 & value) == value)
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
                                if ((nowPart05 & value) == value)
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
                                if ((nowPart06 & value) == value)
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
                                if ((nowPart07 & value) == value)
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
                                if ((nowPart08 & value) == value)
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
                    CSVExceptionService.Log(Ex.Message, nameof(this.LogMonitor));
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

using Common;
using Common.DTO;
using Common.Enums;
using Common.ExConfig;
using Common.Interface;
using Controller.Interface;
using Service.MES.Interface;
using Service.CSV.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Controller.Implement
{
    public class MESController : IMESController
    {
        IMESService MESService => ControllerConfig.GetService<IMESService>();
        ICSVExceptionService CSVExceptionService => ControllerConfig.GetService<ICSVExceptionService>();
        IDeviceController DeviceController => AutofacConfig.Resolve<IDeviceController>();
        IUserController UserController => AutofacConfig.Resolve<IUserController>();

        public CheckItemObject CheckItem { get; private set; }

        public bool IsADCHappenAlarm { get; private set; }

        public List<AlarmMsgDTO> AlarmMsgs 
        {
            get
            {
                IsADCHappenAlarm = false;
                return _AlarmMsgs;
            }
            private set
            {
                _AlarmMsgs = value;
                if (_AlarmMsgs.Count > 0)
                    IsADCHappenAlarm = true;
                else
                    IsADCHappenAlarm = false;
            }
        }
        List<AlarmMsgDTO> _AlarmMsgs;

        public bool IsConnect => MESService.IsConnect;


        public MESController()
        {
            _AlarmMsgs = new List<AlarmMsgDTO>();

            CheckItem = new CheckItemObject();
            foreach (var pInfo in typeof(CheckItemObject).GetProperties())
                pInfo.SetValue(CheckItem,true);
        }


        public ActResult SetADCConfig(ADCConfig ADCConfig_) => MESService.SetADCConfig(ADCConfig_);


        public void SetCheckItem(CheckItemObject CheckItem_)
        {
            this.CheckItem = CheckItem_;
        }


        public ActResult Connect(int Port_= 7070)
        {
            try
            {
                if (MESService.IsConnect)
                    return new ActResult(new Exception("Already Connect."));

                MESService.StartListen(Port_);

                if (MESService.IsConnect)
                    return new ActResult(true);
                else
                    return new ActResult(new Exception("ConnectFail."));
            }
            catch(Exception Ex)
            {
                return new ActResult(Ex);
            }
        }
        public ActResult DisConnect()
        {
            try
            {
                //if (!MESService.IsConnect)
                //    return new ActResult(new Exception("Not Connect."));

                MESService.StopListen();

                if (!MESService.IsConnect)
                    return new ActResult(true);
                else
                    return new ActResult(new Exception("DisConnectFail."));
            }
            catch (Exception Ex)
            {
                return new ActResult(Ex);
            }
        }

        public ActResult SendCreateRecipeNotify(RecipeDTO RecipeDTO_)
            => MESService.SendCreateRecipeNotify(RecipeDTO_);

        public ActResult SendEDC()
        {
            try
            {
                var r1 = DeviceController.GetNowThermostatLog();
                if (!r1.Result)
                {
                    CSVExceptionService.Log(r1.Exception.Message, nameof(DeviceController.GetNowThermostatLog));
                    return new ActResult(new Exception(String.Format("取得{0} 原因:{1}", "溫控器紀錄", r1.Exception.Message)));
                }

                var r2 = DeviceController.GetNowModbus31Log();
                if (!r2.Result)
                {
                    CSVExceptionService.Log(r2.Exception.Message, nameof(DeviceController.GetNowModbus31Log));
                    return new ActResult(new Exception(String.Format("取得{0} 原因:{1}", "Modbus31紀錄", r2.Exception.Message)));
                }

                var r3 = DeviceController.GetNowModbus32Log();
                if (!r3.Result)
                {
                    CSVExceptionService.Log(r3.Exception.Message, nameof(DeviceController.GetNowModbus32Log));
                    return new ActResult(new Exception(String.Format("取得{0} 原因:{1}", "Modbus32紀錄", r3.Exception.Message)));
                }

                var r4 = DeviceController.GetNowModbus33Log();
                if (!r4.Result)
                {
                    CSVExceptionService.Log(r4.Exception.Message, nameof(DeviceController.GetNowModbus33Log));
                    return new ActResult(new Exception(String.Format("取得{0} 原因:{1}", "Modbus33紀錄", r4.Exception.Message)));
                }

                var r5 = DeviceController.GetNowWashDeviceLog();
                if (!r5.Result)
                {
                    CSVExceptionService.Log(r5.Exception.Message, nameof(DeviceController.GetNowWashDeviceLog));
                    return new ActResult(new Exception(String.Format("取得{0} 原因:{1}", "水洗機紀錄", r5.Exception.Message)));
                }
                var EDCxml = MESService.CreateEDCxml(r1.Value, r2.Value, r3.Value, r4.Value, r5.Value);

                var r6 = MESService.SendEDCData(EDCxml);

                return r6;
            }
            catch (Exception Ex)
            {
                CSVExceptionService.Log(Ex.Message, nameof(this.SendEDC));
                return new ActResult(Ex);
            }
        }

        public ActResult SendATC(string LotCode_,string RecipeCode_)
        {

            try
            {
                var r1 = DeviceController.GetNowThermostatLog();
                if (!r1.Result)
                {
                    CSVExceptionService.Log(r1.Exception.Message, nameof(DeviceController.GetNowThermostatLog));
                    return new ActResult(new Exception(String.Format("取得{0} 原因:{1}", "溫控器紀錄", r1.Exception.Message)));
                }

                var r2 = DeviceController.GetNowModbus31Log();
                if (!r2.Result)
                {
                    CSVExceptionService.Log(r2.Exception.Message, nameof(DeviceController.GetNowModbus31Log));
                    return new ActResult(new Exception(String.Format("取得{0} 原因:{1}", "Modbus31紀錄", r2.Exception.Message)));
                }

                var r3 = DeviceController.GetNowModbus32Log();
                if (!r3.Result)
                {
                    CSVExceptionService.Log(r3.Exception.Message, nameof(DeviceController.GetNowModbus32Log));
                    return new ActResult(new Exception(String.Format("取得{0} 原因:{1}", "Modbus32紀錄", r3.Exception.Message)));
                }

                var r4 = DeviceController.GetNowModbus33Log();
                if (!r4.Result)
                {
                    CSVExceptionService.Log(r4.Exception.Message, nameof(DeviceController.GetNowModbus33Log));
                    return new ActResult(new Exception(String.Format("取得{0} 原因:{1}", "Modbus33紀錄", r4.Exception.Message)));
                }

                var r5 = DeviceController.GetNowWashDeviceLog();
                if (!r5.Result)
                {
                    CSVExceptionService.Log(r5.Exception.Message, nameof(DeviceController.GetNowWashDeviceLog));
                    return new ActResult(new Exception(String.Format("取得{0} 原因:{1}", "水洗機紀錄", r5.Exception.Message)));
                }

                var userid = UserController.NowUID;

                var isfail = MESService.ParamterComparison(LotCode_, userid, this.CheckItem, r1.Value, r2.Value, r3.Value, r4.Value, r5.Value);
                
                var exmsg = String.Empty;

                if (!isfail.Result)
                {
                    var alarmmsgs = isfail.Value;
                    foreach (var alarmMsg in alarmmsgs)
                    {
                        exmsg += String.Format("名稱:{0} 當前數值:{1} Max值:{2} Min值:{3}\r\n", alarmMsg.Name, alarmMsg.RealValue, alarmMsg.MaxLimit, alarmMsg.MinLimit);
                    }

                    CSVExceptionService.Log(isfail.Exception.Message, nameof(MESService.ParamterComparison));
                    //增加LOG

                    AlarmMsgs = isfail.Value;
                    var r6 = MESService.SendArmsAlarm(LotCode_, userid, RecipeCode_, isfail.Value.ToArray());
                    if (!r6.Result)
                    {
                        exmsg += r6.Exception.Message;                      
                        CSVExceptionService.Log(r6.Exception.Message, nameof(MESService.SendArmsAlarm));
                    }
                }

                var adcXml = MESService.CreateADCxml(r1.Value, r2.Value, r3.Value, r4.Value, r5.Value);
                var r7 = MESService.SendADCData(adcXml);
                if (!r7.Result)
                {
                    exmsg += r7.Exception.Message;
                    CSVExceptionService.Log(r7.Exception.Message, nameof(MESService.SendADCData));
                }

                if (exmsg != String.Empty)
                    return new ActResult(new Exception(exmsg));
                else
                    return new ActResult(true);
            }
            catch (Exception Ex)
            {
                CSVExceptionService.Log(Ex.Message, nameof(this.SendATC));
                return new ActResult(Ex);
            }
        }
    }
}
                                                  
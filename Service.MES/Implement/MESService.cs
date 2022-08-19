using aE2talkComp;
using Common;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using Common.Interface;
using Service.MES.Enums;
using Service.MES.ExObject;
using Service.MES.Interface;
using Common.DTO;
using Service.MES.Extension;
using Common.Enums;
using Common.Attributes;
using System.Reflection;
using Common.ExConfig;

namespace Service.MES.Implement
{

    internal partial class MESService : IMESService
    {
        const int TimeOut = 10;
        const string DeviceID = "01";

        public ADCConfig NowADCConfig { get; private set; }

        public bool IsConnect { get; set; }

        public AE2TalkObject BasicAE2Talk
        {
            get
            {
                if (_BasicAE2Talk == null)
                    lock (BasicAE2TalkToken)
                        if (_BasicAE2Talk == null)
                            _BasicAE2Talk = JsonConvert.DeserializeObject<AE2TalkObject>(SampleData.AE2TalkObjectValue);

                return _BasicAE2Talk;
            }
        }
        readonly object BasicAE2TalkToken = new object();
        private AE2TalkObject _BasicAE2Talk;

        private aE2talk AE2Talk;

        private bool RMS_ACK_Available { get; set; }
        private string RMS_ACK_Data
        {
            get
            {
                RMS_ACK_Available = false;
                return _RMS_ACK_Data;
            }
            set
            {
                _RMS_ACK_Data = value;
                if (_RMS_ACK_Data != String.Empty)
                    RMS_ACK_Available = true;
            }
        }
        string _RMS_ACK_Data;

        private bool RMS_ERRORType1_Available { get; set; }

        private string RMS_ERRORType1_Data
        {
            get
            {
                RMS_ERRORType1_Available = false;
                return _RMS_ERRORType1_Data;
            }
            set
            {
                _RMS_ERRORType1_Data = value; 
                if (_RMS_ERRORType1_Data != String.Empty)
                    RMS_ERRORType1_Available = true;
            }
        }
        string _RMS_ERRORType1_Data;



        private bool RMS_ERRORType2_Available { get; set; }

        private string RMS_ERRORType2_Data
        {
            get
            {
                RMS_ERRORType2_Available = false;
                return _RMS_ERRORType2_Data;
            }
            set
            {
                _RMS_ERRORType2_Data = value;
                if (_RMS_ERRORType2_Data != String.Empty)
                    RMS_ERRORType2_Available = true;
            }
        }
        string _RMS_ERRORType2_Data;

        private bool RMS_ERRORType3_Available { get; set; }

        private string RMS_ERRORType3_Data
        {
            get
            {
                RMS_ERRORType3_Available = false;
                return _RMS_ERRORType3_Data;
            }
            set
            {
                _RMS_ERRORType3_Data = value;
                if (_RMS_ERRORType3_Data != String.Empty)
                    RMS_ERRORType3_Available = true;
            }
        }
        string _RMS_ERRORType3_Data;



        private bool END_SHELF_ACK_Data_Available { get; set; }
        private string END_SHELF_ACK_Data
        {
            get
            {
                END_SHELF_ACK_Data_Available = false;
                return _END_SHELF_ACK_Data;
            }
            set
            {
                _END_SHELF_ACK_Data = value;
                if (_END_SHELF_ACK_Data != String.Empty)
                    END_SHELF_ACK_Data_Available = true;
            }
        }
        string _END_SHELF_ACK_Data;


        private bool END_SHELF_ERROR_Available { get; set; }
        private string END_SHELF_ERROR_Data
        {
            get
            {
                END_SHELF_ERROR_Available = false;
                return _END_SHELF_ERROR_Data;
            }
            set
            {
                _END_SHELF_ERROR_Data = value;
                if (_END_SHELF_ERROR_Data != String.Empty)
                    END_SHELF_ERROR_Available = true;
            }
        }
        string _END_SHELF_ERROR_Data;

        private bool END_SHELF_RECIPE_ACK_Data_Available { get; set; }
        private string END_SHELF_RECIPE_ACK_Data
        {
            get
            {
                END_SHELF_RECIPE_ACK_Data_Available = false;
                return _END_SHELF_RECIPE_ACK_Data;
            }
            set
            {
                _END_SHELF_RECIPE_ACK_Data = value;
                if (_END_SHELF_RECIPE_ACK_Data != String.Empty)
                    END_SHELF_RECIPE_ACK_Data_Available = true;
            }
        }
        string _END_SHELF_RECIPE_ACK_Data;


        private bool RMS_Create_ACK_Available { get; set; }
        private string RMS_Create_ACK_Data
        {
            get
            {
                RMS_Create_ACK_Available = false;
                return _RMS_Create_ACK_Data;
            }
            set
            {
                _RMS_Create_ACK_Data = value;
                if (_RMS_Create_ACK_Data != String.Empty)
                    RMS_Create_ACK_Available = true;
            }
        }
        string _RMS_Create_ACK_Data;



        private bool Recipe_Check_ACK_Available { get; set; }
        private string Recipe_Check_ACK_Data
        {
            get
            {
                Recipe_Check_ACK_Available = false;
                return _Recipe_Check_ACK_Data;
            }
            set
            {
                _Recipe_Check_ACK_Data = value;
                if (_Recipe_Check_ACK_Data != String.Empty)
                    Recipe_Check_ACK_Available = true;
            }
        }
        string _Recipe_Check_ACK_Data;

        private bool OnReceiveException { get; set; }
        private Exception ReceiveException
        {
            get
            {
                OnReceiveException = false;
                return _ReceiveException;
            }
            set
            {
                _ReceiveException = value;
                OnReceiveException = true;
            }
        }


        Exception _ReceiveException;

        private readonly object AccessToken = new object();


        public MESService()
        {
            //this.SetAE2Talk(null);

            ThreadPool.QueueUserWorkItem(new WaitCallback(this.SetAE2Talk));

            Thread.Sleep(1000);
        }


        public ActResult SetADCConfig(ADCConfig ADCConfig_)
        {
            try
            {
                if (ADCConfig_ == null)
                    NowADCConfig = DefaultConfig.ADCConfig;
                else
                    NowADCConfig = ADCConfig_;

                return new ActResult(true);
            }
            catch (Exception Ex)
            {
                NowADCConfig = DefaultConfig.ADCConfig;
                return new ActResult(Ex);
            }
        }


        private void SetAE2Talk(object obj)
        {
            this.AE2Talk = new aE2talkComp.aE2talk
            {
                AutoResend = false,
                AutoResendCount = 3,
                CtrlTimeOut = true,
                CurrCheckSum = null,
                CurrDataLength = null,
                DeviceID = DeviceID,
                IsSocketServer = false,
                ReConnect = true,
                ReConnectCount = 3,
                ReConnectInterval = 10000D,
                SendHeartBeatByte = true,
                TimerInteval_Conn = 3000,
                TimerInteval_QueryData = 15000,
                TimerInteval_SendData = 5000
            };

            AE2Talk.onReceiveLotInfo += SelfaE2Talk_onReceiveLotInfo;
            AE2Talk.onSocketConnect += AE2Talk_onSocketConnect; ;
            AE2Talk.onSocketDisonnect += AE2Talk_onSocketDisonnect;

        }

        private void AE2Talk_onSocketConnect(object sender, DataSentEventArgs_SocketClientConnect e)
        {
            this.IsConnect = true;
        }

        private void AE2Talk_onSocketDisonnect(object sender, DataSentEventArgs_SocketClientDisconnect e)
        {
            this.IsConnect = false;
        }

        private void SelfaE2Talk_onReceiveLotInfo(object sender, ReceiveDataEventArgs_LotInfo e)
        {
            try
            {
                string cmd = e.Data[0].Split('^')[0].ToUpper();
                switch (cmd)
                {
                    //取得Recipet 成功
                    case nameof(CmdType.RMS_ACK):

                        if (e.Data[0].Split('^')[1].ToUpper().Contains(nameof(CmdType.RMS_ERROR)))
                        {
                            var typeName = e.Data[0].Split('^')[2];
                            var FailReson = e.Data[0].Split('^')[3];
                            switch (typeName)
                            {
                                case "Type1":
                                    RMS_ERRORType1_Data = FailReson;
                                    break;
                                case "Type2":
                                    RMS_ERRORType2_Data = FailReson;
                                    break;
                                case "Type3":
                                    RMS_ERRORType3_Data = FailReson;
                                    break;
                            }
                        }
                        else if (e.Data[0].Split('^')[1].ToUpper() == nameof(CmdType.END_SHELF_ERROR))
                        {
                            END_SHELF_ERROR_Data = e.Data[0].Split('^')[1];
                        }
                        else
                        {
                            RMS_ACK_Data = e.Data[0].Split('^')[1]+ "^" + e.Data[0].Split('^')[2];
                        }
                        break;
                    //尾掛RecipeDTO比對回覆
                    case nameof(CmdType.END_SHELF_ACK):
                        END_SHELF_ACK_Data = e.Data[0].Split('^')[1];
                        break;

                    //尾掛RecipeDTO創建回覆
                    case nameof(CmdType.END_SHELF_RECIPE_ACK):
                        END_SHELF_RECIPE_ACK_Data = e.Data[0].Split('^')[1];
                        break;
                    // 創建新RecipeDTO回覆
                    case nameof(CmdType.RMS_CREATE_ACK):
                        RMS_Create_ACK_Data = e.Data[0].Split('^')[1];
                        break;
                    // 判斷是否有RecipeName
                    case nameof(CmdType.RECIPE_CHECK_ACK):
                        Recipe_Check_ACK_Data = e.Data[0].Split('^')[1];
                        break;
                }
            }
            catch (Exception Ex)
            {
                this.ReceiveException = Ex;
            }
        }
        public void StartListen(int Port_) => this.AE2Talk.StartListen(Port_);

        public void StopListen() => this.AE2Talk.StopListen();


        void SendMsg(string Msg_)
        {
            string[] la_sData = new string[1];
            la_sData[0] = Msg_;
            AE2Talk.SendLotInfo(la_sData);                //使用前需先指定Device ID
        }

        public ActResult<AE2TalkObjectV2> GetMESObject(string LotNo_, string StaffID)
        {
            lock (AccessToken)
            {
                try
                {

                    this.RMS_ERRORType1_Data = String.Empty;
                    this.RMS_ERRORType2_Data = String.Empty;
                    this.RMS_ERRORType3_Data = String.Empty;
                    this.RMS_ACK_Data = String.Empty;

                    var msg = String.Format("RMS^{0}^{1}", LotNo_, StaffID);
                    SendMsg(msg);

                    LogHelper.Log(String.Format("[Send][GetMESObject]:{0}", msg));

                    long startTick = DateTime.Now.Ticks;

                    while (!(this.RMS_ACK_Available || this.OnReceiveException || this.RMS_ERRORType1_Available || this.RMS_ERRORType2_Available || this.RMS_ERRORType3_Available))
                    {
                        Thread.Sleep(200);
                        if (DateTime.Now.Ticks > startTick + TimeOut * 10000000)
                            throw new Exception(string.Format("Wait MES Reply {0} TimeOut.", msg));
                    }

                    if (this.RMS_ERRORType1_Available)
                    {
                        string data = String.Empty;
                        data += this.RMS_ERRORType1_Data;
                        this.RMS_ERRORType1_Data = String.Empty;
                        LogHelper.Log(String.Format("[Get][GetMESObject]:{0}", "RMS_ERRORType1"));

                        return new ActResult<AE2TalkObjectV2>(ExceptionTypes.EmptyRecipe, data, data);
                    }
                    else if (this.RMS_ERRORType2_Available)
                    {
                        string data = String.Empty;
                        data += this.RMS_ERRORType2_Data;
                        this.RMS_ERRORType2_Data = String.Empty;
                        LogHelper.Log(String.Format("[Get][GetMESObject]:{0}", "RMS_ERRORType2"));

                        return new ActResult<AE2TalkObjectV2>(ExceptionTypes.LotNotOnline, data);
                    }
                    else if (this.RMS_ERRORType3_Available)
                    {
                        string data = String.Empty;
                        data += this.RMS_ERRORType3_Data;
                        this.RMS_ERRORType3_Data = String.Empty;
                        LogHelper.Log(String.Format("[Get][GetMESObject]:{0}", "RMS_ERRORType3"));
                        return new ActResult<AE2TalkObjectV2>(ExceptionTypes.WrongUserID, data);
                    }
                    else if (this.RMS_ACK_Available)
                    {
                        string lotno = String.Empty;
                        string data = String.Empty;

                        var datas = this.RMS_ACK_Data.Split('^');
                        var orgData = this.RMS_ACK_Data;
                        lotno = datas[0];
                        data = datas[1];

                        this.RMS_ACK_Data = String.Empty;
                        LogHelper.Log(String.Format("[Get][GetMESObject]:{0}", datas));

                        if (lotno == LotNo_)
                        {
                            var aEobject = JsonConvert.DeserializeObject<AE2TalkObjectV2>(data);//反序列化
                            aEobject.LotNo = lotno;

                            return new ActResult<AE2TalkObjectV2>(aEobject, orgData);
                        }
                        else
                        {
                            return new ActResult<AE2TalkObjectV2>(new Exception(String.Format("Error:LotNo與發送值不相同")));
                        }
                    }
                    else // if (this.OnReceiveException)
                    {
                        Exception ex = this.ReceiveException;
                        throw ex;
                    }

                }
                catch (Exception Ex)
                {
                    LogHelper.Log(String.Format("[Exception][GetMESObject]:{0}", Ex));

                    return new ActResult<AE2TalkObjectV2>(Ex);
                }
            }
        }

        public ActResult<AE2TalkObject> GetEndShelfMESObject(string RecipeName_)
        {
            lock (AccessToken)
            {
                try
                {
                    END_SHELF_ACK_Data = String.Empty;
                    END_SHELF_ERROR_Data = String.Empty;

                    var msg = String.Format("End_Shelf^{0}", RecipeName_);
                    SendMsg(msg);
                    LogHelper.Log(String.Format("[Send][GetEndShelfMESObject]:{0}", msg));
                    long startTick = DateTime.Now.Ticks;
                    while (!(this.END_SHELF_ACK_Data_Available || this.END_SHELF_ERROR_Available || this.OnReceiveException))
                    {
                        Thread.Sleep(200);
                        if (DateTime.Now.Ticks > startTick + TimeOut * 10000000)
                            throw new Exception(string.Format("Wait MES Reply {0} TimeOut.", msg));
                    }

                    if (this.END_SHELF_ERROR_Available)
                    {
                        string data = String.Empty;
                        data += this.END_SHELF_ERROR_Data;

                        LogHelper.Log(String.Format("[Get][GetEndShelfMESObject]:{0}", "END_SHELF_ERROR_Available"));

                        this.END_SHELF_ERROR_Data = String.Empty;
                        throw new Exception(String.Format("{0},MES無此尾掛Recipe請自行建立.", data));
                    }
                    else if (this.END_SHELF_ACK_Data_Available)
                    {
                        string data = String.Empty;
                        data += this.END_SHELF_ACK_Data;

                        LogHelper.Log(String.Format("[Get][GetEndShelfMESObject]:{0}", data));

                        this.END_SHELF_ACK_Data = String.Empty;
                        var aEobject = JsonConvert.DeserializeObject<AE2TalkObject>(data);//反序列化

                        if (RecipeName_ == aEobject.RecipeName)
                            return new ActResult<AE2TalkObject>(aEobject);
                        else
                            return new ActResult<AE2TalkObject>(new Exception(String.Format("Error:Recipe與發送值不相同")));
                    }
                    else // if (this.OnReceiveException)
                    {
                        Exception ex = this.ReceiveException;
                        throw ex;
                    }

                }
                catch (Exception Ex)
                {
                    LogHelper.Log(String.Format("[Exception][GetEndShelfMESObject]:{0}", Ex.Message));
                    return new ActResult<AE2TalkObject>(Ex);
                }
            }
        }

        public ActResult<bool> GetIsSameRecipeName(string RecipeName_)
        {
            lock (AccessToken)
            {
                try
                {
                    Recipe_Check_ACK_Data = String.Empty;

                    var msg = String.Format("Recipe_Check^{0}", RecipeName_);
                    SendMsg(msg);
                    LogHelper.Log(String.Format("[Send][GetIsSameRecipeName]:{0}", msg));
                    long startTick = DateTime.Now.Ticks;
                    while (!(this.Recipe_Check_ACK_Available || this.OnReceiveException))
                    {
                        if (DateTime.Now.Ticks > startTick + TimeOut * 10000000)
                            throw new Exception(string.Format("Wait MES Reply {0} TimeOut.", msg));
                    }

                    if (this.Recipe_Check_ACK_Available)
                    {
                        string data = this.Recipe_Check_ACK_Data.Replace("Recipe_Check_ACK^", "");
                        LogHelper.Log(String.Format("[Get][GetIsSameRecipeName]:{0}", data));

                        if (data.Contains("YES"))
                            return new ActResult<bool>(Obj_: true, Bol_: true);
                        if (data.Contains("NO"))
                            return new ActResult<bool>(Obj_: false, Bol_: true);
                        else
                            throw new Exception(data);
                    }
                    else // if (this.OnReceiveException)
                    {
                        Exception ex = this.ReceiveException;
                        throw ex;
                    }
                }
                catch (Exception Ex)
                {
                    LogHelper.Log(String.Format("[Exception][GetIsSameRecipeName]:{0}", Ex.Message));
                    return new ActResult(Ex);
                }
            }
        }

        public ActResult SendCreateRecipeNotify(RecipeDTO Recipe_)
        {
            lock (AccessToken)
            {
                try
                {
                    RMS_Create_ACK_Data = String.Empty;

                    var aETalkobject = Recipe_.ToAE2TalkObject();
                    var json = JsonConvert.SerializeObject(aETalkobject);

                    var msg = String.Format("RMS_Create^{0}", json);
                    SendMsg(msg);
                    LogHelper.Log(String.Format("[Send][SendCreateRecipeNotify]:{0}", msg));

                    long startTick = DateTime.Now.Ticks;
                    while (!(this.RMS_Create_ACK_Available || this.OnReceiveException))
                    {
                        if (DateTime.Now.Ticks > startTick + TimeOut * 10000000)
                            throw new Exception(string.Format("Wait MES Reply {0} TimeOut.", msg));
                    }

                    if (this.RMS_Create_ACK_Available)
                    {
                        string data = this.RMS_Create_ACK_Data.Replace("RMS_Create_ACK^", "");

                        LogHelper.Log(String.Format("[Get][SendCreateRecipeNotify]:{0}", data));

                        if (data.Contains("OK"))
                            return new ActResult(true);
                        else
                            throw new Exception(data);
                    }
                    else // if (this.OnReceiveException)
                    {
                        Exception ex = this.ReceiveException;
                        throw ex;
                    }
                }
                catch (Exception Ex)
                {
                    LogHelper.Log(String.Format("[Exception][SendCreateRecipeNotify]:{0}", Ex.Message));
                    return new ActResult(Ex);
                }
            }
        }

        public ActResult SendCreateEndshiftRecipeNotify(RecipeDTO Recipe_)
        {
            lock (AccessToken)
            {
                try
                {
                    END_SHELF_RECIPE_ACK_Data = String.Empty;

                    var aETalkobject = Recipe_.ToAE2TalkObject();
                    var json = JsonConvert.SerializeObject(aETalkobject);

                    var msg = String.Format("End_Shelf_Recipe^{0}", json);
                    SendMsg(msg);

                    LogHelper.Log(String.Format("[Send][SendCreateEndshiftRecipeNotify]:{0}", msg));

                    long startTick = DateTime.Now.Ticks;
                    while (!(this.END_SHELF_RECIPE_ACK_Data_Available || this.OnReceiveException))
                    {
                        if (DateTime.Now.Ticks > startTick + TimeOut * 10000000)
                            throw new Exception(string.Format("Wait MES Reply {0} TimeOut.", msg));
                    }

                    if (this.END_SHELF_RECIPE_ACK_Data_Available)
                    {
                        string data = String.Empty;
                        data += this.END_SHELF_RECIPE_ACK_Data.Replace("End_Shelf_Recipe_ACK^", "");

                       LogHelper.Log(String.Format("[Get][SendCreateEndshiftRecipeNotify]:{0}", data));

                        this.END_SHELF_RECIPE_ACK_Data = String.Empty;
                        if (data.Contains("OK"))
                            return new ActResult(true);
                        else
                            throw new Exception(data);
                    }
                    else // if (this.OnReceiveException)
                    {
                        Exception ex = this.ReceiveException;
                        throw ex;
                    }
                }
                catch (Exception Ex)
                {
                    LogHelper.Log(String.Format("[Exception][SendCreateEndshiftRecipeNotify]:{0}", Ex.Message));
                    return new ActResult(Ex);
                }
            }
        }

        public ActResult SendADCData(string EDCxml_)
        {
            lock (AccessToken)
            {
                try
                {
                    SendMsg(String.Format("ADC^{0}", EDCxml_));

                    LogHelper.Log(String.Format("[Send][SendADCData]:ADC^{0}", EDCxml_));
                    return new ActResult(true);
                }
                catch (Exception Ex)
                {
                    LogHelper.Log(String.Format("[Exception][SendADCData]:{0}", Ex.Message));
                    return new ActResult(Ex);
                }
            }
        }

        public ActResult SendArmsAlarm(string LotNo_, string UID_, string RecipeName_, AlarmMsgDTO[] AlarmMsgs_)
        {
            lock (AccessToken)
            {
                try
                {
                    var msg = "<SendArmsAlarmMsg><ROW>";
                    var parameterName = "<ParameterName>";
                    var parameterValue = "<ParameterValue>";
                    var parameterMin = "<ParameterMin>";
                    var parameterMax = "<ParameterMax>";

                    for (int index = 0; index < AlarmMsgs_.Length; index++)
                    {
                        parameterName += AlarmMsgs_[index].Name;
                        parameterValue += AlarmMsgs_[index].RealValue;
                        parameterMin += AlarmMsgs_[index].MinLimit;
                        parameterMax += AlarmMsgs_[index].MaxLimit;

                        if (index + 1 < AlarmMsgs_.Length)
                        {
                            parameterName += ",";
                            parameterValue += ",";
                            parameterMin += ",";
                            parameterMax += ",";
                        }
                    }
                    parameterName += "</ParameterName>";
                    parameterValue += "</ParameterValue>";
                    parameterMin += "</ParameterMin>";
                    parameterMax += "</ParameterMax>";

                    msg += parameterName;
                    msg += parameterValue;
                    msg += parameterMin;
                    msg += parameterMax;
                    msg += "</ROW></SendArmsAlarmMsg>";

                    var cmd = string.Format("ArmsAlarm^{0}^{1}^{2}^{3}", LotNo_, UID_, RecipeName_, msg);

                    SendMsg(cmd);
                    LogHelper.Log(String.Format("[Send][SendArmsAlarm]:{0}", cmd));
                    return new ActResult(true);
                }
                catch (Exception Ex)
                {
                    LogHelper.Log(String.Format("[Exception][SendArmsAlarm]:{0}", Ex.Message));
                    return new ActResult(Ex);
                }
            }
        }

        public ActResult SendAlarmNotify(string AlarmCode_)
        {
            lock (AccessToken)
            {
                try
                {
                    SendMsg(String.Format("EMS^{0}", AlarmCode_));
                    LogHelper.Log(String.Format("[Send][SendAlarmNotify]:EMS^{0}", AlarmCode_));
                    return new ActResult(true);
                }
                catch (Exception Ex)
                {
                    LogHelper.Log(String.Format("[Exception][SendAlarmNotify]:{0}", Ex.Message));
                    return new ActResult(Ex);
                }
            }
        }

        public ActResult SendAlarmNotify(int AlarmCode_)
        {
            lock (AccessToken)
            {
                try
                {
                    SendAlarmNotify("AL" + String.Format("{0:000}", AlarmCode_));
                    return new ActResult(true);
                }
                catch (Exception Ex)
                {
                    return new ActResult(Ex);
                }
            }
        }

        public ActResult SendEDCData(string EDCxml_)
        {
            lock (AccessToken)
            {
                try
                {
                    SendMsg(String.Format("EDC^{0}", EDCxml_));
                    LogHelper.Log(String.Format("[Send][SendAlarmNotify]:EDC^{0}", EDCxml_));
                    return new ActResult(true);
                }
                catch (Exception Ex)
                {
                    LogHelper.Log(String.Format("[Exception][SendAlarmNotify]:{0}", Ex.Message));
                    return new ActResult(Ex);
                }
            }
        }


        public ActResult RecipeComparison(string LotCode_, string UserID_, AE2TalkObject AE2TalkObject_, RecipeDTO Recipe_)
        {
            var items = AE2TalkObject_.Items.ToDictionary(p => p.Id);
            var isfail = false;
            string exmsg = String.Format("RMS_Fail^{0}^{1}^{2}^", LotCode_, UserID_, Recipe_.PanelCode);

            foreach (CheckItemTypes checkType in Enum.GetValues(typeof(CheckItemTypes)))
            {
                if (checkType == CheckItemTypes.None) continue;

                var no = checkType.ToString().Replace("S", "");
                if (!items.ContainsKey(no)) continue;

                var item = items[no];

                double realValue = 0;
                switch (checkType)
                {
                    case CheckItemTypes.S1000002382:
                        realValue = Recipe_.Ni_WB_Adm2;
                        if (realValue > Convert.ToDouble(item.MaxValue) || realValue < Convert.ToDouble(item.MinValue))
                        {
                            isfail = true;
                            exmsg += String.Format("{0} check failed MaxValue[{1}] MinValue[{2}] Setting value[{3}] Real value[{4}]\n", item.Name, item.MaxValue, item.MinValue, item.Value, realValue);
                        }
                        break;
                    case CheckItemTypes.S1000002383:
                        realValue = Recipe_.Ni_B_Adm2;
                        if (realValue > Convert.ToDouble(item.MaxValue) || realValue < Convert.ToDouble(item.MinValue))
                        {
                            isfail = true;
                            exmsg += String.Format("{0} check failed MaxValue[{1}] MinValue[{2}] Setting value[{3}] Real value[{4}]\n", item.Name, item.MaxValue, item.MinValue, item.Value, realValue);
                        }
                        break;
                    case CheckItemTypes.S1000002384:
                        realValue = Recipe_.AuSt_Adm2;
                        if (realValue > Convert.ToDouble(item.MaxValue) || realValue < Convert.ToDouble(item.MinValue))
                        {
                            isfail = true;
                            exmsg += String.Format("{0} check failed MaxValue[{1}] MinValue[{2}] Setting value[{3}] Real value[{4}]\n", item.Name, item.MaxValue, item.MinValue, item.Value, realValue);
                        }
                        break;
                    case CheckItemTypes.S1000002385:
                        realValue = Recipe_.Au_WB_Adm2;
                        if (realValue > Convert.ToDouble(item.MaxValue) || realValue < Convert.ToDouble(item.MinValue))
                        {
                            isfail = true;
                            exmsg += String.Format("{0} check failed MaxValue[{1}] MinValue[{2}] Setting value[{3}] Real value[{4}]\n", item.Name, item.MaxValue, item.MinValue, item.Value, realValue);
                        }
                        break;
                    case CheckItemTypes.S1000002386:
                        realValue = Recipe_.Au_B_Adm2;
                        if (realValue > Convert.ToDouble(item.MaxValue) || realValue < Convert.ToDouble(item.MinValue))
                        {
                            isfail = true;
                            exmsg += String.Format("{0} check failed MaxValue[{1}] MinValue[{2}] Setting value[{3}] Real value[{4}]\n", item.Name, item.MaxValue, item.MinValue, item.Value, realValue);
                        }
                        break;
                    case CheckItemTypes.S1000004167:
                        realValue = Recipe_.WBArea;
                        if (realValue > Convert.ToDouble(item.MaxValue) || realValue < Convert.ToDouble(item.MinValue))
                        {
                            isfail = true;
                            exmsg += String.Format("{0} check failed MaxValue[{1}] MinValue[{2}] Setting value[{3}] Real value[{4}]\n", item.Name, item.MaxValue, item.MinValue, item.Value, realValue);
                        }
                        break;
                    case CheckItemTypes.S1000004170:
                        realValue = Recipe_.BArea;
                        if (realValue > Convert.ToDouble(item.MaxValue) || realValue < Convert.ToDouble(item.MinValue))
                        {
                            isfail = true;
                            exmsg += String.Format("{0} check failed MaxValue[{1}] MinValue[{2}] Setting value[{3}] Real value[{4}]\n", item.Name, item.MaxValue, item.MinValue, item.Value, realValue);
                        }
                        break;
                    default:
                        continue;
                }
            }
            if (isfail)
            {
                SendMsg(exmsg);

                LogHelper.Log(String.Format("[Send][RecipeComparison]:", exmsg));
                return new ActResult(new Exception(exmsg));
            }
            else
            {
                return new ActResult(true);
            }
        }

        public ActResult<List<AlarmMsgDTO>> ParamterComparison(string LotCode_, string UserID_, CheckItemObject CheckItemObject_, ThermostatLogDTO ThermostatLogs_, Modbus31LogDTO APAX5070_31Log_, Modbus32LogDTO APAX5070_32Log_, Modbus33LogDTO APAX5070_33Log_, WashDeviceLogDTO WashDeviceLog_)
        {
            var items = this.BasicAE2Talk.Items.ToDictionary(p => p.Id);
            var isfail = false;
            List<AlarmMsgDTO> alarmMsgs = new List<AlarmMsgDTO>();

            var properties = typeof(CheckItemObject).GetProperties();

            foreach (PropertyInfo propertyInfo in properties)
            {
                if ((bool)propertyInfo.GetValue(CheckItemObject_) == false) continue;

                var no = propertyInfo.Name.Replace("S", "");
                if (!items.ContainsKey(no))
                    continue;

                var item = items[no];

                double realValue = 0;
                switch (propertyInfo.Name)
                {
                    case nameof(CheckItemObject_.HotRinse_1_Temp):
                        realValue = ThermostatLogs_.TC02;
                        if (realValue >NowADCConfig.HotRinse_1_Temp_MaxValue|| realValue < NowADCConfig.HotRinse_1_Temp_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.HotRinse_1_Temp_MaxValue, MinLimit = NowADCConfig.HotRinse_1_Temp_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.HotRinse_2_Temp):
                        realValue = ThermostatLogs_.TC03;
                        if (realValue > NowADCConfig.HotRinse_2_Temp_MaxValue || realValue < NowADCConfig.HotRinse_2_Temp_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.HotRinse_2_Temp_MaxValue, MinLimit = NowADCConfig.HotRinse_2_Temp_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Clean):
                        realValue = APAX5070_31Log_.Clean;
                        if (realValue > NowADCConfig.Clean_MaxValue || realValue < NowADCConfig.Clean_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Clean_MaxValue, MinLimit = NowADCConfig.Clean_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Cleaner_Temp):
                        realValue = ThermostatLogs_.TC01;
                        if (realValue > NowADCConfig.Cleaner_Temp_MaxValue || realValue < NowADCConfig.Cleaner_Temp_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Cleaner_Temp_MaxValue, MinLimit = NowADCConfig.Cleaner_Temp_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.NiEtch_Temp):
                        realValue = ThermostatLogs_.TC04;
                        if (realValue > NowADCConfig.NiEtch_Temp_MaxValue || realValue < NowADCConfig.NiEtch_Temp_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.NiEtch_Temp_MaxValue, MinLimit = NowADCConfig.NiEtch_Temp_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Microerching):
                        realValue = APAX5070_31Log_.Microerching;
                        if (realValue > NowADCConfig.Microerching_MaxValue || realValue < NowADCConfig.Microerching_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Microerching_MaxValue, MinLimit = NowADCConfig.Microerching_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.ACID1):
                        realValue = APAX5070_31Log_.ACID1;
                        if (realValue > NowADCConfig.ACID1_MaxValue || realValue < NowADCConfig.ACID1_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.ACID1_MaxValue, MinLimit = NowADCConfig.ACID1_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Ni1_Temp):
                        realValue = ThermostatLogs_.TC05;
                        if (realValue > NowADCConfig.Ni1_Temp_MaxValue || realValue < NowADCConfig.Ni1_Temp_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Ni1_Temp_MaxValue, MinLimit = NowADCConfig.Ni1_Temp_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel1_1):
                        realValue = APAX5070_31Log_.Nickel1_1;
                        if (realValue > NowADCConfig.Nickel1_1_MaxValue|| realValue < NowADCConfig.Nickel1_1_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel1_1_MaxValue, MinLimit = NowADCConfig.Nickel1_1_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel1_2):
                        realValue = APAX5070_31Log_.Nickel1_2;
                        if (realValue > NowADCConfig.Nickel1_2_MaxValue || realValue < NowADCConfig.Nickel1_2_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel1_2_MaxValue, MinLimit = NowADCConfig.Nickel1_2_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel1_3):
                        realValue = APAX5070_31Log_.Nickel1_3;
                        if (realValue > NowADCConfig.Nickel1_3_MaxValue || realValue < NowADCConfig.Nickel1_3_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel1_3_MaxValue, MinLimit = NowADCConfig.Nickel1_3_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break; ;
                    case nameof(CheckItemObject_.Nickel1_Air_1):
                        realValue = APAX5070_31Log_.Nickel1_Air_1;
                        if (realValue > NowADCConfig.Nickel1_Air_1_MaxValue || realValue < NowADCConfig.Nickel1_Air_1_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel1_Air_1_MaxValue, MinLimit = NowADCConfig.Nickel1_Air_1_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break; ;
                    case nameof(CheckItemObject_.Nickel1_Air_2):
                        realValue = APAX5070_31Log_.Nickel1_Air_2;
                        if (realValue > NowADCConfig.Nickel1_Air_2_MaxValue || realValue < NowADCConfig.Nickel1_Air_2_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel1_Air_2_MaxValue, MinLimit = NowADCConfig.Nickel1_Air_2_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break; ;
                    case nameof(CheckItemObject_.Nickel1_Air_3):
                        realValue = APAX5070_31Log_.Nickel1_Air_3;
                        if (realValue > NowADCConfig.Nickel1_Air_3_MaxValue || realValue < NowADCConfig.Nickel1_Air_3_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel1_Air_3_MaxValue, MinLimit = NowADCConfig.Nickel1_Air_3_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break; ;
                    case nameof(CheckItemObject_.Nickel1_Air_4):
                        realValue = APAX5070_31Log_.Nickel1_Air_4;
                        if (realValue > NowADCConfig.Nickel1_Air_4_MaxValue || realValue < NowADCConfig.Nickel1_Air_4_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel1_Air_4_MaxValue, MinLimit = NowADCConfig.Nickel1_Air_4_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break; ;
                    case nameof(CheckItemObject_.Nickel1_Air_5):
                        realValue = APAX5070_31Log_.Nickel1_Air_5;
                        if (realValue > NowADCConfig.Nickel1_Air_5_MaxValue || realValue < NowADCConfig.Nickel1_Air_5_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel1_Air_5_MaxValue, MinLimit = NowADCConfig.Nickel1_Air_5_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break; ;
                    case nameof(CheckItemObject_.Nickel1_Air_6):
                        realValue = APAX5070_31Log_.Nickel1_Air_6;
                        if (realValue > NowADCConfig.Nickel1_Air_6_MaxValue || realValue < NowADCConfig.Nickel1_Air_6_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel1_Air_6_MaxValue, MinLimit = NowADCConfig.Nickel1_Air_6_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Ni2_Temp):
                        realValue = ThermostatLogs_.TC06;
                        if (realValue > NowADCConfig.Ni2_Temp_MaxValue || realValue < NowADCConfig.Ni2_Temp_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Ni2_Temp_MaxValue, MinLimit = NowADCConfig.Ni2_Temp_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel2_1):
                        realValue = APAX5070_31Log_.Nickel2_1;
                        if (realValue > NowADCConfig.Nickel2_1_MaxValue || realValue < NowADCConfig.Nickel2_1_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel2_1_MaxValue, MinLimit = NowADCConfig.Nickel2_1_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel2_2):
                        realValue = APAX5070_31Log_.Nickel2_2;
                        if (realValue > NowADCConfig.Nickel2_2_MaxValue || realValue < NowADCConfig.Nickel2_2_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel2_2_MaxValue, MinLimit = NowADCConfig.Nickel2_2_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel2_3):
                        realValue = APAX5070_31Log_.Nickel2_3;
                        if (realValue > NowADCConfig.Nickel2_3_MaxValue || realValue < NowADCConfig.Nickel2_3_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel2_3_MaxValue, MinLimit = NowADCConfig.Nickel2_3_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel2_Air_1):
                        realValue = APAX5070_31Log_.Nickel2_Air_1;
                        if (realValue > NowADCConfig.Nickel2_Air_1_MaxValue || realValue < NowADCConfig.Nickel2_Air_1_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel2_Air_1_MaxValue, MinLimit = NowADCConfig.Nickel2_Air_1_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel2_Air_2):
                        realValue = APAX5070_31Log_.Nickel2_Air_2;
                        if (realValue > NowADCConfig.Nickel2_Air_2_MaxValue || realValue < NowADCConfig.Nickel2_Air_2_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel2_Air_2_MaxValue, MinLimit = NowADCConfig.Nickel2_Air_2_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel2_Air_3):
                        realValue = APAX5070_31Log_.Nickel2_Air_3;
                        if (realValue > NowADCConfig.Nickel2_Air_3_MaxValue || realValue < NowADCConfig.Nickel2_Air_3_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel2_Air_3_MaxValue, MinLimit = NowADCConfig.Nickel2_Air_3_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel2_Air_4):
                        realValue = APAX5070_31Log_.Nickel2_Air_4;
                        if (realValue > NowADCConfig.Nickel2_Air_4_MaxValue || realValue < NowADCConfig.Nickel2_Air_4_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel2_Air_4_MaxValue, MinLimit = NowADCConfig.Nickel2_Air_4_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel2_Air_5):
                        realValue = APAX5070_31Log_.Nickel2_Air_5;
                        if (realValue > NowADCConfig.Nickel2_Air_5_MaxValue || realValue < NowADCConfig.Nickel2_Air_5_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel2_Air_5_MaxValue, MinLimit = NowADCConfig.Nickel2_Air_5_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel2_Air_6):
                        realValue = APAX5070_31Log_.Nickel2_Air_6;
                        if (realValue > NowADCConfig.Nickel2_Air_6_MaxValue || realValue < NowADCConfig.Nickel2_Air_6_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel2_Air_6_MaxValue, MinLimit = NowADCConfig.Nickel2_Air_6_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Ni3_Temp):
                        realValue = ThermostatLogs_.TC07;
                        if (realValue > NowADCConfig.Ni3_Temp_MaxValue || realValue < NowADCConfig.Ni3_Temp_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Ni3_Temp_MaxValue, MinLimit = NowADCConfig.Ni3_Temp_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel3_1):
                        realValue = APAX5070_32Log_.Nickel3_1;
                        if (realValue > NowADCConfig.Nickel3_1_MaxValue || realValue < NowADCConfig.Nickel3_1_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel3_1_MaxValue, MinLimit = NowADCConfig.Nickel3_1_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel3_2):
                        realValue = APAX5070_32Log_.Nickel3_2;
                        if (realValue > NowADCConfig.Nickel3_2_MaxValue || realValue < NowADCConfig.Nickel3_2_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel3_2_MaxValue, MinLimit = NowADCConfig.Nickel3_2_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel3_3):
                        realValue = APAX5070_32Log_.Nickel3_3;
                        if (realValue > NowADCConfig.Nickel3_3_MaxValue || realValue < NowADCConfig.Nickel3_3_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel3_3_MaxValue, MinLimit = NowADCConfig.Nickel3_3_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel3_Air_1):
                        realValue = APAX5070_32Log_.Nickel3_Air_1;
                        if (realValue > NowADCConfig.Nickel3_Air_1_MaxValue || realValue < NowADCConfig.Nickel3_Air_1_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel3_Air_1_MaxValue, MinLimit = NowADCConfig.Nickel3_Air_1_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel3_Air_2):
                        realValue = APAX5070_32Log_.Nickel3_Air_2;
                        if (realValue > NowADCConfig.Nickel3_Air_2_MaxValue || realValue < NowADCConfig.Nickel3_Air_2_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel3_Air_2_MaxValue, MinLimit = NowADCConfig.Nickel3_Air_2_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel3_Air_3):
                        realValue = APAX5070_32Log_.Nickel3_Air_3;
                        if (realValue > NowADCConfig.Nickel3_Air_3_MaxValue || realValue < NowADCConfig.Nickel3_Air_3_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel3_Air_3_MaxValue, MinLimit = NowADCConfig.Nickel3_Air_3_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel3_Air_4):
                        realValue = APAX5070_32Log_.Nickel3_Air_4;
                        if (realValue > NowADCConfig.Nickel3_Air_4_MaxValue || realValue < NowADCConfig.Nickel3_Air_4_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel3_Air_4_MaxValue, MinLimit = NowADCConfig.Nickel3_Air_4_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel3_Air_5):
                        realValue = APAX5070_32Log_.Nickel3_Air_5;
                        if (realValue > NowADCConfig.Nickel3_Air_5_MaxValue || realValue < NowADCConfig.Nickel3_Air_5_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel3_Air_5_MaxValue, MinLimit = NowADCConfig.Nickel3_Air_5_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel3_Air_6):
                        realValue = APAX5070_32Log_.Nickel3_Air_6;
                        if (realValue > NowADCConfig.Nickel3_Air_6_MaxValue || realValue < NowADCConfig.Nickel3_Air_6_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel3_Air_6_MaxValue, MinLimit = NowADCConfig.Nickel3_Air_6_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Ni4_Temp):
                        realValue = ThermostatLogs_.TC08;
                        if (realValue > NowADCConfig.Ni4_Temp_MaxValue || realValue < NowADCConfig.Ni4_Temp_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Ni4_Temp_MaxValue, MinLimit = NowADCConfig.Ni4_Temp_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel4_1):
                        realValue = APAX5070_32Log_.Nickel4_1;
                        if (realValue > NowADCConfig.Nickel4_1_MaxValue || realValue < NowADCConfig.Nickel4_1_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel4_1_MaxValue, MinLimit = NowADCConfig.Nickel4_1_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel4_2):
                        realValue = APAX5070_32Log_.Nickel4_2;
                        if (realValue > NowADCConfig.Nickel4_2_MaxValue || realValue < NowADCConfig.Nickel4_2_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel4_2_MaxValue, MinLimit = NowADCConfig.Nickel4_2_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel4_3):
                        realValue = APAX5070_32Log_.Nickel4_3;
                        if (realValue > NowADCConfig.Nickel4_3_MaxValue || realValue < NowADCConfig.Nickel4_3_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel4_3_MaxValue, MinLimit = NowADCConfig.Nickel4_3_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel4_Air_1):
                        realValue = APAX5070_32Log_.Nickel4_Air_1;
                        if (realValue > NowADCConfig.Nickel1_Air_1_MaxValue || realValue < NowADCConfig.Nickel4_Air_1_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel1_Air_1_MaxValue, MinLimit = NowADCConfig.Nickel4_Air_1_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel4_Air_2):
                        realValue = APAX5070_32Log_.Nickel4_Air_2;
                        if (realValue > NowADCConfig.Nickel1_Air_2_MaxValue || realValue < NowADCConfig.Nickel4_Air_2_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel1_Air_2_MaxValue, MinLimit = NowADCConfig.Nickel4_Air_2_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel4_Air_3):
                        realValue = APAX5070_32Log_.Nickel4_Air_3;
                        if (realValue > NowADCConfig.Nickel1_Air_3_MaxValue || realValue < NowADCConfig.Nickel4_Air_3_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel1_Air_3_MaxValue, MinLimit = NowADCConfig.Nickel4_Air_3_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel4_Air_4):
                        realValue = APAX5070_32Log_.Nickel4_Air_4;
                        if (realValue > NowADCConfig.Nickel1_Air_4_MaxValue || realValue < NowADCConfig.Nickel4_Air_4_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel1_Air_4_MaxValue, MinLimit = NowADCConfig.Nickel4_Air_4_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel4_Air_5):
                        realValue = APAX5070_32Log_.Nickel4_Air_5;
                        if (realValue > NowADCConfig.Nickel1_Air_5_MaxValue || realValue < NowADCConfig.Nickel4_Air_5_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel1_Air_5_MaxValue, MinLimit = NowADCConfig.Nickel4_Air_5_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel4_Air_6):
                        realValue = APAX5070_32Log_.Nickel4_Air_6;
                        if (realValue > NowADCConfig.Nickel1_Air_6_MaxValue || realValue < NowADCConfig.Nickel4_Air_6_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel1_Air_6_MaxValue, MinLimit = NowADCConfig.Nickel4_Air_6_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.AuSt_Temp):
                        realValue = ThermostatLogs_.TC09;
                        if (realValue > NowADCConfig.AuSt_Temp_MaxValue || realValue < NowADCConfig.AuSt_Temp_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.AuSt_Temp_MaxValue, MinLimit = NowADCConfig.AuSt_Temp_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.AuSt):
                        realValue = APAX5070_32Log_.Au_Strike;
                        if (realValue > NowADCConfig.AuSt_MaxValue || realValue < NowADCConfig.AuSt_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.AuSt_MaxValue, MinLimit = NowADCConfig.AuSt_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Au_1_Temp):
                        realValue = ThermostatLogs_.TC10;
                        if (realValue > NowADCConfig.Au_1_Temp_MaxValue || realValue < NowADCConfig.Au_1_Temp_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Au_1_Temp_MaxValue, MinLimit = NowADCConfig.Au_1_Temp_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Au_1):
                        realValue = APAX5070_32Log_.Au_1;
                        if (realValue > NowADCConfig.Au_1_MaxValue || realValue < NowADCConfig.Au_1_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Au_1_MaxValue, MinLimit = NowADCConfig.Au_1_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Au_2_Temp):
                        realValue = ThermostatLogs_.TC11;
                        if (realValue > NowADCConfig.Au_2_Temp_MaxValue || realValue < NowADCConfig.Au_2_Temp_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Au_2_Temp_MaxValue, MinLimit = NowADCConfig.Au_2_Temp_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Au_2):
                        realValue = APAX5070_32Log_.Au_2;
                        if (realValue > NowADCConfig.Au_2_MaxValue || realValue < NowADCConfig.Au_2_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Au_2_MaxValue, MinLimit = NowADCConfig.Au_2_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.HDIR_1_Temp):
                        realValue = ThermostatLogs_.TC12;
                        if (realValue > NowADCConfig.HDIR_1_Temp_MaxValue || realValue < NowADCConfig.HDIR_1_Temp_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.HDIR_1_Temp_MaxValue, MinLimit = NowADCConfig.HDIR_1_Temp_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.HDIR_2_Temp):
                        realValue = ThermostatLogs_.TC13;
                        if (realValue > NowADCConfig.HDIR_2_Temp_MaxValue || realValue < NowADCConfig.HDIR_2_Temp_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.HDIR_2_Temp_MaxValue, MinLimit = NowADCConfig.HDIR_2_Temp_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                }
            }

            var dicProperties = new Dictionary<string, PropertyInfo>();
            foreach (var pInfo in typeof(CheckItemObject).GetProperties())
            {
                dicProperties.Add(pInfo.Name, pInfo);
            }

            if (CheckItemObject_.WATER_11)
            {
                if (APAX5070_33Log_.Water11 < NowADCConfig.Water11_MinValue || APAX5070_33Log_.Water11 > NowADCConfig.Water11_MaxValue)
                {
                    alarmMsgs.Add(new AlarmMsgDTO() { Name = dicProperties[nameof(CheckItemObject.WATER_11)].GetCustomAttribute<DisplayAttribute>().ZHTW, MaxLimit = NowADCConfig.Water11_MaxValue, MinLimit = NowADCConfig.Water11_MinValue, RealValue = APAX5070_33Log_.Water11 }); ;
                    isfail = true;
                }
            }
            if (CheckItemObject_.WATER_12)
            {
                if (APAX5070_33Log_.Water12 < NowADCConfig.Water12_MinValue || APAX5070_33Log_.Water12 > NowADCConfig.Water12_MaxValue)
                {
                    alarmMsgs.Add(new AlarmMsgDTO() { Name = dicProperties[nameof(CheckItemObject.WATER_12)].GetCustomAttribute<DisplayAttribute>().ZHTW, MaxLimit = NowADCConfig.Water12_MaxValue, MinLimit = NowADCConfig.Water12_MinValue, RealValue = APAX5070_33Log_.Water12 }); ;
                    isfail = true;
                }
            }
            if (CheckItemObject_.WATER_13)
            {
                if (APAX5070_33Log_.Water13 < NowADCConfig.Water13_MinValue || APAX5070_33Log_.Water13 > NowADCConfig.Water13_MaxValue)
                {
                    alarmMsgs.Add(new AlarmMsgDTO() { Name = dicProperties[nameof(CheckItemObject.WATER_13)].GetCustomAttribute<DisplayAttribute>().ZHTW, MaxLimit = NowADCConfig.Water13_MaxValue, MinLimit = NowADCConfig.Water13_MinValue, RealValue = APAX5070_33Log_.Water13 }); ;
                    isfail = true;
                }
            }
            if (CheckItemObject_.Rinse1)
            {
                if (APAX5070_33Log_.Rinse1 < NowADCConfig.Rinse01_MinValue || APAX5070_33Log_.Rinse1 > NowADCConfig.Rinse01_MaxValue)
                {
                    alarmMsgs.Add(new AlarmMsgDTO() { Name = dicProperties[nameof(CheckItemObject.Rinse1)].GetCustomAttribute<DisplayAttribute>().ZHTW, MaxLimit = NowADCConfig.Rinse01_MaxValue, MinLimit = NowADCConfig.Rinse01_MinValue, RealValue = APAX5070_33Log_.Rinse1 }); ;
                    isfail = true;
                }
            }
            if (CheckItemObject_.Rinse2)
            {
                if (APAX5070_33Log_.Rinse2 < NowADCConfig.Rinse02_MinValue || APAX5070_33Log_.Rinse2 > NowADCConfig.Rinse02_MaxValue)
                {
                    alarmMsgs.Add(new AlarmMsgDTO() { Name = dicProperties[nameof(CheckItemObject.Rinse2)].GetCustomAttribute<DisplayAttribute>().ZHTW, MaxLimit = NowADCConfig.Rinse02_MaxValue, MinLimit = NowADCConfig.Rinse02_MinValue, RealValue = APAX5070_33Log_.Rinse2 }); ;
                    isfail = true;
                }
            }
            if (CheckItemObject_.Rinse3)
            {
                if (APAX5070_33Log_.Rinse3 < NowADCConfig.Rinse03_MinValue || APAX5070_33Log_.Rinse3 > NowADCConfig.Rinse03_MaxValue)
                {
                    alarmMsgs.Add(new AlarmMsgDTO() { Name = dicProperties[nameof(CheckItemObject.Rinse3)].GetCustomAttribute<DisplayAttribute>().ZHTW, MaxLimit = NowADCConfig.Rinse03_MaxValue, MinLimit = NowADCConfig.Rinse03_MinValue, RealValue = APAX5070_33Log_.Rinse3 }); ;
                    isfail = true;
                }
            }
            if (CheckItemObject_.Rinse4)
            {
                if (APAX5070_33Log_.Rinse4 < NowADCConfig.Rinse04_MinValue || APAX5070_33Log_.Rinse4 > NowADCConfig.Rinse04_MaxValue)
                {
                    alarmMsgs.Add(new AlarmMsgDTO() { Name = dicProperties[nameof(CheckItemObject.Rinse4)].GetCustomAttribute<DisplayAttribute>().ZHTW, MaxLimit = NowADCConfig.Rinse04_MaxValue, MinLimit = NowADCConfig.Rinse04_MinValue, RealValue = APAX5070_33Log_.Rinse4 }); ;
                    isfail = true;
                }
            }
            if (CheckItemObject_.Rinse5)
            {
                if (APAX5070_33Log_.Rinse5 < NowADCConfig.Rinse05_MinValue || APAX5070_33Log_.Rinse5 > NowADCConfig.Rinse05_MaxValue)
                {
                    alarmMsgs.Add(new AlarmMsgDTO() { Name = dicProperties[nameof(CheckItemObject.Rinse5)].GetCustomAttribute<DisplayAttribute>().ZHTW, MaxLimit = NowADCConfig.Rinse05_MaxValue, MinLimit = NowADCConfig.Rinse05_MinValue, RealValue = APAX5070_33Log_.Rinse5 }); ;
                    isfail = true;
                }
            }
            if (CheckItemObject_.Rinse7)
            {
                if (APAX5070_33Log_.Rinse7 < NowADCConfig.Rinse07_MinValue || APAX5070_33Log_.Rinse7 > NowADCConfig.Rinse07_MaxValue)
                {
                    alarmMsgs.Add(new AlarmMsgDTO() { Name = dicProperties[nameof(CheckItemObject.Rinse7)].GetCustomAttribute<DisplayAttribute>().ZHTW, MaxLimit = NowADCConfig.Rinse07_MaxValue, MinLimit = NowADCConfig.Rinse07_MinValue, RealValue = APAX5070_33Log_.Rinse7 }); ;
                    isfail = true;
                }

            }
            if (CheckItemObject_.Rinse8)
            {
                if (APAX5070_33Log_.Rinse8 < NowADCConfig.Rinse08_MinValue || APAX5070_33Log_.Rinse8 > NowADCConfig.Rinse08_MaxValue)
                {
                    alarmMsgs.Add(new AlarmMsgDTO() { Name = dicProperties[nameof(CheckItemObject.Rinse8)].GetCustomAttribute<DisplayAttribute>().ZHTW, MaxLimit = NowADCConfig.Rinse08_MaxValue, MinLimit = NowADCConfig.Rinse08_MinValue, RealValue = APAX5070_33Log_.Rinse8 }); ;
                    isfail = true;
                }
            }
            if (CheckItemObject_.Rinse9)
            {
                if (APAX5070_33Log_.Rinse8 < NowADCConfig.Rinse09_MinValue || APAX5070_33Log_.Rinse8 > NowADCConfig.Rinse09_MaxValue)
                {
                    alarmMsgs.Add(new AlarmMsgDTO() { Name = dicProperties[nameof(CheckItemObject.Rinse8)].GetCustomAttribute<DisplayAttribute>().ZHTW, MaxLimit = NowADCConfig.Rinse09_MaxValue, MinLimit = NowADCConfig.Rinse09_MinValue, RealValue = APAX5070_33Log_.Rinse8 }); ;
                    isfail = true;
                }
            }
            if (CheckItemObject_.Rinse10)
            {
                if (APAX5070_33Log_.Rinse10 < NowADCConfig.Rinse10_MinValue || APAX5070_33Log_.Rinse10 > NowADCConfig.Rinse10_MaxValue)
                {
                    alarmMsgs.Add(new AlarmMsgDTO() { Name = dicProperties[nameof(CheckItemObject.Rinse10)].GetCustomAttribute<DisplayAttribute>().ZHTW, MaxLimit = NowADCConfig.Rinse10_MaxValue, MinLimit = NowADCConfig.Rinse10_MinValue, RealValue = APAX5070_33Log_.Rinse10 }); ;
                    isfail = true;
                }
            }
            if (CheckItemObject_.Rinse11)
            {
                if (APAX5070_33Log_.Rinse11 < NowADCConfig.Rinse11_MinValue || APAX5070_33Log_.Rinse11 > NowADCConfig.Rinse11_MaxValue)
                {
                    alarmMsgs.Add(new AlarmMsgDTO() { Name = dicProperties[nameof(CheckItemObject.Rinse11)].GetCustomAttribute<DisplayAttribute>().ZHTW, MaxLimit = NowADCConfig.Rinse11_MaxValue, MinLimit = NowADCConfig.Rinse11_MinValue, RealValue = APAX5070_33Log_.Rinse11 }); ;
                    isfail = true;
                }
            }
            if (CheckItemObject_.Rinse12)
            {
                if (APAX5070_33Log_.Rinse12 < NowADCConfig.Rinse12_MinValue || APAX5070_33Log_.Rinse12 > NowADCConfig.Rinse12_MaxValue)
                {
                    alarmMsgs.Add(new AlarmMsgDTO() { Name = dicProperties[nameof(CheckItemObject.Rinse12)].GetCustomAttribute<DisplayAttribute>().ZHTW, MaxLimit = NowADCConfig.Rinse12_MaxValue, MinLimit = NowADCConfig.Rinse12_MinValue, RealValue = APAX5070_33Log_.Rinse12 }); ;
                    isfail = true;
                }
            }
            if (CheckItemObject_.Rinse13)
            {
                if (APAX5070_33Log_.Rinse13 < NowADCConfig.Rinse13_MinValue || APAX5070_33Log_.Rinse13 > NowADCConfig.Rinse13_MaxValue)
                {
                    alarmMsgs.Add(new AlarmMsgDTO() { Name = dicProperties[nameof(CheckItemObject.Rinse13)].GetCustomAttribute<DisplayAttribute>().ZHTW, MaxLimit = NowADCConfig.Rinse13_MaxValue, MinLimit = NowADCConfig.Rinse13_MinValue, RealValue = APAX5070_33Log_.Rinse13 }); ;
                    isfail = true;
                }
            }
            if (CheckItemObject_.Rinse_Flow1)
            {
                if (APAX5070_33Log_.Rinse_Flow1 < NowADCConfig.Rinse_Flow1_MinValue || APAX5070_33Log_.Rinse13 > NowADCConfig.Rinse_Flow1_MaxValue)
                {
                    alarmMsgs.Add(new AlarmMsgDTO() { Name = dicProperties[nameof(CheckItemObject.Rinse_Flow1)].GetCustomAttribute<DisplayAttribute>().ZHTW, MaxLimit = NowADCConfig.Rinse_Flow1_MaxValue, MinLimit = NowADCConfig.Rinse_Flow1_MinValue, RealValue = APAX5070_33Log_.Rinse_Flow1 }); ;
                    isfail = true;
                }
            }
            if (CheckItemObject_.Rinse_Flow2)
            {
                if (APAX5070_33Log_.Rinse_Flow2 < NowADCConfig.Rinse_Flow2_MinValue || APAX5070_33Log_.Rinse13 > NowADCConfig.Rinse_Flow2_MaxValue)
                {
                    alarmMsgs.Add(new AlarmMsgDTO() { Name = dicProperties[nameof(CheckItemObject.Rinse_Flow2)].GetCustomAttribute<DisplayAttribute>().ZHTW, MaxLimit = NowADCConfig.Rinse_Flow2_MaxValue, MinLimit = NowADCConfig.Rinse_Flow2_MinValue, RealValue = APAX5070_33Log_.Rinse_Flow2 }); ;
                    isfail = true;
                }
            }
            if (CheckItemObject_.Rinse_Flow3)
            {
                if (APAX5070_33Log_.Rinse_Flow3 < NowADCConfig.Rinse_Flow3_MinValue || APAX5070_33Log_.Rinse13 > NowADCConfig.Rinse_Flow3_MaxValue)
                {
                    alarmMsgs.Add(new AlarmMsgDTO() { Name = dicProperties[nameof(CheckItemObject.Rinse_Flow3)].GetCustomAttribute<DisplayAttribute>().ZHTW, MaxLimit = NowADCConfig.Rinse_Flow3_MaxValue, MinLimit = NowADCConfig.Rinse_Flow3_MinValue, RealValue = APAX5070_33Log_.Rinse_Flow3 }); ;
                    isfail = true;
                }
            }
            if (CheckItemObject_.Rinse_EC)
            {
                if (APAX5070_33Log_.Rinse_EC < NowADCConfig.Rinse_EC_MinValue || APAX5070_33Log_.Rinse_EC > NowADCConfig.Rinse_EC_MaxValue)
                {
                    alarmMsgs.Add(new AlarmMsgDTO() { Name = dicProperties[nameof(CheckItemObject.Rinse_EC)].GetCustomAttribute<DisplayAttribute>().ZHTW, MaxLimit = NowADCConfig.Rinse_EC_MaxValue, MinLimit = NowADCConfig.Rinse_EC_MinValue, RealValue = APAX5070_33Log_.Rinse_EC }); ;
                    isfail = true;
                }
            }
            if (CheckItemObject_.LineSpeed)
            {
                if (WashDeviceLog_.Speed < NowADCConfig.WM_LineSpeed_MinValue || WashDeviceLog_.Speed > NowADCConfig.WM_LineSpeed_MaxValue)
                {
                    alarmMsgs.Add(new AlarmMsgDTO() { Name = dicProperties[nameof(CheckItemObject.LineSpeed)].GetCustomAttribute<DisplayAttribute>().ZHTW, MaxLimit = NowADCConfig.WM_LineSpeed_MaxValue, MinLimit = NowADCConfig.WM_LineSpeed_MinValue, RealValue = WashDeviceLog_.Speed }); ;
                    isfail = true;
                }
            }
            if (CheckItemObject_.Temperature)
            {
                if (WashDeviceLog_.Temperature < NowADCConfig.WM_Temperature_MinValue || WashDeviceLog_.Temperature > NowADCConfig.WM_Temperature_MaxValue)
                {
                    alarmMsgs.Add(new AlarmMsgDTO() { Name = dicProperties[nameof(CheckItemObject.Temperature)].GetCustomAttribute<DisplayAttribute>().ZHTW, MaxLimit = NowADCConfig.WM_Temperature_MaxValue, MinLimit = NowADCConfig.WM_Temperature_MinValue, RealValue = WashDeviceLog_.Temperature }); ;
                    isfail = true;
                }
            }
            if (isfail)
            {
                return new ActResult<List<AlarmMsgDTO>>(alarmMsgs, false);
            }
            else
            {
                return new ActResult<List<AlarmMsgDTO>>(true);
            }
        }

        public string CreateEDCxml(
            ThermostatLogDTO ThermostatLogs_,
            Modbus31LogDTO Modbus31Log_,
            Modbus32LogDTO Modbus32Log_,
            Modbus33LogDTO Modbus33Log_,
            WashDeviceLogDTO WashDeviceLog_)
        {

            var PreHotRinse_1_Temp = ThermostatLogs_.TC02;
            var PreHotRinse_2_Temp = ThermostatLogs_.TC03;
            var CleanPressure = Modbus31Log_.Clean;
            var CleanTemp = ThermostatLogs_.TC01;
            var MicrTemp = ThermostatLogs_.TC04;
            var MicrPressure = Modbus31Log_.Microerching;
            var Acid1Pressure = Modbus31Log_.ACID1;

            var Nickel1Temperature = ThermostatLogs_.TC05;
            var Nickel1Pressure1 = Modbus31Log_.Nickel1_1;
            var Nickel1Pressure2 = Modbus31Log_.Nickel1_2;
            var Nickel1Pressure3 = Modbus31Log_.Nickel1_3;
            var Nickel1AirFlow1_1 = Modbus31Log_.Nickel1_Air_1;
            var Nickel1AirFlow1_2 = Modbus31Log_.Nickel1_Air_2;
            var Nickel1AirFlow1_3 = Modbus31Log_.Nickel1_Air_3;
            var Nickel1AirFlow1_4 = Modbus31Log_.Nickel1_Air_4;
            var Nickel1AirFlow1_5 = Modbus31Log_.Nickel1_Air_5;
            var Nickel1AirFlow1_6 = Modbus31Log_.Nickel1_Air_6;

            var Nickel2Temperature = ThermostatLogs_.TC06;
            var Nickel2Pressure1 = Modbus31Log_.Nickel2_1;
            var Nickel2Pressure2 = Modbus31Log_.Nickel2_2;
            var Nickel2Pressure3 = Modbus31Log_.Nickel2_3;
            var Nickel2AirFlow2_1 = Modbus31Log_.Nickel2_Air_1;
            var Nickel2AirFlow2_2 = Modbus31Log_.Nickel2_Air_2;
            var Nickel2AirFlow2_3 = Modbus31Log_.Nickel2_Air_3;
            var Nickel2AirFlow2_4 = Modbus31Log_.Nickel2_Air_4;
            var Nickel2AirFlow2_5 = Modbus31Log_.Nickel2_Air_5;
            var Nickel2AirFlow2_6 = Modbus31Log_.Nickel2_Air_6;

            var Nickel3Temperature = ThermostatLogs_.TC07;
            var Nickel3Pressure1 = Modbus32Log_.Nickel3_1;
            var Nickel3Pressure2 = Modbus32Log_.Nickel3_1;
            var Nickel3Pressure3 = Modbus32Log_.Nickel3_1;
            var Nickel3AirFlow3_1 = Modbus32Log_.Nickel3_Air_1;
            var Nickel3AirFlow3_2 = Modbus32Log_.Nickel3_Air_2;
            var Nickel3AirFlow3_3 = Modbus32Log_.Nickel3_Air_3;
            var Nickel3AirFlow3_4 = Modbus32Log_.Nickel3_Air_4;
            var Nickel3AirFlow3_5 = Modbus32Log_.Nickel3_Air_5;
            var Nickel3AirFlow3_6 = Modbus32Log_.Nickel3_Air_6;

            var Nickel4Temperature = ThermostatLogs_.TC08;
            var Nickel4Pressure1 = Modbus32Log_.Nickel4_1;
            var Nickel4Pressure2 = Modbus32Log_.Nickel4_2;
            var Nickel4Pressure3 = Modbus32Log_.Nickel4_3;
            var Nickel4AirFlow4_1 = Modbus32Log_.Nickel4_Air_1;
            var Nickel4AirFlow4_2 = Modbus32Log_.Nickel4_Air_2;
            var Nickel4AirFlow4_3 = Modbus32Log_.Nickel4_Air_3;
            var Nickel4AirFlow4_4 = Modbus32Log_.Nickel4_Air_4;
            var Nickel4AirFlow4_5 = Modbus32Log_.Nickel4_Air_5;
            var Nickel4AirFlow4_6 = Modbus32Log_.Nickel4_Air_6;

            var StrikeAuTemperature = ThermostatLogs_.TC09;
            var StrikeAuPressure = Modbus32Log_.Au_Strike;
            var StrikeAu1Temperature = ThermostatLogs_.TC10;
            var StrikeAu1Pressure = Modbus32Log_.Au_1;
            var StrikeAu2Temperature = ThermostatLogs_.TC11;
            var StrikeAu2Pressure = Modbus32Log_.Au_2;

            var PostHotRinse1Temperature = ThermostatLogs_.TC12;
            var PostHotRinse2Temperature = ThermostatLogs_.TC13;


            var WashMachineTemperature = WashDeviceLog_.Temperature;
            var WashMachineLineSpeed = WashDeviceLog_.Speed;
            var WashMachine1OverFlow = Modbus33Log_.Water11;
            var WashMachine2OverFlow = Modbus33Log_.Water12;
            var WashMachine3OverFlow = Modbus33Log_.Water13;

            var WashMachineWaterRinseTankPressure1 = Modbus33Log_.Rinse1;
            var WashMachineWaterRinseTankPressure2 = Modbus33Log_.Rinse2;
            var WashMachineWaterRinseTankPressure3 = Modbus33Log_.Rinse3;
            var WashMachineWaterRinseTankPressure4 = Modbus33Log_.Rinse4;
            var WashMachineWaterRinseTankPressure5 = Modbus33Log_.Rinse5;
            var WashMachineWaterRinseTankPressure6 = Modbus33Log_.Rinse6;
            var WashMachineWaterRinseTankPressure7 = Modbus33Log_.Rinse7;
            var WashMachineWaterRinseTankPressure8 = Modbus33Log_.Rinse8;
            var WashMachineWaterRinseTankPressure9 = Modbus33Log_.Rinse9;
            var WashMachineWaterRinseTankPressure10 = Modbus33Log_.Rinse10;
            var WashMachineWaterRinseTankPressure11 = Modbus33Log_.Rinse11;
            var WashMachineWaterRinseTankPressure12 = Modbus33Log_.Rinse12;
            var WashMachineWaterRinseTankPressure13 = Modbus33Log_.Rinse13;

            var WashMachineAirFlow1 = Modbus33Log_.Rinse_Flow1;
            var WashMachineAirFlow2 = Modbus33Log_.Rinse_Flow2;
            var WashMachineAirFlow3 = Modbus33Log_.Rinse_Flow3;
            var WashMachineAirFlow4 = Modbus33Log_.Rinse_Flow4;

            var WashMachineConductance = Modbus33Log_.Rinse_EC;

            var RinseTank3OverFlowAmount = Modbus31Log_.Water1;
            var RinseTank4OverFlowAmount = Modbus31Log_.Water2;
            var RinseTank7OverFlowAmount = Modbus31Log_.Water3;
            var RinseTank9OverFlowAmount = Modbus31Log_.Water4;
            var RinseTank12OverFlowAmount = Modbus32Log_.Water6;
            var RinseTank15OverFlowAmount = Modbus32Log_.Water7;
            var RinseTank17OverFlowAmount = Modbus32Log_.Water8;
            var RinseTank20OverFlowAmount = -99;
            var RinseTank22OverFlowAmount = Modbus32Log_.Water9;
            var RinseTank25OverFlowAmount = Modbus32Log_.Water10;
            var BlowerPressure = Modbus31Log_.Blower;

            string EDCValue = String.Format("<RECORD> <DB_NAME> ASEE_EDC</DB_NAME> <Mach_Facility>ASEE1</Mach_Facility> <Mach_Oper></Mach_Oper> <Mach_ID></Mach_ID> <EQP_Name>M0000802</EQP_Name> <Evt_Name></Evt_Name> <LOT_ID></LOT_ID> <DETAIL> <ROW> <SVID_NAME>PreHotRinse1Temperature</SVID_NAME> <SVID_VALUE>{00}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>PreHotRinse2Temperature</SVID_NAME> <SVID_VALUE>{01}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>CleanPressure</SVID_NAME> <SVID_VALUE>{02}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>CleanTemperature</SVID_NAME> <SVID_VALUE>{03}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>MicroetchingTemperature</SVID_NAME> <SVID_VALUE>{04}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>MicroetchingPressure</SVID_NAME> <SVID_VALUE>{05}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Acid1Pressure</SVID_NAME> <SVID_VALUE>{06}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel1Temperature</SVID_NAME> <SVID_VALUE>{07}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel1Pressure1</SVID_NAME> <SVID_VALUE>{08}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel1Pressure2</SVID_NAME> <SVID_VALUE>{09}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel1Pressure3</SVID_NAME> <SVID_VALUE>{10}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel1AirFlow1_1</SVID_NAME> <SVID_VALUE>{11}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel1AirFlow1_2</SVID_NAME> <SVID_VALUE>{12}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel1AirFlow1_3</SVID_NAME> <SVID_VALUE>{13}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel1AirFlow1_4</SVID_NAME> <SVID_VALUE>{14}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel1AirFlow1_5</SVID_NAME> <SVID_VALUE>{15}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel1AirFlow1_6</SVID_NAME> <SVID_VALUE>{16}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel2Temperature</SVID_NAME> <SVID_VALUE>{17}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel2Pressure1</SVID_NAME> <SVID_VALUE>{18}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel2Pressure2</SVID_NAME> <SVID_VALUE>{19}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel2Pressure3</SVID_NAME> <SVID_VALUE>{20}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel2AirFlow2_1</SVID_NAME> <SVID_VALUE>{21}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel2AirFlow2_2</SVID_NAME> <SVID_VALUE>{22}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel2AirFlow2_3</SVID_NAME> <SVID_VALUE>{23}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel2AirFlow2_4</SVID_NAME> <SVID_VALUE>{24}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel2AirFlow2_5</SVID_NAME> <SVID_VALUE>{25}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel2AirFlow2_6</SVID_NAME> <SVID_VALUE>{26}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel3Temperature</SVID_NAME> <SVID_VALUE>{27}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel3Pressure1</SVID_NAME> <SVID_VALUE>{28}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel3Pressure2</SVID_NAME> <SVID_VALUE>{29}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel3Pressure3</SVID_NAME> <SVID_VALUE>{30}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel3AirFlow3_1</SVID_NAME> <SVID_VALUE>{31}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel3AirFlow3_2</SVID_NAME> <SVID_VALUE>{32}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel3AirFlow3_3</SVID_NAME> <SVID_VALUE>{33}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel3AirFlow3_4</SVID_NAME> <SVID_VALUE>{34}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel3AirFlow3_5</SVID_NAME> <SVID_VALUE>{35}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel3AirFlow3_6</SVID_NAME> <SVID_VALUE>{36}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel4Temperature</SVID_NAME> <SVID_VALUE>{37}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel4Pressure1</SVID_NAME> <SVID_VALUE>{38}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel4Pressure2</SVID_NAME> <SVID_VALUE>{39}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel4Pressure3</SVID_NAME> <SVID_VALUE>{40}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel4AirFlow4_1</SVID_NAME> <SVID_VALUE>{41}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel4AirFlow4_2</SVID_NAME> <SVID_VALUE>{42}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel4AirFlow4_3</SVID_NAME> <SVID_VALUE>{43}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel4AirFlow4_4</SVID_NAME> <SVID_VALUE>{44}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel4AirFlow4_5</SVID_NAME> <SVID_VALUE>{45}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>Nickel4AirFlow4_6</SVID_NAME> <SVID_VALUE>{46}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>StrikeAuTemperature</SVID_NAME> <SVID_VALUE>{47}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>StrikeAuPressure</SVID_NAME> <SVID_VALUE>{48}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>StrikeAu1Temperature</SVID_NAME> <SVID_VALUE>{49}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>StrikeAu1Pressure</SVID_NAME> <SVID_VALUE>{50}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>StrikeAu2Temperature</SVID_NAME> <SVID_VALUE>{51}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>StrikeAu2Pressure</SVID_NAME> <SVID_VALUE>{52}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>PostHotRinse1Temperature</SVID_NAME> <SVID_VALUE>{53}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>PostHotRinse2Temperature</SVID_NAME> <SVID_VALUE>{54}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>WashMachineTemperature</SVID_NAME> <SVID_VALUE>{55}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>WashMachineLineSpeed</SVID_NAME> <SVID_VALUE>{56}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>WashMachine1OverFlow</SVID_NAME> <SVID_VALUE>{57}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>WashMachine2OverFlow</SVID_NAME> <SVID_VALUE>{58}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>WashMachine3OverFlow</SVID_NAME> <SVID_VALUE>{59}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>WashMachineWaterRinseTankPressure1</SVID_NAME> <SVID_VALUE>{60}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>WashMachineWaterRinseTankPressure2</SVID_NAME> <SVID_VALUE>{61}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>WashMachineWaterRinseTankPressure3</SVID_NAME> <SVID_VALUE>{62}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>WashMachineWaterRinseTankPressure4</SVID_NAME> <SVID_VALUE>{63}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>WashMachineWaterRinseTankPressure5</SVID_NAME> <SVID_VALUE>{64}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>WashMachineWaterRinseTankPressure6</SVID_NAME> <SVID_VALUE>{65}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>WashMachineWaterRinseTankPressure7</SVID_NAME> <SVID_VALUE>{66}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>WashMachineWaterRinseTankPressure8</SVID_NAME> <SVID_VALUE>{67}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>WashMachineWaterRinseTankPressure9</SVID_NAME> <SVID_VALUE>{68}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>WashMachineWaterRinseTankPressure10</SVID_NAME> <SVID_VALUE>{69}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>WashMachineWaterRinseTankPressure11</SVID_NAME> <SVID_VALUE>{70}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>WashMachineWaterRinseTankPressure12</SVID_NAME> <SVID_VALUE>{71}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>WashMachineWaterRinseTankPressure13</SVID_NAME> <SVID_VALUE>{72}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>WashMachineAirFlow1</SVID_NAME> <SVID_VALUE>{73}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>WashMachineAirFlow2</SVID_NAME> <SVID_VALUE>{74}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>WashMachineAirFlow3</SVID_NAME> <SVID_VALUE>{75}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>WashMachineAirFlow4</SVID_NAME> <SVID_VALUE>{76}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>WashMachineConductance</SVID_NAME> <SVID_VALUE>{77}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>RinseTank3OverFlowAmount</SVID_NAME> <SVID_VALUE>{78}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>RinseTank4OverFlowAmount</SVID_NAME> <SVID_VALUE>{79}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>RinseTank7OverFlowAmount</SVID_NAME> <SVID_VALUE>{80}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>RinseTank9OverFlowAmount</SVID_NAME> <SVID_VALUE>{81}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>RinseTank12OverFlowAmount</SVID_NAME> <SVID_VALUE>{82}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>RinseTank15OverFlowAmount</SVID_NAME> <SVID_VALUE>{83}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>RinseTank17OverFlowAmount</SVID_NAME> <SVID_VALUE>{84}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>RinseTank20OverFlowAmount</SVID_NAME> <SVID_VALUE>{85}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>RinseTank22OverFlowAmount</SVID_NAME> <SVID_VALUE>{86}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>RinseTank25OverFlowAmount</SVID_NAME> <SVID_VALUE>{87}</SVID_VALUE> </ROW> <ROW> <SVID_NAME>BlowerPressure</SVID_NAME> <SVID_VALUE>{88}</SVID_VALUE> </ROW> </DETAIL> </RECORD>",
            PreHotRinse_1_Temp,
            PreHotRinse_2_Temp,
            CleanPressure,
            CleanTemp,
            MicrTemp,
            MicrPressure,
            Acid1Pressure,
            Nickel1Temperature,
            Nickel1Pressure1,
            Nickel1Pressure2,

            Nickel1Pressure3,
            Nickel1AirFlow1_1,
            Nickel1AirFlow1_2,
            Nickel1AirFlow1_3,
            Nickel1AirFlow1_4,
            Nickel1AirFlow1_5,
            Nickel1AirFlow1_6,
            Nickel2Temperature,
            Nickel2Pressure1,
            Nickel2Pressure2,

            Nickel2Pressure3,
            Nickel2AirFlow2_1,
            Nickel2AirFlow2_2,
            Nickel2AirFlow2_3,
            Nickel2AirFlow2_4,
            Nickel2AirFlow2_5,
            Nickel2AirFlow2_6,
            Nickel3Temperature,
            Nickel3Pressure1,
            Nickel3Pressure2,

            Nickel3Pressure3,
            Nickel3AirFlow3_1,
            Nickel3AirFlow3_2,
            Nickel3AirFlow3_3,
            Nickel3AirFlow3_4,
            Nickel3AirFlow3_5,
            Nickel3AirFlow3_6,
            Nickel4Temperature,
            Nickel4Pressure1,
            Nickel4Pressure2,

            Nickel4Pressure3,
            Nickel4AirFlow4_1,
            Nickel4AirFlow4_2,
            Nickel4AirFlow4_3,
            Nickel4AirFlow4_4,
            Nickel4AirFlow4_5,
            Nickel4AirFlow4_6,
            StrikeAuTemperature,
            StrikeAuPressure,
            StrikeAu1Temperature,

            StrikeAu1Pressure,
            StrikeAu2Temperature,
            StrikeAu2Pressure,
            PostHotRinse1Temperature,
            PostHotRinse2Temperature,
            WashMachineTemperature,
            WashMachineLineSpeed,
            WashMachine1OverFlow,
            WashMachine2OverFlow,
            WashMachine3OverFlow,

            WashMachineWaterRinseTankPressure1,
            WashMachineWaterRinseTankPressure2,
            WashMachineWaterRinseTankPressure3,
            WashMachineWaterRinseTankPressure4,
            WashMachineWaterRinseTankPressure5,
            WashMachineWaterRinseTankPressure6,
            WashMachineWaterRinseTankPressure7,
            WashMachineWaterRinseTankPressure8,
            WashMachineWaterRinseTankPressure9,
            WashMachineWaterRinseTankPressure10,

            WashMachineWaterRinseTankPressure11,
            WashMachineWaterRinseTankPressure12,
            WashMachineWaterRinseTankPressure13,
            WashMachineAirFlow1,
            WashMachineAirFlow2,
            WashMachineAirFlow3,
            WashMachineAirFlow4,
            WashMachineConductance,
            RinseTank3OverFlowAmount,
            RinseTank4OverFlowAmount,

            RinseTank7OverFlowAmount,
            RinseTank9OverFlowAmount,
            RinseTank12OverFlowAmount,
            RinseTank15OverFlowAmount,
            RinseTank17OverFlowAmount,
            RinseTank20OverFlowAmount,
            RinseTank22OverFlowAmount,
            RinseTank25OverFlowAmount,
            BlowerPressure);


            return EDCValue;
        }

        public string CreateADCxml(
            ThermostatLogDTO ThermostatLogs_,
            Modbus31LogDTO Modbus31LogDTO_,
            Modbus32LogDTO Modbus32LogDTO_,
            Modbus33LogDTO Modbus33LogDTO_,
            WashDeviceLogDTO WashDeviceLogDTO_
            )
        {
            var Ni_plated_WB = 0;
            var Ni_plated_B = 0;
            var Au_strike_A = 0;
            var Au_plated_WB = 0;
            var Au_plated_B = 0;

            var PreHotRinse_1_Temp = ThermostatLogs_.TC02;
            var PreHotRinse_2_Temp = ThermostatLogs_.TC03;
            var CleanPressure = Modbus31LogDTO_.Clean;
            var CleanTemp = ThermostatLogs_.TC01;
            var MicrTemp = ThermostatLogs_.TC04;
            var MicrPressure = Modbus31LogDTO_.Microerching;
            var Acid1Pressure = Modbus31LogDTO_.ACID1;

            var Nickel1Temperature = ThermostatLogs_.TC05;
            var Nickel1Pressure1 = Modbus31LogDTO_.Nickel1_1;
            var Nickel1Pressure2 = Modbus31LogDTO_.Nickel1_2;
            var Nickel1Pressure3 = Modbus31LogDTO_.Nickel1_3;
            var Nickel1AirFlow1_1 = Modbus31LogDTO_.Nickel1_Air_1;
            var Nickel1AirFlow1_2 = Modbus31LogDTO_.Nickel1_Air_2;
            var Nickel1AirFlow1_3 = Modbus31LogDTO_.Nickel1_Air_3;
            var Nickel1AirFlow1_4 = Modbus31LogDTO_.Nickel1_Air_4;
            var Nickel1AirFlow1_5 = Modbus31LogDTO_.Nickel1_Air_5;
            var Nickel1AirFlow1_6 = Modbus31LogDTO_.Nickel1_Air_6;

            var Nickel2Temperature = ThermostatLogs_.TC06;
            var Nickel2Pressure1 = Modbus31LogDTO_.Nickel2_1;
            var Nickel2Pressure2 = Modbus31LogDTO_.Nickel2_2;
            var Nickel2Pressure3 = Modbus31LogDTO_.Nickel2_3;
            var Nickel2AirFlow2_1 = Modbus31LogDTO_.Nickel2_Air_1;
            var Nickel2AirFlow2_2 = Modbus31LogDTO_.Nickel2_Air_2;
            var Nickel2AirFlow2_3 = Modbus31LogDTO_.Nickel2_Air_3;
            var Nickel2AirFlow2_4 = Modbus31LogDTO_.Nickel2_Air_4;
            var Nickel2AirFlow2_5 = Modbus31LogDTO_.Nickel2_Air_5;
            var Nickel2AirFlow2_6 = Modbus31LogDTO_.Nickel2_Air_6;

            var Nickel3Temperature = ThermostatLogs_.TC07;
            var Nickel3Pressure1 = Modbus32LogDTO_.Nickel3_1;
            var Nickel3Pressure2 = Modbus32LogDTO_.Nickel3_1;
            var Nickel3Pressure3 = Modbus32LogDTO_.Nickel3_1;
            var Nickel3AirFlow3_1 = Modbus32LogDTO_.Nickel3_Air_1;
            var Nickel3AirFlow3_2 = Modbus32LogDTO_.Nickel3_Air_2;
            var Nickel3AirFlow3_3 = Modbus32LogDTO_.Nickel3_Air_3;
            var Nickel3AirFlow3_4 = Modbus32LogDTO_.Nickel3_Air_4;
            var Nickel3AirFlow3_5 = Modbus32LogDTO_.Nickel3_Air_5;
            var Nickel3AirFlow3_6 = Modbus32LogDTO_.Nickel3_Air_6;

            var Nickel4Temperature = ThermostatLogs_.TC08;
            var Nickel4Pressure1 = Modbus32LogDTO_.Nickel4_1;
            var Nickel4Pressure2 = Modbus32LogDTO_.Nickel4_2;
            var Nickel4Pressure3 = Modbus32LogDTO_.Nickel4_3;
            var Nickel4AirFlow4_1 = Modbus32LogDTO_.Nickel4_Air_1;
            var Nickel4AirFlow4_2 = Modbus32LogDTO_.Nickel4_Air_2;
            var Nickel4AirFlow4_3 = Modbus32LogDTO_.Nickel4_Air_3;
            var Nickel4AirFlow4_4 = Modbus32LogDTO_.Nickel4_Air_4;
            var Nickel4AirFlow4_5 = Modbus32LogDTO_.Nickel4_Air_5;
            var Nickel4AirFlow4_6 = Modbus32LogDTO_.Nickel4_Air_6;

            var StrikeAuTemperature = ThermostatLogs_.TC09;
            var StrikeAuPressure = Modbus32LogDTO_.Au_Strike;
            var StrikeAu1Temperature = ThermostatLogs_.TC10;
            var StrikeAu1Pressure = Modbus32LogDTO_.Au_1;
            var StrikeAu2Temperature = ThermostatLogs_.TC11;
            var StrikeAu2Pressure = Modbus32LogDTO_.Au_2;

            var PostHotRinse1Temperature = ThermostatLogs_.TC10;
            var PostHotRinse2Temperature = ThermostatLogs_.TC11;

            var PlatedAreaTop = 0;
            var PlatedAreaBottom = 0;

            var WashMachineTemperature = WashDeviceLogDTO_.Temperature;
            var WashMachineLineSpeed = WashDeviceLogDTO_.Speed;
            var WashMachine1OverFlow = Modbus33LogDTO_.Water11;
            var WashMachine2OverFlow = Modbus33LogDTO_.Water12;
            var WashMachine3OverFlow = Modbus33LogDTO_.Water13;

            var WashMachineWaterRinseTankPressure1 = Modbus33LogDTO_.Rinse1;
            var WashMachineWaterRinseTankPressure2 = Modbus33LogDTO_.Rinse2;
            var WashMachineWaterRinseTankPressure3 = Modbus33LogDTO_.Rinse3;
            var WashMachineWaterRinseTankPressure4 = Modbus33LogDTO_.Rinse4;
            var WashMachineWaterRinseTankPressure5 = Modbus33LogDTO_.Rinse5;
            var WashMachineWaterRinseTankPressure6 = Modbus33LogDTO_.Rinse6;
            var WashMachineWaterRinseTankPressure7 = Modbus33LogDTO_.Rinse7;
            var WashMachineWaterRinseTankPressure8 = Modbus33LogDTO_.Rinse8;
            var WashMachineWaterRinseTankPressure9 = Modbus33LogDTO_.Rinse9;
            var WashMachineWaterRinseTankPressure10 = Modbus33LogDTO_.Rinse10;
            var WashMachineWaterRinseTankPressure11 = Modbus33LogDTO_.Rinse11;
            var WashMachineWaterRinseTankPressure12 = Modbus33LogDTO_.Rinse12;
            var WashMachineWaterRinseTankPressure13 = Modbus33LogDTO_.Rinse13;

            var WashMachineAirFlow1 = Modbus33LogDTO_.Rinse_Flow1;
            var WashMachineAirFlow2 = Modbus33LogDTO_.Rinse_Flow2;
            var WashMachineAirFlow3 = Modbus33LogDTO_.Rinse_Flow3;
            var WashMachineAirFlow4 = Modbus33LogDTO_.Rinse_Flow4;

            var WashMachineConductance = Modbus33LogDTO_.Rinse_EC;

            var RinseTank3OverFlowAmount = Modbus31LogDTO_.Water1;
            var RinseTank4OverFlowAmount = Modbus31LogDTO_.Water2;
            var RinseTank7OverFlowAmount = Modbus31LogDTO_.Water3;
            var RinseTank9OverFlowAmount = Modbus31LogDTO_.Water4;
            var RinseTank12OverFlowAmount = Modbus32LogDTO_.Water6;
            var RinseTank15OverFlowAmount = Modbus32LogDTO_.Water7;
            var RinseTank17OverFlowAmount = Modbus32LogDTO_.Water8;
            var RinseTank20OverFlowAmount = 0;
            var RinseTank22OverFlowAmount = Modbus32LogDTO_.Water9;
            var RinseTank25OverFlowAmount = Modbus32LogDTO_.Water10;
            var BlowerPressure = Modbus31LogDTO_.Blower;


            var ADCValue = String.Format(
                "<RECORD><DB_NAME>9723_01</DB_NAME><Mach_Facility>ASEE1</Mach_Facility><Mach_Oper>9723</Mach_Oper><Mach_ID>9723-A040-0002</Mach_ID><EQP_Name>M0000802</EQP_Name><Evt_Name></Evt_Name><Lot_ID>L123456789</Lot_ID><DETAIL><ROW><Ni_plated_WB>{00}</Ni_plated_WB><Ni_plated_B>{01}</Ni_plated_B><Au_strike_A>{02}</Au_strike_A><Au_plated_WB>{03}</Au_plated_WB><Au_plated_B>{04}</Au_plated_B><Pre_Hot_rinse_1_Temperature>{05}</Pre_Hot_rinse_1_Temperature><Pre_Hot_rinse_2_Temperature>{06}</Pre_Hot_rinse_2_Temperature><Clean_Pressure>{07}</Clean_Pressure><Clean_Temperature>{08}</Clean_Temperature><Microetching_Temperature>{09}</Microetching_Temperature><Microetching_Pressure>{10}</Microetching_Pressure><Acid_1_Pressure>{11}</Acid_1_Pressure><Nickel_1_Temperature>{12}</Nickel_1_Temperature><Nickel_1_Pressure_1>{13}</Nickel_1_Pressure_1><Nickel_1_Pressure_2>{14}</Nickel_1_Pressure_2><Nickel_1_Pressure_3>{15}</Nickel_1_Pressure_3><Nickel_1_Air_flow_1_1>{16}</Nickel_1_Air_flow_1_1><Nickel_1_Air_flow_1_2>{17}</Nickel_1_Air_flow_1_2><Nickel_1_Air_flow_1_3>{18}</Nickel_1_Air_flow_1_3><Nickel_1_Air_flow_1_4>{19}</Nickel_1_Air_flow_1_4><Nickel_1_Air_flow_1_5>{20}</Nickel_1_Air_flow_1_5><Nickel_1_Air_flow_1_6>{21}</Nickel_1_Air_flow_1_6><Nickel_2_Temperature>{22}</Nickel_2_Temperature><Nickel_2_Pressure_1>{23}</Nickel_2_Pressure_1><Nickel_2_Pressure_2>{24}</Nickel_2_Pressure_2><Nickel_2_Pressure_3>{25}</Nickel_2_Pressure_3><Nickel_2_Air_flow_2_1>{26}</Nickel_2_Air_flow_2_1><Nickel_2_Air_flow_2_2>{27}</Nickel_2_Air_flow_2_2><Nickel_2_Air_flow_2_3>{28}</Nickel_2_Air_flow_2_3><Nickel_2_Air_flow_2_4>{29}</Nickel_2_Air_flow_2_4><Nickel_2_Air_flow_2_5>{30}</Nickel_2_Air_flow_2_5><Nickel_2_Air_flow_2_6>{31}</Nickel_2_Air_flow_2_6><Nickel_3_Temperature>{32}</Nickel_3_Temperature><Nickel_3_Pressure_1>{33}</Nickel_3_Pressure_1><Nickel_3_Pressure_2>{34}</Nickel_3_Pressure_2><Nickel_3_Pressure_3>{35}</Nickel_3_Pressure_3><Nickel_3_Air_flow_3_1>{36}</Nickel_3_Air_flow_3_1><Nickel_3_Air_flow_3_2>{37}</Nickel_3_Air_flow_3_2><Nickel_3_Air_flow_3_3>{38}</Nickel_3_Air_flow_3_3><Nickel_3_Air_flow_3_4>{39}</Nickel_3_Air_flow_3_4><Nickel_3_Air_flow_3_5>{40}</Nickel_3_Air_flow_3_5><Nickel_3_Air_flow_3_6>{41}</Nickel_3_Air_flow_3_6><Nickel_4_Temperature>{42}</Nickel_4_Temperature><Nickel_4_Pressure_1>{43}</Nickel_4_Pressure_1><Nickel_4_Pressure_2>{44}</Nickel_4_Pressure_2><Nickel_4_Pressure_3>{45}</Nickel_4_Pressure_3><Nickel_4_Air_flow_4_1>{46}</Nickel_4_Air_flow_4_1><Nickel_4_Air_flow_4_2>{47}</Nickel_4_Air_flow_4_2><Nickel_4_Air_flow_4_3>{48}</Nickel_4_Air_flow_4_3><Nickel_4_Air_flow_4_4>{49}</Nickel_4_Air_flow_4_4><Nickel_4_Air_flow_4_5>{50}</Nickel_4_Air_flow_4_5><Nickel_4_Air_flow_4_6>{51}</Nickel_4_Air_flow_4_6><Strike_Au_Temperature>{52}</Strike_Au_Temperature><Strike_Au_Pressure>{53}</Strike_Au_Pressure><Au_1_Temperature>{54}</Au_1_Temperature><Au_1_Pressure>{55}</Au_1_Pressure><Au_2_Temperature>{56}</Au_2_Temperature><Au_2_Pressure>{57}</Au_2_Pressure><Post_Hot_rinse_1_Temperature>{58}</Post_Hot_rinse_1_Temperature><Post_Hot_rinse_2_Temperature>{59}</Post_Hot_rinse_2_Temperature><Plated_areaTop>{60}</Plated_areaTop><Plated_areaBottom>{61}</Plated_areaBottom><Water_Rinse_Temperature>{62}</Water_Rinse_Temperature><Water_Rinse_Speed>{63}</Water_Rinse_Speed><Water_Rinse_Flow_1>{64}</Water_Rinse_Flow_1><Water_Rinse_Flow_2>{65}</Water_Rinse_Flow_2><Water_Rinse_Flow_3>{66}</Water_Rinse_Flow_3><Water_Rinse_Tank_Pressure_1>{67}</Water_Rinse_Tank_Pressure_1><Water_Rinse_Tank_Pressure_2>{68}</Water_Rinse_Tank_Pressure_2><Water_Rinse_Tank_Pressure_3>{69}</Water_Rinse_Tank_Pressure_3><Water_Rinse_Tank_Pressure_4>{70}</Water_Rinse_Tank_Pressure_4><Water_Rinse_Tank_Pressure_5>{71}</Water_Rinse_Tank_Pressure_5><Water_Rinse_Tank_Pressure_6>{72}</Water_Rinse_Tank_Pressure_6><Water_Rinse_Tank_Pressure_7>{73}</Water_Rinse_Tank_Pressure_7><Water_Rinse_Tank_Pressure_8>{74}</Water_Rinse_Tank_Pressure_8><Water_Rinse_Tank_Pressure_9>{75}</Water_Rinse_Tank_Pressure_9><Water_Rinse_Tank_Pressure_10>{76}</Water_Rinse_Tank_Pressure_10><Water_Rinse_Tank_Pressure_11>{77}</Water_Rinse_Tank_Pressure_11><Water_Rinse_Tank_Pressure_12>{78}</Water_Rinse_Tank_Pressure_12><Water_Rinse_Tank_Pressure_13>{79}</Water_Rinse_Tank_Pressure_13><Water_Rinse_Blow_1>{80}</Water_Rinse_Blow_1><Water_Rinse_Blow_2>{81}</Water_Rinse_Blow_2><Water_Rinse_Blow_3>{82}</Water_Rinse_Blow_3><Water_Rinse_Blow_4>{83}</Water_Rinse_Blow_4><Water_Rinse_ConductivitySV>{84}</Water_Rinse_ConductivitySV><Water_Rinse_Tank_3_Flow>{85}</Water_Rinse_Tank_3_Flow><Water_Rinse_Tank_4_Flow>{86}</Water_Rinse_Tank_4_Flow><Water_Rinse_Tank_7_Flow>{87}</Water_Rinse_Tank_7_Flow><Water_Rinse_Tank_9_Flow>{88}</Water_Rinse_Tank_9_Flow><Water_Rinse_Tank_12_Flow>{89}</Water_Rinse_Tank_12_Flow><Water_Rinse_Tank_15_Flow>{90}</Water_Rinse_Tank_15_Flow><Water_Rinse_Tank_17_Flow>{91}</Water_Rinse_Tank_17_Flow><Water_Rinse_Tank_20_Flow>{92}</Water_Rinse_Tank_20_Flow><Water_Rinse_Tank_22_Flow>{93}</Water_Rinse_Tank_22_Flow><Water_Rinse_Tank_25_Flow>{94}</Water_Rinse_Tank_25_Flow><Wind_Blow_Pressure>{95}</Wind_Blow_Pressure></ROW></DETAIL></RECORD>",           
            Ni_plated_WB,
            Ni_plated_B,
            Au_strike_A,
            Au_plated_WB,
            Au_plated_B,
            PreHotRinse_1_Temp,
            PreHotRinse_2_Temp,
            CleanPressure,
            CleanTemp,   
            MicrTemp,

            MicrPressure,
            Acid1Pressure,
            Nickel1Temperature,
            Nickel1Pressure1,
            Nickel1Pressure2,
            Nickel1Pressure3,
            Nickel1AirFlow1_1,
            Nickel1AirFlow1_2,      
            Nickel1AirFlow1_3,
            Nickel1AirFlow1_4,

            Nickel1AirFlow1_5,
            Nickel1AirFlow1_6,
            Nickel2Temperature,
            Nickel2Pressure1,
            Nickel2Pressure2,
            Nickel2Pressure3,
            Nickel2AirFlow2_1,
            Nickel2AirFlow2_2,
            Nickel2AirFlow2_3,
            Nickel2AirFlow2_4,

            Nickel2AirFlow2_5,
            Nickel2AirFlow2_6,
            Nickel3Temperature,
            Nickel3Pressure1,
            Nickel3Pressure2,
            Nickel3Pressure3,
            Nickel3AirFlow3_1,
            Nickel3AirFlow3_2,
            Nickel3AirFlow3_3,
            Nickel3AirFlow3_4,

            Nickel3AirFlow3_5,
            Nickel3AirFlow3_6,
            Nickel4Temperature,
            Nickel4Pressure1,
            Nickel4Pressure2,
            Nickel4Pressure3,
            Nickel4AirFlow4_1,
            Nickel4AirFlow4_2,
            Nickel4AirFlow4_3,
            Nickel4AirFlow4_4,

            Nickel4AirFlow4_5,
            Nickel4AirFlow4_6,
            StrikeAuTemperature,
            StrikeAuPressure,
            StrikeAu1Temperature,
            StrikeAu1Pressure,
            StrikeAu2Temperature,
            StrikeAu2Pressure,
            PostHotRinse1Temperature,
            PostHotRinse2Temperature,

            PlatedAreaTop,
            PlatedAreaBottom,
            WashMachineTemperature,
            WashMachineLineSpeed,
            WashMachine1OverFlow,
            WashMachine2OverFlow,
            WashMachine3OverFlow,
            WashMachineWaterRinseTankPressure1,
            WashMachineWaterRinseTankPressure2,
            WashMachineWaterRinseTankPressure3,

            WashMachineWaterRinseTankPressure4,
            WashMachineWaterRinseTankPressure5,
            WashMachineWaterRinseTankPressure6,
            WashMachineWaterRinseTankPressure7,
            WashMachineWaterRinseTankPressure8,
            WashMachineWaterRinseTankPressure9,
            WashMachineWaterRinseTankPressure10,
            WashMachineWaterRinseTankPressure11,
            WashMachineWaterRinseTankPressure12,
            WashMachineWaterRinseTankPressure13,

            WashMachineAirFlow1,
            WashMachineAirFlow2,
            WashMachineAirFlow3,
            WashMachineAirFlow4,
            WashMachineConductance,
            RinseTank3OverFlowAmount,
            RinseTank4OverFlowAmount,
            RinseTank7OverFlowAmount,
            RinseTank9OverFlowAmount,
            RinseTank12OverFlowAmount,

            RinseTank15OverFlowAmount,
            RinseTank17OverFlowAmount,
            RinseTank20OverFlowAmount,
            RinseTank22OverFlowAmount,
            RinseTank25OverFlowAmount,
            BlowerPressure

            );

            return ADCValue;
        }


    }
}

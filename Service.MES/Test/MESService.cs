using Common;
using Common.Attributes;
using Common.DTO;
using Common.Enums;
using Common.ExConfig;
using Newtonsoft.Json;
using Service.MES.ExObject;
using Service.MES.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Service.MES.Test
{
    public class MESService : IMESService
    {
        public bool IsConnect => true;

        public AE2TalkObject BasicAE2Talk => JsonConvert.DeserializeObject<AE2TalkObject>(SampleData.AE2TalkObjectValue);

        public ADCConfig NowADCConfig => DefaultConfig.ADCConfig;

        public string CreateADCxml(ThermostatLogDTO ThermostatLog_, Modbus31LogDTO APAX5070_31Log_, Modbus32LogDTO APAX5070_32Log_, Modbus33LogDTO APAX5070_33Log_, WashDeviceLogDTO WashDeviceLogDTO_)
        {
            return SampleData.ADCValue;
        }

        public string CreateEDCxml(ThermostatLogDTO ThermostatLog_, Modbus31LogDTO APAX5070_31Log_, Modbus32LogDTO APAX5070_32Log_, Modbus33LogDTO APAX5070_33Log_, WashDeviceLogDTO WashDeviceLogDTO_)
        {
            return SampleData.EDCValue;
        }

        public ActResult<AE2TalkObject> GetEndShelfMESObject(string RecipeName_)
        {
            var sampleObject = JsonConvert.DeserializeObject<AE2TalkObject>(SampleData.AE2TalkObjectValue);

            return new ActResult<AE2TalkObject>(sampleObject);
        }

        public ActResult<bool> GetIsSameRecipeName(string RecipeName_)
        {
            return new ActResult<bool>(Obj_: true);
        }

        public ActResult<AE2TalkObjectV2> GetMESObject(string LotNo_, string StaffID)
        {
            var sampleObject = JsonConvert.DeserializeObject<AE2TalkObjectV2>(SampleData.AE2TalkObjectV2Value);

            return new ActResult<AE2TalkObjectV2>(sampleObject);
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
                        if (realValue > NowADCConfig.HotRinse_1_Temp_MaxValue || realValue < NowADCConfig.HotRinse_1_Temp_MinValue)
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
                        if (realValue > NowADCConfig.Nickel1_1_MaxValue || realValue < NowADCConfig.Nickel1_1_MinValue)
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
                        if (realValue > NowADCConfig.Nickel4_Air_1_MaxValue || realValue < NowADCConfig.Nickel4_Air_1_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel4_Air_1_MaxValue, MinLimit = NowADCConfig.Nickel4_Air_1_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel4_Air_2):
                        realValue = APAX5070_32Log_.Nickel4_Air_2;
                        if (realValue > NowADCConfig.Nickel4_Air_2_MaxValue || realValue < NowADCConfig.Nickel4_Air_2_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel4_Air_2_MaxValue, MinLimit = NowADCConfig.Nickel4_Air_2_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel4_Air_3):
                        realValue = APAX5070_32Log_.Nickel4_Air_3;
                        if (realValue > NowADCConfig.Nickel4_Air_3_MaxValue || realValue < NowADCConfig.Nickel4_Air_3_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel4_Air_3_MaxValue, MinLimit = NowADCConfig.Nickel4_Air_3_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel4_Air_4):
                        realValue = APAX5070_32Log_.Nickel4_Air_4;
                        if (realValue > NowADCConfig.Nickel4_Air_4_MaxValue || realValue < NowADCConfig.Nickel4_Air_4_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel4_Air_4_MaxValue, MinLimit = NowADCConfig.Nickel4_Air_4_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel4_Air_5):
                        realValue = APAX5070_32Log_.Nickel4_Air_5;
                        if (realValue > NowADCConfig.Nickel4_Air_5_MaxValue || realValue < NowADCConfig.Nickel4_Air_5_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel4_Air_5_MaxValue, MinLimit = NowADCConfig.Nickel4_Air_5_MinValue, RealValue = realValue }); ;
                            isfail = true;
                        }
                        break;
                    case nameof(CheckItemObject_.Nickel4_Air_6):
                        realValue = APAX5070_32Log_.Nickel4_Air_6;
                        if (realValue > NowADCConfig.Nickel4_Air_6_MaxValue || realValue < NowADCConfig.Nickel4_Air_6_MinValue)
                        {
                            alarmMsgs.Add(new AlarmMsgDTO() { Name = item.Name, MaxLimit = NowADCConfig.Nickel4_Air_6_MaxValue, MinLimit = NowADCConfig.Nickel4_Air_6_MinValue, RealValue = realValue }); ;
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
                if (APAX5070_33Log_.Rinse9 < NowADCConfig.Rinse09_MinValue || APAX5070_33Log_.Rinse9 > NowADCConfig.Rinse09_MaxValue)
                {
                    alarmMsgs.Add(new AlarmMsgDTO() { Name = dicProperties[nameof(CheckItemObject.Rinse9)].GetCustomAttribute<DisplayAttribute>().ZHTW, MaxLimit = NowADCConfig.Rinse09_MaxValue, MinLimit = NowADCConfig.Rinse09_MinValue, RealValue = APAX5070_33Log_.Rinse9 }); ;
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
                if (APAX5070_33Log_.Rinse_Flow1 < NowADCConfig.Rinse_Flow1_MinValue || APAX5070_33Log_.Rinse_Flow1 > NowADCConfig.Rinse_Flow1_MaxValue)
                {
                    alarmMsgs.Add(new AlarmMsgDTO() { Name = dicProperties[nameof(CheckItemObject.Rinse_Flow1)].GetCustomAttribute<DisplayAttribute>().ZHTW, MaxLimit = NowADCConfig.Rinse_Flow1_MaxValue, MinLimit = NowADCConfig.Rinse_Flow1_MinValue, RealValue = APAX5070_33Log_.Rinse_Flow1 }); ;
                    isfail = true;
                }
            }
            if (CheckItemObject_.Rinse_Flow2)
            {
                if (APAX5070_33Log_.Rinse_Flow2 < NowADCConfig.Rinse_Flow2_MinValue || APAX5070_33Log_.Rinse_Flow2 > NowADCConfig.Rinse_Flow2_MaxValue)
                {
                    alarmMsgs.Add(new AlarmMsgDTO() { Name = dicProperties[nameof(CheckItemObject.Rinse_Flow2)].GetCustomAttribute<DisplayAttribute>().ZHTW, MaxLimit = NowADCConfig.Rinse_Flow2_MaxValue, MinLimit = NowADCConfig.Rinse_Flow2_MinValue, RealValue = APAX5070_33Log_.Rinse_Flow2 }); ;
                    isfail = true;
                }
            }
            if (CheckItemObject_.Rinse_Flow3)
            {
                if (APAX5070_33Log_.Rinse_Flow3 < NowADCConfig.Rinse_Flow3_MinValue || APAX5070_33Log_.Rinse_Flow3 > NowADCConfig.Rinse_Flow3_MaxValue)
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


        public ActResult RecipeComparison(string LotCode_, string UserID_, AE2TalkObject AE2TalkObject_, RecipeDTO Recipe_)
        {
            return new ActResult(true);
        }

        public ActResult SendADCData(string EDCxml_)
        {
            return new ActResult(true);
        }

        public ActResult SendAlarmNotify(int AlarmCode_)
        {
            return new ActResult(true);
        }

        public ActResult SendAlarmNotify(string AlarmCode_)
        {
            return new ActResult(true);
        }

        public ActResult SendArmsAlarm(string LotNo_, string UID_, string RecipeName_, AlarmMsgDTO[] AlarmMsgs_)
        {
            return new ActResult(true);
        }

        public ActResult SendCreateEndshiftRecipeNotify(RecipeDTO Recipe_)
        {
            return new ActResult(true);
        }

        public ActResult SendCreateRecipeNotify(RecipeDTO Recipe_)
        {
            return new ActResult(true);
        }

        public ActResult SendEDCData(string EDCxml_)
        {
            return new ActResult(true);
        }

        public ActResult SetADCConfig(ADCConfig ADCConfig_)
        {
            throw new NotImplementedException();
        }

        public void StartListen(int Port_)
        {
            return;
        }

        public void StopListen()
        {
            return;
        }
    }
}

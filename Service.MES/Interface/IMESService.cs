using aE2talkComp;
using Common;
using Common.DTO;
using Common.Enums;
using Common.ExConfig;
using Common.Interface;
using Service.MES.Enums;
using Service.MES.ExObject;
using System.Collections.Generic;

namespace Service.MES.Interface
{
    public interface IMESService: IService
    {
        bool IsConnect { get; }
        AE2TalkObject BasicAE2Talk { get; }

        ActResult SetADCConfig(ADCConfig ADCConfig_);
        string CreateADCxml(ThermostatLogDTO ThermostatLog_, Modbus31LogDTO APAX5070_31Log_, Modbus32LogDTO APAX5070_32Log_, Modbus33LogDTO APAX5070_33Log_,WashDeviceLogDTO WashDeviceLog_);
        string CreateEDCxml(ThermostatLogDTO ThermostatLog_, Modbus31LogDTO APAX5070_31Log_, Modbus32LogDTO APAX5070_32Log_, Modbus33LogDTO APAX5070_33Log_, WashDeviceLogDTO WashDeviceLog_);
        
        ActResult<AE2TalkObject> GetEndShelfMESObject(string RecipeName_);
        ActResult<bool> GetIsSameRecipeName(string RecipeName_);
        ActResult<AE2TalkObjectV2> GetMESObject(string LotNo_, string StaffID);
        ActResult RecipeComparison(string LotCode_, string UserID_, AE2TalkObject AE2TalkObject_, RecipeDTO Recipe_, CheckItemObject CheckItemObject_, ThermostatLogDTO ThermostatLogs_, Modbus31LogDTO APAX5070_31Log_, Modbus32LogDTO APAX5070_32Log_);
        //ActResult RecipeComparison(string LotCode_, string UserID_, AE2TalkObject AE2TalkObject_, RecipeDTO Recipe_);
        ActResult<List<AlarmMsgDTO>> ParamterComparison(string LotCode_, string UserID_, CheckItemObject CheckItemObject_, ThermostatLogDTO ThermostatLogs_, Modbus31LogDTO APAX5070_31Log_, Modbus32LogDTO APAX5070_32Log_, Modbus33LogDTO APAX5070_33Log_, WashDeviceLogDTO WashDeviceLog_);
       
        ActResult SendADCData(string EDCxml_);
        ActResult SendArmsAlarm(string LotNo_, string UID_, string RecipeName_, AlarmMsgDTO[] AlarmMsgs_);
        
        ActResult SendAlarmNotify(int AlarmCode_);
        ActResult SendAlarmNotify(string AlarmCode_);
       
        ActResult SendCreateEndshiftRecipeNotify(RecipeDTO Recipe_);
        ActResult SendCreateRecipeNotify(RecipeDTO Recipe_);
        
        ActResult SendEDCData(string EDCxml_);

        void StartListen(int Port_);
        void StopListen();
    }
}
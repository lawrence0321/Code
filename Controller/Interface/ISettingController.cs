using Common;
using Common.DTO;
using Common.Enums;
using Common.ExConfig;
using Common.Interface;
using System.Collections.Generic;

namespace Controller.Interface
{
    public interface ISettingController : IController
    {
        ActResult<List<UserItemDTO>> GetUserItems();

        ActResult AddUser(string UID_, string Password_ );

        ActResult EditUser(string UID_, string Password_ );

        ActResult DeleteUser(string UID_);

        ActResult AddUserAuthority(UserItemDTO UserItemDTO_);

        ActResult EditUserAuthority(UserItemDTO UserItemDTO_);

        ActResult DeleteUserAuthority(string ID_);



        ActResult ConnectMES(int Port_);

        ActResult DisConnectMES();

        void CreateBasicIni(string IniFilePath_);

        ActResult<CheckItemObject> GetCheckItemValue(string IniPath_);

        ActResult SetCheckItemValue(string IniPath_, CheckItemObject CheckItem_);


        ActResult<CurrentConfig> GetCurrentConfigValue(string IniPath_);

        ActResult<ProcessConfig> GetProcessConfigValue(string IniPath_);

        ActResult<ConvertConfig> GetConvertConfigValue(string IniPath_);

        ActResult<ADCConfig> GetADCConfigValue(string IniPath_);

        ActResult<LoadDataConfig> GetLoadDataConfigValue(string IniPath_);
    }
}

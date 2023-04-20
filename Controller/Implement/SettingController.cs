using Common;
using Common.Attributes;
using Common.DTO;
using Common.Enums;
using Common.ExConfig;
using Controller.Interface;
using Service.DataBase.Interface;
using Service.MES.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Implement
{
    internal class SettingController : ISettingController
    {

        IUserService UserService => ControllerConfig.GetService<IUserService>();
        IMESService MESService => ControllerConfig.GetService<IMESService>();
        ISettingService SettingService => ControllerConfig.GetService<ISettingService>();

        ILoadController LoadController => AutofacConfig.Resolve<ILoadController>();
        public SettingController()
        {
        }

        public ActResult<List<UserItemDTO>> GetUserItems()
        {
            try
            {
                List<UserItemDTO> list = new List<UserItemDTO>();

                var ids = UserService.Gets();
                if (!ids.Result)
                    return new ActResult<List<UserItemDTO>>(new Exception(ids.Exception.Message));


                foreach (var id in ids.Value)
                {
                    var r1 = UserService.GetUserAuthority(id);

                    if (!r1.Result)
                        throw new Exception(r1.Exception.Message);
                    list.Add(r1.Value);
                }
                return new ActResult<List<UserItemDTO>>(list);
            }
            catch(Exception Ex)
            {
                return new ActResult<List<UserItemDTO>>(Ex);
            }
        }


        public ActResult AddUser(string UID_, string Password_ )
            => UserService.AddUser(UID_, Password_);
        public ActResult EditUser(string UID_, string Password_ )
            => UserService.EditUser(UID_, Password_);

        public ActResult DeleteUser(string UID_)
        {
            var r1 = UserService.DeleteUserAuthority(UID_);
            if (!r1.Result)
                return r1;
            var r2 = UserService.DeleteWhiteList(UID_);
            if (!r2.Result)
                return r2;

            return new ActResult(true);
        }

        public ActResult AddUserAuthority(UserItemDTO UserItemDTO_)
            => UserService.AddUserAuthority(UserItemDTO_);

        public ActResult EditUserAuthority(UserItemDTO UserItemDTO_)
            => UserService.EditUserAuthority(UserItemDTO_);

        public ActResult DeleteUserAuthority(string ID_)
            => UserService.DeleteUserAuthority(ID_);

        public ActResult ConnectMES(int Port_)
        {
            MESService.StartListen(Port_);
            return new ActResult(true);
        }

        public ActResult DisConnectMES()
        {
            MESService.StopListen();
            return new ActResult(true);
        }

        public void CreateBasicIni(string IniFilePath_)
        {
            if (!File.Exists(IniFilePath_))
            {
                File.Create(IniFilePath_).Close();

                foreach (var info in typeof(CheckItemObject).GetProperties())
                {
                    var r1 = IniHelper.SetValue(nameof(CheckItemObject), String.Format("#{0}\r\n{1}", info.GetCustomAttribute<DisplayAttribute>().ZHTW, info.Name), (true).ToString(), IniFilePath_);
                }

                foreach (var info in typeof(CurrentConfig).GetProperties())
                {
                    var r1 = IniHelper.SetValue(nameof(CurrentConfig), String.Format("#{0}\r\n{1}", info.GetCustomAttribute<DisplayAttribute>().ZHTW, info.Name), info.GetValue(DefaultConfig.CurrentConfig).ToString(), IniFilePath_);
                }

                foreach (var info in typeof(ProcessConfig).GetProperties())
                {
                    var r1 = IniHelper.SetValue(nameof(ProcessConfig), String.Format("#{0}\r\n{1}", info.GetCustomAttribute<DisplayAttribute>().ZHTW, info.Name), info.GetValue(DefaultConfig.ProcessConfig).ToString(), IniFilePath_);
                }

                foreach (var info in typeof(ConvertConfig).GetProperties())
                {
                    var r1 = IniHelper.SetValue(nameof(ConvertConfig), String.Format("#{0}\r\n{1}", info.GetCustomAttribute<DisplayAttribute>().ZHTW, info.Name), info.GetValue(DefaultConfig.ConvertConfig).ToString(), IniFilePath_);
                }

                foreach (var info in typeof(ADCConfig).GetProperties())
                {
                    var r1 = IniHelper.SetValue(nameof(ADCConfig), String.Format("#{0}\r\n{1}", info.GetCustomAttribute<DisplayAttribute>().ZHTW, info.Name), info.GetValue(DefaultConfig.ADCConfig).ToString(), IniFilePath_);
                }

                foreach (var info in typeof(LoadDataConfig).GetProperties())
                {
                    var r1 = IniHelper.SetValue(nameof(LoadDataConfig), String.Format("#{0}\r\n{1}", info.GetCustomAttribute<DisplayAttribute>().ZHTW, info.Name), info.GetValue(DefaultConfig.LoadDataConfig).ToString(), IniFilePath_);
                }
            }
        }

        public ActResult<CheckItemObject> GetCheckItemValue(string IniPath_)
        {
            try
            {
                var newitem = new CheckItemObject();
                foreach (var info in typeof(CheckItemObject).GetProperties())
                {
                    bool value = IniHelper.GetValue(nameof(CheckItemObject), info.Name, true.ToString(), IniPath_).Value == true.ToString();
                    info.SetValue(newitem, value);
                }
                return new ActResult<CheckItemObject>(newitem);
            }
            catch (Exception Ex)
            {
                return new ActResult<CheckItemObject>(Ex);
            }
        }

        public ActResult<CurrentConfig> GetCurrentConfigValue(string IniPath_)
        {
            try
            {
                var newitem = new CurrentConfig();
                foreach (var info in typeof(CurrentConfig).GetProperties())
                {
                    var value = IniHelper.GetValue<double>(nameof(CurrentConfig), info.Name, (double)info.GetValue(DefaultConfig.CurrentConfig), IniPath_).Value;
                    info.SetValue(newitem, value);
                }
                return new ActResult<CurrentConfig>(newitem);
            }
            catch (Exception Ex)
            {
                return new ActResult<CurrentConfig>(Ex);
            }
        }

        public ActResult<ProcessConfig> GetProcessConfigValue(string IniPath_)
        {
            try
            {
                var newitem = new ProcessConfig();
                foreach (var info in typeof(ProcessConfig).GetProperties())
                {
                    var value = IniHelper.GetValue<int>(nameof(ProcessConfig), info.Name, (int)info.GetValue(DefaultConfig.ProcessConfig), IniPath_).Value;
                    info.SetValue(newitem, value);
                }
                return new ActResult<ProcessConfig>(newitem);
            }
            catch (Exception Ex)
            {
                return new ActResult<ProcessConfig>(Ex);
            }
        }

        public ActResult<ConvertConfig> GetConvertConfigValue(string IniPath_)
        {
            try
            {
                var newitem = new ConvertConfig();
                foreach (var info in typeof(ConvertConfig).GetProperties())
                {
                    var value = IniHelper.GetValue<double>(nameof(ConvertConfig), info.Name, (double)info.GetValue(DefaultConfig.ConvertConfig), IniPath_).Value;
                    info.SetValue(newitem, value);
                }
                return new ActResult<ConvertConfig>(newitem);
            }
            catch (Exception Ex)
            {
                return new ActResult<ConvertConfig>(Ex);
            }
        }

        public ActResult<ADCConfig> GetADCConfigValue(string IniPath_)
        {
            try
            {
                var newitem = new ADCConfig();
                foreach (var info in typeof(ADCConfig).GetProperties())
                {
                    var value = IniHelper.GetValue<double>(nameof(ADCConfig), info.Name,(double) info.GetValue(DefaultConfig.ADCConfig), IniPath_).Value;
                    info.SetValue(newitem, value);
                }
                return new ActResult<ADCConfig>(newitem);
            }
            catch (Exception Ex)
            {
                return new ActResult<ADCConfig>(Ex);
            }
        }

        public ActResult<LoadDataConfig> GetLoadDataConfigValue(string IniPath_)
        {
            try
            {
                var newitem = new LoadDataConfig();
                foreach (var info in typeof(LoadDataConfig).GetProperties())
                {
                    var value = IniHelper.GetValue<int>(nameof(LoadDataConfig), info.Name, (int)info.GetValue(DefaultConfig.LoadDataConfig), IniPath_).Value;
                    info.SetValue(newitem, value);
                }
                return new ActResult<LoadDataConfig>(newitem);
            }
            catch (Exception Ex)
            {
                return new ActResult<LoadDataConfig>(Ex);
            }
        }


        public ActResult SetCheckItemValue(string IniPath_, CheckItemObject CheckItem_)
        {
            try
            {
                foreach (var info in typeof(CheckItemObject).GetProperties())
                {
                    var r1 = IniHelper.SetValue(nameof(CheckItemObject), info.Name, ((bool)info.GetValue(CheckItem_)).ToString(), IniPath_);
                }
                return new ActResult(true);
            }
            catch (Exception Ex)
            {
                return new ActResult(Ex);
            }
        }


    }
}

using Common;
using Common.DTO;
using Common.Enums;
using Common.Extension;
using Controller.Interface;
using Service.DataBase.Interface;
using Service.Device.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Implement
{
    public class UserController : IUserController
    {
        IUserService UserService => ControllerConfig.GetService<IUserService>();

        public string NowUID { get; private set; }
        public bool IsLogging { get; private set; }
        public UserItemDTO UserItemDTO { get; private set; }


        public bool IsOnList(string UID_)
        {
            return UserService.IsOnList(UID_);
        }


        public ActResult LogIn(string UID_)
        {
            IsLogging = true;
            NowUID = UID_;
            var r2 = UserService.IsOnList(UID_);
            if (r2)
            {
                var r1 = UserService.GetUserAuthority(UID_);
                UserItemDTO = null;

                if (!r1.Result)
                    return new ActResult(new Exception("取得操作者權限發生錯誤" + r1.Exception.Message));

                UserItemDTO = r1.Value;
            }
            else 
                UserItemDTO = new UserItemDTO() { UserID = UID_, EditRecipe = false, UseCustomMod = false, SettingPage = false };

            return new ActResult(true);

        }

        public ActResult<UserItemDTO> GetUserItemDTO(string UID_)
        {
            var r1 = UserService.GetUserAuthority(NowUID);

            if (!r1.Result)
                return new ActResult<UserItemDTO>(new Exception("取得操作者權限發生錯誤" + r1.Exception.Message));

            return r1;
        }
        public void LogOut()
        {
            IsLogging = false;
            NowUID = String.Empty;
            UserItemDTO = null;
        }


        public ActResult AddWhiteList(string UID_,string Password_) 
            => UserService.AddUser(UID_, Password_);
            
        public bool Certification(UserAuthority UserAuthority_)
        {
            if (!IsLogging)
                return false;

            switch (UserAuthority_)
            {
                case UserAuthority.EditRecipe:
                    return UserItemDTO.EditRecipe;
                case UserAuthority.UseCustomMod:
                    return UserItemDTO.UseCustomMod;
                case UserAuthority.SettingPage:
                    return UserItemDTO.SettingPage;
                default:
                    return false;
            }
        }
        public ActResult Certification(string UID_, string Password_) 
            => UserService.Certification(UID_, Password_);

        public ActResult DeleteWhiteList(string UID_)
            => UserService.DeleteWhiteList(UID_);

        public ActResult<List<string>> Gets()
            => UserService.Gets();


    }
}

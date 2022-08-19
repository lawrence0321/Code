using Common;
using Common.DTO;
using Common.Enums;
using Common.Interface;
using System.Collections.Generic;

namespace Service.DataBase.Interface
{
    public interface IUserService : IService
    {
        bool IsOnList(string UID_);

        ActResult Certification(string UID_, string Password_);

        ActResult AddUser(string UID_, string Password_);

        ActResult DeleteWhiteList(string UID_);

        ActResult<List<string>> Gets();

        ActResult<bool> IsHaveUserAuthority(string UID_, UserAuthority UserAuthority_);

        ActResult<UserItemDTO> GetUserAuthority(string ID_);
        ActResult DeleteUserAuthority(string iD_);
        ActResult EditUserAuthority(UserItemDTO userItemDTO_);
        ActResult AddUserAuthority(UserItemDTO userItemDTO_);
        ActResult EditUser(string uID_, string password_);
    }
}

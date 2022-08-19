using Common;
using Common.DTO;
using Common.Enums;
using Common.Interface;
using System.Collections.Generic;

namespace Controller.Interface
{
    public interface IUserController : IController
    {
        string NowUID { get; }

        bool IsLogging { get; }

        bool IsOnList(string UID_);

        ActResult LogIn(string UID_);

        ActResult Certification(string UID_, string Password_);

        ActResult<UserItemDTO> GetUserItemDTO(string UID_);

        void LogOut();

        bool Certification(UserAuthority UserAuthority_);

        ActResult AddWhiteList(string UID_, string Password_);

        ActResult DeleteWhiteList(string UID_);

        ActResult<List<string>> Gets();
    }
}

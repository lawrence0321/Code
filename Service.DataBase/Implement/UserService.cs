using Common;
using Common.DTO;
using Common.Enums;
using Common.Extension;
using Dapper;
using Repository;
using Repository.Entity;
using Service.DataBase.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataBase.Implement
{
    internal class UserService : IUserService
    {
        const string DefaultConnString = @"Server=127.0.0.1; Database= 20sa154v4setting; Persist Security Info=True; UId=20SA154; Pwd=20SA154; convert zero datetime=True;SslMode = none;";

        public ActResult AddUser(string UID_,string Password_)
        {
            using (var unitOfWork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var count = unitOfWork.Repository<User>().Reads(p => p.ID == UID_).Count();
                    if (count != 0)
                        throw new Exception("ID重複");

                    var entity = new User() { ID = UID_, Password = Password_, LogTimeTicks = DateTime.Now.Ticks };
                    unitOfWork.Repository<User>().Insert(entity);
                    unitOfWork.Save();

                    return new ActResult(true);
                }
                catch (Exception Ex)
                {
                    return new ActResult(Ex);
                }
            }
        }

        public bool IsOnList(string UID_)
        {
            using (var unitOfWork = ServiceConfig.GetUnitWork())
            {
                var count = unitOfWork.Repository<User>().Reads(p => p.ID == UID_).Count();
                return count != 0;
            }
        }

        public ActResult<UserItemDTO> GetUserAuthority(string ID_)
        {
            try
            {
                using (var unitOfWork = UnitOfWorkFactory.GetUnitOfWork(DefaultConnString, Repository.Enums.InitializerType.CreateDatabaseIfNotExists))
                {
                    var item = unitOfWork.UseDapper<UserItemDTO>(String.Format("Select * FROM `20sa154v4setting`.`userauthority` WHERE UserID = '{0}';", ID_)).ToList().First();

                    return new ActResult<UserItemDTO>(item);
                }
            }
            catch (Exception Ex)
            {
                return new ActResult<UserItemDTO>(Ex);
            }
        }

        public ActResult AddUserAuthority(UserItemDTO userItemDTO_)
        {
            try
            {
                using (var unitOfWork = UnitOfWorkFactory.GetUnitOfWork(DefaultConnString, Repository.Enums.InitializerType.CreateDatabaseIfNotExists))
                {
                    unitOfWork.UseDapper<int>(String.Format("INSERT INTO `20sa154v4setting`.`userauthority` (`UserID`, `SettingPage`, `UseCustomMod`, `EditRecipe`) VALUES ('{0}', {1}, {2}, {3});",
                        userItemDTO_.UserID,
                        userItemDTO_.SettingPage ? 1 : 0,
                        userItemDTO_.UseCustomMod ? 1 : 0,
                        userItemDTO_.EditRecipe ? 1 : 0
                        )
                    );

                    return new ActResult(true);
                }
            }
            catch (Exception Ex)
            {
                return new ActResult(Ex);
            }
        }

        public ActResult EditUserAuthority(UserItemDTO userItemDTO_)
        {
            try
            {
                using (var unitOfWork = UnitOfWorkFactory.GetUnitOfWork(DefaultConnString, Repository.Enums.InitializerType.CreateDatabaseIfNotExists))
                {
                    var par = new DynamicParameters();
                    par.Add("@ID", userItemDTO_.UserID);
                    par.Add("@SettingPage", userItemDTO_.SettingPage ? 1 : 0);
                    par.Add("@UseCustomMod", userItemDTO_.UseCustomMod ? 1 : 0);
                    par.Add("@EditRecipe", userItemDTO_.EditRecipe ? 1 : 0);

                    unitOfWork.UseDapper<int>("UPDATE `20sa154v4setting`.`userauthority` SET `SettingPage`= @SettingPage, `UseCustomMod`= @UseCustomMod, `EditRecipe`= @EditRecipe WHERE  `UserID`= @ID;", par);

                    return new ActResult(true);
                }
            }
            catch (Exception Ex)
            {
                return new ActResult(Ex);
            }
        }


        public ActResult DeleteUserAuthority(string iD_)
        {
            try
            {
                using (var unitOfWork = UnitOfWorkFactory.GetUnitOfWork(DefaultConnString, Repository.Enums.InitializerType.CreateDatabaseIfNotExists))
                {
                    unitOfWork.UseDapper<int>(String.Format("DELETE FROM `20sa154v4setting`.`userauthority` WHERE  `UserID`='{0}';", iD_));

                    return new ActResult(true);
                }
            }
            catch (Exception Ex)
            {
                return new ActResult(Ex);
            }
        }



        public ActResult EditUser(string uID_, string password_)
        {
            using (var unitOfWork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var entity = unitOfWork.Repository<User>().Read(p=>p.ID == uID_);

                    if (entity is null)
                        throw new Exception("無此帳號");

                    entity.Password = password_;
                    unitOfWork.Repository<User>().Update(entity);

                    unitOfWork.Save();

                    return new ActResult(true);
                }
                catch (Exception Ex)
                {
                    return new ActResult(Ex);
                }
            }
        }


        public ActResult<bool> IsHaveUserAuthority(string UID_, UserAuthority UserAuthority_)
        {
            try
            {
                using (var unitOfWork = UnitOfWorkFactory.GetUnitOfWork(DefaultConnString, Repository.Enums.InitializerType.CreateDatabaseIfNotExists))
                {
                    var count = unitOfWork.UseDapper<int>(String.Format("SELECT 1 FROM `20sa154v4setting`.UserAuthority WHERE UserID = '{0}'",UID_), null).ToList().Count;
                    if (count == 0)
                        unitOfWork.UseDapper(String.Format("INSERT INTO `20sa154v4setting`.`userauthority` (`UserID`, `SettingPage`, `UseCustomMod`, `EditRecipe`) VALUES ('{0}', '1', '1', '1');", UID_), null);

                    var value = unitOfWork.UseDapper<int>(String.Format("SELECT {0} FROM `20sa154v4setting`.UserAuthority WHERE UserID = {1}", UserAuthority_.ToString(), UID_), null).ToList().First();

                    return new ActResult<bool>(Obj_: value == 1);
                }
            }
            catch (Exception Ex)
            {
                return new ActResult<bool>(Ex);
            }
        }

        public ActResult Certification(string UID_, string Password_)
        {
            using (var unitOfWork = ServiceConfig.GetUnitWork())
            {
                var users = unitOfWork.Repository<User>().Reads(p => p.ID == UID_).ToList();

                var pw = Password_.GetSHA256();
                if (users.Count == 0)
                    return new ActResult(new Exception("無此帳號"));
                else
                {
                    var user = users[0];

                    if (user.Password != pw)
                        return new ActResult(new Exception("密碼錯誤"));
                    else
                        return new ActResult(true);
                }

            }
        }

        public ActResult DeleteWhiteList(string UID_)
        {
            using (var unitOfWork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var entity = unitOfWork.Repository<User>().Read(p => p.ID == UID_);
                    unitOfWork.Repository<User>().Delete(entity);
                    unitOfWork.Save();

                    return new ActResult(true);
                }
                catch (Exception Ex)
                {
                    return new ActResult(Ex);
                }
            }
        }

        public ActResult<List<string>> Gets()
        {
            using (var unitOfWork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var list = unitOfWork.Repository<User>().Reads().Select(p=>p.ID).ToList();
                    return new ActResult<List<string>>(list);
                }
                catch (Exception Ex)
                {
                    return new ActResult<List<string>>(Ex);
                }
            }
        }


    }
}

using Common;
using Repository;
using Service.DataBase.Interface;
using System;
using System.Linq;

namespace Service.DataBase.Implement
{
    internal class SettingService : ISettingService
    {
        const string DefaultConnString = @"Server=127.0.0.1; Database= 20sa154v4setting; Persist Security Info=True; UId=20SA154; Pwd=20SA154; convert zero datetime=True;SslMode = none;";
        public ActResult<ulong> GetCheckValue()
        {
            try
            {
                using (var unitOfWork = UnitOfWorkFactory.GetUnitOfWork(DefaultConnString, Repository.Enums.InitializerType.CreateDatabaseIfNotExists))
                {
                    var values = unitOfWork.UseDapper<ulong>("SELECT Value FROM `20sa154v4setting`.meschecktype ORDER BY rowid DESC", null).ToList();

                    return new ActResult<ulong>(values[0]);
                }
            }
            catch (Exception Ex)
            {
                return new ActResult<ulong>(Ex);
            }
        }

        public ActResult SetCheckValue(ulong Value_)
        {
            try
            {
                using (var unitOfWork = UnitOfWorkFactory.GetUnitOfWork(DefaultConnString, Repository.Enums.InitializerType.CreateDatabaseIfNotExists))
                {
                    var values = unitOfWork.UseDapper<ulong>(String.Format("INSERT INTO `20sa154v4setting`.`meschecktype` (`Value`) VALUES ('{0}');", Value_), null);
                    return new ActResult(true);
                }
            }
            catch (Exception Ex)
            {
                return new ActResult(Ex);
            }
        }
    }
}

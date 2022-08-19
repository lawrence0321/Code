using Common;
using Repository.Enums;
using Repository.Implement;
using Repository.Interface;

namespace Repository
{
    public class UnitOfWorkFactory
    {

        /// <summary>
        /// 使用內建的連線字串
        /// </summary>
        /// <param name="Initializer_"></param>
        /// <returns></returns>
        public static IUnitOfWork GetUnitOfWork(InitializerType Initializer_ = InitializerType.CreateDatabaseIfNotExists)
        {
            var connectionstring = @"Server=127.0.0.1; Database= 20SA154V4; Persist Security Info=True; UId=20SA154; Pwd=20SA154; convert zero datetime=True;";

            return new EFGenericUnitOfWork(connectionstring, Initializer_);
        }

        /// <summary>
        /// 使用自訂的連線字串
        /// </summary>
        /// <param name="ConnectString_">自訂的連線字串</param>
        /// <param name="Initializer_">DBContext初始化類型</param>
        /// <returns></returns>
        public static IUnitOfWork GetUnitOfWork(string ConnectString_, InitializerType Initializer_)
            => new EFGenericUnitOfWork(ConnectString_, Initializer_);

    }
}

using Repository;
using Repository.Enums;
using Repository.Implement;
using Repository.Interface;


namespace Service.DataBase
{
    /// <summary>
    /// Servicer基礎設定
    /// </summary>
    public static class ServiceConfig
    {
        static InitializerType InitializerType = InitializerType.CreateDatabaseIfNotExists;

        static readonly object CreateToken = new object();

        internal static IUnitOfWork GetUnitWork()
        {
            lock (CreateToken)
            {
                var unitwork = UnitOfWorkFactory.GetUnitOfWork(InitializerType);
                if (InitializerType == InitializerType.DropCreateDatabaseAlways)
                    InitializerType = InitializerType.CreateDatabaseIfNotExists;
                return unitwork;
            }
        }
    }
}

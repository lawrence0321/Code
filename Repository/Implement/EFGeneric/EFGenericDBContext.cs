using MySql.Data.EntityFramework;
using Repository.Entity;
using Repository.Enums;
using Repository.Interface;
using System.Data.Entity;

namespace Repository.Implement
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    internal class EFGenericDBContext : DbContext, IDBContext
    {
        public string ConnectStr { get; private set; }

        /// <summary>
        /// 生產參數
        /// </summary>
        public virtual DbSet<ThermostatLog> ThermostatLogs { get; set; }
        public virtual DbSet<RectifierLog> RectifierLogs { get; set; }
        public virtual DbSet<Alarm> Alarms { get; set; }
        public virtual DbSet<AlarmLog> AlarmLogs { get; set; }
        public virtual DbSet<Modbus31Log> Modbus31Logs { get; set; }
        public virtual DbSet<Modbus32Log> Modbus32Logs { get; set; }
        public virtual DbSet<Modbus33Log> Modbus33Logs { get; set; }
        public virtual DbSet<WashDeviceLog> WashDeviceLogs { get; set; }

        public virtual DbSet<LoadData> LoadDatas { get; set; }
        public virtual DbSet<UnLoadDataLog> UnLoadDataLogs { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<BarLog> BarLogs { get; set; }

        public EFGenericDBContext(string ConnectStr_, InitializerType Type_)
            : base(ConnectStr_)
        {
            this.ConnectStr = ConnectStr_;
            this.SetDataBaseInitializerType(Type_);
        }

        public void SetDataBaseInitializerType(InitializerType Type_)
        {
            switch (Type_)
            {
                case InitializerType.CreateDatabaseIfNotExists:
                    System.Data.Entity.Database.SetInitializer(new DBInitializerCreateDatabaseIfNotExists());
                    break;
                case InitializerType.DropCreateDatabaseAlways:
                    System.Data.Entity.Database.SetInitializer(new DBInitializerDropCreateDatabaseAlways());
                    break;
                case InitializerType.DropCreateDatabaseIfModelChanges:
                    System.Data.Entity.Database.SetInitializer(new DBInitializerDropCreateDatabaseIfModelChanges());
                    break;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

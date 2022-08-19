using System;
using System.Data.Entity;
using Repository.Entity;

namespace Repository.Interface
{
    internal interface IDBContext : IDisposable
    {
        /// <summary>
        /// 連線字串
        /// </summary>
        string ConnectStr { get; }

        DbSet<ThermostatLog> ThermostatLogs { get; set; }
        DbSet<RectifierLog> RectifierLogs { get; set; }
        DbSet<Alarm> Alarms { get; set; }
        DbSet<AlarmLog> AlarmLogs { get; set; }
        DbSet<Modbus31Log> Modbus31Logs { get; set; }
        DbSet<Modbus32Log> Modbus32Logs { get; set; }
        DbSet<Modbus33Log> Modbus33Logs { get; set; }
        DbSet<WashDeviceLog> WashDeviceLogs { get; set; }

        DbSet<LoadData> LoadDatas { get; set; }
        DbSet<UnLoadDataLog> UnLoadDataLogs { get; set; }
        DbSet<Recipe> Recipes { get; set; }

        DbSet<User> Users { get; set; }

        DbSet<BarLog> BarLogs { get; set; }


        /// <summary>
        /// 儲存變更
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }

}

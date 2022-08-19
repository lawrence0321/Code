using Common.Interface;
using Service.CSV;
using Service.CSV.Interface;
using Service.DataBase;
using Service.DataBase.Interface;
using Service.Device;
using Service.Device.Interface;
using Service.MES;
using Service.MES.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    internal static class ControllerConfig
    {

        public static T GetService<T>() where T : IService
        {
            object obj;
            switch (typeof(T).Name)
            {
                case nameof(IRecipeService):
                    obj = DBServiceFactory.Get<IRecipeService>();
                    break;
                case nameof(ILoadDataService):
                    obj = DBServiceFactory.Get<ILoadDataService>();
                    break;
                case nameof(IAlarmLogService):
                    obj = DBServiceFactory.Get<IAlarmLogService>();
                    break;
                case nameof(IThermostatLogService):
                    obj = DBServiceFactory.Get<IThermostatLogService>();
                    break;
                case nameof(IRectifierLogService):
                    obj = DBServiceFactory.Get<IRectifierLogService>();
                    break;
                case nameof(IUnLoadService):
                    obj = DBServiceFactory.Get<IUnLoadService>();
                    break;
                case nameof(IUserService):
                    obj = DBServiceFactory.Get<IUserService>();
                    break;
                case nameof(IModbus31LogService):
                    obj = DBServiceFactory.Get<IModbus31LogService>();
                    break;
                case nameof(IModbus32LogService):
                    obj = DBServiceFactory.Get<IModbus32LogService>();
                    break;
                case nameof(IModbus33LogService):
                    obj = DBServiceFactory.Get<IModbus33LogService>();
                    break;
                case nameof(IWashDeviceLogService):
                    obj = DBServiceFactory.Get<IWashDeviceLogService>();
                    break;
                case nameof(ISettingService):
                    obj = DBServiceFactory.Get<ISettingService>();
                    break;


                case nameof(ICSVAlarmLogService):
                    obj = CSVServiceFactory.Get<ICSVAlarmLogService>();
                    break;
                case nameof(ICSVLoadDataService):
                    obj = CSVServiceFactory.Get<ICSVLoadDataService>();
                    break;
                case nameof(ICSVUnLoadDataService):
                    obj = CSVServiceFactory.Get<ICSVUnLoadDataService>();
                    break;
                case nameof(ICSVModbus31LogService):
                    obj = CSVServiceFactory.Get<ICSVModbus31LogService>();
                    break;
                case nameof(ICSVModbus32LogService):
                    obj = CSVServiceFactory.Get<ICSVModbus32LogService>();
                    break;
                case nameof(ICSVModbus33LogService):
                    obj = CSVServiceFactory.Get<ICSVModbus33LogService>();
                    break;


                case nameof(IDeviceService):
                    obj = DeviceServiceFactory.Get(false);
                    break;
                case nameof(IMESService):
                    obj = MESServiceFactory.Get(false);
                    break;
                default:
                    throw new Exception("Do not support this Service.");
            }
            return (T)obj;  
        }

    }
}

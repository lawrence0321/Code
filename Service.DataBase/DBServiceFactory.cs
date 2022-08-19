using Common.Interface;
using Service.DataBase.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataBase
{
    public static class DBServiceFactory
    {
        public static T Get<T>() where T : class, IService
        {
            object obj;
            switch (typeof(T).Name)
            {
                case nameof(IRecipeService):
                    obj = new Implement.RecipeService();
                    break;
                case nameof(ILoadDataService):
                    obj = new Implement.LoadDataService();
                    break;
                case nameof(IAlarmLogService):
                    obj = new Implement.AlarmLogService();
                    break;
                case nameof(IThermostatLogService):
                    obj = new Implement.ThermostatLogService();
                    break;
                case nameof(IRectifierLogService):
                    obj = new Implement.RectifierLogService();
                    break;
                case nameof(IUnLoadService):
                    obj = new Implement.UnLoadService();
                    break;
                case nameof(IUserService):
                    obj = new Implement.UserService();
                    break;
                case nameof(IModbus31LogService):
                    obj = new Implement.Modbus31LogService();
                    break;
                case nameof(IModbus32LogService):
                    obj = new Implement.Modbus32LogService();
                    break;
                case nameof(IModbus33LogService):
                    obj = new Implement.Modbus33LogService();
                    break;
                case nameof(IWashDeviceLogService):
                    obj = new Implement.WashDeviceLogService();
                    break;
                case nameof(ISettingService):
                    obj = new Implement.SettingService();
                    break;

                default:
                    throw new Exception(String.Format("Not Support {0}.", typeof(T).Name));
            }
            return (T)obj;
        }
    }

}

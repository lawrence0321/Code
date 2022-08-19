using Common;
using Common.DTO;
using Common.Interface;
using Controller.Interface;
using Service.DataBase.Interface;
using System.Collections.Generic;

namespace Controller.Implement
{
    internal class SearchController : ISearchController
    {
        IAlarmLogService AlarmLogService => ControllerConfig.GetService<IAlarmLogService>();
        IThermostatLogService ThermostatLogService => ControllerConfig.GetService<IThermostatLogService>();
        IRectifierLogService RectifierLogService => ControllerConfig.GetService<IRectifierLogService>();
        IUnLoadService UnLoadService => ControllerConfig.GetService<IUnLoadService>();
        ILoadDataService LoadDataService => ControllerConfig.GetService<ILoadDataService>();

        IModbus31LogService Modbus31LogService => ControllerConfig.GetService<IModbus31LogService>();
        IModbus32LogService Modbus32LogService => ControllerConfig.GetService<IModbus32LogService>();
        IModbus33LogService Modbus33LogService => ControllerConfig.GetService<IModbus33LogService>();
        IWashDeviceLogService WashDeviceLogService => ControllerConfig.GetService<IWashDeviceLogService>();

        public ActResult<List<T>> GetLogs<T>(long StartTimeTicks_, long EndTimeTicks_, long Limit_)where T:IDTO
        {
            object rtn = null;
            switch (typeof(T).Name)
            {
                case nameof(UnLoadDataLogDTO):
                    rtn = UnLoadService.Gets(StartTimeTicks_, EndTimeTicks_, Limit_);
                    break;
                case nameof(AlarmLogDTO):
                    rtn = AlarmLogService.ExGets(StartTimeTicks_, EndTimeTicks_);
                    break;
                case nameof(RectifierLogDTO):
                    rtn = RectifierLogService.Gets(StartTimeTicks_, EndTimeTicks_, Limit_, 1);
                    break;
                case nameof(ThermostatLogDTO):
                    rtn = ThermostatLogService.Gets(StartTimeTicks_, EndTimeTicks_, Limit_);
                    break;
                case nameof(LoadDataDTO):
                    rtn = LoadDataService.Gets(StartTimeTicks_, EndTimeTicks_, Limit_);
                    break;

                case nameof(Modbus31LogDTO):
                    rtn = new ActResult<List<Modbus31LogDTO>>(new List<Modbus31LogDTO>());
                    break;
                case nameof(Modbus32LogDTO):
                    rtn = new ActResult<List<Modbus32LogDTO>>(new List<Modbus32LogDTO>());
                    break;
                case nameof(Modbus33LogDTO):
                    rtn = new ActResult<List<Modbus33LogDTO>>(new List<Modbus33LogDTO>());
                    break;
                case nameof(WashDeviceLogDTO):
                    rtn = new ActResult<List<WashDeviceLogDTO>>(new List<WashDeviceLogDTO>());
                    break;
            }
            return (ActResult<List<T>>)rtn;
        }

        public ActResult<List<T>> GetLogs<T>(string LotNo_, long Limit_) where T : IDTO
        {
            object rtn = null;
            switch (typeof(T).Name)
            {
                case nameof(UnLoadDataLogDTO):
                    rtn = UnLoadService.Gets(LotNo_, Limit_);
                    break;
                case nameof(AlarmLogDTO):
                    rtn = AlarmLogService.ExGets(LotNo_);
                    break;
                case nameof(RectifierLogDTO):
                    rtn = RectifierLogService.Gets(LotNo_, Limit_, 1);
                    break;
                case nameof(ThermostatLogDTO):
                    rtn = ThermostatLogService.Gets(LotNo_, Limit_);
                    break;
                case nameof(Modbus31LogDTO):
                    rtn = new ActResult<List<Modbus31LogDTO>>(new List<Modbus31LogDTO>());
                    break;
                case nameof(Modbus32LogDTO):
                    rtn = new ActResult<List<Modbus32LogDTO>>(new List<Modbus32LogDTO>());
                    break;
                case nameof(Modbus33LogDTO):
                    rtn = new ActResult<List<Modbus33LogDTO>>(new List<Modbus33LogDTO>());
                    break;
                case nameof(WashDeviceLogDTO):
                    rtn = new ActResult<List<WashDeviceLogDTO>>(new List<WashDeviceLogDTO>());
                    break;
            }
            return (ActResult<List<T>>)rtn;
        }


        public ActResult<List<UnLoadDataLogDTO>> GetUnLoadDataLogs(long StartTimeTicks_, long EndTimeTicks_, int Limit_)
            => UnLoadService.Gets(StartTimeTicks_, EndTimeTicks_, Limit_);
        public ActResult<List<UnLoadDataLogDTO>> GetUnLoadDataLogs(string LotNo_ , int Limit_)
            => UnLoadService.Gets(LotNo_, Limit_);


        public ActResult<List<AlarmLogDTO>> GetAlarmLogs(long StartTimeTicks_, long EndTimeTicks_)
            => AlarmLogService.ExGets(StartTimeTicks_, EndTimeTicks_);
        public ActResult<List<AlarmLogDTO>> GetAlarmLogs(string LotNo_)
            => AlarmLogService.ExGets(LotNo_);


        public ActResult<List<RectifierLogDTO>> GetRectifierLogs(long StartTimeTicks_, long EndTimeTicks_,long Limit_, int Interval_)
            => RectifierLogService.Gets(StartTimeTicks_, EndTimeTicks_, Limit_, Interval_);
        public ActResult<List<RectifierLogDTO>> GetRectifierLogs(string LotNo_, long Limit_, int Interval_)
            => RectifierLogService.Gets(LotNo_, Limit_, Interval_);


        public ActResult<List<ThermostatLogDTO>> GetThermostatLogs(long StartTimeTicks_, long EndTimeTicks_, long Limit_)
            => ThermostatLogService.Gets(StartTimeTicks_, EndTimeTicks_, Limit_);
        public ActResult<List<ThermostatLogDTO>> GetThermostatLogs(string LotNo_, long Limit_)
            => ThermostatLogService.Gets(LotNo_, Limit_);


        public ActResult<List<WashDeviceLogDTO>> GetWashDeviceLogs(long StartTimeTicks_, long EndTimeTicks_,int Limit_)
        => WashDeviceLogService.Gets(StartTimeTicks_, EndTimeTicks_, Limit_);

        public ActResult<List<WashDeviceLogDTO>> GetWashDeviceLogs(string LotNo_, int Limit_)
        => WashDeviceLogService.Gets(LotNo_, Limit_);


        public ActResult<List<Modbus31LogDTO>> GetModbus31Logs(long StartTimeTicks_, long EndTimeTicks_, int Limit_)
        => Modbus31LogService.Gets(StartTimeTicks_, EndTimeTicks_, Limit_);
        public ActResult<List<Modbus31LogDTO>> GetModbus31Logs(string LotNo_, int Limit_)
        => Modbus31LogService.Gets(LotNo_, Limit_);

        public ActResult<List<Modbus32LogDTO>> GetModbus32Logs(long StartTimeTicks_, long EndTimeTicks_, int Limit_)
        => Modbus32LogService.Gets(StartTimeTicks_, EndTimeTicks_, Limit_);
        public ActResult<List<Modbus32LogDTO>> GetModbus32Logs(string LotNo_, int Limit_)
        => Modbus32LogService.Gets(LotNo_, Limit_);

        public ActResult<List<Modbus33LogDTO>> GetModbus33Logs(long StartTimeTicks_, long EndTimeTicks_, int Limit_)
        => Modbus33LogService.Gets(StartTimeTicks_, EndTimeTicks_, Limit_);
        public ActResult<List<Modbus33LogDTO>> GetModbus33Logs(string LotNo_, int Limit_)
        => Modbus33LogService.Gets(LotNo_, Limit_);
    }
}

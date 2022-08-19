using Common;
using Common.DTO;
using Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Interface
{
    public interface ISearchController : IController
    {
        ActResult<List<T>> GetLogs<T>(long StartTimeTicks_, long EndTimeTicks_, long Limit_) where T : IDTO;
        ActResult<List<T>> GetLogs<T>(string LotNo_, long Limit_) where T : IDTO;

        ActResult<List<ThermostatLogDTO>> GetThermostatLogs(long StartTimeTicks_, long EndTimeTicks_, long Limit_);
        ActResult<List<ThermostatLogDTO>> GetThermostatLogs(string LotNo_, long Limit_);


        ActResult<List<RectifierLogDTO>> GetRectifierLogs(long StartTimeTicks_, long EndTimeTicks_, long Limit_, int Interval);
        ActResult<List<RectifierLogDTO>> GetRectifierLogs(string LotNo_, long Limit_, int Interval);

        ActResult<List<AlarmLogDTO>> GetAlarmLogs(long StartTimeTicks_, long EndTimeTicks_);
        ActResult<List<AlarmLogDTO>> GetAlarmLogs(string LotNo_);

        ActResult<List<Modbus31LogDTO>> GetModbus31Logs(long StartTimeTicks_, long EndTimeTicks_, int Limit_);
        ActResult<List<Modbus31LogDTO>> GetModbus31Logs(string LotNo_, int Limit_);

        ActResult<List<Modbus32LogDTO>> GetModbus32Logs(long StartTimeTicks_, long EndTimeTicks_, int Limit_);
        ActResult<List<Modbus32LogDTO>> GetModbus32Logs(string LotNo_, int Limit_);

        ActResult<List<Modbus33LogDTO>> GetModbus33Logs(long StartTimeTicks_, long EndTimeTicks_, int Limit_);
        ActResult<List<Modbus33LogDTO>> GetModbus33Logs(string LotNo_, int Limit_);

        ActResult<List<WashDeviceLogDTO>> GetWashDeviceLogs(long StartTimeTicks_, long EndTimeTicks_, int Limit_);
        ActResult<List<WashDeviceLogDTO>> GetWashDeviceLogs(string LotNo_,int Limit_);
    }
}

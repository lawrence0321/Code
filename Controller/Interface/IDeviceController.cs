using Common;
using Common.DTO;
using Common.Interface;

namespace Controller.Interface
{
    public interface IDeviceController : IController
    {
        bool IsConnectPLC1 { get; }
        bool IsConnectPLC2 { get; }

        ActResult<Modbus31LogDTO> GetNowModbus31Log();

        ActResult<Modbus32LogDTO> GetNowModbus32Log();

        ActResult<Modbus33LogDTO> GetNowModbus33Log();

        ActResult<ThermostatLogDTO> GetNowThermostatLog();

        ActResult<RectifierLogDTO> GetNowRectifierLog();

        ActResult<WashDeviceLogDTO> GetNowWashDeviceLog();

        ActResult Clear();
    }

}

using Common;
using Common.DTO;
using Common.Interface;
using Service.Device.Enums;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Device.Interface
{
    public interface IDeviceService:IService
    {
        bool IsConnect_PLC1 { get; }
        bool IsConnect_PLC2 { get; }
        ActResult<AlarmTypePackage> GetNowAlarmTypePackage();
        ActResult<PLCStatuses> GetNowPLCStatuses();
        ActResult<PCStatuses> GetNowPCStatuses();
        ActResult<ThermostatLogDTO> GetThermostatLog();
        ActResult<RectifierLogDTO> GetRectifierLog();
        ActResult<UnLoadDataLogDTO> GetUnLoadData(int No_);
        ActResult SendLoadDatas(LoadDataDTO LoadData_);
        ActResult ReSetLoadData();
        ActResult UpdatePCStatuses(PCStatuses Status_, bool Value_);
        ActResult LightLen(int No_, bool Value_);

        ActResult<List<UnLoadDataLogDTO>> GeBackuptUnLoadDatas();
    }

}

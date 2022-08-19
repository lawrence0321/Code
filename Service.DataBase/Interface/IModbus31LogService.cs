using Common;
using Common.DTO;
using Common.Interface;
using System.Collections.Generic;

namespace Service.DataBase.Interface
{

    public interface IModbus31LogService : IService
    {
        ActResult Insert(Modbus31LogDTO NewItem_);

        ActResult<Modbus31LogDTO> Get();

        ActResult<List<Modbus31LogDTO>> Gets(long StartTimeTicks_, long EndTimeTicks_, int Limit_);

        ActResult<List<Modbus31LogDTO>> Gets(string LotNo_, int Limit_);

        ActResult Clear();
    }
    public interface IModbus32LogService : IService
    {
        ActResult Insert(Modbus32LogDTO NewItem_);

        ActResult<Modbus32LogDTO> Get();

        ActResult<List<Modbus32LogDTO>> Gets(long StartTimeTicks_, long EndTimeTicks_, int Limit_);

        ActResult<List<Modbus32LogDTO>> Gets(string LotNo_, int Limit_);

        ActResult Clear();
    }
    public interface IModbus33LogService : IService
    {
        ActResult Insert(Modbus33LogDTO NewItem_);

        ActResult<Modbus33LogDTO> Get();

        ActResult<List<Modbus33LogDTO>> Gets(long StartTimeTicks_, long EndTimeTicks_, int Limit_);

        ActResult<List<Modbus33LogDTO>> Gets(string LotNo_, int Limit_);

        ActResult Clear();
    }

    public interface IWashDeviceLogService : IService
    {
        ActResult Insert(WashDeviceLogDTO NewItem_);

        ActResult<WashDeviceLogDTO> Get();

        ActResult<List<WashDeviceLogDTO>> Gets(long StartTimeTicks_, long EndTimeTicks_, int Limit_);

        ActResult<List<WashDeviceLogDTO>> Gets(string LotNo_, int Limit_);

        ActResult Clear();
    }

}

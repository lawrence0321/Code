using Common;
using Common.DTO;
using Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataBase.Interface
{
    public interface IThermostatLogService : IService
    {
        ActResult Insert(ThermostatLogDTO NewItem_);

        ActResult<ThermostatLogDTO> Get();

        ActResult<List<ThermostatLogDTO>> Gets(long StartTimeTicks_, long EndTimeTicks_, long Limit_);

        ActResult<List<ThermostatLogDTO>> Gets(string LotNo_, long Limit_);
        ActResult Clear();
    }
}

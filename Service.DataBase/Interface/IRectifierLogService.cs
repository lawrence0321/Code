using Common;
using Common.DTO;
using Common.Interface;
using System.Collections.Generic;

namespace Service.DataBase.Interface
{
    public interface IRectifierLogService : IService
    {
        ActResult Insert(RectifierLogDTO NewItem_);

        ActResult<RectifierLogDTO> Get();

        ActResult<List<RectifierLogDTO>> Gets(long StartTimeTicks_, long EndTimeTicks_, long Limit_, int Interval = 1);

        ActResult<List<RectifierLogDTO>> Gets(string LotNo_, long Limit_, int Interval = 1);
        ActResult Clear();
    }
}

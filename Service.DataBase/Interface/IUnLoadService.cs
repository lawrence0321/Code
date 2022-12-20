using Common;
using Common.DTO;
using Common.Interface;
using System.Collections.Generic;

namespace Service.DataBase.Interface
{
    public interface IUnLoadService : IService
    {
        ActResult<int> GetLotCount(string LotCode_);
        ActResult<string> GetLastLotNo();
        ActResult<List<UnLoadDataLogDTO>> Gets(long StartTimeTicks_, long EndTimeTicks_, long Limit_);
        ActResult<List<UnLoadDataLogDTO>> Gets(string LotNo_, long Limit_);
        ActResult Insert(UnLoadDataLogDTO value);

    }
}

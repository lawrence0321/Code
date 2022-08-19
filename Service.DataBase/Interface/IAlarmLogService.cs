using Common;
using Common.DTO;
using Common.Enums;
using Common.Interface;
using System.Collections.Generic;

namespace Service.DataBase.Interface
{
    public interface IAlarmLogService : IService
    {
        ActResult<List<AlarmLogDTO>> ExGets(long StartTimeTicks_, long EndTimeTicks_);
        ActResult<List<AlarmLogDTO>> ExGets(string LotNo_);
        ActResult Start(AlarmTypes_Part01 TypeEnum_);
        ActResult Start(AlarmTypes_Part02 TypeEnum_);
        ActResult Start(AlarmTypes_Part03 TypeEnum_);
        ActResult Start(AlarmTypes_Part04 TypeEnum_);
        ActResult Start(AlarmTypes_Part05 TypeEnum_);
        ActResult Start(AlarmTypes_Part06 TypeEnum_);
        ActResult Start(AlarmTypes_Part07 TypeEnum_);
        ActResult Start(AlarmTypes_Part08 TypeEnum_);

        ActResult Finish(AlarmTypes_Part01 TypeEnum_);
        ActResult Finish(AlarmTypes_Part02 TypeEnum_);
        ActResult Finish(AlarmTypes_Part03 TypeEnum_);
        ActResult Finish(AlarmTypes_Part04 TypeEnum_);
        ActResult Finish(AlarmTypes_Part05 TypeEnum_);
        ActResult Finish(AlarmTypes_Part06 TypeEnum_);
        ActResult Finish(AlarmTypes_Part07 TypeEnum_);
        ActResult Finish(AlarmTypes_Part08 TypeEnum_);

    }
}

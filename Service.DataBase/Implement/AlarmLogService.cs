using Common;
using Common.DTO;
using Common.Enums;
using Common.Extension;
using Repository.Entity;
using Service.DataBase.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataBase.Implement
{

    internal class AlarmLogService : IAlarmLogService
    {
        public ActResult<List<AlarmLogDTO>> ExGets(long StartTimeTicks_, long EndTimeTicks_)
        {
            using (var unitOfWork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var entities = unitOfWork.Repository<AlarmLog>()
                        .Reads(p => p.LogTimeTicks >= StartTimeTicks_ && p.LogTimeTicks <= EndTimeTicks_)
                        .Select(p => new { p.LogTimeTicks, p.AlarmNo, p.AlarmObj, p.FinishTimeTicks })
                        .OrderByDescending(p => p.LogTimeTicks)
                        .Take(10000)
                        .ToList()
                        .Select(p => new AlarmLogDTO()
                        {
                            StartLogTimeTicks = p.LogTimeTicks,
                            FinishLogTimeTicks = p.FinishTimeTicks,
                            Code = String.Format("L{0:000}", p.AlarmNo),
                            Name = p.AlarmObj.Name,
                             ZhName = p.AlarmObj.ChiName
                        })
                        .ToList();
                    if (entities.Count == 0)
                        return new ActResult<List<AlarmLogDTO>>(new List<AlarmLogDTO>());
                    else
                        return new ActResult<List<AlarmLogDTO>>(entities);
                }
                catch (Exception Ex)
                {
                    return new ActResult<List<AlarmLogDTO>>(Ex);
                }
            }
        }
        public ActResult<List<AlarmLogDTO>> ExGets(string LotNo_)
        {
            using (var unitOfWork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var loadDatas = unitOfWork.Repository<LoadData>()
                        .Reads(p => p.First_LotCode == LotNo_ || p.Second_LotCode== LotNo_ && p.IsNormalFinish &&p.FinishTimeTicks != 0).ToList();

                    if (loadDatas.Count == 0)
                        return new ActResult<List<AlarmLogDTO>>(new Exception("尚無該LotNo入料紀錄"));

                    var startTimeTicks = loadDatas.Min(p=>p.FinishTimeTicks);

                    var unLoadDataLogs = unitOfWork.Repository<UnLoadDataLog>().Reads(p => p.LotNo == LotNo_).ToList();
                    var endTimeticks = unLoadDataLogs.Max(p => p.LogTimeTicks);

                    if (unLoadDataLogs.Count == 0)
                        return new ActResult<List<AlarmLogDTO>>(new Exception("尚無該LotNo出料紀錄"));

                    return ExGets(startTimeTicks, endTimeticks);
                }
                catch (Exception Ex)
                {
                    return new ActResult<List<AlarmLogDTO>>(Ex);
                }
            }
        }


        public ActResult Start(int EnumValue_)
        {
            using (var unitOfWork = ServiceConfig.GetUnitWork())
            {
                var entity = new AlarmLog()
                {
                    AlarmNo = EnumValue_,
                    LogTimeTicks = DateTime.Now.Ticks,
                    FinishTimeTicks = 0
                };

                try
                {
                    unitOfWork.Repository<AlarmLog>().Insert(entity);
                    unitOfWork.Save();
                    return new ActResult(true);
                }
                catch (Exception Ex)
                {
                    return new ActResult(Ex);
                }
            }
        }

        public ActResult Finish(int EnumValue)
        {
            using (var unitOfWork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var entity = unitOfWork.Repository<AlarmLog>().Reads(p => p.AlarmNo == EnumValue).OrderByDescending(p => p.LogTimeTicks).First();
                    entity.FinishTimeTicks = DateTime.Now.Ticks;
                    unitOfWork.Repository<AlarmLog>().Update(entity);
                    unitOfWork.Save();
                    return new ActResult(true);
                }
                catch (Exception Ex)
                {
                    return new ActResult(Ex);
                }
            }
        }

        public ActResult Start(AlarmTypes_Part01 TypeEnum_) => Start(TypeEnum_.GetInfo().No);
        public ActResult Start(AlarmTypes_Part02 TypeEnum_) => Start(TypeEnum_.GetInfo().No);
        public ActResult Start(AlarmTypes_Part03 TypeEnum_) => Start(TypeEnum_.GetInfo().No);
        public ActResult Start(AlarmTypes_Part04 TypeEnum_) => Start(TypeEnum_.GetInfo().No);
        public ActResult Start(AlarmTypes_Part05 TypeEnum_) => Start(TypeEnum_.GetInfo().No);
        public ActResult Start(AlarmTypes_Part06 TypeEnum_) => Start(TypeEnum_.GetInfo().No);
        public ActResult Start(AlarmTypes_Part07 TypeEnum_) => Start(TypeEnum_.GetInfo().No);
        public ActResult Start(AlarmTypes_Part08 TypeEnum_) => Start(TypeEnum_.GetInfo().No);

        public ActResult Finish(AlarmTypes_Part01 TypeEnum_) => Finish(TypeEnum_.GetInfo().No);
        public ActResult Finish(AlarmTypes_Part02 TypeEnum_) => Finish(TypeEnum_.GetInfo().No);
        public ActResult Finish(AlarmTypes_Part03 TypeEnum_) => Finish(TypeEnum_.GetInfo().No);
        public ActResult Finish(AlarmTypes_Part04 TypeEnum_) => Finish(TypeEnum_.GetInfo().No);
        public ActResult Finish(AlarmTypes_Part05 TypeEnum_) => Finish(TypeEnum_.GetInfo().No);
        public ActResult Finish(AlarmTypes_Part06 TypeEnum_) => Finish(TypeEnum_.GetInfo().No);
        public ActResult Finish(AlarmTypes_Part07 TypeEnum_) => Finish(TypeEnum_.GetInfo().No);
        public ActResult Finish(AlarmTypes_Part08 TypeEnum_) => Finish(TypeEnum_.GetInfo().No);
    }
}

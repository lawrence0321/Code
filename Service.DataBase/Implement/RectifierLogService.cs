using Common;
using Common.DTO;
using Common.Enums;
using Repository.Entity;
using Service.DataBase.Interface;
using Service.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataBase.Implement
{
    internal class RectifierLogService : IRectifierLogService
    {
        public ActResult<RectifierLogDTO> Get()
        {
            try
            {
                using (var unitOfWork = ServiceConfig.GetUnitWork())
                {
                    var rangeicks = DateTime.Now.AddMinutes(-1).Ticks;
                    var sqlstr = String.Format(
                         @"SELECT *
                        FROM `{0}` AS `Log`
                        INNER JOIN (
                            SELECT `Log`.`{2}`
                            FROM `{0}` AS `Log`  
                            ORDER BY `Log`.`{2}` DESC 
                            LIMIT 1
                        ) AS `IDs` 
                        ON(`Log`.`{2}` = `IDs`.`{2}`)

                            WHERE `Log`.`{3}`>= {1}",
                       nameof(RectifierLog),
                       rangeicks,
                       nameof(RectifierLog.Rowid),
                       nameof(RectifierLog.LogTimeTicks)
                   );


                    var logs = unitOfWork.UseDapper<RectifierLogDTO>(sqlstr).ToList();
                    if (logs.Count() == 0)
                        return new ActResult<RectifierLogDTO>(new Exception("一分鐘內無更新資料"));

                    var dto = logs[0];

                    return new ActResult<RectifierLogDTO>(dto);
                }
            }
            catch (Exception Ex)
            {
                return new ActResult<RectifierLogDTO>(Ex);
            }
        }
        public ActResult<List<RectifierLogDTO>> Gets(long StartTimeTicks_, long EndTimeTicks_,long Limit_,int Interval = 1)
        {
            try
            {
                using (var unitOfWork = ServiceConfig.GetUnitWork())
                {
                    var sqlstr = String.Format(
                        @"
                        SELECT *
                        FROM `{0}` AS `Log`
                        INNER JOIN (
                            SELECT `Log`.`{4}`
                            FROM `{0}` AS `Log`  
                            WHERE `Log`.`{5}`>= {1} AND `Log`.`{5}`<= {2} 
                            ORDER BY `Log`.`{4}` DESC 
                            LIMIT {3}
                        ) AS `IDs` 
                        ON(`Log`.`{4}` = `IDs`.`{4}`) ",
                        nameof(RectifierLog),
                        StartTimeTicks_,
                        EndTimeTicks_,
                        Limit_,
                        nameof(RectifierLog.Rowid),
                        nameof(RectifierLog.LogTimeTicks)
                    );

                    var entities = unitOfWork.UseDapper<RectifierLogDTO>(sqlstr, null).ToList();
                    //var dtos = entities.Select(p=>p.ToDTO()).ToList();
                    return new ActResult<List<RectifierLogDTO>>(entities);
                }
            }
            catch (Exception Ex)
            {
                return new ActResult<List<RectifierLogDTO>>(Ex);
            }
        }

        public ActResult<List<RectifierLogDTO>> Gets(string LotNo_, long Limit_, int Interval = 1)
        {
            using (var unitOfWork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var loadDatas = unitOfWork.Repository<LoadData>()
                        .Reads(p => p.First_LotCode == LotNo_ || p.Second_LotCode == LotNo_ && p.IsNormalFinish && p.FinishTimeTicks != 0).ToList();

                    if (loadDatas.Count == 0)
                        return new ActResult<List<RectifierLogDTO>>(new Exception("尚無該LotNo入料紀錄"));

                    var startTimeTicks = loadDatas.Min(p => p.FinishTimeTicks);

                    var unLoadDataLogs = unitOfWork.Repository<UnLoadDataLog>().Reads(p => p.LotNo == LotNo_).ToList();
                    var endTimeticks = unLoadDataLogs.Max(p => p.LogTimeTicks);

                    if (unLoadDataLogs.Count == 0)
                        return new ActResult<List<RectifierLogDTO>>(new Exception("尚無該LotNo出料紀錄"));

                    return Gets(startTimeTicks, endTimeticks, Interval);
                }
                catch (Exception Ex)
                {
                    return new ActResult<List<RectifierLogDTO>>(Ex);
                }
            }
        }

        public ActResult Insert(RectifierLogDTO NewItem_)
        {
            using (var unitOfWork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var entity = NewItem_.ToEntity();
                    entity.LogTimeTicks = DateTime.Now.Ticks;

                    unitOfWork.Repository<RectifierLog>().Insert(entity);
                    unitOfWork.Save();
                    return new ActResult(true);
                }
                catch (Exception Ex)
                {
                    return new ActResult(Ex);
                }
            }
        }

        public ActResult Clear()
        {
            try
            {
                using (var unitOfWork = ServiceConfig.GetUnitWork())
                {
                    var lastMonth = DateTime.Now.AddDays(-30);
                    var rangeicks = new DateTime(lastMonth.Year, lastMonth.Month, lastMonth.Day, 0, 0, 0).Ticks;

                    var strsql = String.Format(
                        "DELETE FROM `{0}` WHERE `{1}`< {2};",
                        nameof(RectifierLog),
                        nameof(RectifierLog.LogTimeTicks),
                        rangeicks
                    );
                    unitOfWork.UseDapper<RectifierLog>(strsql);
                    return new ActResult(true);
                }
            }
            catch (Exception Ex)
            {
                return new ActResult(Ex);
            }
        }

    }
}

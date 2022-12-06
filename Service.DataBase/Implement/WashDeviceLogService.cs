using Common;
using Common.DTO;
using Repository.Entity;
using Service.DataBase.Interface;
using Service.Extension;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.DataBase.Implement
{
    internal class WashDeviceLogService : IWashDeviceLogService
    {
        public ActResult<WashDeviceLogDTO> Get()
        {
            try
            {
                using (var unitOfWork = ServiceConfig.GetUnitWork())
                {

                    var rangeicks = DateTime.Now.AddMinutes(-5).Ticks;
                    var sqlstr = String.Format(
                       @"SELECT *
                        FROM `{0}` AS `Log`
                        INNER JOIN (
                            SELECT `Log`.`{2}`
                            FROM `{0}` AS `Log`  
                            WHERE `Log`.`{3}`>= {1}
                            ORDER BY `Log`.`{2}` DESC 
                            LIMIT 1
                        ) AS `IDs` 
                        ON(`Log`.`{2}` = `IDs`.`{2}`)",
                        nameof(WashDeviceLog),
                        rangeicks,
                        nameof(WashDeviceLog.Rowid),
                        nameof(WashDeviceLog.LogTimeTicks)
                    );

                    var logs = unitOfWork.UseDapper<WashDeviceLogDTO>(sqlstr).ToList();

                    if (logs.Count() == 0)
                        return new ActResult<WashDeviceLogDTO>(new Exception("五分鐘內無更新資料"));

                    var dto = logs[0];

                    return new ActResult<WashDeviceLogDTO>(dto);
                }
            }
            catch (Exception Ex)
            {
                return new ActResult<WashDeviceLogDTO>(Ex);
            }
        }

        public ActResult<List<WashDeviceLogDTO>> Gets(long StartTimeTicks_, long EndTimeTicks_, int Limit_)
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
                    nameof(WashDeviceLog),
                    StartTimeTicks_,
                    EndTimeTicks_,
                    Limit_,
                    nameof(WashDeviceLog.Rowid),
                    nameof(WashDeviceLog.LogTimeTicks)
                );
                    var dtos = unitOfWork.UseDapper<WashDeviceLogDTO>(sqlstr, null).ToList();
                    return new ActResult<List<WashDeviceLogDTO>>(dtos);
                }
            }
            catch (Exception Ex)
            {
                return new ActResult<List<WashDeviceLogDTO>>(Ex);
            }
        }


        public ActResult<List<WashDeviceLogDTO>> Gets(string LotNo_, int Limit_)
        {
            using (var unitOfWork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var loadDatas = unitOfWork.Repository<LoadData>()
                        .Reads(p => p.First_LotCode == LotNo_ || p.Second_LotCode == LotNo_ && p.IsNormalFinish && p.FinishTimeTicks != 0).ToList();

                    if (loadDatas.Count == 0)
                        return new ActResult<List<WashDeviceLogDTO>>(new Exception("尚無該LotNo入料紀錄"));

                    var startTimeTicks = loadDatas.Min(p => p.FinishTimeTicks);

                    var unLoadDataLogs = unitOfWork.Repository<UnLoadDataLog>().Reads(p => p.LotNo == LotNo_).ToList();
                    var endTimeticks = unLoadDataLogs.Max(p => p.LogTimeTicks);

                    if (unLoadDataLogs.Count == 0)
                        return new ActResult<List<WashDeviceLogDTO>>(new Exception("尚無該LotNo出料紀錄"));

                    return Gets(startTimeTicks, endTimeticks, Limit_);
                }
                catch (Exception Ex)
                {
                    return new ActResult<List<WashDeviceLogDTO>>(Ex);
                }
            }
        }

        public ActResult Insert(WashDeviceLogDTO NewItem_)
        {
            using (var unitOfWork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var entity = NewItem_.ToEntity();
                    entity.LogTimeTicks = DateTime.Now.Ticks;

                    unitOfWork.Repository<WashDeviceLog>().Insert(entity);
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
                        nameof(WashDeviceLog),
                        nameof(WashDeviceLog.LogTimeTicks),
                        rangeicks
                    );
                    unitOfWork.UseDapper<WashDeviceLog>(strsql);
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

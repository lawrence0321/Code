﻿using Common;
using Common.DTO;
using Repository.Entity;
using Service.DataBase.Interface;
using Service.Extension;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.DataBase.Implement
{
    internal class Modbus31LogService : IModbus31LogService
    {
        public ActResult<Modbus31LogDTO> Get()
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
                        nameof(Modbus31Log),
                        rangeicks,
                        nameof(Modbus31Log.Rowid),
                        nameof(Modbus31Log.LogTimeTicks)
                    );

                    var logs = unitOfWork.UseDapper<Modbus31LogDTO>(sqlstr).ToList();
                    if (logs.Count() == 0)
                        return new ActResult<Modbus31LogDTO>(new Exception("五分鐘內無更新資料"));

                    var dto = logs[0];

                    return new ActResult<Modbus31LogDTO>(dto);
                }
            }
            catch (Exception Ex)
            {
                return new ActResult<Modbus31LogDTO>(Ex);
            }
        }

        public ActResult<List<Modbus31LogDTO>> Gets(long StartTimeTicks_, long EndTimeTicks_, int Limit_)
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
                    nameof(Modbus31Log),
                    StartTimeTicks_,
                    EndTimeTicks_,
                    Limit_,
                    nameof(Modbus31Log.Rowid),
                    nameof(Modbus31Log.LogTimeTicks)
                );
                    var dtos = unitOfWork.UseDapper<Modbus31LogDTO>(sqlstr, null).ToList();
                    return new ActResult<List<Modbus31LogDTO>>(dtos);
                }
            }
            catch (Exception Ex)
            {
                return new ActResult<List<Modbus31LogDTO>>(Ex);
            }
        }

        public ActResult<List<Modbus31LogDTO>> Gets(string LotNo_, int Limit_)
        {
            using (var unitOfWork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var loadDatas = unitOfWork.Repository<LoadData>()
                        .Reads(p => p.First_LotCode == LotNo_ || p.Second_LotCode == LotNo_ && p.IsNormalFinish && p.FinishTimeTicks != 0).ToList();

                    if (loadDatas.Count == 0)
                        return new ActResult<List<Modbus31LogDTO>>(new Exception("尚無該LotNo入料紀錄"));

                    var startTimeTicks = loadDatas.Min(p => p.FinishTimeTicks);

                    var unLoadDataLogs = unitOfWork.Repository<UnLoadDataLog>().Reads(p => p.LotNo == LotNo_).ToList();
                    var endTimeticks = unLoadDataLogs.Max(p => p.LogTimeTicks);

                    if (unLoadDataLogs.Count == 0)
                        return new ActResult<List<Modbus31LogDTO>>(new Exception("尚無該LotNo出料紀錄"));

                    return Gets(startTimeTicks, endTimeticks, Limit_);
                }
                catch (Exception Ex)
                {
                    return new ActResult<List<Modbus31LogDTO>>(Ex);
                }
            }
        }

        public ActResult Insert(Modbus31LogDTO NewItem_)
        {
            using (var unitOfWork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var entity = NewItem_.ToEntity();
                    entity.LogTimeTicks = DateTime.Now.Ticks;

                    unitOfWork.Repository<Modbus31Log>().Insert(entity);
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
                        nameof(Modbus31Log),
                        nameof(Modbus31Log.LogTimeTicks),
                        rangeicks
                    );
                    unitOfWork.UseDapper<Modbus31LogDTO>(strsql);
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

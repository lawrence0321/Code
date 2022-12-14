using Common;
using Common.DTO;
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
    internal class UnLoadService : IUnLoadService
    {

        public ActResult<List<UnLoadDataLogDTO>> Gets(string LotNo_, long Limit_)
        {

            var columns = String.Empty;
            columns += " 1 ";

            foreach (var pro in typeof(UnLoadDataLog).GetProperties())
            {
                if (typeof(UnLoadDataLogDTO).GetProperty(pro.Name) is null) continue;
                columns += String.Format(",`{0}`.`{1}` \r\n", nameof(UnLoadDataLog), pro.Name);
            }

            var sqlstr = String.Format(
                @"
                SELECT 
                {5}
                FROM `{0}`
                INNER JOIN (
                    SELECT `Log`.`{1}`
                    FROM `{0}` AS `Log`  
                    WHERE `Log`.`{2}` LIKE '{4}%'
                    ORDER BY `Log`.`{1}` DESC 
                    LIMIT {3}
                ) AS `IDs` 
                ON(`{0}`.`{1}` = `IDs`.`{1}`) 
                ORDER BY `{0}`.`{1}` DESC 
                ",
                nameof(UnLoadDataLog),
                nameof(UnLoadDataLog.Rowid),
                nameof(UnLoadDataLog.LotNo),
                Limit_,
                LotNo_,
                columns
            );

            using (var unitOfWork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var dtos = unitOfWork.UseDapper<UnLoadDataLogDTO>(sqlstr, null).ToList();
                    return new ActResult<List<UnLoadDataLogDTO>>(dtos);
                }
                catch (Exception Ex)
                {
                    return new ActResult<List<UnLoadDataLogDTO>>(Ex);
                }
            }
        }

        public ActResult<int> GetLotCount(string LotCode_)
        {

            var sqlstr = String.Format(
                @"
                SELECT 1
                FROM `{0}`
                INNER JOIN (
                    SELECT `Log`.`{1}`
                    FROM `{0}` AS `Log`  
                    WHERE `Log`.`{2}` = '{3}'
                    ORDER BY `Log`.`{1}` DESC 
                ) AS `IDs` 
                ON(`{0}`.`{1}` = `IDs`.`{1}`) 
                ORDER BY `{0}`.`{1}` DESC 
                ",
                nameof(UnLoadDataLog),
                nameof(UnLoadDataLog.Rowid),
                nameof(UnLoadDataLog.LotNo),
                LotCode_
            );

            using (var unitOfWork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var dtos = unitOfWork.UseDapper<UnLoadDataLogDTO>(sqlstr, null).ToList();
                    return new ActResult<int>(dtos.Count());
                }
                catch (Exception Ex)
                {
                    return new ActResult<int>(Ex);
                }
            }
        }

        public ActResult<string> GetLastLotNo()
        {
            var sqlstr = String.Format(
                  @"
                    SELECT `Log`.`{2}`
                    FROM `{0}` AS `Log`  
                    ORDER BY `Log`.`{1}` DESC 
                ",
                  nameof(UnLoadDataLog),
                  nameof(UnLoadDataLog.Rowid),
                  nameof(UnLoadDataLog.LotNo)
              );

            using (var unitOfWork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var lotNos = unitOfWork.UseDapper<string>(sqlstr, null).ToList();
                    return new ActResult<string>(lotNos.First());
                }
                catch (Exception Ex)
                {
                    return new ActResult<string>(Ex);
                }
            }
        }


        public ActResult<List<UnLoadDataLogDTO>> Gets(long StartTimeTicks_, long EndTimeTicks_, long Limit_)
        {

            using (var unitOfWork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var sqlstr = String.Format(
                        @"
                        SELECT * 
                        FROM {0}
                        INNER JOIN (
                            SELECT `Log`.`{1}`
                            FROM `{0}` AS `Log`  
                            WHERE `Log`.`{2}`>= {4} AND `Log`.`{2}`<= {5} 
                            ORDER BY `Log`.`{1}` DESC 
                            LIMIT {3}
                        ) AS `IDs` 
                        ON(`{0}`.`{1}` = `IDs`.`{1}`)",
                        nameof(UnLoadDataLog),
                        nameof(UnLoadDataLog.Rowid),
                        nameof(UnLoadDataLog.LogTimeTicks),
                        Limit_,
                        StartTimeTicks_,
                        EndTimeTicks_
                    );

                    var dtos = unitOfWork.UseDapper<UnLoadDataLogDTO>(sqlstr, null).ToList();
                    return new ActResult<List<UnLoadDataLogDTO>>(dtos);
                }
                catch (Exception Ex)
                {
                    return new ActResult<List<UnLoadDataLogDTO>>(Ex);
                }
            }
        }

        public ActResult Insert(UnLoadDataLogDTO DTO_)
        {
            using (var unitOfWork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var entity = DTO_.ToEntity();
                    entity.LogTimeTicks = DateTime.Now.Ticks;
                    
                    unitOfWork.Repository<UnLoadDataLog>().Insert(entity);
                    unitOfWork.Save();

                    return new ActResult(true);
                }
                catch (Exception Ex)
                {
                    return new ActResult(Ex);
                }
            }
        }
    }
}

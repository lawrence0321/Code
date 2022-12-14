using Common;
using Common.DTO;
using Common.Enums;
using Common.Extension;
using Repository.Entity;
using Service.DataBase.Interface;
using Service.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Service.DataBase.Implement
{
    internal class LoadDataService : ILoadDataService
    {
        public ActResult<LoadDataDTO> Get(string LoadDataID_) 
        {
            using (var unitwork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    //var strsql = String.Format(
                    //    @"SELECT * 
                    //    FROM {0} 
                    //    INNER JOIN (
                    //        SELECT `{1}`
                    //        FROM `{0}`
                    //        WHERE `{1}` = {2}
                    //    )AS `IDs` 
                    //    ON(`{0}`.`{1}`= `IDs`.`{1}`)
                    //    ",
                    //    nameof(LoadData),
                    //    nameof(LoadData.ID),
                    //    LoadDataID_
                    //    );

                    //var entities = unitwork.UseDapper<LoadData>(strsql).ToList();
                    //if (entities.Count() == 0)
                    //    return new ActResult<LoadDataDTO>(new Exception(String.Format("無此[{0}]LoadData紀錄", LoadDataID_)));
                    //var dto = entities[0].ToDTO();


                    var entity = unitwork.Repository<LoadData>().Read(p => p.ID == LoadDataID_);
                    if (entity is null)
                        return new ActResult<LoadDataDTO>(new Exception(String.Format("無此[{0}]LoadData紀錄",LoadDataID_)));
                    var dto = entity.ToDTO();

                    return new ActResult<LoadDataDTO>(dto);
                }
                catch (Exception Ex)
                {
                    return new ActResult<LoadDataDTO>(Ex);
                }
            }
        }


        public ActResult<int> GetLotCount(string LotCode_)
        {
            try
            {
                using (var unitwork = ServiceConfig.GetUnitWork())
                {
                    var firstcount = unitwork.Repository<LoadData>().Reads(p => p.First_LotCode == LotCode_).Count();
                    var secondcount = unitwork.Repository<LoadData>().Reads(p => p.Second_LotCode == LotCode_).Count();
                    var totalcount = firstcount + secondcount;
                    return new ActResult<int>(totalcount);
                }
            }
            catch (Exception Ex)
            {
                return new ActResult<int>(Ex);
            }
        }

        public ActResult<List<LoadDataDTO>> Gets(long StartTimeTicks_, long EndTimeTicks_, long Limit_)
        {
            var sqlstr = "SELECT * FROM loaddatas AS `LD` WHERE ";
            sqlstr += String.Format("LD.CreateTimeTicks>= {0} AND LD.CreateTimeTicks<= {1} ", StartTimeTicks_, EndTimeTicks_);
            sqlstr += "ORDER BY LD.CreateTimeTicks ";
            sqlstr += String.Format("LIMIT {0} ", Limit_);
            using (var unitOfWork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var dtos = unitOfWork.UseDapper<LoadDataDTO>(sqlstr, null).OrderByDescending(p => p.CreateTimeTicks).ToList();
                    return new ActResult<List<LoadDataDTO>>(dtos);
                }
                catch (Exception Ex)
                {
                    return new ActResult<List<LoadDataDTO>>(Ex);
                }
            }
        }


        public ActResult<LoadDataDTO> GetUnFinishFirst()
        {
            using (var unitwork = ServiceConfig.GetUnitWork())
            {
                var dto = new LoadDataDTO();
                try
                {
                    var entity = unitwork.Repository<LoadData>()
                        .Reads(p => p.FinishTimeTicks == 0 && p.Enabled)
                        .OrderBy(p => p.SortTimeTicks)
                        .First();

                    dto = entity.ToDTO();
                    return new ActResult<LoadDataDTO>(dto);
                }
                catch (Exception Ex)
                {
                    return new ActResult<LoadDataDTO>(Ex);
                }
            }
        }
        public ActResult<List<LoadDataDTO>> GetAllUnFinish()
        {
            using (var unitwork = ServiceConfig.GetUnitWork())
            {
                var dtos = new List<LoadDataDTO>();
                try
                {
                    var entities = unitwork.Repository<LoadData>().Reads(p => p.FinishTimeTicks == 0 && p.Enabled).OrderBy(p => p.SortTimeTicks).ToList();
                    foreach (var entity in entities) dtos.Add(entity.ToDTO());
                    return new ActResult<List<LoadDataDTO>>(dtos);
                }
                catch (Exception Ex)
                {
                    return new ActResult<List<LoadDataDTO>>(Ex);
                }
            }
        }

        public ActResult Insert(List<LoadDataDTO> DTO_, string EditorID_)
        {
            using (var unitwork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var unFinishEntities = unitwork.Repository<LoadData>().Reads(p => p.FinishTimeTicks == 0 && p.Enabled).OrderBy(p => p.SortTimeTicks).ToList();
                    long sortTimeTicks = 0;

                    if (unFinishEntities.Count() != 0)
                        sortTimeTicks = unFinishEntities.Last().SortTimeTicks;
                    else
                        sortTimeTicks = DateTime.Now.Ticks;

                    var entities = DTO_.Select(p => p.ToEntity()).ToList();
                    var count = 0;
                    foreach (var entity in entities)
                    {
                        sortTimeTicks += 50;
                        entity.GetNewIDAndTimeTick();
                        entity.Code = String.Format("{0}-{1:000}", new DateTime(entity.CreateTimeTicks).GetString(ExtensionDateTime.OutputTypes.TypeB), count++);
                        entity.SortTimeTicks = sortTimeTicks;
                        entity.EditorID = EditorID_;
                        entity.Enabled = true;
                        unitwork.Repository<LoadData>().Insert(entity);
                    }
                    unitwork.Save();

                    return new ActResult(true);
                }
                catch (Exception Ex)
                {
                    return new ActResult(Ex);
                }
            }
        }

        public ActResult PlugIn(List<LoadDataDTO> DTO_, long AfterSortTimeTicks_, string EditorID_)
        {
            using (var unitwork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var plugInEntities = DTO_.Select(p => p.ToEntity()).ToList();
                    var sortTimeTicks = AfterSortTimeTicks_; 
                    var count = 0;
                    foreach (var entity in plugInEntities)
                    {
                        entity.GetNewIDAndTimeTick();
                        entity.Code = String.Format("{0}-{1:000}", new DateTime(entity.CreateTimeTicks).GetString(ExtensionDateTime.OutputTypes.TypeB), count++);
                        entity.EditorID = EditorID_;
                        entity.SortTimeTicks = sortTimeTicks += 50;
                        unitwork.Repository<LoadData>().Insert(entity);
                    }

                    var entities = unitwork.Repository<LoadData>().Reads(p => p.FinishTimeTicks == 0 && p.SortTimeTicks >= AfterSortTimeTicks_ && p.Enabled).OrderBy(p=>p.SortTimeTicks).ToList();
                    foreach (var entity in entities)
                    {
                        entity.SortTimeTicks = sortTimeTicks += 50;
                        entity.EditorID = EditorID_;
                        entity.SystemLog += String.Format("Edit SortTimeTicks At {0} By {1}", DateTime.Now.Ticks, EditorID_);
                        unitwork.Repository<LoadData>().Update(entity);
                    }
                    unitwork.Save();

                    return new ActResult(true);
                }
                catch (Exception Ex)
                {
                    return new ActResult(Ex);
                }
            }
        }

        public ActResult<LoadDataDTO> Edit(LoadDataDTO DTO_, string EditorID_)
        {
            using (var unitwork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var entity = unitwork.Repository<LoadData>().Read(p => p.ID == DTO_.ID && p.Enabled);
                    if (entity is null)
                        return new ActResult<LoadDataDTO>(ExceptionTypes.NoRecorded, "無此料號");

                    var newEntity = DTO_.ToEntity();
                    newEntity.GetNewIDAndTimeTick();
                    newEntity.SortTimeTicks = entity.SortTimeTicks;
                    newEntity.SystemLog += String.Format("Create At {0}, ReplaceID:{1} By :{2}", DateTime.Now.GetString(), entity.ID, EditorID_);
                    
                    entity.FinishTimeTicks = DateTime.Now.Ticks;
                    entity.IsNormalFinish = false;
                    entity.SystemLog += String.Format("Edit At {0}, NewLoadData's ID:{1} By :{2}", DateTime.Now.GetString(), newEntity.ID, EditorID_);
                    entity.Enabled = false;

                    unitwork.Repository<LoadData>().Update(entity);
                    unitwork.Repository<LoadData>().Insert(newEntity);
                    unitwork.Save();

                    var dto = entity.ToDTO();

                    return new ActResult<LoadDataDTO>(dto);
                }
                catch (Exception Ex)
                {
                    return new ActResult<LoadDataDTO>(Ex);
                }
            }
        }

        public ActResult Finish(string ID_)
        {
            using (var unitwork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var entity = unitwork.Repository<LoadData>().Read(p => p.ID == ID_ && p.Enabled);
                    entity.FinishTimeTicks = DateTime.Now.Ticks;
                    entity.EditorID = "root";
                    entity.IsNormalFinish = true;
                    entity.Enabled = false;

                    entity.SystemLog += String.Format("Finish At {0}", DateTime.Now.Ticks);
                    unitwork.Repository<LoadData>().Update(entity);
                    unitwork.Save();

                    return new ActResult(true);
                }
                catch (Exception Ex)
                {
                    return new ActResult(Ex);
                }
            }
        }

        public ActResult ReMove(string ID_, string EditorID_)
        {
            using (var unitwork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var entity = unitwork.Repository<LoadData>().Read(p => p.ID == ID_ && p.Enabled);
                    if (entity == null) return new ActResult(new Exception(string.Format("無此 LoadData 紀錄")));
                    entity.FinishTimeTicks = DateTime.Now.Ticks;
                    entity.EditorID = EditorID_;
                    entity.IsNormalFinish = false;
                    entity.Enabled = false;

                    entity.SystemLog += String.Format("ReMove At {0} By {1}", DateTime.Now.GetString(), EditorID_);
                    unitwork.Repository<LoadData>().Update(entity);
                    unitwork.Save();

                    return new ActResult(true);
                }
                catch (Exception Ex)
                {
                    return new ActResult(Ex);
                }
            }
        }

        public ActResult ReSetQueue(string EditorID_)
        {
            using (var unitwork = ServiceConfig.GetUnitWork())
            {
                var dtos = new List<LoadDataDTO>();
                try
                {
                    var entities = unitwork.Repository<LoadData>().Reads(p => p.FinishTimeTicks != 0 && p.Enabled).ToList();
                    foreach (var entity in entities) 
                    {
                        entity.FinishTimeTicks = DateTime.Now.Ticks;
                        entity.EditorID = EditorID_;
                        entity.IsNormalFinish = false;
                        entity.Enabled = false; 
                        unitwork.Repository<LoadData>().Update(entity);
                    }
                    unitwork.Save();

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

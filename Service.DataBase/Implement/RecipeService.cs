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
using System.Text;
using System.Threading.Tasks;

namespace Service.DataBase.Implement
{
    internal class RecipeService : IRecipeService
    {
        public ActResult<RecipeDTO> Get(string RecipeCode_)
        {
            using (var unitwork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var sqlstr = String.Format(
                       @"SELECT *
                        FROM `{0}` AS `Log`
                        INNER JOIN (
                            SELECT `Log`.`{2}`
                            FROM `{0}` AS `Log`  
                            WHERE `Log`.`{3}`LIKE '%{1}%' AND `Log`.`{4}` = TRUE
                            ORDER BY `Log`.`{5}` DESC 
                            LIMIT 1
                        ) AS `IDs` 
                        ON(`Log`.`{2}` = `IDs`.`{2}`)",
                        nameof(Recipe),
                        RecipeCode_,
                        nameof(Recipe.ID),
                        nameof(Recipe.PanelCode),
                        nameof(Recipe.Enabeld),
                        nameof(Recipe.CreateTimeTicks)
                    );
                    var dtos = unitwork.UseDapper<RecipeDTO>(sqlstr).ToList();

                    if (dtos.Count() == 0)
                        return new ActResult<RecipeDTO>(ExceptionTypes.NoRecorded, "無此料號");
                    var dto = dtos[0];
                    return new ActResult<RecipeDTO>(dto);

                    //var entity = unitwork.Repository<Recipe>().Read(p => p.PanelCode == RecipeCode_ && p.Enabeld == true);
                    //if (entity is null)
                    //    return new ActResult<RecipeDTO>(ExceptionTypes.NoRecorded, "無此料號");
                    //var dto = entity.ToDTO();
                    //return new ActResult<RecipeDTO>(dto);
                }
                catch (Exception Ex)
                {
                    return new ActResult<RecipeDTO>(Ex);
                }
            }
        }

        public ActResult<List<RecipeDTO>> Gets(string PartRecipeCode_, PModeTypes PMode_, bool ShowShelfRecipe_)
        {
            using (var unitwork = ServiceConfig.GetUnitWork())
            {

                var str = String.Empty;
                if (PartRecipeCode_.Replace(" ", "") != String.Empty)
                    str += String.Format(" {0} LIKE '%{1}%' AND ", nameof(Recipe.PanelCode), PartRecipeCode_);

                if (PMode_ != PModeTypes.All)
                    str += String.Format("{0} = '{1}' AND ", nameof(Recipe.PMode), PMode_.ToString());

                if (!ShowShelfRecipe_)
                    str += String.Format("{0} = 4 AND ", nameof(Recipe.Quantity));

                var sqlstr = String.Format(
                   @"SELECT *
                    FROM `{0}` AS `Log`
                    INNER JOIN (
                        SELECT `{1}`
                        FROM `{0}`
                        WHERE `{2}` = TRUE AND {4} TRUE
                        ORDER BY `{3}` DESC 
                    ) AS `IDs` 
                    ON(`Log`.`{1}` = `IDs`.`{1}`)",
                    nameof(Recipe),
                    nameof(Recipe.ID),
                    nameof(Recipe.Enabeld),
                    nameof(Recipe.PanelCode),
                    str
                );
                var dtos = unitwork.UseDapper<RecipeDTO>(sqlstr).ToList();

                return new ActResult<List<RecipeDTO>>(dtos);

                //var strsql = String.Format("SELECT * FROM `Recipe` AS `RC` WHERE RC.Enabeld = TRUE AND ");
                //if (PartRecipeCode_.Replace(" ", "") != String.Empty)
                //    strsql += String.Format(" RC.PanelCode LIKE '%{0}%' AND ", PartRecipeCode_);
                //if (PMode_ != PModeTypes.All)
                //    strsql += String.Format("RC.PMode = '{0}' AND ", PMode_.ToString());
                //if (!ShowShelfRecipe_)
                //    strsql += String.Format("RC.Quantity = 4 AND ");
                //strsql += String.Format("TRUE ORDER BY RC.PanelCode");// LIMIT 500");
                //var entities = unitwork.UseDapper<RecipeDTO>(strsql, null).ToList();
                //return new ActResult<List<RecipeDTO>>(entities);
            }
        }


        public ActResult<List<RecipeDTO>> GetRecord(string RecipeCode_)
        {
            using (var unitwork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var sqlstr = String.Format(
                       @"SELECT *
                        FROM `{0}`
                        INNER JOIN (
                            SELECT `{1}`
                            FROM `{0}`
                            WHERE `{0}`.`{2}` = '{5}'
                            ORDER BY `{0}`.`{3}`, `{0}`.`{4}` DESC 
                        ) AS `IDs` 
                        ON(`{0}`.`{1}` = `IDs`.`{1}`)",

                        nameof(Recipe),
                        nameof(Recipe.ID),
                        nameof(Recipe.PanelCode),
                        nameof(Recipe.Enabeld),
                        nameof(Recipe.CreateTimeTicks),
                        RecipeCode_
                    );
                    var dtos = unitwork.UseDapper<RecipeDTO>(sqlstr).ToList();
                    return new ActResult<List<RecipeDTO>>(dtos);

                    //var strsql = String.Format("SELECT * FROM `Recipe` AS `RC` WHERE ");
                    //strsql += String.Format(" RC.DisplayCode = '{0}' AND ", RecipeCode_);
                    //strsql += String.Format("TRUE ORDER BY RC.Enabeld DESC , RC.CreateTimeTicks ");
                    //var entities = unitwork.UseDapper<RecipeDTO>(strsql, null).ToList();
                    //return new ActResult<List<RecipeDTO>>(entities);
                }
                catch (Exception Ex)
                {
                    return new ActResult<List<RecipeDTO>>(Ex);
                }
            }
        }

        public bool IsExist(string RecipeCode_)
        {
            using (var unitwork = ServiceConfig.GetUnitWork())
            {
                var isExist = unitwork.Repository<Recipe>().Reads(p => p.PanelCode == RecipeCode_ && p.Enabeld)
                     .Count() > 0;

                return isExist;
            }
        }

        public ActResult<RecipeDTO> Insert(RecipeDTO Recipe_, string EditorID_)
        {
            using (var unitwork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var haveSameCode = unitwork.Repository<Recipe>().Reads(p => p.PanelCode == Recipe_.PanelCode && p.Enabeld).Count() != 0;
                    if (haveSameCode)
                        return new ActResult<RecipeDTO>(ExceptionTypes.Duplicate, "重複料號");

                    var entity = Recipe_.ToEntity();
                    IDFactory.GetNewIDAndTimeTick(entity);
                    entity.DisplayCode = Recipe_.PanelCode;
                    entity.Enabeld = true;
                    entity.EditorID = EditorID_;
                    entity.SystemLog += String.Format("At {0} Create By {1}", DateTime.Now.GetString(), EditorID_);

                    unitwork.Repository<Recipe>().Insert(entity);
                    unitwork.Save();

                    var dto = entity.ToDTO();
                    return new ActResult<RecipeDTO>(dto);
                }
                catch (Exception Ex)
                {
                    return new ActResult<RecipeDTO>(Ex);
                }
            }
        }
        public ActResult Insert(RecipeDTO[] Recipes_, string EditorID_)
        {
            using (var unitwork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    foreach (var recipe in Recipes_)
                    {
                        var haveSameCode = unitwork.Repository<Recipe>().Reads(p => p.PanelCode == recipe.PanelCode && p.Enabeld).Count() != 0;
                        if (haveSameCode)
                            return new ActResult(ExceptionTypes.Duplicate, "重複料號");

                        var entity = recipe.ToEntity();
                        IDFactory.GetNewIDAndTimeTick(entity);
                        entity.DisplayCode = recipe.PanelCode;
                        entity.Enabeld = true;
                        entity.EditorID = EditorID_;
                        entity.SystemLog += String.Format("At {0} Create By {1}", DateTime.Now.GetString(), EditorID_);

                        unitwork.Repository<Recipe>().Insert(entity);
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

        public ActResult UpDate(RecipeDTO Recipe_, string EditorID_)
        {
            using (var unitwork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var recipe = unitwork.Repository<Recipe>().Read(p => p.ID == Recipe_.ID && p.Enabeld);
                    if (recipe is null)
                        return new ActResult(ExceptionTypes.NoRecorded, "無此料號");

                    var OrgRecipe_ = unitwork.Repository<Recipe>().Read(p => p.PanelCode == Recipe_.PanelCode);
                    OrgRecipe_.PanelCode = OrgRecipe_.ID;
                    OrgRecipe_.Enabeld = false;
                    OrgRecipe_.EditorID = EditorID_;

                    var entity = Recipe_.ToEntity();
                    IDFactory.GetNewIDAndTimeTick(entity);
                    entity.Enabeld = true;
                    entity.EditorID = EditorID_;
                    entity.DisplayCode = Recipe_.PanelCode;

                    entity.SystemLog += String.Format("At {0} Copy From {1} Create By {2}", DateTime.Now.GetString(), OrgRecipe_.ID, EditorID_);
                    OrgRecipe_.SystemLog += String.Format("At {0} Edit To {1} Edit By {2}", DateTime.Now.GetString(), entity.ID, EditorID_);


                    unitwork.Repository<Recipe>().Insert(entity);
                    unitwork.Repository<Recipe>().Update(OrgRecipe_);

                    unitwork.Save();
                    return new ActResult(true);
                }
                catch (Exception Ex)
                {
                    return new ActResult(Ex);
                }
            }
        }

        public ActResult UpDate(RecipeDTO[] Recipes_, string EditorID_)
        {
            using (var unitwork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    foreach (var recipe in Recipes_)
                    {
                        var entity = recipe.ToEntity();
                        IDFactory.GetNewIDAndTimeTick(entity);
                        entity.Enabeld = true;
                        entity.EditorID = EditorID_;
                        entity.DisplayCode = recipe.PanelCode;

                        var orgRecipe = unitwork.Repository<Recipe>().Read(p => p.PanelCode == recipe.PanelCode && p.Enabeld);
                        if (!(orgRecipe is null))
                        {
                            orgRecipe.PanelCode = orgRecipe.ID;
                            orgRecipe.Enabeld = false;
                            orgRecipe.EditorID = EditorID_;
                            orgRecipe.SystemLog += String.Format("At {0} Edit To {1} Edit By {2}", DateTime.Now.GetString(), entity.ID, EditorID_);

                            entity.SystemLog += String.Format("At {0} Copy From {1} Create By {2}", DateTime.Now.GetString(), orgRecipe.ID, EditorID_);

                            unitwork.Repository<Recipe>().Update(orgRecipe);
                        }
                        else
                        {
                            entity.SystemLog += String.Format("At {0} Create By {1}", DateTime.Now.GetString(), EditorID_);
                        }
                        unitwork.Repository<Recipe>().Insert(entity);
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


        public ActResult Delete(string PenalCode_, string EditorID_)
        {
            using (var unitwork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var recipe = unitwork.Repository<Recipe>().Read(p => p.PanelCode == PenalCode_ && p.Enabeld);
                    if (recipe is null)
                        return new ActResult(ExceptionTypes.NoRecorded, "無此料號");
                    var panelCode = recipe.PanelCode;
                    recipe.PanelCode = recipe.ID;
                    recipe.Enabeld = false;
                    recipe.SystemLog += String.Format("At {0} Delete By {1}", DateTime.Now.GetString(), EditorID_);

                    unitwork.Repository<Recipe>().Update(recipe);
                    unitwork.Save();
                    return new ActResult(true);
                }
                catch (Exception Ex)
                {
                    return new ActResult(Ex);
                }
            }
        }

        public ActResult Delete(string[] PanelCodes_, string EditorID_)
        {
            using (var unitwork = ServiceConfig.GetUnitWork())
            {
                try
                {
                    var recipes = unitwork.Repository<Recipe>().Reads(p => PanelCodes_.Contains(p.PanelCode)).ToList();

                    foreach (var recipe in recipes)
                    {
                        var panelCode = recipe.PanelCode;
                        recipe.PanelCode = recipe.ID;
                        recipe.Enabeld = false;
                        recipe.SystemLog += String.Format("At {0} Delete By {1}", DateTime.Now.GetString(), EditorID_);

                        unitwork.Repository<Recipe>().Update(recipe);
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

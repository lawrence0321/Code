using Common;
using Common.DTO;
using Common.Enums;
using Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataBase.Interface
{

    public interface IRecipeService : IService
    {
        bool IsExist(string RecipeCode_);

        ActResult<RecipeDTO> Get(string RecipeCode_);

        ActResult<List<RecipeDTO>> Gets(string PartRecipeCode_, PModeTypes PMode_, bool ShowShelfRecipe_);

        ActResult<List<RecipeDTO>> GetRecord(string RecipeCode_);

        ActResult<RecipeDTO> Insert(RecipeDTO Recipe_, string EditorID_);

        ActResult UpDate(RecipeDTO Recipe_, string EditorID_);

        ActResult Delete(string ID_, string EditorID_);

        ActResult Insert(RecipeDTO[] Recipes_, string EditorID_);

        ActResult UpDate(RecipeDTO[] Recipes_, string EditorID_);

        ActResult Delete(string[] IDs_, string EditorID_);
    }


}

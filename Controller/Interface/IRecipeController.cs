using Common;
using Common.DTO;
using Common.Enums;
using Common.ExConfig;
using Common.Interface;
using System.Collections.Generic;

namespace Controller.Interface
{
    public interface IRecipeController:IController
    {
        /// <summary>
        /// DummyRecipe
        /// </summary>
        RecipeDTO DummyRecipe { get; }

        ConvertConfig NowConvertConfig { get; }

        CurrentConfig NowCurrentConfig { get; }

        ProcessConfig NowProcessConfig { get; }

        ActResult SetConvertConfig(ConvertConfig ConvertConfig_);

        ActResult SetCurrentConfig(CurrentConfig CurrentConfig_);

        ActResult SetProcessConfig(ProcessConfig ProcessConfig_);

        /// <summary>
        /// 取得Recipe
        /// </summary>
        /// <param name="RecipeCode_">Recipe ID</param>
        /// <returns></returns>
        ActResult<RecipeDTO> Get(string RecipeCode_);

        /// <summary>
        /// 轉換Recipe
        /// </summary>
        /// <param name="Recipe_">配方</param>
        /// <param name="Quantity_">尾掛數量</param>
        /// <returns></returns>
        ActResult<RecipeDTO> ConvertShelf(RecipeDTO Recipe_, int Quantity_);

        /// <summary>
        /// 創建新Recipe
        /// </summary>
        /// <param name="Recipe_">新Recipe內容</param>
        /// <param name="EditorID_">編輯者ID</param>
        /// <returns></returns>
        ActResult<RecipeDTO> Create(RecipeDTO Recipe_, string EditorID_);
        /// <summary>
        /// 修改新Recipe
        /// </summary>
        /// <param name="Recipe_">新Recipe內容</param>
        /// <param name="EditorID_">編輯者ID</param>
        /// <returns></returns>
        ActResult Edit(RecipeDTO Recipe_, string EditorID_);
        /// <summary>
        /// 刪除新Recipe
        /// </summary>
        /// <param name="RecipeID_">愈刪除Recipe's Code</param>
        /// <param name="EditorID_">編輯者ID</param>
        /// <returns></returns>
        ActResult Remove(string RecipeCode_, string EditorID_);
        /// <summary>
        /// 查詢Recipe
        /// </summary>
        /// <param name="PartCode_">部分PanelCode</param>
        /// <param name="PMode_">作業模式</param>
        /// <param name="IsShowShelf_">是否要顯示尾掛Recipe</param>
        /// <returns></returns>
        ActResult<List<RecipeDTO>> Search(string PartCode_, PModeTypes PMode_, bool IsShowShelf_ = false);
        /// <summary>
        /// 查詢所有紀錄
        /// </summary>
        /// <param name="RecipeCode_">PanelCode</param>
        /// <returns></returns>
        ActResult<List<RecipeDTO>> GetRecord(string RecipeCode_);
    }

}

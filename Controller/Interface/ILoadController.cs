using Common;
using Common.DTO;
using Common.Enums;
using Common.Interface;
using Service.MES.Enums;
using System;
using System.Collections.Generic;

namespace Controller.Interface
{
    public interface ILoadController : IController
    {

        string DummyLotCode { get; }

        /// <summary>
        /// 作業模式
        /// </summary>
        StatusTypes StatusType { get; }

        /// <summary>
        /// 取得LoadData
        /// </summary>
        ActResult<LoadDataDTO> Get(string LoadDataID_);

        /// <summary>
        /// 待生產LoadData
        /// </summary>
        ActResult<List<LoadDataDTO>> GetPrepList();

        /// <summary>
        /// 改變作業模式
        /// </summary>
        void ChangeStatusType();

        /// <summary>
        /// 改變檢查項目
        /// </summary>
        void SetCheckItemType(CheckItemTypes NewValue, string UID_);

        /// <summary>
        /// 待生產LoadDataList改變事件
        /// </summary>
        event EventHandler PerListChanged;
        /// <summary>
        /// 需要更新LoadDataList
        /// </summary>
        bool NeedUpdatePerList { get; set; }
        /// <summary>
        /// 編輯LoadData
        /// </summary>
        /// <param name="LoadData_"></param>
        /// <returns></returns>
        ActResult EditLoadData(LoadDataDTO LoadData_, string EditorID_);

        /// <summary>
        /// 插入LoadData
        /// </summary>
        /// <param name="LoadDatas_"></param>
        /// <param name="EditorID_"></param>
        /// <returns></returns>
        ActResult PlugIn(List<LoadDataDTO> LoadDatas_, long AfterSortTimeTicks_, string EditorID_);
        /// <summary>
        /// 加入LoadData
        /// </summary>
        /// <param name="LoadDatas_"></param>
        /// <returns></returns>
        ActResult Enqueue(List<LoadDataDTO> LoadDatas_, string EditorID_);
        /// <summary>
        /// 將指定LoadData移除待生產序列中
        /// </summary>
        /// <param name="DTO_"></param>
        /// <returns></returns>
        ActResult ReMove(string LoadDataID_, string EditorID_);
        /// <summary>
        /// 移除待生產序列中所有LoadData
        /// </summary>
        /// <returns></returns>
        ActResult RemoveAll(string EditorID_);
        /// <summary>
        /// 重置待生產序列
        /// </summary>
        /// <returns></returns>
        ActResult ReSetQueue(string EditorID_);

        ActResult Finish(string LoadDataID_);

        /// <summary>
        /// 取得 Dummy's LoadData
        /// </summary>
        /// <param name="CraneQuantity_">天車數量</param>
        /// <param name="EditorID_">編輯者</param>
        /// <returns></returns>
        ActResult<List<LoadDataDTO>> CreateDummyLoadData(int CraneQuantity_, string EditorID_);
        /// <summary>
        /// 取得自訂模式's LoadData
        /// </summary>
        /// <param name="SpecialMode_">是否使用特殊模式</param>
        /// <param name="Quantity_">總片數</param>
        /// <param name="LotCode_">生產批號</param>
        /// <param name="EditorID_">員工工號</param>
        /// <param name="FullShelfRecipe_">滿掛Recipe</param>
        /// <returns></returns>
        ActResult<List<LoadDataDTO>> CreateLoadDataByCustom(bool SpecialMode_, int Quantity_, string LotCode_, string EditorID_, RecipeDTO FullShelfRecipe_);
        /// <summary>
        /// 取得 MES's LoadData
        /// </summary>
        /// <param name="SpecialMode_">是否使用特殊模式</param>
        /// <param name="Quantity_">總片數</param>
        /// <param name="LotCode_">生產批號</param>
        /// <param name="EditorID_">員工工號</param>
        /// <param name="CheckItemTypes_">檢查項目</param>
        /// <param name="ThermostatLog_">當前溫度紀錄</param>
        /// <param name="Modbus31LogDTO_">當前Modbus31紀錄</param>
        /// <param name="Modbus32LogDTO_">當前Modbus32紀錄</param>
        /// <returns></returns>
        ActResult<List<LoadDataDTO>> CreateLoadDataByMES(bool SpecialMode_, int Quantity_, string LotCode_, string EditorID_);

        /// <summary>
        /// 查詢Recipe
        /// </summary>
        /// <param name="PartCode_">部分RecipeCode</param>
        /// <param name="PMode_">作業模式</param>
        /// <param name="IsShowShelf_">是否顯示尾掛Recipe</param>
        /// <returns></returns>
        ActResult<List<RecipeDTO>> SearchRecipe(string PartCode_, PModeTypes PMode_, bool IsShowShelf_ = false);
    }

}

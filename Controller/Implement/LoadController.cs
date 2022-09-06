using Common;
using Common.DTO;
using Common.Enums;
using Common.Extension;
using Controller.ExObject;
using Controller.Interface;
using Service.DataBase.Interface;
using Service.MES.Enums;
using Service.CSV;
using Service.CSV.Interface;
using Service.MES.Extension;
using Service.MES.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Controller.Implement
{

    internal class LoadController : ILoadController
    {
        public StatusTypes StatusType { get; private set; }



        public event EventHandler PerListChanged;

        ILoadDataService LoadDataService => ControllerConfig.GetService<ILoadDataService>();
        IRecipeService RecipeService => ControllerConfig.GetService<IRecipeService>();
        IMESService MESService => ControllerConfig.GetService<IMESService>();

        IRecipeController RecipeController => AutofacConfig.Resolve<IRecipeController>();
        IMESController MESController => AutofacConfig.Resolve<IMESController>();
        IDeviceController DeviceController => AutofacConfig.Resolve<IDeviceController>();


        public string DummyLotCode => "(RackOnly)";

        public bool NeedUpdatePerList { get; set; }

        public LoadController()
        {
            StatusType = StatusTypes.Manual;
        }
        public void ChangeStatusType()
        {
            StatusType = (StatusType == StatusTypes.Auto) ? StatusTypes.Manual : StatusTypes.Auto;
        }

        public ActResult<LoadDataDTO> Get(string LoadDataID_)
            => LoadDataService.Get(LoadDataID_);

        public ActResult<List<LoadDataDTO>> GetPrepList()
            => LoadDataService.GetAllUnFinish();


        public ActResult Finish(string LoadDataID_)
        {
            var r1 = LoadDataService.Finish(LoadDataID_);
            
            if (r1.Result)
            {
                NeedUpdatePerList = true;
            }
            return r1;
        }


        public void SetCheckItemType(CheckItemTypes NewValue, string UID_)
        { 

        }

        private List<LoadDataDTO> CreateLoadDatas(LoadSourceTypes LoadSourceType_, bool SpecialMode_, int Quantity_, string LotCode_, string EditorID_, RecipeDTO FullShelfRecipe_, RecipeDTO ShelfRecipe_)
        {
            var list = new List<LoadDataDTO>();

            //是否為特規掛數
            if (!SpecialMode_)
            {
                //滿車的數量
                var quantity = Quantity_ / 8;
                for (int index = 0; index < quantity; index++)
                {
                    var loadData = LoadDataLogic.Create(LoadSourceType_, EditorID_, LotCode_, FullShelfRecipe_);
                    list.Add(loadData);
                }

                //剩餘數量
                var leftQuantity = Quantity_ % 8;
                
                if (leftQuantity == 4)
                {
                    var otherloadData = LoadDataLogic.Create(LoadSourceType_, EditorID_, DummyLotCode, RecipeController.DummyRecipe, LotCode_, FullShelfRecipe_);
                    list.Add(otherloadData);
                }
                else if (leftQuantity != 0)
                {
                    if (leftQuantity > 4)
                    {
                        var otherloadData = LoadDataLogic.Create(LoadSourceType_, EditorID_, LotCode_, FullShelfRecipe_ , LotCode_, ShelfRecipe_);
                        list.Add(otherloadData);
                    }
                    else
                    {
                        var otherloadData = LoadDataLogic.Create(LoadSourceType_, EditorID_, DummyLotCode, RecipeController.DummyRecipe, LotCode_, ShelfRecipe_);
                        list.Add(otherloadData);
                    }
                }
            }
            else
            {
                //單掛的總數量
                var quantity = Quantity_ / 4;

                for (int index = 0; index < quantity; index++)
                {
                    var loadData = LoadDataLogic.Create(LoadSourceType_, EditorID_, DummyLotCode, RecipeController.DummyRecipe, LotCode_, FullShelfRecipe_);
                    list.Add(loadData);
                }
                if (Quantity_ % 4 != 0)
                {
                    //剩餘數量
                    var otherloadData = LoadDataLogic.Create(LoadSourceType_, EditorID_, DummyLotCode, RecipeController.DummyRecipe, LotCode_, ShelfRecipe_);
                    list.Add(otherloadData);
                }
            }
            return list;
        }

        public ActResult<List<LoadDataDTO>> CreateLoadDataByMES(bool SpecialMode_, int Quantity_, string LotCode_, string EditorID_)
        {
            try
            {
                if (!MESService.IsConnect) return new ActResult<List<LoadDataDTO>>(new Exception("無法與MES建立連線"));

                var r1 = MESService.GetMESObject(LotCode_, EditorID_);

                if (!r1.Result)
                {
                    switch (r1.ExceptionType)
                    {
                        case ExceptionTypes.EmptyRecipe:break;


                        case ExceptionTypes.LotNotOnline:
                            return new ActResult<List<LoadDataDTO>>(new Exception(String.Format("從MES取得Recipe失敗，錯誤訊息:此批未上機")));
                        case ExceptionTypes.WrongUserID:
                            return new ActResult<List<LoadDataDTO>>(new Exception(String.Format("從MES取得Recipe失敗，錯誤訊息:無此無塵衣號碼紀錄")));
                        default:
                            return new ActResult<List<LoadDataDTO>>(new Exception(String.Format("從MES取得Recipe失敗，錯誤訊息:{0}", r1.Exception.Message)));
                    }
                }

                var returnLotno = String.Empty;
                var recipeName = String.Empty;

                if (r1.Result == false)
                {
                    if (r1.ExceptionType != ExceptionTypes.EmptyRecipe)
                        return new ActResult<List<LoadDataDTO>>(new Exception(String.Format("從MES取得Recipe失敗，錯誤訊息:{0},原始命令:{1}", "AE2TalkObjectV2 為空值.", r1.Remarks)));
                    else
                    {
                        returnLotno = LotCode_;
                        recipeName = r1.Remarks;
                    }
                }
                else
                {
                    returnLotno = r1.Value.LotNo;
                    recipeName = r1.Value.ToRecipe().PanelCode;
                }

                if (returnLotno != LotCode_)
                    return new ActResult<List<LoadDataDTO>>(new Exception(String.Format("從MES取得Recipe失敗，錯誤訊息:{0}", "MES回覆LotNo與原發送LotNo不相符")));

                RecipeDTO dbRecipe;
                var isRecipeExist = RecipeService.IsExist(recipeName);

                if (isRecipeExist)
                {
                    var r2 = RecipeService.Get(recipeName);
                    if (!r2.Result) return new ActResult<List<LoadDataDTO>>(new Exception(String.Format("從DataBase取得Recipe失敗，錯誤訊息:{0}", r2.Exception.Message)));
                    dbRecipe = r2.Value;
                    if (r1.ExceptionType == ExceptionTypes.EmptyRecipe)
                    {
                        var r3 = MESService.SendCreateRecipeNotify(dbRecipe);
                        if (!r3.Result)
                        {
                            var msgs = r3.Exception.Message.Replace("Eqp_Name:M0000802", "").Split(',');
                            var msg = msgs[1] + msgs[2];
                            return new ActResult<List<LoadDataDTO>>(new Exception(msg));
                        }
                    }
                    else
                    {
                        var aE2Talk = r1.Value;//拆

                        var checkItem = MESController.CheckItem;

                        var th = DeviceController.GetNowThermostatLog();
                        if (!th.Result)
                        {
                            return new ActResult<List<LoadDataDTO>>(new Exception(String.Format("取得{0}失敗，原因:{1}", "溫控器紀錄", th.Exception.Message)));
                        }

                        var m31 = DeviceController.GetNowModbus31Log();
                        if (!m31.Result)
                        {
                            return new ActResult<List<LoadDataDTO>>(new Exception(String.Format("取得{0}失敗，原因:{1}", "Modbus31紀錄", m31.Exception.Message)));
                        }

                        var m32 = DeviceController.GetNowModbus32Log();
                        if (!m32.Result)
                        {
                            return new ActResult<List<LoadDataDTO>>(new Exception(String.Format("取得{0}失敗，原因:{1}", "Modbus32紀錄", m32.Exception.Message)));
                        }


                        var r3 = MESService.RecipeComparison(LotCode_, EditorID_, aE2Talk, dbRecipe, checkItem, th.Value, m31.Value, m32.Value);

                        if (!r3.Result) return new ActResult<List<LoadDataDTO>>(new Exception(String.Format("參數比對失敗，錯誤訊息:{0}", m32.Exception.Message)));
                    }
                }
                else if (r1.Result)
                {
                    var mesRecipe = r1.Value.ToRecipe();

                    var r2 = RecipeController.ConvertShelf(mesRecipe, 1);
                    var r3 = RecipeController.ConvertShelf(mesRecipe, 2);
                    var r4 = RecipeController.ConvertShelf(mesRecipe, 3);

                    if (!(r2.Result && r3.Result && r4.Result))
                    {
                        var errormsg = String.Empty;
                        errormsg += r2.Result ? "" : r2.Exception.Message;
                        errormsg += r3.Result ? "" : r3.Exception.Message;
                        errormsg += r4.Result ? "" : r4.Exception.Message;

                        return new ActResult<List<LoadDataDTO>>(new Exception(String.Format("自動產生尾掛Recipe失敗，錯誤訊息:{0}", errormsg)));
                    }

                    var r5 = RecipeService.Insert(new RecipeDTO[] { mesRecipe, r4.Value, r3.Value, r2.Value }, EditorID_);
                    if (!r5.Result)
                        return new ActResult<List<LoadDataDTO>>(new Exception(String.Format("從DataBase新增Recipe失敗，錯誤訊息:{0}", r5.Exception.Message)));
                    else
                    {
                        MESService.SendCreateEndshiftRecipeNotify(r2.Value);
                        MESService.SendCreateEndshiftRecipeNotify(r3.Value);
                        MESService.SendCreateEndshiftRecipeNotify(r4.Value);
                    }
                    var r6 = RecipeService.Get(mesRecipe.PanelCode);
                    if (!r6.Result) return new ActResult<List<LoadDataDTO>>(new Exception(String.Format("從DataBase查詢Recipe失敗，錯誤訊息:{0}", r6.Exception.Message)));

                    dbRecipe = r6.Value;
                }
                else
                {
                    return new ActResult<List<LoadDataDTO>>(new Exception("MES與資料庫皆無此Recipe紀錄 拒絕操作"));
                }

                //尾掛Recipe相關
                var shelfQuantity = Quantity_ % 4;
                RecipeDTO shelfDBRecipe = RecipeController.DummyRecipe;
                if (shelfQuantity != 0)
                {
                    var shelfRecipeName = dbRecipe.PanelCode.Substring(0, dbRecipe.PanelCode.Length - 1) + shelfQuantity.ToString();

                    var isSheetRecipeExistDB = RecipeService.IsExist(shelfRecipeName);

                    if (isSheetRecipeExistDB)
                    {
                        var r4 = RecipeService.Get(shelfRecipeName);
                        if (!r4.Result) return new ActResult<List<LoadDataDTO>>(new Exception(String.Format("從DataBase取得尾掛Recipe失敗，錯誤訊息:{0}", r4.Exception.Message)));
                        shelfDBRecipe = r4.Value;

                        var r5 = MESService.GetEndShelfMESObject(shelfRecipeName);
                        if (!r5.Result)
                        {
                            //上拋尾掛
                            var r51 = MESService.SendCreateEndshiftRecipeNotify(r4.Value);
                            if (r51.Result)
                            {
                                var msgs = r51.Exception.Message.Replace("Eqp_Name:M0000802", "").Split(',');
                                var msg = msgs[1] + msgs[2];
                                return new ActResult<List<LoadDataDTO>>(new Exception(msg));
                            }
                        }
                        else
                        {
                            var shelfMESObj = r5.Value;

                            var th = DeviceController.GetNowThermostatLog();
                            if (!th.Result)
                            {
                                return new ActResult<List<LoadDataDTO>>(new Exception(String.Format("取得{0}失敗，原因:{1}", "溫控器紀錄", th.Exception.Message)));
                            }

                            var m31 = DeviceController.GetNowModbus31Log();
                            if (!m31.Result)
                            {
                                return new ActResult<List<LoadDataDTO>>(new Exception(String.Format("取得{0}失敗，原因:{1}", "Modbus31紀錄", m31.Exception.Message)));
                            }

                            var m32 = DeviceController.GetNowModbus32Log();
                            if (!m32.Result)
                            {
                                return new ActResult<List<LoadDataDTO>>(new Exception(String.Format("取得{0}失敗，原因:{1}", "Modbus32紀錄", m32.Exception.Message)));
                            }
                            var checkItem = MESController.CheckItem;


                            var r6 = MESService.RecipeComparison(LotCode_, EditorID_, shelfMESObj, shelfDBRecipe, checkItem, th.Value, m31.Value, m32.Value);


                            if (!r6.Result) return new ActResult<List<LoadDataDTO>>(new Exception(String.Format("尾掛參數比對失敗，錯誤訊息:{0}", r6.Exception.Message)));
                        }
                    }
                    else
                    {
                        var r7 = RecipeController.ConvertShelf(dbRecipe, shelfQuantity);

                        if (!r7.Result)
                            return new ActResult<List<LoadDataDTO>>(new Exception(String.Format("轉化尾掛Recipe失敗，錯誤訊息:{0}", r7.Exception.Message)));
                        else
                        {
                            shelfDBRecipe = r7.Value;
                            var r8 = RecipeService.Insert(r7.Value, EditorID_);
                            if (!r8.Result)
                                return new ActResult<List<LoadDataDTO>>(new Exception(String.Format("從DataBase新增Recipe失敗，錯誤訊息:{0}", r8.Exception.Message)));
                            else
                                MESService.SendCreateEndshiftRecipeNotify(r7.Value);
                        }
                    }
                }

                var list = CreateLoadDatas(LoadSourceTypes.MES, SpecialMode_, Quantity_, returnLotno, EditorID_, dbRecipe, shelfDBRecipe);

                return new ActResult<List<LoadDataDTO>>(list);
            }
            catch (Exception Ex)
            {
                return new ActResult<List<LoadDataDTO>>(Ex);
            }
        }

        public ActResult<List<LoadDataDTO>> CreateLoadDataByCustom(bool SpecialMode_, int Quantity_, string LotCode_, string EditorID_, RecipeDTO FullShelfRecipe_)
        {
            try
            {
                var shelfQuantity = Quantity_ % 4;

                var shelfRecipeName = FullShelfRecipe_.PanelCode.Substring(0, FullShelfRecipe_.PanelCode.Length - 1) + shelfQuantity.ToString();

                RecipeDTO shelfRecipe;
                if (shelfQuantity == 0)
                {
                    shelfRecipe = RecipeController.DummyRecipe;
                }
                else
                {
                    var isRecipeExist = RecipeService.IsExist(shelfRecipeName);
                    if (!isRecipeExist)
                    {
                        var r1 = RecipeController.ConvertShelf(FullShelfRecipe_, shelfQuantity);
                        if (!r1.Result) return new ActResult<List<LoadDataDTO>>(new Exception(String.Format("創建尾掛Recipe失敗，錯誤訊息:{0}", r1.Exception.Message)));
                        shelfRecipe = r1.Value;
                    }
                    else
                    {
                        var r1 = RecipeService.Get(shelfRecipeName);
                        if (!r1.Result) return new ActResult<List<LoadDataDTO>>(new Exception(String.Format("從DataBase讀取尾掛Recipe失敗，錯誤訊息:{0}", r1.Exception.Message)));
                        shelfRecipe = r1.Value;
                    }
                }
                var list = CreateLoadDatas(LoadSourceTypes.Custom, SpecialMode_, Quantity_, LotCode_, EditorID_, FullShelfRecipe_, shelfRecipe);
                return new ActResult<List<LoadDataDTO>>(list);
            }
            catch (Exception Ex)
            {
                return new ActResult<List<LoadDataDTO>>(Ex);
            }
        }

        public ActResult<List<LoadDataDTO>> CreateDummyLoadData(int CraneQuantity_, string EditorID_)
        {
            try
            {
                var quantity = CraneQuantity_ * 8;
                var list = CreateLoadDatas(LoadSourceTypes.Custom, false, quantity, DummyLotCode, EditorID_, RecipeController.DummyRecipe, RecipeController.DummyRecipe);
                return new ActResult<List<LoadDataDTO>>(list);
            }
            catch (Exception Ex)
            {
                return new ActResult<List<LoadDataDTO>>(Ex);
            }
        }

        public ActResult EditLoadData(LoadDataDTO DTO_, string EditorID_)
        {
            try
            {
                if (StatusType != StatusTypes.Manual) return new ActResult(new Exception("生產中，禁止編輯"));

                var result = LoadDataService.Edit(DTO_,EditorID_);

                if (!result.Result) return new ActResult(new Exception(String.Format("Error From LoadDataService.EditLoadData({0}) : {1}", DTO_.ToJson(), result.Exception.Message)));
                
                PerListChanged?.Invoke(this,null);

                return new ActResult(true);
            }
            catch (Exception Ex)
            {
                return new ActResult(Ex);
            }
        }

        public ActResult Enqueue(List<LoadDataDTO> DTOs_, string EditorID_)
        {
            try
            {
                var result = LoadDataService.Insert(DTOs_, EditorID_);

                if (!result.Result) return new ActResult(new Exception(String.Format("Error From LoadDataService.Enqueue({0}) : {1}", DTOs_.ToJson(), result.Exception.Message)));

                PerListChanged?.Invoke(this, null);
                return new ActResult(true);
            }
            catch (Exception Ex)
            {
                return new ActResult(Ex);
            }
        }

        public ActResult PlugIn(List<LoadDataDTO> DTOs_, long AfterSortTimeTicks_, string EditorID_)
        {
            try
            {
                if (StatusType != StatusTypes.Manual) return new ActResult(new Exception("生產中，禁止編輯"));

                var result = LoadDataService.PlugIn(DTOs_, AfterSortTimeTicks_, EditorID_);

                if (!result.Result) return new ActResult(new Exception(String.Format("Error From LoadDataService.PlugIn({0}) : {1}", DTOs_.ToJson(), result.Exception.Message)));

                PerListChanged?.Invoke(this, null);
                return new ActResult(true);
            }
            catch (Exception Ex)
            {
                return new ActResult(Ex);
            }
        }


        public ActResult ReMove(string LoadDataID_, string EditorID_)
        {
            try
            {
                if (StatusType != StatusTypes.Manual) return new ActResult(new Exception("生產中，禁止編輯"));

                var r1 = LoadDataService.ReMove(LoadDataID_, EditorID_);

                if (!r1.Result) return new ActResult(new Exception(String.Format("Fail Form LoadDataService.ReMove({0}) : {1}", LoadDataID_, r1.Exception.Message)));

                var newDTO = r1.Value;

                var r2 = LoadDataService.GetAllUnFinish();
                if (!r1.Result) return new ActResult(new Exception(String.Format("Error Form LoadDataService.GetAllUnFinish() : {0}", r1.Exception.Message)));

                PerListChanged?.Invoke(this, null);
                return new ActResult(true);
            }
            catch (Exception Ex)
            {
                return new ActResult(Ex);
            }
        }

        public ActResult RemoveAll(string EditorID_)
        {
            try
            {
                if (StatusType != StatusTypes.Manual) return new ActResult(new Exception("生產中，禁止編輯"));

                var r1 = LoadDataService.GetAllUnFinish();

                if (!r1.Result) return new ActResult(new Exception(String.Format("Error Form LoadDataService.GetAllUnFinish(): {0}", r1.Exception.Message)));

                var dtos = r1.Value;

                foreach (var dto in dtos)
                {
                    LoadDataService.ReMove(dto.ID, EditorID_);
                }

                PerListChanged?.Invoke(this, null);
                return new ActResult(true);
            }
            catch (Exception Ex)
            {
                return new ActResult(Ex);
            }
        }

        public ActResult ReSetQueue(string EditorID_)
        {
            try
            {
                if (StatusType != StatusTypes.Manual) return new ActResult(new Exception("生產中，禁止編輯"));

                var r1 = LoadDataService.ReSetQueue(EditorID_);

                if (!r1.Result) return new ActResult(new Exception(String.Format("Error Form LoadDataService.ReSetQueue : {0}", r1.Exception.Message)));

                PerListChanged?.Invoke(this, null);
                return new ActResult(true);
            }
            catch (Exception Ex)
            {
                return new ActResult(Ex);
            }
        }

        public ActResult<List<RecipeDTO>> SearchRecipe(string PartCode_, PModeTypes PMode_, bool IsShowShelf_)
            => RecipeController.Search(PartCode_, PMode_, IsShowShelf_);
    }


}

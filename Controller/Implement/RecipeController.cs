using Common;
using Common.DTO;
using Common.Enums;
using Common.ExConfig;
using Common.Extension;
using Controller.Interface;
using Service.DataBase.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controller.Implement
{
    internal class RecipeController : IRecipeController
    {
        public RecipeDTO DummyRecipe => _DummyRecipe;

        readonly RecipeDTO _DummyRecipe;

        public ConvertConfig NowConvertConfig
        {
            get
            {
                if (_NowConvertConfig is null)
                    _NowConvertConfig = DefaultConfig.ConvertConfig;
                return _NowConvertConfig;
            }
        }
        public ConvertConfig _NowConvertConfig;

        public CurrentConfig NowCurrentConfig
        {
            get
            {
                if (_NowCurrentConfig is null)
                    _NowCurrentConfig = DefaultConfig.CurrentConfig;
                return _NowCurrentConfig;
            }
        }
        public CurrentConfig _NowCurrentConfig;

        public ProcessConfig NowProcessConfig
        {
            get
            {
                if (_NowProcessConfig is null)
                    _NowProcessConfig = DefaultConfig.ProcessConfig;
                return _NowProcessConfig;
            }
        }
        public ProcessConfig _NowProcessConfig;

        IRecipeService RecipeService => ControllerConfig.GetService<IRecipeService>();


        public RecipeController()
        {
            _DummyRecipe = new RecipeDTO()
            {
                ID = "DummyRecipe",
                PanelCode = "Dummy",
                DisplayCode = "Dummy",
                CreateTimeTicks = new DateTime(2021, 01, 01, 00, 00, 00).Ticks,
                EditorID = "root",
                Quantity = 0,
                PMode = " ",
                Size = " ",
                Thickness = 0,
                Ni_WB_Adm2 = 0,
                Ni_B_Adm2 = 0,
                Ni_PlatingTime = 2010,
                Au_WB_Adm2 = 0,
                Au_B_Adm2 = 0,
                Au_PlatingTime = 290,
                AuSt_Adm2 = 0,
                AuSt_PlatingTime = 20,
                WBArea = 0,
                BArea = 0,
                Enabeld = true,
                Remarks = "Dummy Recipe",
                SystemLog = "Dummy Recipe",
                 
            };
        }

        public ActResult SetConvertConfig(ConvertConfig ConvertConfig_)
        {
            try
            {
                if (ConvertConfig_ == null)
                    _NowConvertConfig = DefaultConfig.ConvertConfig;
                else
                    _NowConvertConfig = ConvertConfig_;

                return new ActResult(true);
            }
            catch (Exception Ex)
            {
                _NowConvertConfig = DefaultConfig.ConvertConfig;

                return new ActResult(Ex);
            }
        }

        public ActResult SetCurrentConfig(CurrentConfig CurrentConfig_)
        {
            try
            {
                if (CurrentConfig_ == null)
                    _NowCurrentConfig = DefaultConfig.CurrentConfig;
                else
                    _NowCurrentConfig = CurrentConfig_;

                return new ActResult(true);
            }
            catch (Exception Ex)
            {
                _NowCurrentConfig = DefaultConfig.CurrentConfig;

                return new ActResult(Ex);
            }
        }

        public ActResult SetProcessConfig(ProcessConfig ProcessConfig_)
        {
            try
            {
                if (ProcessConfig_ == null)
                    _NowProcessConfig = DefaultConfig.ProcessConfig;
                else
                    _NowProcessConfig = ProcessConfig_;

                return new ActResult(true);
            }
            catch (Exception Ex)
            {
                _NowProcessConfig = DefaultConfig.ProcessConfig;

                return new ActResult(Ex);
            }
        }


        public ActResult<RecipeDTO> Get(string RecipeCode_)
            => RecipeService.Get(RecipeCode_);

        public ActResult<RecipeDTO> ConvertShelf(RecipeDTO Recipe_, int Quantity_)
        {
            if (Recipe_.Quantity != 4 || Recipe_.PanelCode.Last() != '4')
                return new ActResult<RecipeDTO>(new Exception(String.Format("非滿掛4片的Recipe.")));

            if (Quantity_ < 1 || Quantity_ > 4)
                return new ActResult<RecipeDTO>(new Exception(String.Format("{0} 為非正常數量", Quantity_)));

            double ni_WB = (Recipe_.Ni_WB_Adm2 * GetWeight(Recipe_.WBArea + Recipe_.BArea, Quantity_)).ExRound(3);
            double ni_B = Recipe_.Ni_B_Adm2 * GetWeight(Recipe_.WBArea + Recipe_.BArea, Quantity_).ExRound(3);
            double au_WB = Recipe_.Au_WB_Adm2 * GetWeight(Recipe_.WBArea + Recipe_.BArea, Quantity_).ExRound(3);
            double au_B = Recipe_.Au_B_Adm2 * GetWeight(Recipe_.WBArea + Recipe_.BArea, Quantity_).ExRound(3);

            var quantityChar = Quantity_ == 3 ? '3' : Quantity_ == 2 ? '2' : '1';

            var shelfRecipe = new RecipeDTO()
            {
                PanelCode = Recipe_.PanelCode.Substring(0, Recipe_.PanelCode.Length-1) + quantityChar,
                PMode = Recipe_.PMode,
                Quantity = Quantity_,
                WBArea = Recipe_.WBArea,
                BArea = Recipe_.BArea,
                Size = Recipe_.Size,
                Thickness = Recipe_.Thickness,
                Remarks = Recipe_.Remarks,
                Ni_PlatingTime = Recipe_.Ni_PlatingTime,
                Au_PlatingTime = Recipe_.Au_PlatingTime,
                AuSt_PlatingTime = Recipe_.AuSt_PlatingTime,
                AuSt_Adm2 = Recipe_.AuSt_Adm2,
                Ni_WB_Adm2 = ni_WB,
                Ni_B_Adm2 = ni_B,
                Au_WB_Adm2 = au_WB,
                Au_B_Adm2 = au_B,
                CreateTimeTicks = DateTime.Now.Ticks,
                EditorID = "root",
                DisplayCode = Recipe_.PanelCode.PadRight(Recipe_.PanelCode.Length - 1) + quantityChar,
                Enabeld = true,
                SystemLog = String.Format("Create At {0}, By Auto Convert Recipe.", DateTime.Now.GetString())
            };
            return new ActResult<RecipeDTO>(shelfRecipe);
        }

        double GetWeight(long Area_, int Quantity_)
        {
            double weight;

            if (5000 <= Area_ && Area_ <= 10000)
            {
                switch (Quantity_)
                {
                    case 1: weight = NowConvertConfig.Area_5000_10000_Quantity_1; break;
                    case 2: weight = NowConvertConfig.Area_5000_10000_Quantity_2; break;
                    case 3: weight = NowConvertConfig.Area_5000_10000_Quantity_3; break;
                    default: throw new Exception("數量<=0 or 數量>=4");
                }
            }
            else if (10001 <= Area_ && Area_ <= 20000)
            {
                switch (Quantity_)
                {
                    case 1: weight = NowConvertConfig.Area_10001_20000_Quantity_1; break;
                    case 2: weight = NowConvertConfig.Area_10001_20000_Quantity_2; break;
                    case 3: weight = NowConvertConfig.Area_10001_20000_Quantity_3; break;
                    default: throw new Exception("數量<=0 or 數量>=4");
                }
            }
            else if (20001 <= Area_ && Area_ <= 40000)
            {
                switch (Quantity_)
                {
                    case 1: weight = NowConvertConfig.Area_20001_40000_Quantity_1; break;
                    case 2: weight = NowConvertConfig.Area_20001_40000_Quantity_2; break;
                    case 3: weight = NowConvertConfig.Area_20001_40000_Quantity_3; break;
                    default: throw new Exception("數量<=0 or 數量>=4");
                }
            }
            else if (40001 <= Area_ && Area_ <= 60000)
            {
                switch (Quantity_)
                {
                    case 1: weight = NowConvertConfig.Area_40001_60000_Quantity_1; break;
                    case 2: weight = NowConvertConfig.Area_40001_60000_Quantity_2; break;
                    case 3: weight = NowConvertConfig.Area_40001_60000_Quantity_3; break;
                    default: throw new Exception("數量<=0 or 數量>=4");
                }
            }
            else if (60001 <= Area_ && Area_ <= 80000)
            {
                switch (Quantity_)
                {
                    case 1: weight = NowConvertConfig.Area_60001_80000_Quantity_1; break;
                    case 2: weight = NowConvertConfig.Area_60001_80000_Quantity_2; break;
                    case 3: weight = NowConvertConfig.Area_60001_80000_Quantity_3; break;
                    default: throw new Exception("數量<=0 or 數量>=4");
                }
            }
            else if (80001 <= Area_ && Area_ <= 100000)
            {
                switch (Quantity_)
                {
                    case 1: weight = NowConvertConfig.Area_80001_100000_Quantity_1; break;
                    case 2: weight = NowConvertConfig.Area_80001_100000_Quantity_2; break;
                    case 3: weight = NowConvertConfig.Area_80001_100000_Quantity_3; break;
                    default: throw new Exception("數量<=0 or 數量>=4");
                }
            }
            else if (Area_ >= 100001)
            {
                switch (Quantity_)
                {
                    case 1: weight = NowConvertConfig.Area_100001_Quantity_1; break;
                    case 2: weight = NowConvertConfig.Area_100001_Quantity_2; break;
                    case 3: weight = NowConvertConfig.Area_100001_Quantity_3; break;
                    default: throw new Exception("數量<=0 or 數量>=4");
                }
            }
            else
            {
                throw new Exception("面積 <= 5000mm2");
            }
            return weight;
        }

        bool IsLegalCode(string PanelCode_)
        {
            try
            {
                if (PanelCode_ == DummyRecipe.PanelCode) return true;

                string[] parts = PanelCode_.Split('-');
                string stationNo = parts[0];
                string itemNo = parts[1];
                string verQuantity = parts[2].ToUpper();

                if (verQuantity[0] != 'V') return false;

                int ver = Convert.ToInt32(verQuantity.Substring(1, 3));
                int quantity = Convert.ToInt32(verQuantity.Substring(4, 1));

                return true;
            }
            catch
            {
                return false;
            }
        }

        public ActResult<RecipeDTO> Create(RecipeDTO Recipe_, string EditorID_)
        {
            var panelCode = Recipe_.PanelCode;
            try
            {
                string stationNo;
                try { stationNo = panelCode.Split('-')[0]; }
                catch
                {
                    return new ActResult<RecipeDTO>(new Exception(String.Format("非合法的料號名稱，無法取得站號")));
                }

                string itemNo;
                try { itemNo = panelCode.Split('-')[1]; }
                catch
                {
                    return new ActResult<RecipeDTO>(new Exception(String.Format("非合法的料號名稱，無法取得版號")));
                }

                int ver;
                try { ver = Convert.ToInt32(panelCode.Split('-')[2].Replace("V", "").Substring(3)); }
                catch
                {
                    return new ActResult<RecipeDTO>(new Exception(String.Format("非合法的料號名稱，無法取得版本編號")));
                }

                int quantity;
                try { quantity = Convert.ToInt32(panelCode.Split('-')[2].Replace("V", "").Substring(3, 1)); }
                catch
                {
                    return new ActResult<RecipeDTO>(new Exception(String.Format("非合法的料號名稱，無法取得數量")));
                }

                if (1 > quantity || quantity > 4)
                {
                    return new ActResult<RecipeDTO>(new Exception(String.Format("數量僅能介於 1 ~ 4之間做設定")));
                }

                if (!IsLegalCode(Recipe_.PanelCode)) return new ActResult<RecipeDTO>(new Exception(String.Format("不合格的PanelCode 拒絕新增")));

                if (RecipeService.IsExist(Recipe_.PanelCode)) return new ActResult<RecipeDTO>(new Exception(String.Format("重複PanelCode 拒絕新增")));

                if (quantity != 4)
                {
                    var r1 = RecipeService.Insert(Recipe_, EditorID_);
                    return r1;
                }
                else
                {
                    var r1 = ConvertShelf(Recipe_, 1);
                    var r2 = ConvertShelf(Recipe_, 2);
                    var r3 = ConvertShelf(Recipe_, 3);
                    if (!(r1.Result && r2.Result && r3.Result))
                        return new ActResult<RecipeDTO>(new Exception("轉換Recipe 失敗"));

                    RecipeDTO[] recipes = new RecipeDTO[] { r1.Value, r2.Value, r3.Value, Recipe_ };
                    var r4 = RecipeService.Insert(recipes, EditorID_);

                    if (!r4.Result)
                        return new ActResult<RecipeDTO>(new Exception("存入資料庫失敗 失敗"));
                    else
                        return RecipeService.Get(Recipe_.PanelCode);
                }
            }
            catch (Exception Ex)
            {
                return new ActResult<RecipeDTO>(Ex);
            }
        }

        public ActResult Edit(RecipeDTO Recipe_, string EditorID_)
        {
            try
            {
                if (Recipe_.PanelCode == DummyRecipe.PanelCode) return new ActResult(new Exception(String.Format("拒絕修改Dummy Recipe.")));

                if (!RecipeService.IsExist(Recipe_.PanelCode)) return new ActResult(new Exception(String.Format("無此PanelCode 拒絕修改")));

                var quantity = Recipe_.Quantity;

                if (quantity != 4)
                {
                    var r1 = RecipeService.UpDate(Recipe_, EditorID_);
                    if (r1.Result)
                        return new ActResult(true);
                    else
                        return new ActResult(r1.Exception);
                }
                else
                {
                    var r1 = ConvertShelf(Recipe_, 1);
                    var r2 = ConvertShelf(Recipe_, 2);
                    var r3 = ConvertShelf(Recipe_, 3);
                    if (!(r1.Result && r2.Result && r3.Result))
                        return new ActResult(new Exception("轉換Recipe 失敗"));

                    RecipeDTO[] recipes = new RecipeDTO[] { r1.Value, r2.Value, r3.Value, Recipe_ };
                    var r4 = RecipeService.UpDate(recipes, EditorID_);

                    return r4;
                }
            }
            catch (Exception Ex)
            {
                return new ActResult(Ex);
            }
        }

        public ActResult Remove(string RecipeCode_, string EditorID_)
        {
            try
            {
                if (RecipeCode_ == DummyRecipe.PanelCode) return new ActResult(new Exception(String.Format("拒絕刪除Dummy Recipe.")));

                if (!RecipeService.IsExist(RecipeCode_)) return new ActResult(new Exception(String.Format("無此PanelCode 拒絕刪除")));

                var quantity = Convert.ToInt32(RecipeCode_.ElementAt(RecipeCode_.Length-1 ).ToString());
                if (quantity != 4)
                {
                    var r1 = RecipeService.Delete(RecipeCode_, EditorID_);
                    return r1;
                }
                else
                {
                    var r1 = RecipeCode_.Substring(0, RecipeCode_.Length - 1) + '1';
                    var r2 = RecipeCode_.Substring(0, RecipeCode_.Length - 1) + '2';
                    var r3 = RecipeCode_.Substring(0, RecipeCode_.Length - 1) + '3';

                    var r4 = RecipeService.Delete(new string[] { RecipeCode_, r1, r2, r3 }, EditorID_);

                    return r4;
                }
            }
            catch (Exception Ex)
            {
                return new ActResult(Ex);
            }
        }

        public ActResult<List<RecipeDTO>> Search(string PartCode_, PModeTypes PMode_, bool IsShowShelf_ = false)
        {
            try
            {
                var r1 = RecipeService.Gets(PartCode_, PMode_, IsShowShelf_);
                return r1;
            }
            catch (Exception Ex)
            {
                return new ActResult<List<RecipeDTO>>(Ex);
            }
        }

        public ActResult<List<RecipeDTO>> GetRecord(string PartCode_)
        {
            try
            {
                var r1 = RecipeService.GetRecord(PartCode_);
                return r1;
            }
            catch (Exception Ex)
            {
                return new ActResult<List<RecipeDTO>>(Ex);
            }
        }
    }


}

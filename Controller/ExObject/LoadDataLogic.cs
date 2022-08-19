using Common.DTO;
using Common.Enums;
using Common.Extension;
using System;

namespace Controller.ExObject
{
    public static class LoadDataLogic
    {
        public enum CurrentTypes
        {
            Ni,
            Au,
            AuSt
        }

        public enum AreaTypes
        {
            none,
            WB,
            B,
        }

        /// <summary>
        /// 滿車滿掛
        /// </summary>
        /// <param name="LoadSourceType_">創建來源</param>
        /// <param name="LotCode_">批號</param>
        /// <param name="EditorID_">工號</param>
        /// <param name="Recipe_">參數</param>
        /// <returns></returns>
        public static LoadDataDTO Create(LoadSourceTypes LoadSourceType_,string EditorID_, string LotCode_,  RecipeDTO Recipe_)
        {
            var nowDT = DateTime.Now;
            var quantity = Recipe_.Quantity;
            var dto = new LoadDataDTO()
            {
                CreateTimeTicks = nowDT.Ticks,
                SystemLog = String.Format("Source {0} Create At {1}", LoadSourceType_.ToString(), nowDT.GetString()),
                IsNormalFinish = false,
                EditorID = EditorID_,
                Enabled = true,

                First_IsEmpty = Recipe_.Quantity == 0,
                First_LotCode = LotCode_,
                First_RecipeCode = Recipe_.PanelCode,
                First_PMode = Recipe_.PMode,
                First_Size = Recipe_.Size,
                First_Thickness = Recipe_.Thickness,
                First_Quantity = quantity,
                First_WBArea = Recipe_.WBArea,
                First_BArea = Recipe_.BArea,
                First_Ni_WB_Current = GetCurrent(Recipe_, CurrentTypes.Ni, AreaTypes.WB),
                First_Ni_B_Current = GetCurrent(Recipe_, CurrentTypes.Ni, AreaTypes.B),
                First_Ni_PTime = Recipe_.Ni_PlatingTime,
                First_Au_WB_Current = GetCurrent(Recipe_, CurrentTypes.Au, AreaTypes.WB),
                First_Au_B_Current = GetCurrent(Recipe_, CurrentTypes.Au, AreaTypes.B),
                First_Au_PTime = Recipe_.Au_PlatingTime,
                First_AuSt_Current = GetCurrent(Recipe_, CurrentTypes.AuSt, AreaTypes.none),
                First_AuSt_PTime = Recipe_.AuSt_PlatingTime,

                Second_IsEmpty = Recipe_.Quantity == 0,
                Second_LotCode = LotCode_,
                Second_RecipeCode = Recipe_.PanelCode,
                Second_PMode = Recipe_.PMode,
                Second_Size = Recipe_.Size,
                Second_Thickness = Recipe_.Thickness,
                Second_Quantity = quantity,
                Second_WBArea = Recipe_.WBArea,
                Second_BArea = Recipe_.BArea,
                Second_Ni_WB_Current = GetCurrent(Recipe_, CurrentTypes.Ni, AreaTypes.WB),
                Second_Ni_B_Current = GetCurrent(Recipe_, CurrentTypes.Ni, AreaTypes.B),
                Second_Ni_PTime = Recipe_.Ni_PlatingTime,
                Second_Au_WB_Current = GetCurrent(Recipe_, CurrentTypes.Au, AreaTypes.WB),
                Second_Au_B_Current = GetCurrent(Recipe_, CurrentTypes.Au, AreaTypes.B),
                Second_Au_PTime = Recipe_.Au_PlatingTime,
                Second_AuSt_Current = GetCurrent(Recipe_, CurrentTypes.AuSt, AreaTypes.none),
                Second_AuSt_PTime = Recipe_.AuSt_PlatingTime,
                LoadSourceType = LoadSourceType_,
            };
            return dto;
        }

        /// <summary>
        /// 個別設定參數
        /// </summary>
        /// <param name="LoadSourceType_">創建來源</param>
        /// <param name="EditorID_">工號</param>
        /// <param name="FirstLotCode_">首掛批號</param>
        /// <param name="FirstRecipe_">首掛參數</param>
        /// <param name="SecondLotCode_">二掛批號</param>
        /// <param name="SecondRecipe_">二掛參數</param>
        /// <returns></returns>
        public static LoadDataDTO Create(LoadSourceTypes LoadSourceType_, string EditorID_, string FirstLotCode_, RecipeDTO FirstRecipe_, string SecondLotCode_, RecipeDTO SecondRecipe_)
        {
            var nowDT = DateTime.Now;
            var firstQuantity = FirstRecipe_.Quantity;
            var secondQuantity = SecondRecipe_.Quantity;
            var dto = new LoadDataDTO()
            {
                CreateTimeTicks = nowDT.Ticks,
                SystemLog = String.Format("Source {0} Create At {1} By {2}", LoadSourceType_.ToString(), nowDT.GetString(), EditorID_),
                IsNormalFinish = false,
                EditorID = EditorID_,
                Enabled = true,

                First_IsEmpty = firstQuantity  == 0,
                First_LotCode = FirstLotCode_,
                First_RecipeCode = FirstRecipe_.PanelCode,
                First_PMode = FirstRecipe_.PMode,
                First_Size = FirstRecipe_.Size,
                First_Thickness = FirstRecipe_.Thickness,
                First_Quantity = firstQuantity,
                First_WBArea = FirstRecipe_.WBArea,
                First_BArea = FirstRecipe_.BArea,
                First_Ni_WB_Current = GetCurrent(FirstRecipe_, CurrentTypes.Ni, AreaTypes.WB),
                First_Ni_B_Current = GetCurrent(FirstRecipe_, CurrentTypes.Ni, AreaTypes.B),
                First_Ni_PTime = FirstRecipe_.Ni_PlatingTime,
                First_Au_WB_Current = GetCurrent(FirstRecipe_, CurrentTypes.Au, AreaTypes.WB),
                First_Au_B_Current = GetCurrent(FirstRecipe_, CurrentTypes.Au, AreaTypes.B),
                First_Au_PTime = FirstRecipe_.Au_PlatingTime,
                First_AuSt_Current = GetCurrent(FirstRecipe_, CurrentTypes.AuSt, AreaTypes.none),
                First_AuSt_PTime = FirstRecipe_.AuSt_PlatingTime,

                Second_IsEmpty = secondQuantity ==0,
                Second_LotCode = SecondLotCode_,
                Second_RecipeCode = SecondRecipe_.PanelCode,
                Second_PMode = SecondRecipe_.PMode,
                Second_Size = SecondRecipe_.Size,
                Second_Thickness = SecondRecipe_.Thickness,
                Second_Quantity = secondQuantity,
                Second_WBArea = SecondRecipe_.WBArea,
                Second_BArea = SecondRecipe_.BArea,
                Second_Ni_WB_Current = GetCurrent(SecondRecipe_, CurrentTypes.Ni, AreaTypes.WB),
                Second_Ni_B_Current = GetCurrent(SecondRecipe_, CurrentTypes.Ni, AreaTypes.B),
                Second_Ni_PTime = SecondRecipe_.Ni_PlatingTime,
                Second_Au_WB_Current = GetCurrent(SecondRecipe_, CurrentTypes.Au, AreaTypes.WB),
                Second_Au_B_Current = GetCurrent(SecondRecipe_, CurrentTypes.Au, AreaTypes.B),
                Second_Au_PTime = SecondRecipe_.Au_PlatingTime,
                Second_AuSt_Current = GetCurrent(SecondRecipe_, CurrentTypes.AuSt, AreaTypes.none),
                Second_AuSt_PTime = SecondRecipe_.AuSt_PlatingTime,
                LoadSourceType = LoadSourceType_,                  
            };
            return dto;
        }

        public static double GetCurrent(RecipeDTO Recipe_, CurrentTypes CurrentType_, AreaTypes AreaType_)
        {
            switch (CurrentType_)
            {
                case CurrentTypes.Ni:
                    switch (AreaType_)
                    {
                        case AreaTypes.WB:
                            return (Recipe_.Quantity * Recipe_.WBArea * Recipe_.Ni_WB_Adm2 / 10000).ExRound(3);
                        case AreaTypes.B:
                            return (Recipe_.Quantity * Recipe_.BArea * Recipe_.Ni_B_Adm2 / 10000).ExRound(3);
                        default:
                            throw new Exception("Do Not Supper this Type.");
                    }
                case CurrentTypes.Au:
                    switch (AreaType_)
                    {
                        case AreaTypes.WB:
                            return (Recipe_.Quantity * Recipe_.WBArea * Recipe_.Au_WB_Adm2 / 10000).ExRound(3);
                        case AreaTypes.B:
                            return (Recipe_.Quantity * Recipe_.BArea * Recipe_.Au_B_Adm2 / 10000).ExRound(3);
                        default:
                            throw new Exception("Do Not Supper this Type.");
                    }
                case CurrentTypes.AuSt:
                    switch (AreaType_)
                    {
                        case AreaTypes.none:
                            return (4 * (Recipe_.WBArea + Recipe_.BArea) * Recipe_.AuSt_Adm2 / 10000).ExRound(3);
                        default:
                            throw new Exception("Do Not Supper this Type.");
                    }
                default:
                    throw new Exception("Do Not Supper this Type.");
            }
        }
    }


}

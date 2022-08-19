using Common.DTO;
using Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extension
{
    public static class DTOExsample
    {

        public static T Get<T>() where T : IDTO
        {
            object obj;
            switch (typeof(T).Name)
            {
                case nameof(RecipeDTO):
                    obj = new RecipeDTO()
                    {
                        PanelCode = "TESTRecipe",
                        Size = "SMALL",
                        BArea = 1000000,
                        WBArea = 2000000,
                        Quantity = 4,
                        PMode = "87",
                        Thickness = 10,
                        AuSt_Adm2 = 10.01,
                        AuSt_PlatingTime = 100,
                        Au_B_Adm2 = 20.01,
                        Au_PlatingTime = 200,
                        Au_WB_Adm2 = 20.02,
                        Ni_B_Adm2 = 30.01,
                        Ni_WB_Adm2 = 30.02,
                        Ni_PlatingTime = 300,
                        Remarks = "This is TestExsample."

                    };
                    break;
                case nameof(LoadDataDTO):
                    obj = new LoadDataDTO()
                    {
                        Code = "123486",
                        LoadSourceType = Enums.LoadSourceTypes.Custom,
                        SortTimeTicks = DateTime.Now.Ticks,
                        First_LotCode = "LotNo",
                        First_BArea = 104,
                        First_WBArea = 105,
                        First_Quantity = 4,
                        First_RecipeCode = "Recipe",
                        First_Size = "SMALL",
                        First_Thickness = 10,
                        First_PMode = "P",
                        First_IsEmpty = false,
                        First_Ni_B_Current = 101.001,
                        First_Ni_WB_Current = 101.002,
                        First_Ni_PTime = 101,
                        First_Au_B_Current = 102.001,
                        First_Au_WB_Current = 102.002,
                        First_Au_PTime = 102,
                        First_AuSt_Current = 103.001,
                        First_AuSt_PTime = 103,

                        Second_LotCode = "LotNo",
                        Second_BArea = 104,
                        Second_WBArea = 105,
                        Second_Quantity = 4,
                        Second_RecipeCode = "Recipe",
                        Second_Size = "SMALL",
                        Second_Thickness = 10,
                        Second_PMode = "P",
                        Second_IsEmpty = false,
                        Second_Ni_B_Current = 201.001,
                        Second_Ni_WB_Current = 201.002,
                        Second_Ni_PTime = 201,
                        Second_Au_B_Current = 202.001,
                        Second_Au_WB_Current = 202.002,
                        Second_Au_PTime = 202,
                        Second_AuSt_Current = 203.001,
                        Second_AuSt_PTime = 203,                     
                    };
                    break;
                case nameof(ThermostatLogDTO):
                    obj = new ThermostatLogDTO()
                    {
                         LogTimeTicks = DateTime.Now.Ticks,
                         Rowid = 1
                    };

                    foreach (var p in typeof(ThermostatLogDTO).GetProperties())
                    {
                        if (p.PropertyType.Name != typeof(double).Name) continue;
                        p.SetValue(obj, 999.99);
                    }
                    break;
                default:
                    throw new Exception();
            }
            return (T)obj;
        }
    }
}

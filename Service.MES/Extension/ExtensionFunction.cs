using Common.DTO;
using Newtonsoft.Json;
using Service.MES.ExObject;
using System;
using System.Linq;

namespace Service.MES.Extension
{
    public static class ExtensionFunction
    {
        public static RecipeDTO ToRecipe(this AE2TalkObject AE2TalkObject_)
        {
            var items = AE2TalkObject_.Items.ToDictionary(p => p.Id);

            var panelCode = AE2TalkObject_.RecipeName;

            string stationNo;
            try { stationNo = panelCode.Split('-')[0]; } catch { stationNo = String.Empty; }

            string itemNo;
            try { itemNo = panelCode.Split('-')[1]; } catch { itemNo = String.Empty; }

            int ver;
            try { ver = Convert.ToInt32(panelCode.Split('-')[2].Replace("V", "").Substring(3)); } catch { ver = 0; }

            int quantity;
            try { quantity = Convert.ToInt32(panelCode.Split('-')[2].Replace("V", "").Substring(3, 1)); } catch { quantity = 1; }

            var recipe = new RecipeDTO()
            {
                PanelCode = panelCode,
                Quantity = quantity,


                Thickness = 0,
                PMode = "A",
                Size = "SMALL",


                WBArea = Convert.ToInt64(items["1000004167"].Value),
                BArea = Convert.ToInt64(items["1000004170"].Value),

                Ni_WB_Adm2 = Convert.ToDouble(items["1000002382"].Value),
                Ni_B_Adm2 = Convert.ToDouble(items["1000002383"].Value),
                Ni_PlatingTime = 2010,


                Au_WB_Adm2 = Convert.ToDouble(items["1000002385"].Value),
                Au_B_Adm2 = Convert.ToDouble(items["1000002386"].Value),
                Au_PlatingTime = 290,


                AuSt_Adm2 = Convert.ToDouble(items["1000002384"].Value),
                AuSt_PlatingTime = 20,
            };

            return recipe;
        }

        public static AE2TalkObject ToAE2TalkObject(this RecipeDTO Recipe_)
        {
            var sampleJson = SampleData.AE2TalkObjectValue;

            var sampleObject = JsonConvert.DeserializeObject<AE2TalkObject>(sampleJson);

            sampleObject.IsMultiRecipe = false;
            sampleObject.Creator = "k04604";
            sampleObject.Eqp_Name = "M0000802";
            sampleObject.Mach_Type = "A040002";
            sampleObject.RMSName = "GOLDEN_RECIPE_AUNI_E_PLATING";
            sampleObject.RecipeName = Recipe_.PanelCode;
            sampleObject.RecipeStatus = "ACTIVE";
            sampleObject.ResultFlag = true;
            sampleObject.TypeStatus = "ACTIVE";
            sampleObject.Version = "0";

            var AE2TalkItems = sampleObject.Items.ToDictionary(p => p.Id, p => p);

            AE2TalkItems["1000002382"].Value = Convert.ToDecimal(Recipe_.Ni_WB_Adm2);
            AE2TalkItems["1000002383"].Value = Convert.ToDecimal(Recipe_.Ni_B_Adm2);
            AE2TalkItems["1000002385"].Value = Convert.ToDecimal(Recipe_.Au_WB_Adm2);
            AE2TalkItems["1000002386"].Value = Convert.ToDecimal(Recipe_.Au_B_Adm2);
            AE2TalkItems["1000002384"].Value = Convert.ToDecimal(Recipe_.AuSt_Adm2);
            AE2TalkItems["1000004167"].Value = Convert.ToDecimal(Recipe_.WBArea);
            AE2TalkItems["1000004170"].Value = Convert.ToDecimal(Recipe_.BArea);


            return sampleObject;
        }
    }

}

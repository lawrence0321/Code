using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.MES.ExObject
{
    public class AE2TalkObjectV2 : AE2TalkObject
    {
        public string LotNo { get; set; }
    }

    public class AE2TalkObject
    {
        public string Creator { get; set; }

        public string Eqp_Name { get; set; }

        public bool IsMultiRecipe { get; set; }

        public AE2talkItem[] Items { get; set; }

        public string Mach_Type { get; set; }

        public string Machine_Descript { get; set; }

        public string RMSName { get; set; }

        public string RecipeName { get; set; }

        public string RecipeNames { get; set; }

        public string RecipeStatus { get; set; }

        public bool ResultFlag { get; set; }

        public string ResultMessage { get; set; }

        public string StepId { get; set; }

        public string StepName { get; set; }

        public string TypeStatus { get; set; }

        public string Version { get; set; }

    }

}

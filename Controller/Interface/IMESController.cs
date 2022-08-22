using Common;
using Common.DTO;
using Common.Enums;
using Common.ExConfig;
using Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Interface
{
    public interface IMESController :IController
    {
        bool IsConnect { get; }

        /// <summary>
        /// 檢查項目
        /// </summary>
        CheckItemObject CheckItem { get; }

        bool IsADCHappenAlarm { get; }

        List<AlarmMsgDTO> AlarmMsgs { get; }

        ActResult SetADCConfig(ADCConfig ADCConfig_);

        void SetCheckItem(CheckItemObject Value_);

        ActResult SendCreateRecipeNotify(RecipeDTO RecipeDTO_);

        ActResult SendEDC();

        ActResult SendATC(string LotCode_,string RecipeCode);

        ActResult Connect(int Port_ = 7070);

        ActResult DisConnect();
    }
}

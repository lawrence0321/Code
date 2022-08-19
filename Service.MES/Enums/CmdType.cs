using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.MES.Enums
{
    internal enum CmdType
    {
        RMS,
        RMS_ACK,
        RMS_ERROR,
        END_SHELF_ACK,
        END_SHELF_ERROR,
        End_Shelf_Recipe,
        END_SHELF_RECIPE_ACK,
        ADC,
        EDC,
        EMS,
        RMS_Create,
        RMS_CREATE_ACK,
        Recipe_Check,
        RECIPE_CHECK_ACK,
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    [Flags]
    public enum UserAuthority:Int16
    {
        none = 0,

        SettingPage=1,

        UseCustomMod=2,

        EditRecipe = 4,

        All= 7
    }
}

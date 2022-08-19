using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class UserItemDTO
    {
        public string UserID { get; set; }

        public bool SettingPage { get; set; }

        public bool UseCustomMod { get; set; }

        public bool EditRecipe { get; set; }
    }
}

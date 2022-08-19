using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;

namespace Common.DTO
{
    public class AlarmTypePackage
    {
        public AlarmTypes_Part01 Part01 { get; set; }
        public AlarmTypes_Part02 Part02 { get; set; }
        public AlarmTypes_Part03 Part03 { get; set; }
        public AlarmTypes_Part04 Part04 { get; set; }
        public AlarmTypes_Part05 Part05 { get; set; }
        public AlarmTypes_Part06 Part06 { get; set; }
        public AlarmTypes_Part07 Part07 { get; set; }
        public AlarmTypes_Part08 Part08 { get; set; }

        public AlarmTypePackage()
        {
            Part01 = AlarmTypes_Part01.None;
            Part02 = AlarmTypes_Part02.None;
            Part03 = AlarmTypes_Part03.None;
            Part04 = AlarmTypes_Part04.None;
            Part05 = AlarmTypes_Part05.None;
            Part06 = AlarmTypes_Part06.None;
            Part07 = AlarmTypes_Part07.None;
            Part08 = AlarmTypes_Part08.None;
        }
    }
}

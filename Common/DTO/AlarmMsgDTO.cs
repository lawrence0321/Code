using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{ 
    public class AlarmMsgDTO
    {
        public string Name { get; set; }
        public double RealValue { get; set; }
        public double MinLimit { get; set; }
        public double MaxLimit { get; set; }
    }
}

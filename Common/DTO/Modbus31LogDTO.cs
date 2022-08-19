using Common.Attributes;
using Common.Extension;
using Common.Interface;
using System;

namespace Common.DTO
{
    public class Modbus31LogDTO:IDTO
    {
        [Display()]
        public long Rowid { get; set; }
        [Display()]
        public long LogTimeTicks { get; set; }
        [Display()]
        public DateTime LogDateTime => new DateTime(LogTimeTicks);
        [Display("紀錄時間")]
        public string LogDateTimeString => LogDateTime.GetString();

        [Display("酸1過濾罐")]
        public double ACID1 { get; set; }
        [Display("鼓風機壓力")]
        public double Blower { get; set; }
        [Display("脫脂過濾罐")]
        public double Clean { get; set; }
        [Display("微蝕刻過濾罐")]
        public double Microerching { get; set; }
        [Display("鎳金1-1")]
        public double Nickel1_1 { get; set; }
        [Display("鎳金1-2")]
        public double Nickel1_2 { get; set; }
        [Display("鎳金1-3")]
        public double Nickel1_3 { get; set; }
        [Display("鎳金1空氣流量計1")]
        public double Nickel1_Air_1 { get; set; }
        [Display("鎳金1空氣流量計2")]
        public double Nickel1_Air_2 { get; set; }
        [Display("鎳金1空氣流量計3")]
        public double Nickel1_Air_3 { get; set; }
        [Display("鎳金1空氣流量計4")]
        public double Nickel1_Air_4 { get; set; }
        [Display("鎳金1空氣流量計5")]
        public double Nickel1_Air_5 { get; set; }
        [Display("鎳金1空氣流量計6")]
        public double Nickel1_Air_6 { get; set; }
        [Display("鎳金2-1")]
        public double Nickel2_1 { get; set; }
        [Display("鎳金2-2")]
        public double Nickel2_2 { get; set; }
        [Display("鎳金2-3")]
        public double Nickel2_3 { get; set; }
        [Display("鎳金2空氣流量計1")]
        public double Nickel2_Air_1 { get; set; }
        [Display("鎳金2空氣流量計2")]
        public double Nickel2_Air_2 { get; set; }
        [Display("鎳金2空氣流量計3")]
        public double Nickel2_Air_3 { get; set; }
        [Display("鎳金2空氣流量計4")]
        public double Nickel2_Air_4 { get; set; }
        [Display("鎳金2空氣流量計5")]
        public double Nickel2_Air_5 { get; set; }
        [Display("鎳金2空氣流量計6")]
        public double Nickel2_Air_6 { get; set; }
        [Display("熱水洗3流量計")]
        public double Water1 { get; set; }
        [Display("水洗4流量計")]
        public double Water2 { get; set; }
        [Display("水洗7流量計")]
        public double Water3 { get; set; }
        [Display("水洗9流量計")]
        public double Water4 { get; set; }
    }

}

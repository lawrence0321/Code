using Common.Attributes;
using Common.Extension;
using Common.Interface;
using System;

namespace Common.DTO
{
    public class Modbus32LogDTO : IDTO
    {
        [Display()]
        public long Rowid { get; set; }
        [Display()]
        public long LogTimeTicks { get; set; }
        [Display()]
        public DateTime LogDateTime => new DateTime(LogTimeTicks);
        [Display("紀錄時間")]
        public string LogDateTimeString => LogDateTime.GetString();

        [Display("金1過濾罐")]
        public double Au_1 { get; set; }
        [Display("金2過濾罐")]
        public double Au_2 { get; set; }
        [Display("預鍍金過濾罐")]
        public double Au_Strike { get; set; }
        [Display("鎳金3-1")]
        public double Nickel3_1 { get; set; }
        [Display("鎳金3-2")]
        public double Nickel3_2 { get; set; }
        [Display("鎳金3-3")]
        public double Nickel3_3 { get; set; }
        [Display("鎳金3空氣流量1")]
        public double Nickel3_Air_1 { get; set; }
        [Display("鎳金3空氣流量2")]
        public double Nickel3_Air_2 { get; set; }
        [Display("鎳金3空氣流量3")]
        public double Nickel3_Air_3 { get; set; }
        [Display("鎳金3空氣流量4")]
        public double Nickel3_Air_4 { get; set; }
        [Display("鎳金3空氣流量5")]
        public double Nickel3_Air_5 { get; set; }
        [Display("鎳金3空氣流量6")]
        public double Nickel3_Air_6 { get; set; }
        [Display("鎳金4-1")]
        public double Nickel4_1 { get; set; }
        [Display("鎳金4-2")]
        public double Nickel4_2 { get; set; }
        [Display("鎳金4-3")]
        public double Nickel4_3 { get; set; }
        [Display("鎳金4空氣流量1")]
        public double Nickel4_Air_1 { get; set; }
        [Display("鎳金4空氣流量2")]
        public double Nickel4_Air_2 { get; set; }
        [Display("鎳金4空氣流量3")]
        public double Nickel4_Air_3 { get; set; }
        [Display("鎳金4空氣流量4")]
        public double Nickel4_Air_4 { get; set; }
        [Display("鎳金4空氣流量5")]
        public double Nickel4_Air_5 { get; set; }
        [Display("鎳金4空氣流量6")]
        public double Nickel4_Air_6 { get; set; }
        [Display("水洗25流量計")]
        public double Water10 { get; set; }
        [Display("水洗12流量計")]
        public double Water6 { get; set; }
        [Display("水洗15流量計")]
        public double Water7 { get; set; }
        [Display("水洗17流量計")]
        public double Water8 { get; set; }
        [Display("水洗22流量計")]
        public double Water9 { get; set; }
    }
}
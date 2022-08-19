using Common.Attributes;
using Common.Extension;
using Common.Interface;
using System;

namespace Common.DTO
{
    public class Modbus33LogDTO : IDTO
    {
        [Display()]
        public long Rowid { get; set; }
        [Display()]
        public long LogTimeTicks { get; set; }
        [Display()]
        public DateTime LogDateTime => new DateTime(LogTimeTicks);
        [Display("紀錄時間")]
        public string LogDateTimeString => LogDateTime.GetString();

        [Display("水洗機電導度")]
        public double Rinse_EC { get; set; }
        [Display("水洗機風量1")]
        public double Rinse_Flow1 { get; set; }
        [Display("水洗機風量2")]
        public double Rinse_Flow2 { get; set; }
        [Display("水洗機風量3")]
        public double Rinse_Flow3 { get; set; }
        [Display("水洗機風量4")]
        public double Rinse_Flow4 { get; set; }
        [Display("水洗機水洗槽噴壓1")]
        public double Rinse1 { get; set; }
        [Display("水洗機水洗槽噴壓10")]
        public double Rinse10 { get; set; }
        [Display("水洗機水洗槽噴壓11")]
        public double Rinse11 { get; set; }
        [Display("水洗機水洗槽噴壓12")]
        public double Rinse12 { get; set; }
        [Display("水洗機水洗槽噴壓13")]
        public double Rinse13 { get; set; }
        [Display("水洗機水洗槽噴壓2")]
        public double Rinse2 { get; set; }
        [Display("水洗機水洗槽噴壓3")]
        public double Rinse3 { get; set; }
        [Display("水洗機水洗槽噴壓4")]
        public double Rinse4 { get; set; }
        [Display("水洗機水洗槽噴壓5")]
        public double Rinse5 { get; set; }
        [Display("水洗機水洗槽噴壓6")]
        public double Rinse6 { get; set; }
        [Display("水洗機水洗槽噴壓7")]
        public double Rinse7 { get; set; }
        [Display("水洗機水洗槽噴壓8")]
        public double Rinse8 { get; set; }
        [Display("水洗機水洗槽噴壓9")]
        public double Rinse9 { get; set; }
        [Display("水洗機1流量計")]
        public double Water11 { get; set; }
        [Display("水洗機2流量計")]
        public double Water12 { get; set; }
        [Display("水洗機3流量計")]
        public double Water13 { get; set; }
    }

}

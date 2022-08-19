using Common.Attributes;
using Common.Extension;
using Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class RectifierLogDTO : IDTO
    {
        /// <summary>
        /// 序列號
        /// </summary>
        [Display("序列號")]
        public long Rowid { get; set; }
        /// <summary>
        /// 紀錄時間
        /// </summary>
        [Display()]
        public long LogTimeTicks { get; set; }
        /// <summary>
        /// 紀錄時間
        /// </summary>
        [Display()]
        public DateTime LogDateTime => new DateTime(LogTimeTicks);
        /// <summary>
        /// 紀錄時間
        /// </summary>
        [Display("紀錄時間")]
        public string LogDateTimeString => LogDateTime.GetString();
        /// <summary>
        /// Ni#01 FbA
        /// </summary>
        [Display("Ni#01 FbA")]
        public double Ni_01_FbA { get; set; }
        /// <summary>
        /// Ni#01 FbV
        /// </summary>
        [Display("Ni#01 FbV")]
        public double Ni_01_FbV { get; set; }
        /// <summary>
        /// Ni#01 SetA
        /// </summary>
        [Display("Ni#01 SetA")]
        public double Ni_01_SetA { get; set; }
        /// <summary>
        /// Ni#02 FbA
        /// </summary>
        [Display("Ni#02 FbA")]
        public double Ni_02_FbA { get; set; }
        /// <summary>
        /// Ni#02 FbV
        /// </summary>
        [Display("Ni#02 FbV")]
        public double Ni_02_FbV { get; set; }
        /// <summary>
        /// Ni#02 SetA
        /// </summary>
        [Display("Ni#02 SetA")]
        public double Ni_02_SetA { get; set; }
        /// <summary>
        /// Ni#03 FbA
        /// </summary>
        [Display("Ni#03 FbA")]
        public double Ni_03_FbA { get; set; }
        /// <summary>
        /// Ni#03 FbV
        /// </summary>
        [Display("Ni#03 FbV")]
        public double Ni_03_FbV { get; set; }
        /// <summary>
        /// Ni#03 SetA
        /// </summary>
        [Display("Ni#03 SetA")]
        public double Ni_03_SetA { get; set; }
        /// <summary>
        /// Ni#04 FbA
        /// </summary>
        [Display("Ni#04 FbA")]
        public double Ni_04_FbA { get; set; }
        /// <summary>
        /// Ni#04 FbV
        /// </summary>
        [Display("Ni#04 FbV")]
        public double Ni_04_FbV { get; set; }
        /// <summary>
        /// Ni#04 SetA
        /// </summary>
        [Display("Ni#04 SetA")]
        public double Ni_04_SetA { get; set; }
        /// <summary>
        /// Ni#05 FbA
        /// </summary>
        [Display("Ni#05 FbA")]
        public double Ni_05_FbA { get; set; }
        /// <summary>
        /// Ni#05 FbV
        /// </summary>
        [Display("Ni#05 FbV")]
        public double Ni_05_FbV { get; set; }
        /// <summary>
        /// Ni#05 SetA
        /// </summary>
        [Display("Ni#05 SetA")]
        public double Ni_05_SetA { get; set; }
        /// <summary>
        /// Ni#06 FbA
        /// </summary>
        [Display("Ni#06 FbA")]
        public double Ni_06_FbA { get; set; }
        /// <summary>
        /// Ni#06 FbV
        /// </summary>
        [Display("Ni#06 FbV")]
        public double Ni_06_FbV { get; set; }
        /// <summary>
        /// Ni#06 SetA
        /// </summary>
        [Display("Ni#06 SetA")]
        public double Ni_06_SetA { get; set; }
        /// <summary>
        /// Ni#07 FbA
        /// </summary>
        [Display("Ni#07 FbA")]
        public double Ni_07_FbA { get; set; }
        /// <summary>
        /// Ni#07 FbV
        /// </summary>
        [Display("Ni#07 FbV")]
        public double Ni_07_FbV { get; set; }
        /// <summary>
        /// Ni#07 SetA
        /// </summary>
        [Display("Ni#07 SetA")]
        public double Ni_07_SetA { get; set; }
        /// <summary>
        /// Ni#08 FbA
        /// </summary>
        [Display("Ni#08 FbA")]
        public double Ni_08_FbA { get; set; }
        /// <summary>
        /// Ni#08 FbV
        /// </summary>
        [Display("Ni#08 FbV")]
        public double Ni_08_FbV { get; set; }
        /// <summary>
        /// Ni#08 SetA
        /// </summary>
        [Display("Ni#08 SetA")]
        public double Ni_08_SetA { get; set; }
        /// <summary>
        /// Ni#09 FbA
        /// </summary>
        [Display("Ni#09 FbA")]
        public double Ni_09_FbA { get; set; }
        /// <summary>
        /// Ni#09 FbV
        /// </summary>
        [Display("Ni#09 FbV")]
        public double Ni_09_FbV { get; set; }
        /// <summary>
        /// Ni#09 SetA
        /// </summary>
        [Display("Ni#09 SetA")]
        public double Ni_09_SetA { get; set; }
        /// <summary>
        /// Ni#10 FbA
        /// </summary>
        [Display("Ni#10FbA")]
        public double Ni_10_FbA { get; set; }
        /// <summary>
        /// Ni#10 FbV
        /// </summary>
        [Display("Ni#01 FbV")]
        public double Ni_10_FbV { get; set; }
        /// <summary>
        /// Ni#10 SetA
        /// </summary>
        [Display("Ni#01 SetA")]
        public double Ni_10_SetA { get; set; }
        /// <summary>
        /// Ni#11 FbA
        /// </summary>
        [Display("Ni#11 FbA")]
        public double Ni_11_FbA { get; set; }
        /// <summary>
        /// Ni#11 FbV
        /// </summary>
        [Display("Ni#11 FbV")]
        public double Ni_11_FbV { get; set; }
        /// <summary>
        /// Ni#11 SetA
        /// </summary>
        [Display("Ni#11 SetA")]
        public double Ni_11_SetA { get; set; }
        /// <summary>
        /// Ni#12 FbA
        /// </summary>
        [Display("Ni#12 FbA")]
        public double Ni_12_FbA { get; set; }
        /// <summary>
        /// Ni#12 FbV
        /// </summary>
        [Display("Ni#12 FbV")]
        public double Ni_12_FbV { get; set; }
        /// <summary>
        /// Ni#12 SetA
        /// </summary>
        [Display("Ni#12 SetA")]
        public double Ni_12_SetA { get; set; }
        /// <summary>
        /// Ni#13 FbA
        /// </summary>
        [Display("Ni#13 FbA")]
        public double Ni_13_FbA { get; set; }
        /// <summary>
        /// Ni#13 FbV
        /// </summary>
        [Display("Ni#13 FbV")]
        public double Ni_13_FbV { get; set; }
        /// <summary>
        /// Ni#13 SetA
        /// </summary>
        [Display("Ni#13 SetA")]
        public double Ni_13_SetA { get; set; }
        /// <summary>
        /// Ni#14 FbA
        /// </summary>
        [Display("Ni#14 FbA")]
        public double Ni_14_FbA { get; set; }
        /// <summary>
        /// Ni#14 FbV
        /// </summary>
        [Display("Ni#14 FbV")]
        public double Ni_14_FbV { get; set; }
        /// <summary>
        /// Ni#14 SetA
        /// </summary>
        [Display("Ni#14 SetA")]
        public double Ni_14_SetA { get; set; }
        /// <summary>
        /// Ni#15 FbA
        /// </summary>
        [Display("Ni#15 FbA")]
        public double Ni_15_FbA { get; set; }
        /// <summary>
        /// Ni#15 FbV
        /// </summary>
        [Display("Ni#15 FbV")]
        public double Ni_15_FbV { get; set; }
        /// <summary>
        /// Ni#15 SetA
        /// </summary>
        [Display("Ni#15 SetA")]
        public double Ni_15_SetA { get; set; }
        /// <summary>
        /// Ni#16 FbA
        /// </summary>
        [Display("Ni#16 FbA")]
        public double Ni_16_FbA { get; set; }
        /// <summary>
        /// Ni#16 FbV
        /// </summary>
        [Display("Ni#16 FbV")]
        public double Ni_16_FbV { get; set; }
        /// <summary>
        /// Ni#16 SetA
        /// </summary>
        [Display("Ni#16 SetA")]
        public double Ni_16_SetA { get; set; }
        /// <summary>
        /// Ni#17 FbA
        /// </summary>
        [Display("Ni#17 FbA")]
        public double Ni_17_FbA { get; set; }
        /// <summary>
        /// Ni#17 FbV
        /// </summary>
        [Display("Ni#17 FbV")]
        public double Ni_17_FbV { get; set; }
        /// <summary>
        /// Ni#17 SetA
        /// </summary>
        [Display("Ni#17 SetA")]
        public double Ni_17_SetA { get; set; }
        /// <summary>
        /// Ni#18 FbA
        /// </summary>
        [Display("Ni#18 FbA")]
        public double Ni_18_FbA { get; set; }
        /// <summary>
        /// Ni#18 FbV
        /// </summary>
        [Display("Ni#18 FbV")]
        public double Ni_18_FbV { get; set; }
        /// <summary>
        /// Ni#18 SetA
        /// </summary>
        [Display("Ni#18 SetA")]
        public double Ni_18_SetA { get; set; }
        /// <summary>
        /// Ni#19 FbA
        /// </summary>
        [Display("Ni#19 FbA")]
        public double Ni_19_FbA { get; set; }
        /// <summary>
        /// Ni#19 FbV
        /// </summary>
        [Display("Ni#19 FbV")]
        public double Ni_19_FbV { get; set; }
        /// <summary>
        /// Ni#19 SetA
        /// </summary>
        [Display("Ni#19 SetA")]
        public double Ni_19_SetA { get; set; }
        /// <summary>
        /// Ni#20 FbA
        /// </summary>
        [Display("Ni#20 FbA")]
        public double Ni_20_FbA { get; set; }
        /// <summary>
        /// Ni#20 FbV
        /// </summary>
        [Display("Ni#20 FbV")]
        public double Ni_20_FbV { get; set; }
        /// <summary>
        /// Ni#20 SetA
        /// </summary>
        [Display("Ni#20 SetA")]
        public double Ni_20_SetA { get; set; }
        /// <summary>
        /// Ni#21 FbA
        /// </summary>
        [Display("Ni#21 FbA")]
        public double Ni_21_FbA { get; set; }
        /// <summary>
        /// Ni#21 FbV
        /// </summary>
        [Display("Ni#21 FbV")]
        public double Ni_21_FbV { get; set; }
        /// <summary>
        /// Ni#21 SetA
        /// </summary>
        [Display("Ni#21 SetA")]
        public double Ni_21_SetA { get; set; }
        /// <summary>
        /// Ni#22 FbA
        /// </summary>
        [Display("Ni#22 FbA")]
        public double Ni_22_FbA { get; set; }
        /// <summary>
        /// Ni#22 FbV
        /// </summary>
        [Display("Ni#22 FbV")]
        public double Ni_22_FbV { get; set; }
        /// <summary>
        /// Ni#22 SetA
        /// </summary>
        [Display("Ni#22 SetA")]
        public double Ni_22_SetA { get; set; }
        /// <summary>
        /// Ni#23 FbA
        /// </summary>
        [Display("Ni#23 FbA")]
        public double Ni_23_FbA { get; set; }
        /// <summary>
        /// Ni#23 FbV
        /// </summary>
        [Display("Ni#23 FbV")]
        public double Ni_23_FbV { get; set; }
        /// <summary>
        /// Ni#23 SetA
        /// </summary>
        [Display("Ni#23 SetA")]
        public double Ni_23_SetA { get; set; }
        /// <summary>
        /// Ni#24 FbA
        /// </summary>
        [Display("Ni#24 FbA")]
        public double Ni_24_FbA { get; set; }
        /// <summary>
        /// Ni#24 FbV
        /// </summary>
        [Display("Ni#24 FbV")]
        public double Ni_24_FbV { get; set; }
        /// <summary>
        /// Ni#24 SetA
        /// </summary>
        [Display("Ni#24 SetA")]
        public double Ni_24_SetA { get; set; }
        /// <summary>
        /// Ni#25 FbA
        /// </summary>
        [Display("Ni#25 FbA")]
        public double Ni_25_FbA { get; set; }
        /// <summary>
        /// Ni#25 FbV
        /// </summary>
        [Display("Ni#25 FbV")]
        public double Ni_25_FbV { get; set; }
        /// <summary>
        /// Ni#25 SetA
        /// </summary>
        [Display("Ni#25 SetA")]
        public double Ni_25_SetA { get; set; }
        /// <summary>
        /// Ni#26 FbA
        /// </summary>
        [Display("Ni#26 FbA")]
        public double Ni_26_FbA { get; set; }
        /// <summary>
        /// Ni#26 FbV
        /// </summary>
        [Display("Ni#26 FbV")]
        public double Ni_26_FbV { get; set; }
        /// <summary>
        /// Ni#26 SetA
        /// </summary>
        [Display("Ni#26 SetA")]
        public double Ni_26_SetA { get; set; }
        /// <summary>
        /// Ni#27 FbA
        /// </summary>
        [Display("Ni#27 FbA")]
        public double Ni_27_FbA { get; set; }
        /// <summary>
        /// Ni#27 FbV
        /// </summary>
        [Display("Ni#27 FbV")]
        public double Ni_27_FbV { get; set; }
        /// <summary>
        /// Ni#27 SetA
        /// </summary>
        [Display("Ni#27 SetA")]
        public double Ni_27_SetA { get; set; }
        /// <summary>
        /// Ni#28 FbA
        /// </summary>
        [Display("Ni#28 FbA")]
        public double Ni_28_FbA { get; set; }
        /// <summary>
        /// Ni#28 FbV
        /// </summary>
        [Display("Ni#28 FbV")]
        public double Ni_28_FbV { get; set; }
        /// <summary>
        /// Ni#28 SetA
        /// </summary>
        [Display("Ni#28 SetA")]
        public double Ni_28_SetA { get; set; }
        /// <summary>
        /// Ni#29 FbA
        /// </summary>
        [Display("Ni#29 FbA")]
        public double Ni_29_FbA { get; set; }
        /// <summary>
        /// Ni#29 FbV
        /// </summary>
        [Display("Ni#29 FbV")]
        public double Ni_29_FbV { get; set; }
        /// <summary>
        /// Ni#29 SetA
        /// </summary>
        [Display("Ni#29 SetA")]
        public double Ni_29_SetA { get; set; }
        /// <summary>
        /// Ni#30 FbA
        /// </summary>
        [Display("Ni#30 FbA")]
        public double Ni_30_FbA { get; set; }
        /// <summary>
        /// Ni#30 FbV
        /// </summary>
        [Display("Ni#30 FbV")]
        public double Ni_30_FbV { get; set; }
        /// <summary>
        /// Ni#30 SetA
        /// </summary>
        [Display("Ni#30 SetA")]
        public double Ni_30_SetA { get; set; }

        /// <summary>
        /// Ni#31 FbA
        /// </summary>
        [Display("Ni#31 FbA")]
        public double Ni_31_FbA { get; set; }
        /// <summary>
        /// Ni#31 FbV
        /// </summary>
        [Display("Ni#31 FbV")]
        public double Ni_31_FbV { get; set; }
        /// <summary>
        /// Ni#31 SetA
        /// </summary>
        [Display("Ni#31 SetA")]
        public double Ni_31_SetA { get; set; }
        /// <summary>
        /// Ni#32 FbA
        /// </summary>
        [Display("Ni#32 FbA")]
        public double Ni_32_FbA { get; set; }
        /// <summary>
        /// Ni#32 FbV
        /// </summary>
        [Display("Ni#32 FbV")]
        public double Ni_32_FbV { get; set; }
        /// <summary>
        /// Ni#32 SetA
        /// </summary>
        [Display("Ni#32 SetA")]
        public double Ni_32_SetA { get; set; }
        /// <summary>
        /// Ni#33 FbA
        /// </summary>
        [Display("Ni#33 FbA")]
        public double Ni_33_FbA { get; set; }
        /// <summary>
        /// Ni#33 FbV
        /// </summary>
        [Display("Ni#33 FbV")]
        public double Ni_33_FbV { get; set; }
        /// <summary>
        /// Ni#33 SetA
        /// </summary>
        [Display("Ni#33 SetA")]
        public double Ni_33_SetA { get; set; }
        /// <summary>
        /// Ni#34 FbA
        /// </summary>
        [Display("Ni#34 FbA")]
        public double Ni_34_FbA { get; set; }
        /// <summary>
        /// Ni#34 FbV
        /// </summary>
        [Display("Ni#34 FbV")]
        public double Ni_34_FbV { get; set; }
        /// <summary>
        /// Ni#34 SetA
        /// </summary>
        [Display("Ni#34 SetA")]
        public double Ni_34_SetA { get; set; }
        /// <summary>
        /// Ni#35 FbA
        /// </summary>
        [Display("Ni#35 FbA")]
        public double Ni_35_FbA { get; set; }
        /// <summary>
        /// Ni#35 FbV
        /// </summary>
        [Display("Ni#35 FbV")]
        public double Ni_35_FbV { get; set; }
        /// <summary>
        /// Ni#35 SetA
        /// </summary>
        [Display("Ni#35 SetA")]
        public double Ni_35_SetA { get; set; }
        /// <summary>
        /// Ni#36 FbA
        /// </summary>
        [Display("Ni#36 FbA")]
        public double Ni_36_FbA { get; set; }
        /// <summary>
        /// Ni#36 FbV
        /// </summary>
        [Display("Ni#36 FbV")]
        public double Ni_36_FbV { get; set; }
        /// <summary>
        /// Ni#36 SetA
        /// </summary>
        [Display("Ni#36 SetA")]
        public double Ni_36_SetA { get; set; }
        /// <summary>
        /// Ni#37 FbA
        /// </summary>
        [Display("Ni#37 FbA")]
        public double Ni_37_FbA { get; set; }
        /// <summary>
        /// Ni#37 FbV
        /// </summary>
        [Display("Ni#37 FbV")]
        public double Ni_37_FbV { get; set; }
        /// <summary>
        /// Ni#37 SetA
        /// </summary>
        [Display("Ni#37 SetA")]
        public double Ni_37_SetA { get; set; }
        /// <summary>
        /// Ni#38 FbA
        /// </summary>
        [Display("Ni#38 FbA")]
        public double Ni_38_FbA { get; set; }
        /// <summary>
        /// Ni#38 FbV
        /// </summary>
        [Display("Ni#38 FbV")]
        public double Ni_38_FbV { get; set; }
        /// <summary>
        /// Ni#38 SetA
        /// </summary>
        [Display("Ni#38 SetA")]
        public double Ni_38_SetA { get; set; }
        /// <summary>
        /// Ni#39 FbA
        /// </summary>
        [Display("Ni#39 FbA")]
        public double Ni_39_FbA { get; set; }
        /// <summary>
        /// Ni#39 FbV
        /// </summary>
        [Display("Ni#39 FbV")]
        public double Ni_39_FbV { get; set; }
        /// <summary>
        /// Ni#39 SetA
        /// </summary>
        [Display("Ni#39 SetA")]
        public double Ni_39_SetA { get; set; }
        /// <summary>
        /// Ni#40 FbA
        /// </summary>
        [Display("Ni#40 FbA")]
        public double Ni_40_FbA { get; set; }
        /// <summary>
        /// Ni#40 FbV
        /// </summary>
        [Display("Ni#40 FbV")]
        public double Ni_40_FbV { get; set; }
        /// <summary>
        /// Ni#40 SetA
        /// </summary>
        [Display("Ni#40 SetA")]
        public double Ni_40_SetA { get; set; }
        /// <summary>
        /// Ni#41 FbA
        /// </summary>
        [Display("Ni#41 FbA")]
        public double Ni_41_FbA { get; set; }
        /// <summary>
        /// Ni#41 FbV
        /// </summary>
        [Display("Ni#41 FbV")]
        public double Ni_41_FbV { get; set; }
        /// <summary>
        /// Ni#41 SetA
        /// </summary>
        [Display("Ni#41 SetA")]
        public double Ni_41_SetA { get; set; }
        /// <summary>
        /// Ni#42 FbA
        /// </summary>
        [Display("Ni#42 FbA")]
        public double Ni_42_FbA { get; set; }
        /// <summary>
        /// Ni#42 FbV
        /// </summary>
        [Display("Ni#42 FbV")]
        public double Ni_42_FbV { get; set; }
        /// <summary>
        /// Ni#42 SetA
        /// </summary>
        [Display("Ni#42 SetA")]
        public double Ni_42_SetA { get; set; }
        /// <summary>
        /// Ni#43 FbA
        /// </summary>
        [Display("Ni#43 FbA")]
        public double Ni_43_FbA { get; set; }
        /// <summary>
        /// Ni#43 FbV
        /// </summary>
        [Display("Ni#43 FbV")]
        public double Ni_43_FbV { get; set; }
        /// <summary>
        /// Ni#43 SetA
        /// </summary>
        [Display("Ni#43 SetA")]
        public double Ni_43_SetA { get; set; }
        /// <summary>
        /// Ni#44 FbA
        /// </summary>
        [Display("Ni#44 FbA")]
        public double Ni_44_FbA { get; set; }
        /// <summary>
        /// Ni#44 FbV
        /// </summary>
        [Display("Ni#44 FbV")]
        public double Ni_44_FbV { get; set; }
        /// <summary>
        /// Ni#44 SetA
        /// </summary>
        [Display("Ni#44 SetA")]
        public double Ni_44_SetA { get; set; }
        /// <summary>
        /// Ni#45 FbA
        /// </summary>
        [Display("Ni#45 FbA")]
        public double Ni_45_FbA { get; set; }
        /// <summary>
        /// Ni#45 FbV
        /// </summary>
        [Display("Ni#45 FbV")]
        public double Ni_45_FbV { get; set; }
        /// <summary>
        /// Ni#45 SetA
        /// </summary>
        [Display("Ni#45 SetA")]
        public double Ni_45_SetA { get; set; }
        /// <summary>
        /// Ni#46 FbA
        /// </summary>
        [Display("Ni#46 FbA")]
        public double Ni_46_FbA { get; set; }
        /// <summary>
        /// Ni#46 FbV
        /// </summary>
        [Display("Ni#46 FbV")]
        public double Ni_46_FbV { get; set; }
        /// <summary>
        /// Ni#46 SetA
        /// </summary>
        [Display("Ni#46 SetA")]
        public double Ni_46_SetA { get; set; }
        /// <summary>
        /// Ni#47 FbA
        /// </summary>
        [Display("Ni#47 FbA")]
        public double Ni_47_FbA { get; set; }
        /// <summary>
        /// Ni#47 FbV
        /// </summary>
        [Display("Ni#47 FbV")]
        public double Ni_47_FbV { get; set; }
        /// <summary>
        /// Ni#47 SetA
        /// </summary>
        [Display("Ni#47 SetA")]
        public double Ni_47_SetA { get; set; }
        /// <summary>
        /// Ni#48 FbA
        /// </summary>
        [Display("Ni#48 FbA")]
        public double Ni_48_FbA { get; set; }
        /// <summary>
        /// Ni#48 FbV
        /// </summary>
        [Display("Ni#48 FbV")]
        public double Ni_48_FbV { get; set; }
        /// <summary>
        /// Ni#48 SetA
        /// </summary>
        [Display("Ni#48 SetA")]
        public double Ni_48_SetA { get; set; }

        /// <summary>
        /// AuSt#01 FbA
        /// </summary>
        [Display("AuSt#01 FbA")]
        public double AuSt_01_FbA { get; set; }
        /// <summary>
        /// AuSt#01 FbV
        /// </summary>
        [Display("AuSt#01 FbV")]
        public double AuSt_01_FbV { get; set; }
        /// <summary>
        /// AuSt#01 SetA
        /// </summary>
        [Display("AuSt#01 SetA")]
        public double AuSt_01_SetA { get; set; }
        /// <summary>
        /// AuSt#02 FbA
        /// </summary>
        [Display("AuSt#02 FbA")]
        public double AuSt_02_FbA { get; set; }
        /// <summary>
        /// AuSt#02 FbV
        /// </summary>
        [Display("AuSt#02 FbV")]
        public double AuSt_02_FbV { get; set; }
        /// <summary>
        /// AuSt#02 SetA
        /// </summary>
        [Display("AuSt#02 SetA")]
        public double AuSt_02_SetA { get; set; }
        /// <summary>
        /// Au#01 FbA
        /// </summary>
        [Display("Au#01 FbA")]
        public double Au_01_FbA { get; set; }
        /// <summary>
        /// Au#01 FbV
        /// </summary>
        [Display("Au#01 FbV")]
        public double Au_01_FbV { get; set; }
        /// <summary>
        /// Au#01 SetA
        /// </summary>
        [Display("Au#01 SetA")]
        public double Au_01_SetA { get; set; }
        /// <summary>
        /// Au#02 FbA
        /// </summary>
        [Display("Au#02 FbA")]
        public double Au_02_FbA { get; set; }
        /// <summary>
        /// Au#02 FbV
        /// </summary>
        [Display("Au#02 FbV")]
        public double Au_02_FbV { get; set; }
        /// <summary>
        /// Au#02 SetA
        /// </summary>
        [Display("Au#02 SetA")]
        public double Au_02_SetA { get; set; }
        /// <summary>
        /// Au#03 FbA
        /// </summary>
        [Display("Au#03 FbA")]
        public double Au_03_FbA { get; set; }
        /// <summary>
        /// Au#03 FbV
        /// </summary>
        [Display("Au#03 FbV")]
        public double Au_03_FbV { get; set; }
        /// <summary>
        /// Au#03 SetA
        /// </summary>
        [Display("Au#03 SetA")]
        public double Au_03_SetA { get; set; }
        /// <summary>
        /// Au#04 FbA
        /// </summary>
        [Display("Au#04 FbA")]
        public double Au_04_FbA { get; set; }
        /// <summary>
        /// Au#04 FbV
        /// </summary>
        [Display("Au#04 FbV")]
        public double Au_04_FbV { get; set; }
        /// <summary>
        /// Au#04 SetA
        /// </summary>
        [Display("Au#04 SetA")]
        public double Au_04_SetA { get; set; }
        /// <summary>
        /// Au#05 FbA
        /// </summary>
        [Display("Au#05 FbA")]
        public double Au_05_FbA { get; set; }
        /// <summary>
        /// Au#05 FbV
        /// </summary>
        [Display("Au#05 FbV")]
        public double Au_05_FbV { get; set; }
        /// <summary>
        /// Au#05 SetA
        /// </summary>
        [Display("Au#05 SetA")]
        public double Au_05_SetA { get; set; }
        /// <summary>
        /// Au#06 FbA
        /// </summary>
        [Display("Au#06 FbA")]
        public double Au_06_FbA { get; set; }
        /// <summary>
        /// Au#06 FbV
        /// </summary>
        [Display("Au#06 FbV")]
        public double Au_06_FbV { get; set; }
        /// <summary>
        /// Au#06 SetA
        /// </summary>
        [Display("Au#06 SetA")]
        public double Au_06_SetA { get; set; }
        /// <summary>
        /// Au#07 FbA
        /// </summary>
        [Display("Au#07 FbA")]
        public double Au_07_FbA { get; set; }
        /// <summary>
        /// Au#07 FbV
        /// </summary>
        [Display("Au#07 FbV")]
        public double Au_07_FbV { get; set; }
        /// <summary>
        /// Au#07 SetA
        /// </summary>
        [Display("Au#07 SetA")]
        public double Au_07_SetA { get; set; }
        /// <summary>
        /// Au#08 FbA
        /// </summary>
        [Display("Au#08 FbA")]
        public double Au_08_FbA { get; set; }
        /// <summary>
        /// Au#08 FbV
        /// </summary>
        [Display("Au#08 FbV")]
        public double Au_08_FbV { get; set; }
        /// <summary>
        /// Au#08 SetA
        /// </summary>
        [Display("Au#08 SetA")]
        public double Au_08_SetA { get; set; }
    }
}

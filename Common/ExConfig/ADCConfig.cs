using Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ExConfig
{
    public class ADCConfig
    {
        /// <summary>
        /// HotRinse#1溫度最大值
        /// </summary>
        [Display("HotRinse#1溫度最大值")]
        public double HotRinse_1_Temp_MaxValue { get; set; }
        /// <summary>
        /// HotRinse#1溫度最小值
        /// </summary>
        [Display("HotRinse#1溫度最小值")]
        public double HotRinse_1_Temp_MinValue { get; set; }

        /// <summary>
        /// HotRinse#2溫度最大值
        /// </summary>
        [Display("HotRinse#2溫度最大值")]
        public double HotRinse_2_Temp_MaxValue { get; set; }
        /// <summary>
        /// HotRinse#2溫度最小值
        /// </summary>
        [Display("HotRinse#2溫度最小值")]
        public double HotRinse_2_Temp_MinValue { get; set; }

        /// <summary>
        /// 脫脂過濾罐最大值
        /// </summary>
        [Display("脫脂過濾罐最大值")]
        public double Clean_MaxValue { get; set; }
        /// <summary>
        /// 脫脂過濾罐最小值
        /// </summary>
        [Display("脫脂過濾罐最小值")]
        public double Clean_MinValue { get; set; }
        /// <summary>
        /// 脫脂過濾罐溫度最大值
        /// </summary>
        [Display("脫脂過濾罐溫度最大值")]
        public double Cleaner_Temp_MaxValue { get; set; }
        /// <summary>
        /// 脫脂過濾溫度罐最小值
        /// </summary>
        [Display("脫脂過濾罐溫度最小值")]
        public double Cleaner_Temp_MinValue { get; set; }

        /// <summary>
        /// Ni.Etch溫度最大值
        /// </summary>
        [Display("Ni.Etch溫度最大值")]
        public double NiEtch_Temp_MaxValue { get; set; }
        /// <summary>
        /// Ni.Etch溫度最小值
        /// </summary>
        [Display("Ni.Etch溫度最小值")]
        public double NiEtch_Temp_MinValue { get; set; }

        /// <summary>
        /// 微蝕刻過濾罐最大值
        /// </summary>
        [Display("微蝕刻過濾罐最大值")]
        public double Microerching_MaxValue { get; set; }
        /// <summary>
        /// 微蝕刻過濾罐最小值
        /// </summary>
        [Display("微蝕刻過濾罐最小值")]
        public double Microerching_MinValue { get; set; }

        /// <summary>
        /// 微蝕刻過濾罐最大值
        /// </summary>
        [Display("微蝕刻過濾罐最大值")]
        public double ACID1_MaxValue { get; set; }
        /// <summary>
        /// 酸1過濾罐最小值
        /// </summary>
        [Display("酸1過濾罐最小值")]
        public double ACID1_MinValue { get; set; }

        /// <summary>
        /// Ni#1溫度最大值
        /// </summary>
        [Display("Ni#1溫度最大值")]
        public double Ni1_Temp_MaxValue { get; set; }
        /// <summary>
        /// Ni#1溫度最小值
        /// </summary>
        [Display("Ni#1溫度最小值")]
        public double Ni1_Temp_MinValue { get; set; }

        /// <summary>
        /// 鎳金1-1最大值
        /// </summary>
        [Display("鎳金1-1最大值")]
        public double Nickel1_1_MaxValue { get; set; }
        /// <summary>
        /// 鎳金1-1最小值
        /// </summary>
        [Display("鎳金1-1最小值")]
        public double Nickel1_1_MinValue { get; set; }

        /// <summary>
        /// 鎳金1-2最大值
        /// </summary>
        [Display("鎳金1-2最大值")]
        public double Nickel1_2_MaxValue { get; set; }
        /// <summary>
        /// 鎳金1-2最小值
        /// </summary>
        [Display("鎳金1-2最小值")]
        public double Nickel1_2_MinValue { get; set; }

        /// <summary>
        /// 鎳金1-3最大值
        /// </summary>
        [Display("Ni 1-3最大值")]
        public double Nickel1_3_MaxValue { get; set; }
        /// <summary>
        /// 鎳金1-3最小值
        /// </summary>
        [Display("鎳金1-3最小值")]
        public double Nickel1_3_MinValue { get; set; }

        /// <summary>
        /// 鎳金1空氣流量計1最大值
        /// </summary>
        [Display("鎳金1空氣流量計1最大值")]
        public double Nickel1_Air_1_MaxValue { get; set; }
        /// <summary>
        /// 鎳金1空氣流量計1最小值
        /// </summary>
        [Display("鎳金1空氣流量計1最小值")]
        public double Nickel1_Air_1_MinValue { get; set; }

        /// <summary>
        /// 鎳金1空氣流量計2最大值
        /// </summary>
        [Display("鎳金1空氣流量計2最大值")]
        public double Nickel1_Air_2_MaxValue { get; set; }
        /// <summary>
        /// 鎳金1空氣流量計2最小值
        /// </summary>
        [Display("鎳金1空氣流量計2最小值")]
        public double Nickel1_Air_2_MinValue { get; set; }

        /// <summary>
        /// 鎳金1空氣流量計3最大值
        /// </summary>
        [Display("鎳金1空氣流量計3最大值")]
        public double Nickel1_Air_3_MaxValue { get; set; }
        /// <summary>
        /// 鎳金1空氣流量計3最小值
        /// </summary>
        [Display("鎳金1空氣流量計3最小值")]
        public double Nickel1_Air_3_MinValue { get; set; }

        /// <summary>
        /// 鎳金1空氣流量計4最大值
        /// </summary>
        [Display("鎳金1空氣流量計4最大值")]
        public double Nickel1_Air_4_MaxValue { get; set; }
        /// <summary>
        /// 鎳金1空氣流量計4最小值
        /// </summary>
        [Display("鎳金1空氣流量計4最小值")]
        public double Nickel1_Air_4_MinValue { get; set; }

        /// <summary>
        /// 鎳金1空氣流量計5最大值
        /// </summary>
        [Display("鎳金1空氣流量計5最大值")]
        public double Nickel1_Air_5_MaxValue { get; set; }
        /// <summary>
        /// 鎳金1空氣流量計5最小值
        /// </summary>
        [Display("鎳金1空氣流量計5最小值")]
        public double Nickel1_Air_5_MinValue { get; set; }

        /// <summary>
        /// 鎳金1空氣流量計6最大值
        /// </summary>
        [Display("鎳金1空氣流量計6最大值")]

        public double Nickel1_Air_6_MaxValue { get; set; }
        /// <summary>
        /// 鎳金1空氣流量計6最小值
        /// </summary>
        [Display("鎳金1空氣流量計6最小值")]
        public double Nickel1_Air_6_MinValue { get; set; }

        /// <summary>
        /// Ni#2溫度最大值
        /// </summary>
        [Display("Ni#2溫度最大值")]
        public double Ni2_Temp_MaxValue { get; set; }
        /// <summary>
        /// Ni#2溫度最小值
        /// </summary>
        [Display("Ni#2溫度最小值")]
        public double Ni2_Temp_MinValue { get; set; }

        /// <summary>
        ///鎳金2-1最大值
        /// </summary>
        [Display("鎳金2-1最大值")]
        public double Nickel2_1_MaxValue { get; set; }
        /// <summary>
        ///鎳金2-1最小值
        /// </summary>
        [Display("鎳金2-1最小值")]
        public double Nickel2_1_MinValue { get; set; }

        /// <summary>
        ///鎳金2-2最大值
        /// </summary>
        [Display("鎳金2-2最大值")]
        public double Nickel2_2_MaxValue { get; set; }
        /// <summary>
        ///鎳金2-2最小值
        /// </summary>
        [Display("鎳金2-2最小值")]
        public double Nickel2_2_MinValue { get; set; }

        /// <summary>
        ///鎳金2-3最大值
        /// </summary>
        [Display("鎳金2-3最大值")]
        public double Nickel2_3_MaxValue { get; set; }
        /// <summary>
        ///鎳金2-3最小值
        /// </summary>
        [Display("鎳金2-3最小值")]
        public double Nickel2_3_MinValue { get; set; }

        /// <summary>
        /// 鎳金2空氣流量計1最大值
        /// </summary>
        [Display("鎳金2空氣流量計1最大值")]
        public double Nickel2_Air_1_MaxValue { get; set; }
        /// <summary>
        /// 鎳金2空氣流量計1最小值
        /// </summary>
        [Display("鎳金2空氣流量計1最小值")]
        public double Nickel2_Air_1_MinValue { get; set; }

        /// <summary>
        /// 鎳金2空氣流量計2最大值
        /// </summary>
        [Display("鎳金2空氣流量計2最大值")]
        public double Nickel2_Air_2_MaxValue { get; set; }
        /// <summary>
        /// 鎳金2空氣流量計2最小值
        /// </summary>
        [Display("鎳金2空氣流量計2最小值")]
        public double Nickel2_Air_2_MinValue { get; set; }

        /// <summary>
        /// 鎳金2空氣流量計3最大值
        /// </summary>
        [Display("鎳金2空氣流量計3最大值")]
        public double Nickel2_Air_3_MaxValue { get; set; }
        /// <summary>
        /// 鎳金2空氣流量計3最小值
        /// </summary>
        [Display("鎳金2空氣流量計3最小值")]
        public double Nickel2_Air_3_MinValue { get; set; }

        /// <summary>
        /// 鎳金2空氣流量計4最大值
        /// </summary>
        [Display("鎳金2空氣流量計4最大值")]
        public double Nickel2_Air_4_MaxValue { get; set; }
        /// <summary>
        /// 鎳金2空氣流量計4最小值
        /// </summary>
        [Display("鎳金2空氣流量計4最小值")]
        public double Nickel2_Air_4_MinValue { get; set; }

        /// <summary>
        /// 鎳金2空氣流量計5最大值
        /// </summary>
        [Display("鎳金2空氣流量計5最大值")]
        public double Nickel2_Air_5_MaxValue { get; set; }
        /// <summary>
        /// 鎳金2空氣流量計5最小值
        /// </summary>
        [Display("鎳金2空氣流量計5最小值")]
        public double Nickel2_Air_5_MinValue { get; set; }

        /// <summary>
        /// 鎳金2空氣流量計6最大值
        /// </summary>
        [Display("鎳金2空氣流量計6最大值")]
        public double Nickel2_Air_6_MaxValue { get; set; }
        /// <summary>
        /// 鎳金2空氣流量計6最小值
        /// </summary>
        [Display("鎳金2空氣流量計6最小值")]
        public double Nickel2_Air_6_MinValue { get; set; }

        /// <summary>
        /// Ni#3溫度最大值
        /// </summary>
        [Display("Ni#3溫度最大值")]
        public double Ni3_Temp_MaxValue { get; set; }
        /// <summary>
        /// Ni#3溫度最小值
        /// </summary>
        [Display("Ni#3溫度最小值")]
        public double Ni3_Temp_MinValue { get; set; }

        /// <summary>
        ///鎳金3-1最大值
        /// </summary>
        [Display("鎳金3-1最大值")]
        public double Nickel3_1_MaxValue { get; set; }
        /// <summary>
        ///鎳金3-1最小值
        /// </summary>
        [Display("鎳金3-1最小值")]
        public double Nickel3_1_MinValue { get; set; }

        /// <summary>
        ///鎳金3-2最大值
        /// </summary>
        [Display("鎳金3-2最大值")]
        public double Nickel3_2_MaxValue { get; set; }
        /// <summary>
        ///鎳金3-2最小值
        /// </summary>
        [Display("鎳金3-2最小值")]
        public double Nickel3_2_MinValue { get; set; }

        /// <summary>
        ///鎳金3-3最大值
        /// </summary>
        [Display("鎳金3-3最大值")]
        public double Nickel3_3_MaxValue { get; set; }
        /// <summary>
        ///鎳金3-3最小值
        /// </summary>
        [Display("鎳金3-3最小值")]
        public double Nickel3_3_MinValue { get; set; }

        /// <summary>
        /// 鎳金3空氣流量計1最大值
        /// </summary>
        [Display("鎳金3空氣流量計1最大值")]
        public double Nickel3_Air_1_MaxValue { get; set; }
        /// <summary>
        /// 鎳金3空氣流量計1最小值
        /// </summary>
        [Display("鎳金3空氣流量計1最小值")]
        public double Nickel3_Air_1_MinValue { get; set; }

        /// <summary>
        /// 鎳金3空氣流量計2最大值
        /// </summary>
        [Display("鎳金3空氣流量計2最大值")]
        public double Nickel3_Air_2_MaxValue { get; set; }
        /// <summary>
        /// 鎳金3空氣流量計2最小值
        /// </summary>
        [Display("鎳金3空氣流量計2最小值")]
        public double Nickel3_Air_2_MinValue { get; set; }

        /// <summary>
        /// 鎳金3空氣流量計3最大值
        /// </summary>
        [Display("鎳金3空氣流量計3最大值")]
        public double Nickel3_Air_3_MaxValue { get; set; }
        /// <summary>
        /// 鎳金3空氣流量計3最小值
        /// </summary>
        [Display("鎳金3空氣流量計3最小值")]
        public double Nickel3_Air_3_MinValue { get; set; }

        /// <summary>
        /// 鎳金3空氣流量計4最大值
        /// </summary>
        [Display("鎳金3空氣流量計4最大值")]
        public double Nickel3_Air_4_MaxValue { get; set; }
        /// <summary>
        /// 鎳金3空氣流量計4最小值
        /// </summary>
        [Display("鎳金3空氣流量計4最小值")]
        public double Nickel3_Air_4_MinValue { get; set; }

        /// <summary>
        /// 鎳金3空氣流量計5最大值
        /// </summary>
        [Display("鎳金3空氣流量計5最大值")]
        public double Nickel3_Air_5_MaxValue { get; set; }
        /// <summary>
        /// 鎳金3空氣流量計5最小值
        /// </summary>
        [Display("鎳金3空氣流量計5最小值")]
        public double Nickel3_Air_5_MinValue { get; set; }

        /// <summary>
        /// 鎳金3空氣流量計6最大值
        /// </summary>
        [Display("鎳金3空氣流量計6最大值")]
        public double Nickel3_Air_6_MaxValue { get; set; }
        /// <summary>
        /// 鎳金3空氣流量計6最小值
        /// </summary>
        [Display("鎳金3空氣流量計6最小值")]
        public double Nickel3_Air_6_MinValue { get; set; }

        /// <summary>
        /// Ni#4溫度最大值
        /// </summary>
        [Display("Ni#4溫度最大值")]
        public double Ni4_Temp_MaxValue { get; set; }
        /// <summary>
        /// Ni#4溫度最小值
        /// </summary>
        [Display("Ni#4溫度最小值")]
        public double Ni4_Temp_MinValue { get; set; }

        /// <summary>
        ///鎳金4-1最大值
        /// </summary>
        [Display("鎳金4-1最大值")]
        public double Nickel4_1_MaxValue { get; set; }
        /// <summary>
        ///鎳金4-1最小值
        /// </summary>
        [Display("鎳金4-1最小值")]
        public double Nickel4_1_MinValue { get; set; }

        /// <summary>
        ///鎳金4-2最大值
        /// </summary>
        [Display("鎳金4-2最大值")]
        public double Nickel4_2_MaxValue { get; set; }
        /// <summary>
        ///鎳金4-2最小值
        /// </summary>
        [Display("鎳金4-2最小值")]
        public double Nickel4_2_MinValue { get; set; }

        /// <summary>
        ///鎳金4-3最大值
        /// </summary>
        [Display("鎳金4-3最大值")]
        public double Nickel4_3_MaxValue { get; set; }
        /// <summary>
        ///鎳金4-3最小值
        /// </summary>
        [Display("鎳金4-3最小值")]
        public double Nickel4_3_MinValue { get; set; }

        /// <summary>
        /// 鎳金4空氣流量計1最大值
        /// </summary>
        [Display("鎳金4空氣流量計1最大值")]
        public double Nickel4_Air_1_MaxValue { get; set; }
        /// <summary>
        /// 鎳金4空氣流量計1最小值
        /// </summary>
        [Display("鎳金4空氣流量計1最小值")]
        public double Nickel4_Air_1_MinValue { get; set; }

        /// <summary>
        /// 鎳金4空氣流量計2最大值
        /// </summary>
        [Display("鎳金4空氣流量計2最大值")]
        public double Nickel4_Air_2_MaxValue { get; set; }
        /// <summary>
        /// 鎳金4空氣流量計2最小值
        /// </summary>
        [Display("鎳金4空氣流量計2最小值")]
        public double Nickel4_Air_2_MinValue { get; set; }

        /// <summary>
        /// 鎳金4空氣流量計3最大值
        /// </summary>
        [Display("鎳金4空氣流量計3最大值")]
        public double Nickel4_Air_3_MaxValue { get; set; }
        /// <summary>
        /// 鎳金4空氣流量計3最小值
        /// </summary>
        [Display("鎳金4空氣流量計3最小值")]
        public double Nickel4_Air_3_MinValue { get; set; }

        /// <summary>
        /// 鎳金4空氣流量計4最大值
        /// </summary>
        [Display("鎳金4空氣流量計4最大值")]
        public double Nickel4_Air_4_MaxValue { get; set; }
        /// <summary>
        /// 鎳金4空氣流量計4最小值
        /// </summary>
        [Display("鎳金4空氣流量計4最小值")]
        public double Nickel4_Air_4_MinValue { get; set; }

        /// <summary>
        /// 鎳金4空氣流量計5最大值
        /// </summary>
        [Display("鎳金4空氣流量計5最大值")]
        public double Nickel4_Air_5_MaxValue { get; set; }
        /// <summary>
        /// 鎳金4空氣流量計5最小值
        /// </summary>
        [Display("鎳金4空氣流量計5最小值")]
        public double Nickel4_Air_5_MinValue { get; set; }

        /// <summary>
        /// 鎳金4空氣流量計6最大值
        /// </summary>
        [Display("鎳金4空氣流量計6最大值")]
        public double Nickel4_Air_6_MaxValue { get; set; }
        /// <summary>
        /// 鎳金4空氣流量計6最小值
        /// </summary>
        [Display("鎳金4空氣流量計6最小值")]
        public double Nickel4_Air_6_MinValue { get; set; }

        /// <summary>
        /// AuSt溫度最大值
        /// </summary>
        [Display("AuSt溫度最大值")]
        public double AuSt_Temp_MaxValue { get; set; }
        /// <summary>
        /// AuSt溫度最小值
        /// </summary>
        [Display("AuSt溫度最小值")]
        public double AuSt_Temp_MinValue { get; set; }

        /// <summary>
        /// 預鍍金過濾罐最大值
        /// </summary>
        [Display("預鍍金過濾罐最大值")]
        public double AuSt_MaxValue { get; set; }
        /// <summary>
        /// 預鍍金過濾罐最小值
        /// </summary>
        [Display("預鍍金過濾罐最小值")]
        public double AuSt_MinValue { get; set; }

        /// <summary>
        /// Au#1溫度最大值
        /// </summary>
        [Display("Au#1溫度最大值")]
        public double Au_1_Temp_MaxValue { get; set; }
        /// <summary>
        /// Au#1溫度最小值
        /// </summary>
        [Display("Au#1溫度最小值")]
        public double Au_1_Temp_MinValue { get; set; }

        /// <summary>
        /// Au#1過濾罐最大值
        /// </summary>
        [Display("Au#1過濾罐最大值")]
        public double Au_1_MaxValue { get; set; }
        /// <summary>
        /// Au#1過濾罐最小值
        /// </summary>
        [Display("Au#1過濾罐最小值")]
        public double Au_1_MinValue { get; set; }

        /// <summary>
        /// Au#2溫度最大值
        /// </summary>
        [Display("Au#2溫度最大值")]
        public double Au_2_Temp_MaxValue { get; set; }
        /// <summary>
        /// Au#2溫度最小值
        /// </summary>
        [Display("Au#2溫度最小值")]
        public double Au_2_Temp_MinValue { get; set; }

        /// <summary>
        /// Au#2過濾罐最大值
        /// </summary>
        [Display("Au#2過濾罐最大值")]
        public double Au_2_MaxValue { get; set; }
        /// <summary>
        /// Au#2過濾罐最小值
        /// </summary>
        [Display("Au#2過濾罐最小值")]
        public double Au_2_MinValue { get; set; }

        /// <summary>
        /// HDIR#1溫度最大值
        /// </summary>
        [Display("HDIR#1溫度最大值")]
        public double HDIR_1_Temp_MaxValue { get; set; }
        /// <summary>
        /// HDIR#1溫度最小值
        /// </summary>
        [Display("HDIR#1溫度最小值")]
        public double HDIR_1_Temp_MinValue { get; set; }

        /// <summary>
        /// HDIR#2溫度最大值
        /// </summary>
        [Display("HDIR#2溫度最大值")]
        public double HDIR_2_Temp_MaxValue { get; set; }
        /// <summary>
        /// HDIR#2溫度最小值
        /// </summary>
        [Display("HDIR#2溫度最小值")]
        public double HDIR_2_Temp_MinValue { get; set; }

        /// <summary>
        /// 水洗機1流量計最大值
        /// </summary>
        [Display("水洗機1流量計最大值")]
        public double Water11_MaxValue { get; set; }
        /// <summary>
        /// 水洗機1流量計最小值
        /// </summary>
        [Display("水洗機1流量計最小值")]
        public double Water11_MinValue { get; set; }

        /// <summary>
        /// 水洗機2流量計最大值
        /// </summary>
        [Display("水洗機2流量計最大值")]
        public double Water12_MaxValue { get; set; }
        /// <summary>
        /// 水洗機2流量計最小值
        /// </summary>
        [Display("水洗機2流量計最小值")]
        public double Water12_MinValue { get; set; }

        /// <summary>
        /// 水洗機3流量計最大值
        /// </summary>
        [Display("水洗機3流量計最大值")]
        public double Water13_MaxValue { get; set; }
        /// <summary>
        /// 水洗機3流量計最小值
        /// </summary>
        [Display("水洗機3流量計最小值")]
        public double Water13_MinValue { get; set; }

        /// <summary>
        /// 水洗機水洗槽噴壓01最大值
        /// </summary>
        [Display("水洗機水洗槽噴壓01最大值")]
        public double Rinse01_MaxValue { get; set; }
        /// <summary>
        /// 水洗機水洗槽噴壓01最小值
        /// </summary>
        [Display("水洗機水洗槽噴壓01最小值")]
        public double Rinse01_MinValue { get; set; }

        /// <summary>
        /// 水洗機水洗槽噴壓02最大值
        /// </summary>
        [Display("水洗機水洗槽噴壓02最大值")]
        public double Rinse02_MaxValue { get; set; }
        /// <summary>
        /// 水洗機水洗槽噴壓02最小值
        /// </summary>
        [Display("水洗機水洗槽噴壓02最小值")]
        public double Rinse02_MinValue { get; set; }

        /// <summary>
        /// 水洗機水洗槽噴壓03最大值
        /// </summary>
        [Display("水洗機水洗槽噴壓03最大值")]
        public double Rinse03_MaxValue { get; set; }
        /// <summary>
        /// 水洗機水洗槽噴壓03最小值
        /// </summary>
        [Display("水洗機水洗槽噴壓03最小值")]
        public double Rinse03_MinValue { get; set; }

        /// <summary>
        /// 水洗機水洗槽噴壓04最大值
        /// </summary>
        [Display("水洗機水洗槽噴壓04最大值")]
        public double Rinse04_MaxValue { get; set; }
        /// <summary>
        /// 水洗機水洗槽噴壓04最小值
        /// </summary>
        [Display("水洗機水洗槽噴壓04最小值")]
        public double Rinse04_MinValue { get; set; }

        /// <summary>
        /// 水洗機水洗槽噴壓05最大值
        /// </summary>
        [Display("水洗機水洗槽噴壓05最大值")]
        public double Rinse05_MaxValue { get; set; }
        /// <summary>
        /// 水洗機水洗槽噴壓05最小值
        /// </summary>
        [Display("水洗機水洗槽噴壓05最小值")]
        public double Rinse05_MinValue { get; set; }

        /// <summary>
        /// 水洗機水洗槽噴壓06最大值
        /// </summary>
        [Display("水洗機水洗槽噴壓06最大值")]
        public double Rinse06_MaxValue { get; set; }
        /// <summary>
        /// 水洗機水洗槽噴壓06最小值
        /// </summary>
        [Display("水洗機水洗槽噴壓06最小值")]
        public double Rinse06_MinValue { get; set; }

        /// <summary>
        /// 水洗機水洗槽噴壓07最大值
        /// </summary>
        [Display("水洗機水洗槽噴壓07最大值")]
        public double Rinse07_MaxValue { get; set; }
        /// <summary>
        /// 水洗機水洗槽噴壓07最小值
        /// </summary>
        [Display("水洗機水洗槽噴壓07最小值")]
        public double Rinse07_MinValue { get; set; }

        /// <summary>
        /// 水洗機水洗槽噴壓08最大值
        /// </summary>
        [Display("水洗機水洗槽噴壓08最大值")]
        public double Rinse08_MaxValue { get; set; }
        /// <summary>
        /// 水洗機水洗槽噴壓08最小值
        /// </summary>
        [Display("水洗機水洗槽噴壓08最小值")]
        public double Rinse08_MinValue { get; set; }

        /// <summary>
        /// 水洗機水洗槽噴壓09最大值
        /// </summary>
        [Display("水洗機水洗槽噴壓09最大值")]
        public double Rinse09_MaxValue { get; set; }
        /// <summary>
        /// 水洗機水洗槽噴壓09最小值
        /// </summary>
        [Display("水洗機水洗槽噴壓09最小值")]
        public double Rinse09_MinValue { get; set; }

        /// <summary>
        /// 水洗機水洗槽噴壓10最大值
        /// </summary>
        [Display("水洗機水洗槽噴壓10最大值")]
        public double Rinse10_MaxValue { get; set; }
        /// <summary>
        /// 水洗機水洗槽噴壓10最小值
        /// </summary>
        [Display("水洗機水洗槽噴壓10最小值")]
        public double Rinse10_MinValue { get; set; }

        /// <summary>
        /// 水洗機水洗槽噴壓11最大值
        /// </summary>
        [Display("水洗機水洗槽噴壓11最大值")]
        public double Rinse11_MaxValue { get; set; }
        /// <summary>
        /// 水洗機水洗槽噴壓11最小值
        /// </summary>
        [Display("水洗機水洗槽噴壓11最小值")]
        public double Rinse11_MinValue { get; set; }

        /// <summary>
        /// 水洗機水洗槽噴壓12最大值
        /// </summary>
        [Display("水洗機水洗槽噴壓12最大值")]
        public double Rinse12_MaxValue { get; set; }
        /// <summary>
        /// 水洗機水洗槽噴壓12最小值
        /// </summary>
        [Display("水洗機水洗槽噴壓12最小值")]
        public double Rinse12_MinValue { get; set; }

        /// <summary>
        /// 水洗機水洗槽噴壓13最大值
        /// </summary>
        [Display("水洗機水洗槽噴壓13最大值")]
        public double Rinse13_MaxValue { get; set; }
        /// <summary>
        /// 水洗機水洗槽噴壓13最小值
        /// </summary>
        [Display("水洗機水洗槽噴壓13最小值")]
        public double Rinse13_MinValue { get; set; }

        /// <summary>
        /// 水洗機風量1最大值
        /// </summary>
        [Display("水洗機風量1最大值")]
        public double Rinse_Flow1_MaxValue { get; set; }
        /// <summary>
        /// 水洗機風量1最小值
        /// </summary>
        [Display("水洗機風量1最小值")]
        public double Rinse_Flow1_MinValue { get; set; }

        /// <summary>
        /// 水洗機風量2最大值
        /// </summary>
        [Display("水洗機風量2最大值")]
        public double Rinse_Flow2_MaxValue { get; set; }
        /// <summary>
        /// 水洗機風量2最小值
        /// </summary>
        [Display("水洗機風量2最小值")]
        public double Rinse_Flow2_MinValue { get; set; }

        /// <summary>
        /// 水洗機風量3最大值
        /// </summary>
        [Display("水洗機風量3最大值")]
        public double Rinse_Flow3_MaxValue { get; set; }
        /// <summary>
        /// 水洗機風量3最小值
        /// </summary>
        [Display("水洗機風量3最小值")]
        public double Rinse_Flow3_MinValue { get; set; }

        /// <summary>
        /// 水洗機風量4最大值
        /// </summary>
        [Display("水洗機風量4最大值")]
        public double Rinse_Flow4_MaxValue { get; set; }
        /// <summary>
        /// 水洗機風量4最小值
        /// </summary>
        [Display("水洗機風量4最小值")]
        public double Rinse_Flow4_MinValue { get; set; }

        /// <summary>
        /// 水洗機電導度最大值
        /// </summary>
        [Display("水洗機電導度最大值")]
        public double Rinse_EC_MaxValue { get; set; }
        /// <summary>
        /// 水洗機電導度最小值
        /// </summary>
        [Display("水洗機電導度最小值")]
        public double Rinse_EC_MinValue { get; set; }

        /// <summary>
        /// 水洗機線速最大值
        /// </summary>
        [Display("水洗機線速最大值")]
        public double WM_LineSpeed_MaxValue { get; set; }
        /// <summary>
        /// 水洗機線速最小值
        /// </summary>
        [Display("水洗機線速最小值")]
        public double WM_LineSpeed_MinValue { get; set; }

        /// <summary>
        /// 水洗機溫度最大值
        /// </summary>
        [Display("水洗機溫度最大值")]
        public double WM_Temperature_MaxValue { get; set; }
        /// <summary>
        /// 水洗機溫度最小值
        /// </summary>
        [Display("水洗機溫度最小值")]
        public double WM_Temperature_MinValue { get; set; }
    }

}

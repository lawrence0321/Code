using Common.Attributes;
using System;

namespace Common.Enums
{
    public class CheckItemObject
    {        /// <summary>
        /// 前熱水洗(1) 溫度
        /// </summary>
        [Display("前熱水洗(1) 溫度")]
        public bool HotRinse_1_Temp { get; set; }
        /// <summary>
        /// 前熱水洗(2) 溫度
        /// </summary>
        [Display("前熱水洗(2) 溫度")]
        public bool HotRinse_2_Temp { get; set; }
        /// <summary>
        /// 脫脂 壓力
        /// </summary>
        [Display("脫脂 壓力")]
        public bool Clean { get; set; }
        /// <summary>
        /// 脫脂 溫度
        /// </summary>
        [Display("脫脂 溫度")]
        public bool Cleaner_Temp { get; set; }
        /// <summary>
        /// 微蝕 溫度
        /// </summary>
        [Display("微蝕 溫度")]
        public bool NiEtch_Temp { get; set; }
        /// <summary>
        /// 微蝕 壓力
        /// </summary>
        [Display("微蝕 壓力")]
        public bool Microerching { get; set; }
        /// <summary>
        /// 酸洗(1) 壓力
        /// </summary>
        [Display("酸洗(1) 壓力")]
        public bool ACID1 { get; set; }
        /// <summary>
        /// 鎳(1) 溫度
        /// </summary>
        [Display("鎳(1) 溫度")]
        public bool Ni1_Temp { get; set; }
        /// <summary>
        /// 鎳(1) 壓力(1)
        /// </summary>
        [Display("鎳(1) 壓力(1)")]
        public bool Nickel1_1 { get; set; }
        /// <summary>
        /// 鎳(1) 壓力(2)
        /// </summary>
        [Display("鎳(1) 壓力(2)")]
        public bool Nickel1_2 { get; set; }
        /// <summary>
        /// 鎳(1) 壓力(3)
        /// </summary>
        [Display("鎳(1) 壓力(3)")]
        public bool Nickel1_3 { get; set; }
        /// <summary>
        /// 鎳(1) 空氣流量(1)
        /// </summary>
        [Display("鎳(1) 空氣流量 1-1")]
        public bool Nickel1_Air_1 { get; set; }
        /// <summary>
        /// 鎳(1) 空氣流量(2)
        /// </summary>
        [Display("鎳(1) 空氣流量 1-2")]
        public bool Nickel1_Air_2 { get; set; }
        /// <summary>
        /// 鎳(1) 空氣流量(3)
        /// </summary>
        [Display("鎳(1) 空氣流量 1-3")]
        public bool Nickel1_Air_3 { get; set; }
        /// <summary>
        /// 鎳(1) 空氣流量(4)
        /// </summary>
        [Display("鎳(1) 空氣流量 1-4")]
        public bool Nickel1_Air_4 { get; set; }
        /// <summary>
        /// 鎳(1) 空氣流量(5)
        /// </summary>
        [Display("鎳(1) 空氣流量 1-5")]
        public bool Nickel1_Air_5 { get; set; }
        /// <summary>
        /// 鎳(1) 空氣流量(6)
        /// </summary>
        [Display("鎳(1) 空氣流量 1-6")]
        public bool Nickel1_Air_6 { get; set; }
        /// <summary>
        /// 鎳(2) 溫度
        /// </summary>
        [Display("鎳(2) 溫度")]
        public bool Ni2_Temp { get; set; }
        /// <summary>
        /// 鎳(2) 壓力(1)
        /// </summary>
        [Display("鎳(2) 壓力(1)")]
        public bool Nickel2_1 { get; set; }
        /// <summary>
        /// 鎳(2) 壓力(2)
        /// </summary>
        [Display("鎳(2) 壓力(2)")]
        public bool Nickel2_2 { get; set; }
        /// <summary>
        /// 鎳(2) 壓力(3)
        /// </summary>
        [Display("鎳(2) 壓力(3)")]
        public bool Nickel2_3 { get; set; }
        /// <summary>
        /// 鎳(2) 空氣流量(1)
        /// </summary>
        [Display("鎳(2) 空氣流量(1)")]
        public bool Nickel2_Air_1 { get; set; }
        /// <summary>
        /// 鎳(2) 空氣流量(2)
        /// </summary>
        [Display("鎳(2) 空氣流量(2)")]
        public bool Nickel2_Air_2 { get; set; }
        /// <summary>
        /// 鎳(2) 空氣流量(3)
        /// </summary>
        [Display("鎳(2) 空氣流量(3)")]
        public bool Nickel2_Air_3 { get; set; }
        /// <summary>
        /// 鎳(2) 空氣流量(4)
        /// </summary>
        [Display("鎳(2) 空氣流量(4)")]
        public bool Nickel2_Air_4 { get; set; }
        /// <summary>
        /// 鎳(2) 空氣流量(5)
        /// </summary>
        [Display("鎳(2) 空氣流量(5)")]
        public bool Nickel2_Air_5 { get; set; }
        /// <summary>
        /// 鎳(2) 空氣流量(6)
        /// </summary> 
        [Display("鎳(2) 空氣流量(6)")]
        public bool Nickel2_Air_6 { get; set; }
        /// <summary>
        /// 鎳(3) 溫度
        /// </summary>
        [Display("鎳(3) 溫度")]
        public bool Ni3_Temp { get; set; }
        /// <summary>
        /// 鎳(3) 壓力(1)
        /// </summary>
        [Display("鎳(3) 壓力(1)")]
        public bool Nickel3_1 { get; set; }
        /// <summary>
        /// 鎳(3) 壓力(2)
        /// </summary>
        [Display("鎳(3) 壓力(2)")]
        public bool Nickel3_2 { get; set; }
        /// <summary>
        /// 鎳(3) 壓力(3)
        /// </summary>
        [Display("鎳(3) 壓力(3)")]
        public bool Nickel3_3 { get; set; }
        /// <summary>
        /// 鎳(3) 空氣流量(1)
        /// </summary>
        [Display("鎳(3) 空氣流量(1)")]
        public bool Nickel3_Air_1 { get; set; }
        /// <summary>
        /// 鎳(3) 空氣流量(2)
        /// </summary>
        [Display("鎳(3) 空氣流量(2)")]
        public bool Nickel3_Air_2 { get; set; }
        /// <summary>
        /// 鎳(3) 空氣流量(3)
        /// </summary>
        [Display("鎳(3) 空氣流量(3)")]
        public bool Nickel3_Air_3 { get; set; }
        /// <summary>
        /// 鎳(3) 空氣流量(4)
        /// </summary>
        [Display("鎳(3) 空氣流量(4)")]
        public bool Nickel3_Air_4 { get; set; }
        /// <summary>
        /// 鎳(3) 空氣流量(5)
        /// </summary>
        [Display("鎳(3) 空氣流量(5)")]
        public bool Nickel3_Air_5 { get; set; }
        /// <summary>
        /// 鎳(3) 空氣流量(6)
        /// </summary>
        [Display("鎳(3) 空氣流量(6)")]
        public bool Nickel3_Air_6 { get; set; }
        /// <summary>
        /// 鎳(4) 溫度
        /// </summary>
        [Display("鎳(4) 溫度")]
        public bool Ni4_Temp { get; set; }
        /// <summary>
        /// 鎳(4) 壓力(1)
        /// </summary>
        [Display("鎳(4) 壓力(1)")]
        public bool Nickel4_1 { get; set; }
        /// <summary>
        /// 鎳(4) 壓力(2)
        /// </summary>
        [Display("鎳(4) 壓力(2)")]
        public bool Nickel4_2 { get; set; }
        /// <summary>
        /// 鎳(4) 壓力(3)
        /// </summary>
        [Display("鎳(4) 壓力(3)")]
        public bool Nickel4_3 { get; set; }
        /// <summary>
        /// 鎳(4) 空氣流量(1)
        /// </summary>
        [Display("鎳(4) 空氣流量(1)")]
        public bool Nickel4_Air_1 { get; set; }
        /// <summary>
        /// 鎳(4) 空氣流量(2)
        /// </summary>
        [Display("鎳(4) 空氣流量(2)")]
        public bool Nickel4_Air_2 { get; set; }
        /// <summary>
        /// 鎳(4) 空氣流量(3)
        /// </summary>
        [Display("鎳(4) 空氣流量(3)")]
        public bool Nickel4_Air_3 { get; set; }
        /// <summary>
        /// 鎳(4) 空氣流量(4)
        /// </summary>
        [Display("鎳(4) 空氣流量(4)")]
        public bool Nickel4_Air_4 { get; set; }
        /// <summary>
        /// 鎳(4) 空氣流量(5)
        /// </summary>
        [Display("鎳(4) 空氣流量(5)")]
        public bool Nickel4_Air_5 { get; set; }
        /// <summary>
        /// 鎳(4) 空氣流量(6)
        /// </summary>
        [Display("鎳(4) 空氣流量(6)")]
        public bool Nickel4_Air_6 { get; set; }
        /// <summary>
        /// 預金 溫度
        /// </summary>
        [Display("預金 溫度")]
        public bool AuSt_Temp { get; set; }
        /// <summary>
        /// 預金 壓力
        /// </summary>
        [Display("預金 壓力")]
        public bool AuSt { get; set; }
        /// <summary>
        /// 金(1) 溫度
        /// </summary>
        [Display("金(1) 溫度")]
        public bool Au_1_Temp { get; set; }
        /// <summary>
        /// 金(1) 壓力
        /// </summary>
        [Display("金(1) 壓力")]
        public bool Au_1 { get; set; }
        /// <summary>
        /// 金(2) 溫度
        /// </summary>
        [Display("金(2) 溫度")]
        public bool Au_2_Temp { get; set; }
        /// <summary>
        /// 金(2) 壓力
        /// </summary>
        [Display("金(2) 壓力")]
        public bool Au_2 { get; set; }
        /// <summary>
        ///後熱水洗(1) 溫度
        /// </summary>
        [Display("後熱水洗(1) 溫度")]
        public bool HDIR_1_Temp { get; set; }
        /// <summary>
        ///後熱水洗(2) 溫度
        /// </summary>
        [Display("後熱水洗(2) 溫度")]
        public bool HDIR_2_Temp { get; set; }

        /// <summary>
        /// 水洗機1流量計
        /// </summary>
        [Display("水洗機1流量計")]
        public bool WATER_11 { get; set; }
        /// <summary>
        /// 水洗機2流量計
        /// </summary>
        [Display("水洗機2流量計")]
        public bool WATER_12 { get; set; }
        /// <summary>
        /// 水洗機3流量計
        /// </summary>
        [Display("水洗機3流量計")]
        public bool WATER_13 { get; set; }
        /// <summary>
        /// 水洗機水洗槽噴壓01
        /// </summary>
        [Display("水洗機水洗槽噴壓01")]
        public bool Rinse1 { get; set; }
        /// <summary>
        /// 水洗機水洗槽噴壓02
        /// </summary>
        [Display("水洗機水洗槽噴壓02")]
        public bool Rinse2 { get; set; }
        /// <summary>
        /// 水洗機水洗槽噴壓03
        /// </summary>
        [Display("水洗機水洗槽噴壓03")]
        public bool Rinse3 { get; set; }
        /// <summary>
        /// 水洗機水洗槽噴壓04
        /// </summary>
        [Display("水洗機水洗槽噴壓04")]
        public bool Rinse4 { get; set; }
        /// <summary>
        /// 水洗機水洗槽噴壓05
        /// </summary>
        [Display("水洗機水洗槽噴壓05")]
        public bool Rinse5 { get; set; }
        /// <summary>
        /// 水洗機水洗槽噴壓06
        /// </summary>
        [Display("水洗機水洗槽噴壓06")]
        public bool Rinse6 { get; set; }
        /// <summary>
        /// 水洗機水洗槽噴壓07
        /// </summary>
        [Display("水洗機水洗槽噴壓07")]
        public bool Rinse7 { get; set; }
        /// <summary>
        /// 水洗機水洗槽噴壓08
        /// </summary>
        [Display("水洗機水洗槽噴壓08")]
        public bool Rinse8 { get; set; }
        /// <summary>
        /// 水洗機水洗槽噴壓09
        /// </summary>
        [Display("水洗機水洗槽噴壓09")]
        public bool Rinse9 { get; set; }
        /// <summary>
        /// 水洗機水洗槽噴壓10
        /// </summary>
        [Display("水洗機水洗槽噴壓10")]
        public bool Rinse10 { get; set; }
        /// <summary>
        /// 水洗機水洗槽噴壓11
        /// </summary>
        [Display("水洗機水洗槽噴壓11")]
        public bool Rinse11 { get; set; }
        /// <summary>
        /// 水洗機水洗槽噴壓12
        /// </summary>
        [Display("水洗機水洗槽噴壓12")]
        public bool Rinse12 { get; set; }
        /// <summary>
        /// 水洗機水洗槽噴壓13
        /// </summary>
        [Display("水洗機水洗槽噴壓13")]
        public bool Rinse13 { get; set; }
        /// <summary>
        /// 水洗機風量01
        /// </summary>
        [Display("水洗機風量01")]
        public bool Rinse_Flow1 { get; set; }
        /// <summary>
        /// 水洗機風量02
        /// </summary>
        [Display("水洗機風量02")]
        public bool Rinse_Flow2 { get; set; }
        /// <summary>
        /// 水洗機風量03
        /// </summary>
        [Display("水洗機風量03")]
        public bool Rinse_Flow3 { get; set; }
        /// <summary>
        /// 水洗機風量04
        /// </summary>
        [Display("水洗機風量04")]
        public bool Rinse_Flow4 { get; set; }
        /// <summary>
        /// 水洗機電導度
        /// </summary>
        [Display("水洗機電導度")]
        public bool Rinse_EC { get; set; }
        /// <summary>
        /// 水洗機線速
        /// </summary>
        [Display("水洗機線速")]
        public bool LineSpeed { get; set; }
        /// <summary>
        /// 水洗機溫度
        /// </summary>
        [Display("水洗機溫度")]
        public bool Temperature { get; set; }

    }

    [Flags]
    public enum CheckItemTypes : Int64
    {
        None = 0x0000_0000_0000_0000,
        /// <summary>
        /// 鍍鎳 (W/B)
        /// </summary>
        [Display("鍍鎳 (W/B)")]
        S1000002382 = 0x0000_0000_0000_0001,
        /// <summary>
        /// 鍍鎳 (B)
        /// </summary>
        [Display("鍍鎳 (B)")]
        S1000002383 = 0x0000_0000_0000_0002,
        /// <summary>
        /// 預鍍金 (A)
        /// </summary>
        [Display("預鍍金 (A)")]
        S1000002384 = 0x0000_0000_0000_0004,
        /// <summary>
        /// 鍍金 (W/B)
        /// </summary>
        [Display("鍍金 (W/B)")]
        S1000002385 = 0x0000_0000_0000_0008,
        /// <summary>
        /// 鍍金 (B)
        /// </summary>
        [Display("鍍金 (B)")]
        S1000002386 = 0x0000_0000_0000_0010,
        /// <summary>
        /// 前熱水洗(1) 溫度
        /// </summary>
        [Display("前熱水洗(1) 溫度")]
        S1000002390 = 0x0000_0000_0000_0020,
        /// <summary>
        /// 前熱水洗(2) 溫度
        /// </summary>
        [Display("前熱水洗(2) 溫度")]
        S1000002391 = 0x0000_0000_0000_0040,
        /// <summary>
        /// 脫脂 壓力
        /// </summary>
        [Display("脫脂 壓力")]
        S1000002392 = 0x0000_0000_0000_0080,
        /// <summary>
        /// 脫脂 溫度
        /// </summary>
        [Display("脫脂 溫度")]
        S1000002393 = 0x0000_0000_0000_0100,
        /// <summary>
        /// 微蝕 溫度
        /// </summary>
        [Display("微蝕 溫度")]
        S1000002394 = 0x0000_0000_0000_0200,
        /// <summary>
        /// 微蝕 壓力
        /// </summary>
        [Display("微蝕 壓力")]
        S1000002395 = 0x0000_0000_0000_0400,
        /// <summary>
        /// 酸洗(1) 壓力
        /// </summary>
        [Display("酸洗(1) 壓力")]
        S1000002396 = 0x0000_0000_0000_0800,
        /// <summary>
        /// 鎳(1) 溫度
        /// </summary>
        [Display("鎳(1) 溫度")]
        S1000002397 = 0x0000_0000_0000_1000,
        /// <summary>
        /// 鎳(1) 壓力(1)
        /// </summary>
        [Display("鎳(1) 壓力(1)")]
        S1000002398 = 0x0000_0000_0000_2000,
        /// <summary>
        /// 鎳(1) 壓力(2)
        /// </summary>
        [Display("鎳(1) 壓力(2)")]
        S1000002399 = 0x0000_0000_0000_4000,
        /// <summary>
        /// 鎳(1) 壓力(3)
        /// </summary>
        [Display("鎳(1) 壓力(3)")]
        S1000002400 = 0x0000_0000_0000_8000,
        /// <summary>
        /// 鎳(1) 空氣流量 (1)
        /// </summary>
        [Display("鎳(1) 空氣流量(1)")]
        S1000002401 = 0x0000_0000_0001_0000,
        /// <summary>
        /// 鎳(1) 空氣流量 (2)
        /// </summary>
        [Display("鎳(1) 空氣流量(2)")]
        S1000002402 = 0x0000_0000_0002_0000,
        /// <summary>
        /// 鎳(1) 空氣流量 (3)
        /// </summary>
        [Display("鎳(1) 空氣流量(3)")]
        S1000002403 = 0x0000_0000_0004_0000,
        /// <summary>
        /// 鎳(1) 空氣流量 (4)
        /// </summary>
        [Display("鎳(1) 空氣流量(4)")]
        S1000002404 = 0x0000_0000_0008_0000,
        /// <summary>
        /// 鎳(1) 空氣流量 (5)
        /// </summary>
        [Display("鎳(1) 空氣流量(5)")]
        S1000002405 = 0x0000_0000_0010_0000,
        /// <summary>
        /// 鎳(1) 空氣流量 (6)
        /// </summary>
        [Display("鎳(1) 空氣流量(6)")]
        S1000002406 = 0x0000_0000_0020_0000,
        /// <summary>
        /// 鎳(2) 溫度
        /// </summary>
        [Display("鎳(2) 溫度")]
        S1000002407 = 0x0000_0000_0040_0000,
        /// <summary>
        /// 鎳(2) 壓力(1)
        /// </summary>
        [Display("鎳(2) 壓力(1)")]
        S1000002408 = 0x0000_0000_0080_0000,
        /// <summary>
        /// 鎳(2) 壓力(2)
        /// </summary>
        [Display("鎳(2) 壓力(2)")]
        S1000002409 = 0x0000_0000_0100_0000,
        /// <summary>
        /// 鎳(2) 壓力(3)
        /// </summary>
        [Display("鎳(2) 壓力(3)")]
        S1000002410 = 0x0000_0000_0200_0000,
        /// <summary>
        /// 鎳(2) 空氣流量(1)
        /// </summary>
        [Display("鎳(2) 空氣流量(1)")]
        S1000002411 = 0x0000_0000_0400_0000,
        /// <summary>
        /// 鎳(2) 空氣流量(2)
        /// </summary>
        [Display("鎳(2) 空氣流量(2)")]
        S1000002412 = 0x0000_0000_0800_0000,
        /// <summary>
        /// 鎳(2) 空氣流量(3)
        /// </summary>
        [Display("鎳(2) 空氣流量(3)")]
        S1000002413 = 0x0000_0000_1000_0000,
        /// <summary>
        /// 鎳(2) 空氣流量(4)
        /// </summary>
        [Display("鎳(2) 空氣流量(4)")]
        S1000002414 = 0x0000_0000_2000_0000,
        /// <summary>
        /// 鎳(2) 空氣流量(5)
        /// </summary>
        [Display("鎳(2) 空氣流量(5)")]
        S1000002415 = 0x0000_0000_4000_0000,
        /// <summary>
        /// 鎳(2) 空氣流量(6)
        /// </summary>
        [Display("鎳(2) 空氣流量(6)")]
        S1000002416 = 0x0000_0000_8000_0000,
        /// <summary>
        /// 鎳(3) 溫度
        /// </summary>
        [Display("鎳(3) 溫度")]
        S1000002417 = 0x0000_0001_0000_0000,
        /// <summary>
        /// 鎳(3) 壓力(1)
        /// </summary>
        [Display("鎳(3) 壓力(1)")]
        S1000002418 = 0x0000_0002_0000_0000,
        /// <summary>
        /// 鎳(3) 壓力(2)
        /// </summary>
        [Display("鎳(3) 壓力(2)")]
        S1000002419 = 0x0000_0004_0000_0000,
        /// <summary>
        /// 鎳(3) 壓力(3)
        /// </summary>
        [Display("鎳(3) 壓力(3)")]
        S1000002420 = 0x0000_0008_0000_0000,
        /// <summary>
        /// 鎳(3) 空氣流量(1)
        /// </summary>
        [Display("鎳(3) 空氣流量(1)")]
        S1000002421 = 0x0000_0010_0000_0000,
        /// <summary>
        /// 鎳(3) 空氣流量(2)
        /// </summary>
        [Display("鎳(3) 空氣流量(2)")]
        S1000002422 = 0x0000_0020_0000_0000,
        /// <summary>
        /// 鎳(3) 空氣流量(3)
        /// </summary>
        [Display("鎳(3) 空氣流量(3)")]
        S1000002423 = 0x0000_0040_0000_0000,
        /// <summary>
        /// 鎳(3) 空氣流量(4)
        /// </summary>
        [Display("鎳(3) 空氣流量(4)")]
        S1000002424 = 0x0000_0080_0000_0000,
        /// <summary>
        /// 鎳(3) 空氣流量(5)
        /// </summary>
        [Display("鎳(3) 空氣流量(5)")]
        S1000002425 = 0x0000_0100_0000_0000,
        /// <summary>
        /// 鎳(3) 空氣流量(6)
        /// </summary>
        [Display("鎳(3) 空氣流量(6)")]
        S1000002426 = 0x0000_0200_0000_0000,
        /// <summary>
        /// 鎳(4) 溫度
        /// </summary>
        [Display("鎳(4) 溫度")]
        S1000002427 = 0x0000_0400_0000_0000,
        /// <summary>
        /// 鎳(4) 壓力(1)
        /// </summary>
        [Display("鎳(4) 壓力(1)")]
        S1000002428 = 0x0000_0800_0000_0000,
        /// <summary>
        /// 鎳(4) 壓力(2)
        /// </summary>
        [Display("鎳(4) 壓力(2)")]
        S1000002431 = 0x0000_1000_0000_0000,
        /// <summary>
        /// 鎳(4) 壓力(3)
        /// </summary>
        [Display("鎳(4) 壓力(3)")]
        S1000002432 = 0x0000_2000_0000_0000,
        /// <summary>
        /// 鎳(4) 空氣流量(1)
        /// </summary>
        [Display("鎳(4) 空氣流量(1)")]
        S1000002433 = 0x0000_4000_0000_0000,
        /// <summary>
        /// 鎳(4) 空氣流量(2)
        /// </summary>
        [Display("鎳(4) 空氣流量(2)")]
        S1000002434 = 0x0000_8000_0000_0000,
        /// <summary>
        /// 鎳(4) 空氣流量(3)
        /// </summary>
        [Display("鎳(4) 空氣流量(3)")]
        S1000002435 = 0x0001_0000_0000_0000,
        /// <summary>
        /// 鎳(4) 空氣流量(4)
        /// </summary>
        [Display("鎳(4) 空氣流量(4)")]
        S1000002436 = 0x0002_0000_0000_0000,
        /// <summary>
        /// 鎳(4) 空氣流量(5)
        /// </summary>
        [Display("鎳(4) 空氣流量(5)")]
        S1000002437 = 0x0004_0000_0000_0000,
        /// <summary>
        /// 鎳(4) 空氣流量(6)
        /// </summary>
        [Display("鎳(4) 空氣流量(6)")]
        S1000002438 = 0x0008_0000_0000_0000,
        /// <summary>
        /// 預金 溫度
        /// </summary>
        [Display("預金 溫度")]
        S1000002440 = 0x0010_0000_0000_0000,
        /// <summary>
        /// 預金 壓力
        /// </summary>
        [Display("預金 壓力")]
        S1000002441 = 0x0020_0000_0000_0000,
        /// <summary>
        /// 金(1) 溫度
        /// </summary>
        [Display("金(1) 溫度")]
        S1000002442 = 0x0040_0000_0000_0000,
        /// <summary>
        /// 金(1) 壓力
        /// </summary>
        [Display("金(1) 壓力")]
        S1000002443 = 0x0080_0000_0000_0000,
        /// <summary>
        /// 金(2) 溫度
        /// </summary>
        [Display("金(2) 溫度")]
        S1000002444 = 0x0100_0000_0000_0000,
        /// <summary>
        /// 金(2) 壓力
        /// </summary>
        [Display("金(2) 壓力")]
        S1000002445 = 0x0200_0000_0000_0000,
        /// <summary>
        ///後熱水洗(1) 溫度
        /// </summary>
        [Display("後熱水洗(1) 溫度")]
        S1000002446 = 0x0400_0000_0000_0000,
        /// <summary>
        ///後熱水洗(2) 溫度
        /// </summary>
        [Display("後熱水洗(2) 溫度")]
        S1000002447 = 0x0800_0000_0000_0000,
        /// <summary>
        /// 電鍍面積(Top)
        /// </summary>
        [Display("電鍍面積(Top)")]
        S1000004167 = 0x1000_0000_0000_0000,
        /// <summary>
        /// 電鍍面積(Bottom)
        /// </summary>
        [Display("電鍍面積(Bottom)")]
        S1000004170 = 0x2000_0000_0000_0000,

        ALL = 0x3FFF_FFFF_FFFF_FFFF,
    }
}

using Common.Attributes;
using System;

namespace Common.Enums
{
    [Flags]
    public enum AlarmTypes_Part03 : UInt64
    {
        None = 0x0000_0000_0000_0000,

        [Display(ENG_: "728 Cleaner Pump Trip(M21)", ZHTW_: "728 清潔槽馬達過載(M21)")]
        [AlarmInfo(728,046)]
        M728 = 0x0000_0000_0000_0001,

        [Display(ENG_: "729 Micro Etch Pump Trip(M22)", ZHTW_: "729 微蝕槽馬達過載(M22)")]
        [AlarmInfo(729,047)]
        M729 = 0x0000_0000_0000_0002,

        [Display(ENG_: "730 Micro Etch Pump Trip(M23)", ZHTW_: "730 微蝕槽馬達過載(M23)")]
        [AlarmInfo(730,048)]
        M730 = 0x0000_0000_0000_0004,

        [Display(ENG_: "731 Acid Dip Pump Trip(M24)", ZHTW_: "731 酸1槽馬達過載(M24)")]
        [AlarmInfo(731,048)]
        M731 = 0x0000_0000_0000_0008,


        [Display(ENG_: "732 Ni Plate1-1 Pump Trip(M31)", ZHTW_: "732 鎳1-1馬達過載(M31)")]
        [AlarmInfo(732,050)]
        M732 = 0x0000_0000_0000_0010,

        [Display(ENG_: "733 Ni Plate1-2 Pump Trip(M32)", ZHTW_: "733 鎳1-2馬達過載(M32)")]
        [AlarmInfo(733,051)]
        M733 = 0x0000_0000_0000_0020,

        [Display(ENG_: "734 Ni Plate1-3 Pump Trip(M33)", ZHTW_: "734 鎳1-3馬達過載(M33)")]
        [AlarmInfo(734,052)]
        M734 = 0x0000_0000_0000_0040,

        [Display(ENG_: "735 Ni Plate2-1 Pump Trip(M34)", ZHTW_: "735 鎳2-1馬達過載(M34)")]
        [AlarmInfo(735,053)]
        M735 = 0x0000_0000_0000_0080,


        [Display(ENG_: "736 Ni Plate2-2 Pump Trip(M35)", ZHTW_: "736 鎳2-2馬達過載(M35)")]
        [AlarmInfo(736,054)]
        M736 = 0x0000_0000_0000_0100,

        [Display(ENG_: "737 Ni Plate2-3 Pump Trip(M36)", ZHTW_: "737 鎳2-3馬達過載(M36)")]
        [AlarmInfo(737,055)]
        M737 = 0x0000_0000_0000_0200,

        [Display(ENG_: "738 Ni Plate3-1 Pump Trip(M37)", ZHTW_: "738 鎳3-1馬達過載(M37)")]
        [AlarmInfo(738,056)]
        M738 = 0x0000_0000_0000_0400,

        [Display(ENG_: "739 Ni Plate3-2 Pump Trip(M38)", ZHTW_: "739 鎳3-2馬達過載(M38)")]
        [AlarmInfo(739,057)]
        M739 = 0x0000_0000_0000_0800,


        [Display(ENG_: "740 Ni Plate3-3 Pump Trip(M39)", ZHTW_: "740 鎳3-3馬達過載(M39)")]
        [AlarmInfo(740,058)]
        M740 = 0x0000_0000_0000_1000,

        [Display(ENG_: "741 Ni Plate4-1 Pump Trip(M40)", ZHTW_: "741 鎳4-1馬達過載(M40)")]
        [AlarmInfo(741,059)]
        M741 = 0x0000_0000_0000_2000,

        [Display(ENG_: "742 Ni Plate4-2 Pump Trip(M41)", ZHTW_: "742 鎳4-2馬達過載(M41)")]
        [AlarmInfo(742,060)]
        M742 = 0x0000_0000_0000_4000,

        [Display(ENG_: "743 Ni Plate4-3 Pump Trip(M42)", ZHTW_: "743 鎳4-3馬達過載(M42)")]
        [AlarmInfo(743,061)]
        M743 = 0x0000_0000_0000_8000,


        [Display(ENG_: "744 Au Strike Pump Trip(M43)", ZHTW_: "744 預金槽馬達過載(M43)")]
        [AlarmInfo(744,062)]
        M744 = 0x0000_0000_0001_0000,

        [Display(ENG_: "745 Au Plate1 Pump Trip (M44)", ZHTW_: "745 金1槽馬達過載(M44)")]
        [AlarmInfo(745,063)]
        M745 = 0x0000_0000_0002_0000,

        [Display(ENG_: "746 Au Plate2 Pump Trip (M45)", ZHTW_: "746 金2槽馬達過載(M44)")]
        [AlarmInfo(746,064)]
        M746 = 0x0000_0000_0004_0000,

        [Display(ENG_: "747 Ni Dummy Tank Pump Trip(M51)", ZHTW_: "747 鎳建浴槽馬達過載(M51)")]
        [AlarmInfo(747,065)]
        M747 = 0x0000_0000_0008_0000,


        [Display(ENG_: "748 Carbon Treatment Pump Trip(M52)", ZHTW_: "748 碳處理槽馬達過載(M52)")]
        [AlarmInfo(748,066)]
        M748 = 0x0000_0000_0010_0000,

        [Display(ENG_: "749 Carbon Treatment1 Mixer Trip(M53)", ZHTW_: "749 碳處理混合1槽馬達過載(M53)")]
        [AlarmInfo(749,067)]
        M749 = 0x0000_0000_0020_0000,

        [Display(ENG_: "750 Carbon Treatment2 Mixer Trip(M54)", ZHTW_: "750 碳處理混合2槽馬達過載(M54)")]
        [AlarmInfo(750,068)]
        M750 = 0x0000_0000_0040_0000,

        [Display(ENG_: "751 Blower Trip(M61)", ZHTW_: "751 鼓風機過載(M61)")]
        [AlarmInfo(751,069)]
        M751 = 0x0000_0000_0080_0000,


        [Display(ENG_: "752 Blower Trip(M62)", ZHTW_: "752 鼓風機過載(M62)")]
        [AlarmInfo(752,070)]
        M752 = 0x0000_0000_0100_0000,

        [Display(ENG_: "753 -", ZHTW_: "753 -")]
        [AlarmInfo(753)]
        M753 = 0x0000_0000_0200_0000,

        [Display(ENG_: "754 -", ZHTW_: "754 -")]
        [AlarmInfo(754)]
        M754 = 0x0000_0000_0400_0000,

        [Display(ENG_: "755 -", ZHTW_: "755 -")]
        [AlarmInfo(755)]
        M755 = 0x0000_0000_0800_0000,


        [Display(ENG_: "756 Emergency Stop(Pump)", ZHTW_: "756 緊急停止(馬達)")]
        [AlarmInfo(756,021)]
        M756 = 0x0000_0000_1000_0000,

        [Display(ENG_: "757 -", ZHTW_: "757 -")]
        [AlarmInfo(757)]
        M757 = 0x0000_0000_2000_0000,

        [Display(ENG_: "758 -", ZHTW_: "758 -")]
        [AlarmInfo(758)]
        M758 = 0x0000_0000_4000_0000,

        [Display(ENG_: "759 -", ZHTW_: "759 -")]
        [AlarmInfo(759)]
        M759 = 0x0000_0000_8000_0000,


        [Display(ENG_: "760 Cleaner Temp.Alarm(TC1)", ZHTW_: "760 清潔槽溫度異常(TC1)")]
        [AlarmInfo(760,030)]
        M760 = 0x0000_0001_0000_0000,

        [Display(ENG_: "761 Hot Rinse Temp.Alarm(TC2)", ZHTW_: "761 熱水洗溫度異常(TC2)")]
        [AlarmInfo(761,031)]
        M761 = 0x0000_0002_0000_0000,

        [Display(ENG_: "762 Hot Rinse Temp.Alarm(TC3)", ZHTW_: "762 熱水洗溫度異常(TC3)")]
        [AlarmInfo(762,032)]
        M762 = 0x0000_0004_0000_0000,

        [Display(ENG_: "763 Micro Etch Temp.Alarm(TC4)", ZHTW_: "763 微蝕槽溫度異常(TC4)")]
        [AlarmInfo(763,033)]
        M763 = 0x0000_0008_0000_0000,


        [Display(ENG_: "764 Ni Plate1 Temp.Alarm(TC5)", ZHTW_: "764 鎳1槽溫度異常(TC5)")]
        [AlarmInfo(764,034)]
        M764 = 0x0000_0010_0000_0000,

        [Display(ENG_: "765 Ni Plate2 Temp.Alarm(TC6)", ZHTW_: "765 鎳2槽溫度異常(TC6)")]
        [AlarmInfo(765,035)]
        M765 = 0x0000_0020_0000_0000,

        [Display(ENG_: "766 Ni Plate3 Temp.Alarm(TC7)", ZHTW_: "766 鎳3槽溫度異常(TC7)")]
        [AlarmInfo(766,036)]
        M766 = 0x0000_0040_0000_0000,

        [Display(ENG_: "767 Ni Plate4 Temp.Alarm(TC8)", ZHTW_: "767 鎳4槽溫度異常(TC8)")]
        [AlarmInfo(767,037)]
        M767 = 0x0000_0080_0000_0000,


        [Display(ENG_: "768 Au Strike Temp.Alarm(TC9)", ZHTW_: "768 預金槽溫度異常(TC9)")]
        [AlarmInfo(768,038)]
        M768 = 0x0000_0100_0000_0000,

        [Display(ENG_: "769 Au Plate1 Temp.Alarm(TC10)", ZHTW_: "769 金1槽溫度異常(TC10)")]
        [AlarmInfo(769,039)]
        M769 = 0x0000_0200_0000_0000,

        [Display(ENG_: "770 Au Plate2 Temp.Alarm(TC11)", ZHTW_: "770 金2槽溫度異常(TC11)")]
        [AlarmInfo(770,040)]
        M770 = 0x0000_0400_0000_0000,

        [Display(ENG_: "771 Hot D.I.Rinse Temp.Alarm(TC12)", ZHTW_: "771 熱水洗溫度異常(TC12)")]
        [AlarmInfo(771,041)]
        M771 = 0x0000_0800_0000_0000,


        [Display(ENG_: "772 Hot D.I.Rinse Temp.Alarm(TC13)", ZHTW_: "772 熱水洗溫度異常(TC13)")]
        [AlarmInfo(772,042)]
        M772 = 0x0000_1000_0000_0000,

        [Display(ENG_: "773 Ni Dummy Temp.Alarm(TC14)", ZHTW_: "773 鎳建浴槽溫度異常(TC14)")]
        [AlarmInfo(773,043)]
        M773 = 0x0000_2000_0000_0000,

        [Display(ENG_: "774 Carbon Treatment1 Temp.Alarm(TC15)", ZHTW_: "774 碳處理1槽溫度異常(TC15)")]
        [AlarmInfo(774,044)]
        M774 = 0x0000_4000_0000_0000,

        [Display(ENG_: "775 Carbon Treatment2 Temp.Alarm(TC16)", ZHTW_: "775 碳處理2槽溫度異常(TC16)")]
        [AlarmInfo(775,045)]
        M775 = 0x0000_8000_0000_0000,


        [Display(ENG_: "776 -", ZHTW_: "776 -")]
        [AlarmInfo(776)]
        M776 = 0x0001_0000_0000_0000,

        [Display(ENG_: "777 -", ZHTW_: "777 -")]
        [AlarmInfo(777)]
        M777 = 0x0002_0000_0000_0000,

        [Display(ENG_: "778 -", ZHTW_: "778 -")]
        [AlarmInfo(778)]
        M778 = 0x0004_0000_0000_0000,

        [Display(ENG_: "779 -", ZHTW_: "779 -")]
        [AlarmInfo(779)]
        M779 = 0x0008_0000_0000_0000,


        [Display(ENG_: "780 -人側闖入光閘觸發", ZHTW_: "780 -人側闖入光閘觸發")]
        [AlarmInfo(780)]
        M780 = 0x0010_0000_0000_0000,

        [Display(ENG_: "781 -人側闖入光閘觸發", ZHTW_: "781 -人側闖入光閘觸發")]
        [AlarmInfo(781)]
        M781 = 0x0020_0000_0000_0000,

        [Display(ENG_: "782 -", ZHTW_: "782 -")]
        [AlarmInfo(782)]
        M782 = 0x0040_0000_0000_0000,

        [Display(ENG_: "783 -", ZHTW_: "783 -")]
        [AlarmInfo(783)]
        M783 = 0x0080_0000_0000_0000,


        [Display(ENG_: "784 -", ZHTW_: "784 -")]
        [AlarmInfo(784)]
        M784 = 0x0100_0000_0000_0000,

        [Display(ENG_: "785 -", ZHTW_: "785 -")]
        [AlarmInfo(785)]
        M785 = 0x0200_0000_0000_0000,

        [Display(ENG_: "786 -", ZHTW_: "786 -")]
        [AlarmInfo(786)]
        M786 = 0x0400_0000_0000_0000,

        [Display(ENG_: "787 -", ZHTW_: "787 -")]
        [AlarmInfo(787)]
        M787 = 0x0800_0000_0000_0000,


        [Display(ENG_: "788 -", ZHTW_: "788 -")]
        [AlarmInfo(788)]
        M788 = 0x1000_0000_0000_0000,

        [Display(ENG_: "789 -", ZHTW_: "789 -")]
        [AlarmInfo(789)]
        M789 = 0x2000_0000_0000_0000,

        [Display(ENG_: "790 -", ZHTW_: "790 -")]
        [AlarmInfo(790)]
        M790 = 0x4000_0000_0000_0000,

        [Display(ENG_: "791 -", ZHTW_: "791 -")]
        [AlarmInfo(791)]
        M791 = 0x8000_0000_0000_0000,
    }
}


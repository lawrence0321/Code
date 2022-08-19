using Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    [Flags]
    public enum AlarmTypes_Part04 : UInt64
    {
        None = 0x0000_0000_0000_0000,

        [Display(ENG_: "792 -", ZHTW_: "792 -")]
        [AlarmInfo(792)]
        M792 = 0x0000_0000_0000_0001,

        [Display(ENG_: "793 Ni Plate1 Level High Alarm", ZHTW_: "793 鎳1槽高液位異常")]
        [AlarmInfo(793,090)]
        M793 = 0x0000_0000_0000_0002,

        [Display(ENG_: "794 Ni Plate2 Level High Alarm", ZHTW_: "794 鎳2槽高液位異常")]
        [AlarmInfo(794,091)]
        M794 = 0x0000_0000_0000_0004,

        [Display(ENG_: "795 Ni Plate3 Level High Alarm", ZHTW_: "795 鎳3槽高液位異常")]
        [AlarmInfo(795,092)]
        M795 = 0x0000_0000_0000_0008,


        [Display(ENG_: "796 Ni Plate4 Level High Alarm", ZHTW_: "796 鎳4槽高液位異常")]
        [AlarmInfo(796,093)]
        M796 = 0x0000_0000_0000_0010,

        [Display(ENG_: "797 -", ZHTW_: "797 -")]
        [AlarmInfo(797)]
        M797 = 0x0000_0000_0000_0020,

        [Display(ENG_: "798 -", ZHTW_: "798 -")]
        [AlarmInfo(798)]
        M798 = 0x0000_0000_0000_0040,

        [Display(ENG_: "799 Ni Dummy Tank Level High Alarm", ZHTW_: "799 鎳建浴槽高液位異常")]
        [AlarmInfo(799,094)]
        M799 = 0x0000_0000_0000_0080,


        [Display(ENG_: "800 Carbon Treatment1 Level High Alarm", ZHTW_: "800 碳處理1槽高液位異常")]
        [AlarmInfo(800,095)]
        M800 = 0x0000_0000_0000_0100,

        [Display(ENG_: "801 Carbon Treatment2 Level High Alarm", ZHTW_: "801 碳處理2槽高液位異常")]
        [AlarmInfo(801,096)]
        M801 = 0x0000_0000_0000_0200,

        [Display(ENG_: "802 -", ZHTW_: "802 -")]
        [AlarmInfo(802)]
        M802 = 0x0000_0000_0000_0400,

        [Display(ENG_: "803 -", ZHTW_: "803 -")]
        [AlarmInfo(803)]
        M803 = 0x0000_0000_0000_0800,


        [Display(ENG_: "804 -", ZHTW_: "804 -")]
        [AlarmInfo(804)]
        M804 = 0x0000_0000_0000_1000,

        [Display(ENG_: "805 -", ZHTW_: "805 -")]
        [AlarmInfo(805)]
        M805 = 0x0000_0000_0000_2000,

        [Display(ENG_: "806 -", ZHTW_: "806 -")]
        [AlarmInfo(806)]
        M806 = 0x0000_0000_0000_4000,

        [Display(ENG_: "807 -", ZHTW_: "807 -")]
        [AlarmInfo(807)]
        M807 = 0x0000_0000_0000_8000,


        [Display(ENG_: "808 Cleaner Level O.F Low Alarm", ZHTW_: "808 清潔槽低低液位異常")]
        [AlarmInfo(808,071)]
        M808 = 0x0000_0000_0001_0000,

        [Display(ENG_: "809 Micro Etch Level O.F Low Alarm", ZHTW_: "809 微蝕槽低低液位異常")]
        [AlarmInfo(809,702)]
        M809 = 0x0000_0000_0002_0000,

        [Display(ENG_: "810 Micro Et.Supply Level Low Alarm", ZHTW_: "810 微蝕添加槽低液位異常")]
        [AlarmInfo(810,073)]
        M810 = 0x0000_0000_0004_0000,

        [Display(ENG_: "811 Acid Dip Level O.F Low Alarm", ZHTW_: "811 酸1槽低低液位異常")]
        [AlarmInfo(811,074)]
        M811 = 0x0000_0000_0008_0000,


        [Display(ENG_: "812 Ni Plate1 Level O.F Low Alarm", ZHTW_: "812 鎳1槽低低液位異常")]
        [AlarmInfo(812,075)]
        M812 = 0x0000_0000_0010_0000,

        [Display(ENG_: "813 Ni Plate1 Level Low Alarm", ZHTW_: "813 鎳1槽低液位異常")]
        [AlarmInfo(813,076)]
        M813 = 0x0000_0000_0020_0000,

        [Display(ENG_: "814 Ni Plate2 Level O.F Low Alarm", ZHTW_: "814 鎳2槽低低液位異常")]
        [AlarmInfo(814,077)]
        M814 = 0x0000_0000_0040_0000,

        [Display(ENG_: "815 Ni Plate2 Level Low Alarm", ZHTW_: "815 鎳2槽低液位異常")]
        [AlarmInfo(815,078)]
        M815 = 0x0000_0000_0080_0000,


        [Display(ENG_: "816 Ni Plate3 Level O.F Low Alarm", ZHTW_: "816 鎳3槽低低液位異常")]
        [AlarmInfo(816,079)]
        M816 = 0x0000_0000_0100_0000,

        [Display(ENG_: "817 Ni Plate3 Level Low Alarm", ZHTW_: "817 鎳3槽低液位異常")]
        [AlarmInfo(817,080)]
        M817 = 0x0000_0000_0200_0000,

        [Display(ENG_: "818 Ni Plate4 Level O.F Low Alarm", ZHTW_: "818 鎳4槽低低液位異常")]
        [AlarmInfo(818,081)]
        M818 = 0x0000_0000_0400_0000,

        [Display(ENG_: "819 Ni Plate4 Level Low Alarm", ZHTW_: "819 鎳4槽低液位異常")]
        [AlarmInfo(819,082)]
        M819 = 0x0000_0000_0800_0000,


        [Display(ENG_: "820 Au Strike Level O.F Low Alarm", ZHTW_: "820 預金槽低低液位異常")]
        [AlarmInfo(820,083)]
        M820 = 0x0000_0000_1000_0000,

        [Display(ENG_: "821 Au Plate1 Level O.F Low Alarm", ZHTW_: "821 金1槽低低液位異常")]
        [AlarmInfo(821,084)]
        M821 = 0x0000_0000_2000_0000,

        [Display(ENG_: "822 Au Plate2 Level O.F Low Alarm", ZHTW_: "822 金2槽低低液位異常")]
        [AlarmInfo(822,085)]
        M822 = 0x0000_0000_4000_0000,

        [Display(ENG_: "823 Ni Dummy Tank Level Low Alarm", ZHTW_: "823 鎳建浴槽低液位異常")]
        [AlarmInfo(823,086)]
        M823 = 0x0000_0000_8000_0000,


        [Display(ENG_: "824 Carbon Treatment1 Level Low Alarm", ZHTW_: "824 碳處理1槽低液位異常")]
        [AlarmInfo(824,087)]
        M824 = 0x0000_0001_0000_0000,

        [Display(ENG_: "825 Carbon Treatment2 Level Low Alarm", ZHTW_: "825 碳處理2槽低液位異常")]
        [AlarmInfo(825,088)]
        M825 = 0x0000_0002_0000_0000,

        [Display(ENG_: "826 -", ZHTW_: "826 -")]
        [AlarmInfo(826)]
        M826 = 0x0000_0004_0000_0000,

        [Display(ENG_: "827 -", ZHTW_: "827 -")]
        [AlarmInfo(827)]
        M827 = 0x0000_0008_0000_0000,


        [Display(ENG_: "828 -", ZHTW_: "828 -")]
        [AlarmInfo(828)]
        M828 = 0x0000_0010_0000_0000,

        [Display(ENG_: "829 -", ZHTW_: "829 -")]
        [AlarmInfo(829)]
        M829 = 0x0000_0020_0000_0000,

        [Display(ENG_: "830 -", ZHTW_: "830 -")]
        [AlarmInfo(830)]
        M830 = 0x0000_0040_0000_0000,

        [Display(ENG_: "831 -", ZHTW_: "831 -")]
        [AlarmInfo(831)]
        M831 = 0x0000_0080_0000_0000,


        [Display(ENG_: "832 -", ZHTW_: "832 -")]
        [AlarmInfo(832)]
        M832 = 0x0000_0100_0000_0000,

        [Display(ENG_: "833 -", ZHTW_: "833 -")]
        [AlarmInfo(833)]
        M833 = 0x0000_0200_0000_0000,

        [Display(ENG_: "834 -", ZHTW_: "834 -")]
        [AlarmInfo(834)]
        M834 = 0x0000_0400_0000_0000,

        [Display(ENG_: "835 -", ZHTW_: "835 -")]
        [AlarmInfo(835)]
        M835 = 0x0000_0800_0000_0000,


        [Display(ENG_: "836 -", ZHTW_: "760 -")]
        [AlarmInfo(836)]
        M836 = 0x0000_1000_0000_0000,

        [Display(ENG_: "837 -", ZHTW_: "837 -")]
        [AlarmInfo(837)]
        M837 = 0x0000_2000_0000_0000,

        [Display(ENG_: "838 -", ZHTW_: "838 -")]
        [AlarmInfo(838)]
        M838 = 0x0000_4000_0000_0000,

        [Display(ENG_: "839 -", ZHTW_: "839 -")]
        [AlarmInfo(839)]
        M839 = 0x0000_8000_0000_0000,


        [Display(ENG_: "840 RF Alarm", ZHTW_: "840 RF異常")]
        [AlarmInfo(840,196)]
        M840 = 0x0001_0000_0000_0000,

        [Display(ENG_: "841 -", ZHTW_: "841 -")]
        [AlarmInfo(841)]
        M841 = 0x0002_0000_0000_0000,

        [Display(ENG_: "842 -", ZHTW_: "842 -")]
        [AlarmInfo(842)]
        M842 = 0x0004_0000_0000_0000,

        [Display(ENG_: "843 -", ZHTW_: "843 -")]
        [AlarmInfo(843)]
        M843 = 0x0008_0000_0000_0000,


        [Display(ENG_: "844 Ni1 AH Count Up", ZHTW_: "844 鎳1安培小時計數超過上限")]
        [AlarmInfo(844,022)]
        M844 = 0x0010_0000_0000_0000,

        [Display(ENG_: "845 Ni2 AH Count Up", ZHTW_: "845 鎳2安培小時計數超過上限")]
        [AlarmInfo(845,023)]
        M845 = 0x0020_0000_0000_0000,

        [Display(ENG_: "846 Ni3 AH Count UP", ZHTW_: "846 鎳3安培小時計數超過上限")]
        [AlarmInfo(846,024)]
        M846 = 0x0040_0000_0000_0000,

        [Display(ENG_: "847 Ni4 AH Count UP", ZHTW_: "847 鎳4安培小時計數超過上限")]
        [AlarmInfo(847,025)]
        M847 = 0x0080_0000_0000_0000,


        [Display(ENG_: "848 AuST AH Count Up", ZHTW_: "848 預鍍金安培小時計數超過上限")]
        [AlarmInfo(848,026)]
        M848 = 0x0100_0000_0000_0000,

        [Display(ENG_: "849 Au1 AH Count UP", ZHTW_: "849 鍍金1安培小時計數超過上限")]
        [AlarmInfo(849,027)]
        M849 = 0x0200_0000_0000_0000,

        [Display(ENG_: "850 Au2 AH Count Up", ZHTW_: "850 鍍金2安培小時計數超過上限")]
        [AlarmInfo(850,028)]
        M850 = 0x0400_0000_0000_0000,

        [Display(ENG_: "851 -", ZHTW_: "851 -")]
        [AlarmInfo(851)]
        M851 = 0x0800_0000_0000_0000,


        [Display(ENG_: "852 Load Data Wait", ZHTW_: "852 上料超時")]
        [AlarmInfo(852,008)]
        M852 = 0x1000_0000_0000_0000,

        [Display(ENG_: "853 -", ZHTW_: "853 -")]
        [AlarmInfo(853)]
        M853 = 0x2000_0000_0000_0000,

        [Display(ENG_: "854 -", ZHTW_: "854 -")]
        [AlarmInfo(854)]
        M854 = 0x4000_0000_0000_0000,

        [Display(ENG_: "855 -", ZHTW_: "855 -")]
        [AlarmInfo(855)]
        M855 = 0x8000_0000_0000_0000,
    }

}


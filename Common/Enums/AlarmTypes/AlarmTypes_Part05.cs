using Common.Attributes;
using System;

namespace Common.Enums
{
    [Flags]
    public enum AlarmTypes_Part05 : UInt64
    {
        None = 0x0000_0000_0000_0000,

        [Display(ENG_: "M1001 RF01 Current Alarm H", ZHTW_: "M1001 RF01電流高於設定值")]
        [AlarmInfo(1001, 263)]
        M1001 = 0x0000_0000_0000_0001,

        [Display(ENG_: "M1002 RF02 Current Alarm H", ZHTW_: "M1002 RF02電流高於設定值")]
        [AlarmInfo(1002, 264)]
        M1002 = 0x0000_0000_0000_0002,

        [Display(ENG_: "M1003 RF03 Current Alarm H", ZHTW_: "M1003 RF03電流高於設定值")]
        [AlarmInfo(1003, 265)]
        M1003 = 0x0000_0000_0000_0004,

        [Display(ENG_: "M1004 RF04 Current Alarm H", ZHTW_: "M1004 RF04電流高於設定值")]
        [AlarmInfo(1004, 266)]
        M1004 = 0x0000_0000_0000_0008,


        [Display(ENG_: "M1005 RF05 Current Alarm H", ZHTW_: "M1005 RF05電流高於設定值")]
        [AlarmInfo(1005, 267)]
        M1005 = 0x0000_0000_0000_0010,

        [Display(ENG_: "M1006 RF06 Current Alarm H", ZHTW_: "M1006 RF06電流高於設定值")]
        [AlarmInfo(1006, 268)]
        M1006 = 0x0000_0000_0000_0020,

        [Display(ENG_: "M1007 RF07 Current Alarm H", ZHTW_: "M1007 RF07電流高於設定值")]
        [AlarmInfo(1007, 269)]
        M1007 = 0x0000_0000_0000_0040,

        [Display(ENG_: "M1008 RF08 Current Alarm H", ZHTW_: "M1008 RF08電流高於設定值")]
        [AlarmInfo(1008, 270)]
        M1008 = 0x0000_0000_0000_0080,


        [Display(ENG_: "M1009 RF09 Current Alarm H", ZHTW_: "M1009 RF09電流高於設定值")]
        [AlarmInfo(1009, 271)]
        M1009 = 0x0000_0000_0000_0100,

        [Display(ENG_: "M1010 RF10 Current Alarm H", ZHTW_: "M1010 RF10電流高於設定值")]
        [AlarmInfo(1010, 272)]
        M1010 = 0x0000_0000_0000_0200,

        [Display(ENG_: "M1011 RF11 Current Alarm H", ZHTW_: "M1011 RF11電流高於設定值")]
        [AlarmInfo(1011, 273)]
        M1011 = 0x0000_0000_0000_0400,

        [Display(ENG_: "M1012 RF12 Current Alarm H", ZHTW_: "M1012 RF12電流高於設定值")]
        [AlarmInfo(1012, 274)]
        M1012 = 0x0000_0000_0000_0800,


        [Display(ENG_: "M1013 RF13 Current Alarm H", ZHTW_: "M1013 RF13電流高於設定值")]
        [AlarmInfo(1013, 275)]
        M1013 = 0x0000_0000_0000_1000,

        [Display(ENG_: "M1014 RF14 Current Alarm H", ZHTW_: "M1014 RF14電流高於設定值")]
        [AlarmInfo(1014, 276)]
        M1014 = 0x0000_0000_0000_2000,

        [Display(ENG_: "M1015 RF15 Current Alarm H", ZHTW_: "M1015 RF15電流高於設定值")]
        [AlarmInfo(1015, 277)]
        M1015 = 0x0000_0000_0000_4000,

        [Display(ENG_: "M1016 RF16 Current Alarm H", ZHTW_: "M1016 RF16電流高於設定值")]
        [AlarmInfo(1016, 278)]
        M1016 = 0x0000_0000_0000_8000,


        [Display(ENG_: "M1017 RF17 Current Alarm H", ZHTW_: "M1017 RF17電流高於設定值")]
        [AlarmInfo(1017, 279)]
        M1017 = 0x0000_0000_0001_0000,

        [Display(ENG_: "M1018 RF18 Current Alarm H", ZHTW_: "M1018 RF18電流高於設定值")]
        [AlarmInfo(1018, 280)]
        M1018 = 0x0000_0000_0002_0000,

        [Display(ENG_: "M1019 RF19 Current Alarm H", ZHTW_: "M1019 RF19電流高於設定值")]
        [AlarmInfo(1019, 281)]
        M1019 = 0x0000_0000_0004_0000,

        [Display(ENG_: "M1020 RF20 Current Alarm H", ZHTW_: "M1020RF20電流高於設定值")]
        [AlarmInfo(1020, 282)]
        M1020 = 0x0000_0000_0008_0000,


        [Display(ENG_: "M1021 RF21 Current Alarm H", ZHTW_: "M1021 RF21電流高於設定值")]
        [AlarmInfo(1021, 283)]
        M1021 = 0x0000_0000_0010_0000,

        [Display(ENG_: "M1022 RF22 Current Alarm H", ZHTW_: "M1022 RF22電流高於設定值")]
        [AlarmInfo(1022, 284)]
        M1022 = 0x0000_0000_0020_0000,

        [Display(ENG_: "M1023 RF23 Current Alarm H", ZHTW_: "M1023 RF23電流高於設定值")]
        [AlarmInfo(1023, 285)]
        M1023 = 0x0000_0000_0040_0000,

        [Display(ENG_: "M1024 RF24 Current Alarm H", ZHTW_: "M1024 RF24電流高於設定值")]
        [AlarmInfo(1024, 286)]
        M1024 = 0x0000_0000_0080_0000,


        [Display(ENG_: "M1025 RF25 Current Alarm H", ZHTW_: "M1025 RF25電流高於設定值")]
        [AlarmInfo(1025, 287)]
        M1025 = 0x0000_0000_0100_0000,

        [Display(ENG_: "M1026 RF26 Current Alarm H", ZHTW_: "M1026 RF26電流高於設定值")]
        [AlarmInfo(1026, 288)]
        M1026 = 0x0000_0000_0200_0000,

        [Display(ENG_: "M1027 RF27 Current Alarm H", ZHTW_: "M1027 RF27電流高於設定值")]
        [AlarmInfo(1027, 289)]
        M1027 = 0x0000_0000_0400_0000,

        [Display(ENG_: "M1028 RF28 Current Alarm H", ZHTW_: "M1028 RF28電流高於設定值")]
        [AlarmInfo(1028, 290)]
        M1028 = 0x0000_0000_0800_0000,


        [Display(ENG_: "M1029 RF29 Current Alarm H", ZHTW_: "M1029 RF29電流高於設定值")]
        [AlarmInfo(1029, 291)]
        M1029 = 0x0000_0000_1000_0000,

        [Display(ENG_: "M1030 RF30 Current Alarm H", ZHTW_: "M1030 RF30電流高於設定值")]
        [AlarmInfo(1030, 292)]
        M1030 = 0x0000_0000_2000_0000,

        [Display(ENG_: "M1031 RF31 Current Alarm H", ZHTW_: "M1031 RF31電流高於設定值")]
        [AlarmInfo(1031, 293)]
        M1031 = 0x0000_0000_4000_0000,

        [Display(ENG_: "M1032 RF32 Current Alarm H", ZHTW_: "M1032 RF32電流高於設定值")]
        [AlarmInfo(1032, 294)]
        M1032 = 0x0000_0000_8000_0000,


        [Display(ENG_: "M1033 RF33 Current Alarm H", ZHTW_: "M1033 RF33電流高於設定值")]
        [AlarmInfo(1033, 295)]
        M1033 = 0x0000_0001_0000_0000,

        [Display(ENG_: "M1034 RF34 Current Alarm H", ZHTW_: "M1034 RF34電流高於設定值")]
        [AlarmInfo(1034, 296)]
        M1034 = 0x0000_0002_0000_0000,

        [Display(ENG_: "M1035 RF35 Current Alarm H", ZHTW_: "M1035 RF35電流高於設定值")]
        [AlarmInfo(1035, 297)]
        M1035 = 0x0000_0004_0000_0000,

        [Display(ENG_: "M1036 RF36 Current Alarm H", ZHTW_: "M1036 RF36電流高於設定值")]
        [AlarmInfo(1036, 298)]
        M1036 = 0x0000_0008_0000_0000,


        [Display(ENG_: "M1037 RF37 Current Alarm H", ZHTW_: "M1037 RF37電流高於設定值")]
        [AlarmInfo(1037, 299)]
        M1037 = 0x0000_0010_0000_0000,

        [Display(ENG_: "M1038 RF38 Current Alarm H", ZHTW_: "M1038 RF38電流高於設定值")]
        [AlarmInfo(1038, 300)]
        M1038 = 0x0000_0020_0000_0000,

        [Display(ENG_: "M1039 RF39 Current Alarm H", ZHTW_: "M1039 RF39電流高於設定值")]
        [AlarmInfo(1039, 301)]
        M1039 = 0x0000_0040_0000_0000,

        [Display(ENG_: "M1040 RF40 Current Alarm H", ZHTW_: "M1040 RF40電流高於設定值")]
        [AlarmInfo(1040, 302)]
        M1040 = 0x0000_0080_0000_0000,


        [Display(ENG_: "M1041 RF41 Current Alarm H", ZHTW_: "M1041 RF41電流高於設定值")]
        [AlarmInfo(1041, 303)]
        M1041 = 0x0000_0100_0000_0000,

        [Display(ENG_: "M1042 RF42 Current Alarm H", ZHTW_: "M1042 RF42電流高於設定值")]
        [AlarmInfo(1042, 304)]
        M1042 = 0x0000_0200_0000_0000,

        [Display(ENG_: "M1043 RF43 Current Alarm H", ZHTW_: "M1043 RF43電流高於設定值")]
        [AlarmInfo(1043, 305)]
        M1043 = 0x0000_0400_0000_0000,

        [Display(ENG_: "M1044 RF44 Current Alarm H", ZHTW_: "M1044 RF44電流高於設定值")]
        [AlarmInfo(1044, 306)]
        M1044 = 0x0000_0800_0000_0000,


        [Display(ENG_: "M1045 RF45 Current Alarm H", ZHTW_: "M1045 RF45電流高於設定值")]
        [AlarmInfo(1045, 307)]
        M1045 = 0x0000_1000_0000_0000,

        [Display(ENG_: "M1046 RF46 Current Alarm H", ZHTW_: "M1046 RF46電流高於設定值")]
        [AlarmInfo(1046, 308)]
        M1046 = 0x0000_2000_0000_0000,

        [Display(ENG_: "M1047 RF47 Current Alarm H", ZHTW_: "M1047 RF47電流高於設定值")]
        [AlarmInfo(1047, 309)]
        M1047 = 0x0000_4000_0000_0000,

        [Display(ENG_: "M1048 RF48 Current Alarm H", ZHTW_: "M1048 RF48電流高於設定值")]
        [AlarmInfo(1048, 310)]
        M1048 = 0x0000_8000_0000_0000,

        [Display(ENG_: "M1049 RF49 Current Alarm H", ZHTW_: "M1049 RF49電流高於設定值")]
        [AlarmInfo(1049, 311)]
        M1049 = 0x0001_0000_0000_0000,

        [Display(ENG_: "M1050 RF50 Current Alarm H", ZHTW_: "M1050 RF50電流高於設定值")]
        [AlarmInfo(1050, 312)]
        M1050 = 0x0002_0000_0000_0000,

        [Display(ENG_: "M1051 RF51 Current Alarm H", ZHTW_: "M1051 RF51電流高於設定值")]
        [AlarmInfo(1051, 313)]
        M1051 = 0x0004_0000_0000_0000,

        [Display(ENG_: "M1052 RF52 Current Alarm H", ZHTW_: "M1052 RF52電流高於設定值")]
        [AlarmInfo(1052, 314)]
        M1052 = 0x0008_0000_0000_0000,


        [Display(ENG_: "M1053 RF53 Current Alarm H", ZHTW_: "M1053 RF53電流高於設定值")]
        [AlarmInfo(1053, 315)]
        M1053 = 0x0010_0000_0000_0000,

        [Display(ENG_: "M1054 RF54 Current Alarm H", ZHTW_: "M1054 RF54電流高於設定值")]
        [AlarmInfo(1054, 316)]
        M1054 = 0x0020_0000_0000_0000,

        [Display(ENG_: "M1055 RF55 Current Alarm H", ZHTW_: "M1055 RF55電流高於設定值")]
        [AlarmInfo(1055, 317)]
        M1055 = 0x0040_0000_0000_0000,

        [Display(ENG_: "M1056 RF56 Current Alarm H", ZHTW_: "M1056 RF56電流高於設定值")]
        [AlarmInfo(1056, 318)]
        M1056 = 0x0080_0000_0000_0000,


        [Display(ENG_: "M1057 RF57 Current Alarm H", ZHTW_: "M1057 RF57電流高於設定值")]
        [AlarmInfo(1057, 319)]
        M1057 = 0x0100_0000_0000_0000,

        [Display(ENG_: "M1058 RF58 Current Alarm H", ZHTW_: "M1058 RF58電流高於設定值")]
        [AlarmInfo(1058, 320)]
        M1058 = 0x0200_0000_0000_0000,

        [Display(ENG_: "M1059 -", ZHTW_: "M1059 -")]
        [AlarmInfo(1059)]
        M1059 = 0x0400_0000_0000_0000,

        [Display(ENG_: "M1060 -", ZHTW_: "M1060 -")]
        [AlarmInfo(1060)]
        M1060 = 0x0800_0000_0000_0000,


        [Display(ENG_: "M1061 -", ZHTW_: "M1061 -")]
        [AlarmInfo(1061)]
        M1061 = 0x1000_0000_0000_0000,

        [Display(ENG_: "M1062 -", ZHTW_: "M1062 -")]
        [AlarmInfo(1062)]
        M1062 = 0x2000_0000_0000_0000,

        [Display(ENG_: "M1063 -", ZHTW_: "M1063 -")]
        [AlarmInfo(1063)]
        M1063 = 0x4000_0000_0000_0000,

        [Display(ENG_: "M1064 -", ZHTW_: "M1064 -")]
        [AlarmInfo(1064)]
        M1064 = 0x8000_0000_0000_0000,
    }
}

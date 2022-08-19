using Common.Attributes;
using System;

namespace Common.Enums
{
    [Flags]
    public enum AlarmTypes_Part06 : UInt64
    {
        None = 0x0000_0000_0000_0000,

        [Display(ENG_: "M1101 RF01 Current Alarm L", ZHTW_: "M1101 RF01電流低於設定值")]
        [AlarmInfo(1101, 321)]
        M1101 = 0x0000_0000_0000_0001,

        [Display(ENG_: "M1102 RF02 Current Alarm L", ZHTW_: "M1102 RF02電流低於設定值")]
        [AlarmInfo(1102, 322)]
        M1102 = 0x0000_0000_0000_0002,

        [Display(ENG_: "M1103 RF03 Current Alarm L", ZHTW_: "M1103 RF03電流低於設定值")]
        [AlarmInfo(1103, 323)]
        M1103 = 0x0000_0000_0000_0004,

        [Display(ENG_: "M1104 RF04 Current Alarm L", ZHTW_: "M1104 RF04電流低於設定值")]
        [AlarmInfo(1104, 324)]
        M1104 = 0x0000_0000_0000_0008,


        [Display(ENG_: "M1105 RF05 Current Alarm L", ZHTW_: "M1105 RF05電流低於設定值")]
        [AlarmInfo(1105, 325)]
        M1105 = 0x0000_0000_0000_0010,

        [Display(ENG_: "M1106 RF06 Current Alarm L", ZHTW_: "M1106 RF06電流低於設定值")]
        [AlarmInfo(1106, 326)]
        M1106 = 0x0000_0000_0000_0020,

        [Display(ENG_: "M1107 RF07 Current Alarm L", ZHTW_: "M1107 RF07電流低於設定值")]
        [AlarmInfo(1107, 327)]
        M1107 = 0x0000_0000_0000_0040,

        [Display(ENG_: "M1108 RF08 Current Alarm L", ZHTW_: "M1108 RF08電流低於設定值")]
        [AlarmInfo(1108, 328)]
        M1108 = 0x0000_0000_0000_0080,


        [Display(ENG_: "M1109 RF09 Current Alarm L", ZHTW_: "M1109 RF09電流低於設定值")]
        [AlarmInfo(1109, 329)]
        M1109 = 0x0000_0000_0000_0100,

        [Display(ENG_: "M1110 RF10 Current Alarm L", ZHTW_: "M1110 RF10電流低於設定值")]
        [AlarmInfo(1110, 330)]
        M1110 = 0x0000_0000_0000_0200,

        [Display(ENG_: "M1111 RF11 Current Alarm L", ZHTW_: "M1111 RF11電流低於設定值")]
        [AlarmInfo(1111, 331)]
        M1111 = 0x0000_0000_0000_0400,

        [Display(ENG_: "M1112 RF12 Current Alarm L", ZHTW_: "M1112 RF12電流低於設定值")]
        [AlarmInfo(1112, 332)]
        M1112 = 0x0000_0000_0000_0800,


        [Display(ENG_: "M1113 RF13 Current Alarm L", ZHTW_: "M1113 RF13電流低於設定值")]
        [AlarmInfo(1113, 333)]
        M1113 = 0x0000_0000_0000_1000,

        [Display(ENG_: "M1114 RF14 Current Alarm L", ZHTW_: "M1114 RF14電流低於設定值")]
        [AlarmInfo(1114, 334)]
        M1114 = 0x0000_0000_0000_2000,

        [Display(ENG_: "M1115 RF15 Current Alarm L", ZHTW_: "M1115 RF15電流低於設定值")]
        [AlarmInfo(1115, 335)]
        M1115 = 0x0000_0000_0000_4000,

        [Display(ENG_: "M1116 RF16 Current Alarm L", ZHTW_: "M1116 RF16電流低於設定值")]
        [AlarmInfo(1116, 336)]
        M1116 = 0x0000_0000_0000_8000,


        [Display(ENG_: "M1117 RF17 Current Alarm L", ZHTW_: "M1117 RF17電流低於設定值")]
        [AlarmInfo(1117, 337)]
        M1117 = 0x0000_0000_0001_0000,

        [Display(ENG_: "M1118 RF18 Current Alarm L", ZHTW_: "M1118 RF18電流低於設定值")]
        [AlarmInfo(1118, 338)]
        M1118 = 0x0000_0000_0002_0000,

        [Display(ENG_: "M1119 RF19 Current Alarm L", ZHTW_: "M1119 RF19電流低於設定值")]
        [AlarmInfo(1119, 339)]
        M1119 = 0x0000_0000_0004_0000,

        [Display(ENG_: "M1120 RF20 Current Alarm L", ZHTW_: "M1120 RF20電流低於設定值")]
        [AlarmInfo(1120, 340)]
        M1120 = 0x0000_0000_0008_0000,


        [Display(ENG_: "M1121 RF21 Current Alarm L", ZHTW_: "M1121 RF21電流低於設定值")]
        [AlarmInfo(1121, 341)]
        M1121 = 0x0000_0000_0010_0000,

        [Display(ENG_: "M1122 RF22 Current Alarm L", ZHTW_: "M1122 RF22電流低於設定值")]
        [AlarmInfo(1122, 342)]
        M1122 = 0x0000_0000_0020_0000,

        [Display(ENG_: "M1123 RF23 Current Alarm L", ZHTW_: "M1123 RF23電流低於設定值")]
        [AlarmInfo(1123, 343)]
        M1123 = 0x0000_0000_0040_0000,

        [Display(ENG_: "M1124 RF24 Current Alarm L", ZHTW_: "M1124 RF24電流低於設定值")]
        [AlarmInfo(1124, 344)]
        M1124 = 0x0000_0000_0080_0000,


        [Display(ENG_: "M1125 RF25 Current Alarm L", ZHTW_: "M1125 RF25電流低於設定值")]
        [AlarmInfo(1125, 345)]
        M1125 = 0x0000_0000_0100_0000,

        [Display(ENG_: "M1126 RF26 Current Alarm L", ZHTW_: "M1126 RF26電流低於設定值")]
        [AlarmInfo(1126, 346)]
        M1126 = 0x0000_0000_0200_0000,

        [Display(ENG_: "M1127 RF27 Current Alarm L", ZHTW_: "M1127 RF27電流低於設定值")]
        [AlarmInfo(1127, 347)]
        M1127 = 0x0000_0000_0400_0000,

        [Display(ENG_: "M1128 RF28 Current Alarm L", ZHTW_: "M1128 RF28電流低於設定值")]
        [AlarmInfo(1128, 348)]
        M1128 = 0x0000_0000_0800_0000,


        [Display(ENG_: "M1129 RF29 Current Alarm L", ZHTW_: "M1129 RF29電流低於設定值")]
        [AlarmInfo(1129, 349)]
        M1129 = 0x0000_0000_1000_0000,

        [Display(ENG_: "M1130 RF30 Current Alarm L", ZHTW_: "M1130 RF30電流低於設定值")]
        [AlarmInfo(1130, 350)]
        M1130 = 0x0000_0000_2000_0000,

        [Display(ENG_: "M1131 RF31 Current Alarm L", ZHTW_: "M1131 RF31電流低於設定值")]
        [AlarmInfo(1131, 351)]
        M1131 = 0x0000_0000_4000_0000,

        [Display(ENG_: "M1132 RF32 Current Alarm L", ZHTW_: "M1132 RF32電流低於設定值")]
        [AlarmInfo(1132, 352)]
        M1132 = 0x0000_0000_8000_0000,


        [Display(ENG_: "M1133 RF33 Current Alarm L", ZHTW_: "M1133 RF33電流低於設定值")]
        [AlarmInfo(1133, 353)]
        M1133 = 0x0000_0001_0000_0000,

        [Display(ENG_: "M1134 RF34 Current Alarm L", ZHTW_: "M1134 RF34電流低於設定值")]
        [AlarmInfo(1134, 354)]
        M1134 = 0x0000_0002_0000_0000,

        [Display(ENG_: "M1135 RF35 Current Alarm L", ZHTW_: "M1135 RF35電流低於設定值")]
        [AlarmInfo(1135, 355)]
        M1135 = 0x0000_0004_0000_0000,

        [Display(ENG_: "M1136 RF36 Current Alarm L", ZHTW_: "M1136 RF36電流低於設定值")]
        [AlarmInfo(1136, 356)]
        M1136 = 0x0000_0008_0000_0000,


        [Display(ENG_: "M1137 RF37 Current Alarm L", ZHTW_: "M1137 RF37電流低於設定值")]
        [AlarmInfo(1137, 357)]
        M1137 = 0x0000_0010_0000_0000,

        [Display(ENG_: "M1138 RF38 Current Alarm L", ZHTW_: "M1138 RF38電流低於設定值")]
        [AlarmInfo(1138, 358)]
        M1138 = 0x0000_0020_0000_0000,

        [Display(ENG_: "M1139 RF39 Current Alarm L", ZHTW_: "M1139 RF39電流低於設定值")]
        [AlarmInfo(1139, 359)]
        M1139 = 0x0000_0040_0000_0000,

        [Display(ENG_: "M1140 RF40 Current Alarm L", ZHTW_: "M1140 RF40電流低於設定值")]
        [AlarmInfo(1140, 360)]
        M1140 = 0x0000_0080_0000_0000,


        [Display(ENG_: "M1141 RF41 Current Alarm L", ZHTW_: "M1141 RF41電流低於設定值")]
        [AlarmInfo(1141, 361)]
        M1141 = 0x0000_0100_0000_0000,

        [Display(ENG_: "M1142 RF42 Current Alarm L", ZHTW_: "M1142 RF42電流低於設定值")]
        [AlarmInfo(1142, 362)]
        M1142 = 0x0000_0200_0000_0000,

        [Display(ENG_: "M1143 RF43 Current Alarm L", ZHTW_: "M1143 RF43電流低於設定值")]
        [AlarmInfo(1143, 363)]
        M1143 = 0x0000_0400_0000_0000,

        [Display(ENG_: "M1144 RF44 Current Alarm L", ZHTW_: "M1144 RF44電流低於設定值")]
        [AlarmInfo(1144, 364)]
        M1144 = 0x0000_0800_0000_0000,


        [Display(ENG_: "M1145 RF45 Current Alarm L", ZHTW_: "M1145 RF45電流低於設定值")]
        [AlarmInfo(1145, 365)]
        M1145 = 0x0000_1000_0000_0000,

        [Display(ENG_: "M1146 RF46 Current Alarm L", ZHTW_: "M1146 RF46電流低於設定值")]
        [AlarmInfo(1146, 366)]
        M1146 = 0x0000_2000_0000_0000,

        [Display(ENG_: "M1147 RF47 Current Alarm L", ZHTW_: "M1147 RF47電流低於設定值")]
        [AlarmInfo(1147, 367)]
        M1147 = 0x0000_4000_0000_0000,

        [Display(ENG_: "M1148 RF48 Current Alarm L", ZHTW_: "M1148 RF48電流低於設定值")]
        [AlarmInfo(1148, 368)]
        M1148 = 0x0000_8000_0000_0000,


        [Display(ENG_: "M1149 RF49 Current Alarm L", ZHTW_: "M1149 RF49電流低於設定值")]
        [AlarmInfo(1149, 369)]
        M1149 = 0x0001_0000_0000_0000,

        [Display(ENG_: "M1150 RF50 Current Alarm L", ZHTW_: "M1150 RF50電流低於設定值")]
        [AlarmInfo(1150, 370)]
        M1150 = 0x0002_0000_0000_0000,

        [Display(ENG_: "M1151 RF51 Current Alarm L", ZHTW_: "M1151 RF51電流低於設定值")]
        [AlarmInfo(1151, 371)]
        M1151 = 0x0004_0000_0000_0000,

        [Display(ENG_: "M1152 RF52 Current Alarm L", ZHTW_: "M1152 RF52電流低於設定值")]
        [AlarmInfo(1152, 372)]
        M1152 = 0x0008_0000_0000_0000,


        [Display(ENG_: "M1153 RF53 Current Alarm L", ZHTW_: "M1153 RF53電流低於設定值")]
        [AlarmInfo(1153, 373)]
        M1153 = 0x0010_0000_0000_0000,

        [Display(ENG_: "M1154 RF54 Current Alarm L", ZHTW_: "M1154 RF54電流低於設定值")]
        [AlarmInfo(1154, 374)]
        M1154 = 0x0020_0000_0000_0000,

        [Display(ENG_: "M1155 RF55 Current Alarm L", ZHTW_: "M1155 RF55電流低於設定值")]
        [AlarmInfo(1155, 375)]
        M1155 = 0x0040_0000_0000_0000,

        [Display(ENG_: "M1156 RF56 Current Alarm L", ZHTW_: "M1156 RF56電流低於設定值")]
        [AlarmInfo(1156, 376)]
        M1156 = 0x0080_0000_0000_0000,


        [Display(ENG_: "M1157 RF57 Current Alarm L", ZHTW_: "M1157 RF57電流低於設定值")]
        [AlarmInfo(1157, 377)]
        M1157 = 0x0100_0000_0000_0000,

        [Display(ENG_: "M1158 RF58 Current Alarm L", ZHTW_: "M1158 RF58電流低於設定值")]
        [AlarmInfo(1158, 378)]
        M1158 = 0x0200_0000_0000_0000,

        [Display(ENG_: "M1159 -", ZHTW_: "M1159 -")]
        [AlarmInfo(1159)]
        M1159 = 0x0400_0000_0000_0000,

        [Display(ENG_: "M1160 -", ZHTW_: "M1160 -")]
        [AlarmInfo(1160)]
        M1160 = 0x0800_0000_0000_0000,


        [Display(ENG_: "M1161 -", ZHTW_: "M1161 -")]
        [AlarmInfo(1161)]
        M1161 = 0x1000_0000_0000_0000,

        [Display(ENG_: "M1162 -", ZHTW_: "M1162 -")]
        [AlarmInfo(1162)]
        M1162 = 0x2000_0000_0000_0000,

        [Display(ENG_: "M1163 -", ZHTW_: "M1163 -")]
        [AlarmInfo(1163)]
        M1163 = 0x4000_0000_0000_0000,

        [Display(ENG_: "M1164 -", ZHTW_: "M1164 -")]
        [AlarmInfo(1164)]
        M1164 = 0x8000_0000_0000_0000,
    }

}

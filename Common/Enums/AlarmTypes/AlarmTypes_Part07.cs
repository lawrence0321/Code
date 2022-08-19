using Common.Attributes;
using System;

namespace Common.Enums
{
    [Flags]
    public enum AlarmTypes_Part07 : UInt64
    {
        None = 0x0000_0000_0000_0000,

        [Display(ENG_: "M1201 RF01 Voltage Alarm H", ZHTW_: "M1201 RF01電壓高於設定值")]
        [AlarmInfo(1201, 379)]
        M1201 = 0x0000_0000_0000_0001,

        [Display(ENG_: "M1202 RF02 Voltage Alarm H", ZHTW_: "M1202 RF02電壓高於設定值")]
        [AlarmInfo(1202, 380)]
        M1202 = 0x0000_0000_0000_0002,

        [Display(ENG_: "M1203 RF03 Voltage Alarm H", ZHTW_: "M1203 RF03電壓高於設定值")]
        [AlarmInfo(1203, 381)]
        M1203 = 0x0000_0000_0000_0004,

        [Display(ENG_: "M1204 RF04 Voltage Alarm H", ZHTW_: "M1204 RF04電壓高於設定值")]
        [AlarmInfo(1204, 382)]
        M1204 = 0x0000_0000_0000_0008,


        [Display(ENG_: "M1205 RF05 Voltage Alarm H", ZHTW_: "M1205 RF05電壓高於設定值")]
        [AlarmInfo(1205, 383)]
        M1205 = 0x0000_0000_0000_0010,

        [Display(ENG_: "M1206 RF06 Voltage Alarm H", ZHTW_: "M1206 RF06電壓高於設定值")]
        [AlarmInfo(1206, 384)]
        M1206 = 0x0000_0000_0000_0020,

        [Display(ENG_: "M1207 RF07 Voltage Alarm H", ZHTW_: "M1207 RF07電壓高於設定值")]
        [AlarmInfo(1207, 385)]
        M1207 = 0x0000_0000_0000_0040,

        [Display(ENG_: "M1208 RF08 Voltage Alarm H", ZHTW_: "M1208 RF08電壓高於設定值")]
        [AlarmInfo(1208, 386)]
        M1208 = 0x0000_0000_0000_0080,


        [Display(ENG_: "M1209 RF09 Voltage Alarm H", ZHTW_: "M1209 RF09電壓高於設定值")]
        [AlarmInfo(1209, 387)]
        M1209 = 0x0000_0000_0000_0100,

        [Display(ENG_: "M1210 RF10 Voltage Alarm H", ZHTW_: "M1210 RF10電壓高於設定值")]
        [AlarmInfo(1210, 388)]
        M1210 = 0x0000_0000_0000_0200,

        [Display(ENG_: "M1211 RF11 Voltage Alarm H", ZHTW_: "M1211 RF11電壓高於設定值")]
        [AlarmInfo(1211, 389)]
        M1211 = 0x0000_0000_0000_0400,

        [Display(ENG_: "M1212 RF12 Voltage Alarm H", ZHTW_: "M1212 RF12電壓高於設定值")]
        [AlarmInfo(1212, 390)]
        M1212 = 0x0000_0000_0000_0800,


        [Display(ENG_: "M1213 RF13 Voltage Alarm H", ZHTW_: "M1213 RF13電壓高於設定值")]
        [AlarmInfo(1213, 391)]
        M1213 = 0x0000_0000_0000_1000,

        [Display(ENG_: "M1214 RF14 Voltage Alarm H", ZHTW_: "M1214 RF14電壓高於設定值")]
        [AlarmInfo(1214, 392)]
        M1214 = 0x0000_0000_0000_2000,

        [Display(ENG_: "M1215 RF15 Voltage Alarm H", ZHTW_: "M1215 RF15電壓高於設定值")]
        [AlarmInfo(1215, 393)]
        M1215 = 0x0000_0000_0000_4000,

        [Display(ENG_: "M1216 RF16 Voltage Alarm H", ZHTW_: "M1216 RF16電壓高於設定值")]
        [AlarmInfo(1216, 394)]
        M1216 = 0x0000_0000_0000_8000,


        [Display(ENG_: "M1217 RF17 Voltage Alarm H", ZHTW_: "M1217 RF17電壓高於設定值")]
        [AlarmInfo(1217, 395)]
        M1217 = 0x0000_0000_0001_0000,

        [Display(ENG_: "M1218 RF18 Voltage Alarm H", ZHTW_: "M1218 RF18電壓高於設定值")]
        [AlarmInfo(1218, 396)]
        M1218 = 0x0000_0000_0002_0000,

        [Display(ENG_: "M1219 RF19 Voltage Alarm H", ZHTW_: "M1219 RF19電壓高於設定值")]
        [AlarmInfo(1219, 397)]
        M1219 = 0x0000_0000_0004_0000,

        [Display(ENG_: "M1220 RF20 Voltage Alarm H", ZHTW_: "M1220 RF20電壓高於設定值")]
        [AlarmInfo(1220, 398)]
        M1220 = 0x0000_0000_0008_0000,


        [Display(ENG_: "M1221 RF21 Voltage Alarm H", ZHTW_: "M1221 RF21電壓高於設定值")]
        [AlarmInfo(1221, 399)]
        M1221 = 0x0000_0000_0010_0000,

        [Display(ENG_: "M1222 RF22 Voltage Alarm H", ZHTW_: "M1222 RF22電壓高於設定值")]
        [AlarmInfo(1222, 400)]
        M1222 = 0x0000_0000_0020_0000,

        [Display(ENG_: "M1223 RF23 Voltage Alarm H", ZHTW_: "M1223 RF23電壓高於設定值")]
        [AlarmInfo(1223, 401)]
        M1223 = 0x0000_0000_0040_0000,

        [Display(ENG_: "M1224 RF24 Voltage Alarm H", ZHTW_: "M1224 RF24電壓高於設定值")]
        [AlarmInfo(1224, 402)]
        M1224 = 0x0000_0000_0080_0000,


        [Display(ENG_: "M1225 RF25 Voltage Alarm H", ZHTW_: "M1225 RF25電壓高於設定值")]
        [AlarmInfo(1225, 403)]
        M1225 = 0x0000_0000_0100_0000,

        [Display(ENG_: "M1226 RF26 Voltage Alarm H", ZHTW_: "M1226 RF26電壓高於設定值")]
        [AlarmInfo(1226, 404)]
        M1226 = 0x0000_0000_0200_0000,

        [Display(ENG_: "M1227 RF27 Voltage Alarm H", ZHTW_: "M1227 RF27電壓高於設定值")]
        [AlarmInfo(1227, 405)]
        M1227 = 0x0000_0000_0400_0000,

        [Display(ENG_: "M1228 RF28 Voltage Alarm H", ZHTW_: "M1228 RF28電壓高於設定值")]
        [AlarmInfo(1228, 406)]
        M1228 = 0x0000_0000_0800_0000,


        [Display(ENG_: "M1229 RF29 Voltage Alarm H", ZHTW_: "M1229 RF29電壓高於設定值")]
        [AlarmInfo(1229, 407)]
        M1229 = 0x0000_0000_1000_0000,

        [Display(ENG_: "M1230 RF30 Voltage Alarm H", ZHTW_: "M1230 RF30電壓高於設定值")]
        [AlarmInfo(1230, 408)]
        M1230 = 0x0000_0000_2000_0000,

        [Display(ENG_: "M1231 RF31 Voltage Alarm H", ZHTW_: "M1231 RF31電壓高於設定值")]
        [AlarmInfo(1231, 409)]
        M1231 = 0x0000_0000_4000_0000,

        [Display(ENG_: "M1232 RF32 Voltage Alarm H", ZHTW_: "M1232 RF32電壓高於設定值")]
        [AlarmInfo(1232, 410)]
        M1232 = 0x0000_0000_8000_0000,


        [Display(ENG_: "M1233 RF33 Voltage Alarm H", ZHTW_: "M1233 RF33電壓高於設定值")]
        [AlarmInfo(1233, 411)]
        M1233 = 0x0000_0001_0000_0000,

        [Display(ENG_: "M1234 RF34 Voltage Alarm H", ZHTW_: "M1234 RF34電壓高於設定值")]
        [AlarmInfo(1234, 412)]
        M1234 = 0x0000_0002_0000_0000,

        [Display(ENG_: "M1235 RF35 Voltage Alarm H", ZHTW_: "M1235 RF35電壓高於設定值")]
        [AlarmInfo(1235, 413)]
        M1235 = 0x0000_0004_0000_0000,

        [Display(ENG_: "M1236 RF36 Voltage Alarm H", ZHTW_: "M1236 RF36電壓高於設定值")]
        [AlarmInfo(1236, 414)]
        M1236 = 0x0000_0008_0000_0000,


        [Display(ENG_: "M1237 RF37 Voltage Alarm H", ZHTW_: "M1237 RF37電壓高於設定值")]
        [AlarmInfo(1237, 415)]
        M1237 = 0x0000_0010_0000_0000,

        [Display(ENG_: "M1238 RF38 Voltage Alarm H", ZHTW_: "M1238 RF38電壓高於設定值")]
        [AlarmInfo(1238, 416)]
        M1238 = 0x0000_0020_0000_0000,

        [Display(ENG_: "M1239 RF39 Voltage Alarm H", ZHTW_: "M1239 RF39電壓高於設定值")]
        [AlarmInfo(1239, 417)]
        M1239 = 0x0000_0040_0000_0000,

        [Display(ENG_: "M1240 RF40 Voltage Alarm H", ZHTW_: "M1240 RF40電壓高於設定值")]
        [AlarmInfo(1240, 418)]
        M1240 = 0x0000_0080_0000_0000,


        [Display(ENG_: "M1241 RF41 Voltage Alarm H", ZHTW_: "M1241 RF41電壓高於設定值")]
        [AlarmInfo(1241, 419)]
        M1241 = 0x0000_0100_0000_0000,

        [Display(ENG_: "M1242 RF42 Voltage Alarm H", ZHTW_: "M1242 RF42電壓高於設定值")]
        [AlarmInfo(1242, 420)]
        M1242 = 0x0000_0200_0000_0000,

        [Display(ENG_: "M1243 RF43 Voltage Alarm H", ZHTW_: "M1243 RF43電壓高於設定值")]
        [AlarmInfo(1243, 421)]
        M1243 = 0x0000_0400_0000_0000,

        [Display(ENG_: "M1244 RF44 Voltage Alarm H", ZHTW_: "M1244 RF44電壓高於設定值")]
        [AlarmInfo(1244, 422)]
        M1244 = 0x0000_0800_0000_0000,


        [Display(ENG_: "M1245 RF45 Voltage Alarm H", ZHTW_: "M1245 RF45電壓高於設定值")]
        [AlarmInfo(1245, 423)]
        M1245 = 0x0000_1000_0000_0000,

        [Display(ENG_: "M1246 RF46 Voltage Alarm H", ZHTW_: "M1246 RF46電壓高於設定值")]
        [AlarmInfo(1246, 424)]
        M1246 = 0x0000_2000_0000_0000,

        [Display(ENG_: "M1247 RF47 Voltage Alarm H", ZHTW_: "M1247 RF47電壓高於設定值")]
        [AlarmInfo(1247, 425)]
        M1247 = 0x0000_4000_0000_0000,

        [Display(ENG_: "M1248 RF48 Voltage Alarm H", ZHTW_: "M1248 RF48電壓高於設定值")]
        [AlarmInfo(1248, 426)]
        M1248 = 0x0000_8000_0000_0000,


        [Display(ENG_: "M1249 RF49 Voltage Alarm H", ZHTW_: "M1249 RF49電壓高於設定值")]
        [AlarmInfo(1249, 427)]
        M1249 = 0x0001_0000_0000_0000,

        [Display(ENG_: "M1250 RF50 Voltage Alarm H", ZHTW_: "M1250 RF50電壓高於設定值")]
        [AlarmInfo(1250, 428)]
        M1250 = 0x0002_0000_0000_0000,

        [Display(ENG_: "M1251 RF51 Voltage Alarm H", ZHTW_: "M1251 RF51電壓高於設定值")]
        [AlarmInfo(1251, 429)]
        M1251 = 0x0004_0000_0000_0000,

        [Display(ENG_: "M1252 RF52 Voltage Alarm H", ZHTW_: "M1252 RF52電壓高於設定值")]
        [AlarmInfo(1252, 430)]
        M1252 = 0x0008_0000_0000_0000,


        [Display(ENG_: "M1253 RF53 Voltage Alarm H", ZHTW_: "M1253 RF53電壓高於設定值")]
        [AlarmInfo(1253, 431)]
        M1253 = 0x0010_0000_0000_0000,

        [Display(ENG_: "M1254 RF54 Voltage Alarm H", ZHTW_: "M1254 RF54電壓高於設定值")]
        [AlarmInfo(1254, 432)]
        M1254 = 0x0020_0000_0000_0000,

        [Display(ENG_: "M1255 RF55 Voltage Alarm H", ZHTW_: "M1255 RF55電壓高於設定值")]
        [AlarmInfo(1255, 433)]
        M1255 = 0x0040_0000_0000_0000,

        [Display(ENG_: "M1256 RF56 Voltage Alarm H", ZHTW_: "M1256 RF56電壓高於設定值")]
        [AlarmInfo(1256, 434)]
        M1256 = 0x0080_0000_0000_0000,


        [Display(ENG_: "M1257 RF57 Voltage Alarm H", ZHTW_: "M1257 RF57電壓高於設定值")]
        [AlarmInfo(1257, 435)]
        M1257 = 0x0100_0000_0000_0000,

        [Display(ENG_: "M1258 RF58 Voltage Alarm H", ZHTW_: "M1258 RF58電壓高於設定值")]
        [AlarmInfo(1258, 436)]
        M1258 = 0x0200_0000_0000_0000,

        [Display(ENG_: "M1259 -", ZHTW_: "M1259 -")]
        [AlarmInfo(1259)]
        M1259 = 0x0400_0000_0000_0000,

        [Display(ENG_: "M1260 -", ZHTW_: "M1260 -")]
        [AlarmInfo(1260)]
        M1260 = 0x0800_0000_0000_0000,


        [Display(ENG_: "M1261 -", ZHTW_: "M1261 -")]
        [AlarmInfo(1261)]
        M1261 = 0x1000_0000_0000_0000,

        [Display(ENG_: "M1262 -", ZHTW_: "M1262 -")]
        [AlarmInfo(1262)]
        M1262 = 0x2000_0000_0000_0000,

        [Display(ENG_: "M1263 -", ZHTW_: "M1263 -")]
        [AlarmInfo(1263)]
        M1263 = 0x4000_0000_0000_0000,

        [Display(ENG_: "M1264 -", ZHTW_: "M1264 -")]
        [AlarmInfo(1264)]
        M1264 = 0x8000_0000_0000_0000,
    }
}

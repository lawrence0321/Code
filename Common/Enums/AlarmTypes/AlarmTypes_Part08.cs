using Common.Attributes;
using System;
using System.ComponentModel;

namespace Common.Enums
{
    [Flags]
    public enum AlarmTypes_Part08 : UInt64
    {
        None = 0x0000_0000_0000_0000,

        [Display(ENG_: "M1301 RF01 Voltage Alarm L", ZHTW_: "M1301 RF01電壓低於設定值")]
        [AlarmInfo(1301, 205)]
        M1301 = 0x0000_0000_0000_0001,

        [Display(ENG_: "M1302 RF02 Voltage Alarm L", ZHTW_: "M1302 RF02電壓低於設定值")]
        [AlarmInfo(1302, 206)]
        M1302 = 0x0000_0000_0000_0002,

        [Display(ENG_: "M1303 RF03 Voltage Alarm L", ZHTW_: "M1303 RF03電壓低於設定值")]
        [AlarmInfo(1303, 207)]
        M1303 = 0x0000_0000_0000_0004,

        [Display(ENG_: "M1304 RF04 Voltage Alarm L", ZHTW_: "M1304 RF04電壓低於設定值")]
        [AlarmInfo(1304, 208)]
        M1304 = 0x0000_0000_0000_0008,


        [Display(ENG_: "M1305 RF05 Voltage Alarm L", ZHTW_: "M1305 RF05電壓低於設定值")]
        [AlarmInfo(1305, 209)]
        M1305 = 0x0000_0000_0000_0010,

        [Display(ENG_: "M1306 RF06 Voltage Alarm L", ZHTW_: "M1306 RF06電壓低於設定值")]
        [AlarmInfo(1306, 210)]
        M1306 = 0x0000_0000_0000_0020,

        [Display(ENG_: "M1307 RF07 Voltage Alarm L", ZHTW_: "M1307 RF07電壓低於設定值")]
        [AlarmInfo(1307, 211)]
        M1307 = 0x0000_0000_0000_0040,

        [Display(ENG_: "M1308 RF08 Voltage Alarm L", ZHTW_: "M1308 RF08電壓低於設定值")]
        [AlarmInfo(1308, 212)]
        M1308 = 0x0000_0000_0000_0080,


        [Display(ENG_: "M1309 RF09 Voltage Alarm L", ZHTW_: "M1309 RF09電壓低於設定值")]
        [AlarmInfo(1309, 213)]
        M1309 = 0x0000_0000_0000_0100,

        [Display(ENG_: "M1310 RF10 Voltage Alarm L", ZHTW_: "M1310 RF10電壓低於設定值")]
        [AlarmInfo(1310, 214)]
        M1310 = 0x0000_0000_0000_0200,

        [Display(ENG_: "M1311 RF11 Voltage Alarm L", ZHTW_: "M1311 RF11電壓低於設定值")]
        [AlarmInfo(1311, 215)]
        M1311 = 0x0000_0000_0000_0400,

        [Display(ENG_: "M1312 RF12 Voltage Alarm L", ZHTW_: "M1312 RF12電壓低於設定值")]
        [AlarmInfo(1312, 216)]
        M1312 = 0x0000_0000_0000_0800,


        [Display(ENG_: "M1313 RF13 Voltage Alarm L", ZHTW_: "M1313 RF13電壓低於設定值")]
        [AlarmInfo(1313, 217)]
        M1313 = 0x0000_0000_0000_1000,

        [Display(ENG_: "M1314 RF14 Voltage Alarm L", ZHTW_: "M1314 RF14電壓低於設定值")]
        [AlarmInfo(1314, 218)]
        M1314 = 0x0000_0000_0000_2000,

        [Display(ENG_: "M1315 RF15 Voltage Alarm L", ZHTW_: "M1315 RF15電壓低於設定值")]
        [AlarmInfo(1315, 219)]
        M1315 = 0x0000_0000_0000_4000,

        [Display(ENG_: "M1316 RF16 Voltage Alarm L", ZHTW_: "M1316 RF16電壓低於設定值")]
        [AlarmInfo(1316, 220)]
        M1316 = 0x0000_0000_0000_8000,


        [Display(ENG_: "M1317 RF17 Voltage Alarm L", ZHTW_: "M1317 RF17電壓低於設定值")]
        [AlarmInfo(1317, 221)]
        M1317 = 0x0000_0000_0001_0000,

        [Display(ENG_: "M1318 RF18 Voltage Alarm L", ZHTW_: "M1318 RF18電壓低於設定值")]
        [AlarmInfo(1318, 222)]
        M1318 = 0x0000_0000_0002_0000,

        [Display(ENG_: "M1319 RF19 Voltage Alarm L", ZHTW_: "M1319 RF19電壓低於設定值")]
        [AlarmInfo(1319, 223)]
        M1319 = 0x0000_0000_0004_0000,

        [Display(ENG_: "M1320 RF20 Voltage Alarm L", ZHTW_: "M1320 RF20電壓低於設定值")]
        [AlarmInfo(1320, 224)]
        M1320 = 0x0000_0000_0008_0000,


        [Display(ENG_: "M1321 RF21 Voltage Alarm L", ZHTW_: "M1321 RF21電壓低於設定值")]
        [AlarmInfo(1321, 225)]
        M1321 = 0x0000_0000_0010_0000,

        [Display(ENG_: "M1322 RF22 Voltage Alarm L", ZHTW_: "M1322 RF22電壓低於設定值")]
        [AlarmInfo(1322, 226)]
        M1322 = 0x0000_0000_0020_0000,

        [Display(ENG_: "M1323 RF23 Voltage Alarm L", ZHTW_: "M1323 RF23電壓低於設定值")]
        [AlarmInfo(1323, 227)]
        M1323 = 0x0000_0000_0040_0000,

        [Display(ENG_: "M1324 RF24 Voltage Alarm L", ZHTW_: "M1324 RF24電壓低於設定值")]
        [AlarmInfo(1324, 228)]
        M1324 = 0x0000_0000_0080_0000,


        [Display(ENG_: "M1325 RF25 Voltage Alarm L", ZHTW_: "M1325 RF25電壓低於設定值")]
        [AlarmInfo(1325, 229)]
        M1325 = 0x0000_0000_0100_0000,

        [Display(ENG_: "M1326 RF26 Voltage Alarm L", ZHTW_: "M1326 RF26電壓低於設定值")]
        [AlarmInfo(1326, 230)]
        M1326 = 0x0000_0000_0200_0000,

        [Display(ENG_: "M1327 RF27 Voltage Alarm L", ZHTW_: "M1327 RF27電壓低於設定值")]
        [AlarmInfo(1327, 231)]
        M1327 = 0x0000_0000_0400_0000,

        [Display(ENG_: "M1328 RF28 Voltage Alarm L", ZHTW_: "M1328 RF28電壓低於設定值")]
        [AlarmInfo(1328, 232)]
        M1328 = 0x0000_0000_0800_0000,


        [Display(ENG_: "M1329 RF29 Voltage Alarm L", ZHTW_: "M1329 RF29電壓低於設定值")]
        [AlarmInfo(1329, 233)]
        M1329 = 0x0000_0000_1000_0000,

        [Display(ENG_: "M1330 RF30 Voltage Alarm L", ZHTW_: "M1330 RF30電壓低於設定值")]
        [AlarmInfo(1330, 234)]
        M1330 = 0x0000_0000_2000_0000,

        [Display(ENG_: "M1331 RF31 Voltage Alarm L", ZHTW_: "M1331 RF31電壓低於設定值")]
        [AlarmInfo(1331, 235)]
        M1331 = 0x0000_0000_4000_0000,

        [Display(ENG_: "M1332 RF32 Voltage Alarm L", ZHTW_: "M1332 RF32電壓低於設定值")]
        [AlarmInfo(1332, 236)]
        M1332 = 0x0000_0000_8000_0000,


        [Display(ENG_: "M1333 RF33 Voltage Alarm L", ZHTW_: "M1333 RF33電壓低於設定值")]
        [AlarmInfo(1333, 237)]
        M1333 = 0x0000_0001_0000_0000,

        [Display(ENG_: "M1334 RF34 Voltage Alarm L", ZHTW_: "M1334 RF34電壓低於設定值")]
        [AlarmInfo(1334, 238)]
        M1334 = 0x0000_0002_0000_0000,

        [Display(ENG_: "M1335 RF35 Voltage Alarm L", ZHTW_: "M1335 RF35電壓低於設定值")]
        [AlarmInfo(1335, 239)]
        M1335 = 0x0000_0004_0000_0000,

        [Display(ENG_: "M1336 RF36 Voltage Alarm L", ZHTW_: "M1336 RF36電壓低於設定值")]
        [AlarmInfo(1336, 240)]
        M1336 = 0x0000_0008_0000_0000,


        [Display(ENG_: "M1337 RF37 Voltage Alarm L", ZHTW_: "M1337 RF37電壓低於設定值")]
        [AlarmInfo(1337, 241)]
        M1337 = 0x0000_0010_0000_0000,

        [Display(ENG_: "M1338 RF38 Voltage Alarm L", ZHTW_: "M1338 RF38電壓低於設定值")]
        [AlarmInfo(1338, 242)]
        M1338 = 0x0000_0020_0000_0000,

        [Display(ENG_: "M1339 RF39 Voltage Alarm L", ZHTW_: "M1339 RF39電壓低於設定值")]
        [AlarmInfo(1339, 243)]
        M1339 = 0x0000_0040_0000_0000,

        [Display(ENG_: "M1340 RF40 Voltage Alarm L", ZHTW_: "M1340 RF40電壓低於設定值")]
        [AlarmInfo(1340, 244)]
        M1340 = 0x0000_0080_0000_0000,


        [Display(ENG_: "M1341 RF41 Voltage Alarm L", ZHTW_: "M1341 RF41電壓低於設定值")]
        [AlarmInfo(1341, 245)]
        M1341 = 0x0000_0100_0000_0000,

        [Display(ENG_: "M1342 RF42 Voltage Alarm L", ZHTW_: "M1342 RF42電壓低於設定值")]
        [AlarmInfo(1342, 246)]
        M1342 = 0x0000_0200_0000_0000,

        [Display(ENG_: "M1343 RF43 Voltage Alarm L", ZHTW_: "M1343 RF43電壓低於設定值")]
        [AlarmInfo(1343, 247)]
        M1343 = 0x0000_0400_0000_0000,

        [Display(ENG_: "M1344 RF44 Voltage Alarm L", ZHTW_: "M1344 RF44電壓低於設定值")]
        [AlarmInfo(1344, 248)]
        M1344 = 0x0000_0800_0000_0000,


        [Display(ENG_: "M1345 RF45 Voltage Alarm L", ZHTW_: "M1345 RF45電壓低於設定值")]
        [AlarmInfo(1345, 249)]
        M1345 = 0x0000_1000_0000_0000,

        [Display(ENG_: "M1346 RF46 Voltage Alarm L", ZHTW_: "M1346 RF46電壓低於設定值")]
        [AlarmInfo(1346, 250)]
        M1346 = 0x0000_2000_0000_0000,

        [Display(ENG_: "M1347 RF47 Voltage Alarm L", ZHTW_: "M1347 RF47電壓低於設定值")]
        [AlarmInfo(1347, 251)]
        M1347 = 0x0000_4000_0000_0000,

        [Display(ENG_: "M1348 RF48 Voltage Alarm L", ZHTW_: "M1348 RF48電壓低於設定值")]
        [AlarmInfo(1348, 252)]
        M1348 = 0x0000_8000_0000_0000,


        [Display(ENG_: "M1349 RF49 Voltage Alarm L", ZHTW_: "M1349 RF49電壓低於設定值")]
        [AlarmInfo(1349, 253)]
        M1349 = 0x0001_0000_0000_0000,

        [Display(ENG_: "M1350 RF50 Voltage Alarm L", ZHTW_: "M1350 RF50電壓低於設定值")]
        [AlarmInfo(1350, 254)]
        M1350 = 0x0002_0000_0000_0000,

        [Display(ENG_: "M1351 RF51 Voltage Alarm L", ZHTW_: "M1351 RF51電壓低於設定值")]
        [AlarmInfo(1351, 255)]
        M1351 = 0x0004_0000_0000_0000,

        [Display(ENG_: "M1352 RF52 Voltage Alarm L", ZHTW_: "M1352 RF52電壓低於設定值")]
        [AlarmInfo(1352, 256)]
        M1352 = 0x0008_0000_0000_0000,


        [Display(ENG_: "M1353 RF53 Voltage Alarm L", ZHTW_: "M1353 RF53電壓低於設定值")]
        [AlarmInfo(1353, 257)]
        M1353 = 0x0010_0000_0000_0000,

        [Display(ENG_: "M1354 RF54 Voltage Alarm L", ZHTW_: "M1354 RF54電壓低於設定值")]
        [AlarmInfo(1354, 258)]
        M1354 = 0x0020_0000_0000_0000,

        [Display(ENG_: "M1355 RF55 Voltage Alarm L", ZHTW_: "M1355 RF55電壓低於設定值")]
        [AlarmInfo(1355, 259)]
        M1355 = 0x0040_0000_0000_0000,

        [Display(ENG_: "M1356 RF56 Voltage Alarm L", ZHTW_: "M1356 RF56電壓低於設定值")]
        [AlarmInfo(1356, 260)]
        M1356 = 0x0080_0000_0000_0000,


        [Display(ENG_: "M1357 RF57 Voltage Alarm L", ZHTW_: "M1357 RF57電壓低於設定值")]
        [AlarmInfo(1357, 261)]
        M1357 = 0x0100_0000_0000_0000,

        [Display(ENG_: "M1358 RF58 Voltage Alarm L", ZHTW_: "M1358 RF58電壓低於設定值")]
        [AlarmInfo(1358, 262)]
        M1358 = 0x0200_0000_0000_0000,

        [Display(ENG_: "M1359 -", ZHTW_: "M1359 -")]
        [AlarmInfo(1359)]
        M1359 = 0x0400_0000_0000_0000,

        [Display(ENG_: "M1360 -", ZHTW_: "M1360 -")]
        [AlarmInfo(1360)]
        M1360 = 0x0800_0000_0000_0000,


        [Display(ENG_: "M1361 -", ZHTW_: "M1361 -")]
        [AlarmInfo(1361)]
        M1361 = 0x1000_0000_0000_0000,

        [Display(ENG_: "M1362 -", ZHTW_: "M1362 -")]
        [AlarmInfo(1362)]
        M1362 = 0x2000_0000_0000_0000,

        [Display(ENG_: "M1363 -", ZHTW_: "M1363 -")]
        [AlarmInfo(1363)]
        M1363 = 0x4000_0000_0000_0000,

        [Display(ENG_: "M1364 -", ZHTW_: "M1364 -")]
        [AlarmInfo(1364)]
        M1364 = 0x8000_0000_0000_0000,
    }
}

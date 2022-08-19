using Common.Attributes;
using System;

namespace Common.Enums
{
    [Flags]
    public enum AlarmTypes_Part01 : UInt64
    {
        [Display()]
        None = 0x0000_0000_0000_0000,


        [Display(ENG_: "600 Emergency Stop(Machine)", ZHTW_: "600 緊急停止(機構)")]
        [AlarmInfo(600, 002)]
        M600 = 0x0000_0000_0000_0001,
        [Display(ENG_: "601 DC24V Alarm", ZHTW_: "601 DC24V異常")]
        [AlarmInfo(601, 003)]
        M601 = 0x0000_0000_0000_0002,
        [Display(ENG_: "602 Start Bar Alarm", ZHTW_: "602 啟始掛架位置異常")]
        [AlarmInfo(602, 004)]
        M602 = 0x0000_0000_0000_0004,
        [Display(ENG_: "603 -", ZHTW_: "603 -")]
        [AlarmInfo(603)]
        M603 = 0x0000_0000_0000_0008,

        [Display(ENG_: "604 X0ACH B7A Alarm", ZHTW_: "604 X0ACH B7A異常")]
        [AlarmInfo(604, 005)]
        M604 = 0x0000_0000_0000_0010,
        [Display(ENG_: "605 X0BCH B7A Alarm", ZHTW_: "605 X0BCH B7A異常")]
        [AlarmInfo(605, 006)]
        M605 = 0x0000_0000_0000_0020,
        [Display(ENG_: "606 -", ZHTW_: "606 -")]
        [AlarmInfo(606)]
        M606 = 0x0000_0000_0000_0040,
        [Display(ENG_: "607 -", ZHTW_: "607 -")]
        [AlarmInfo(607)]
        M607 = 0x0000_0000_0000_0080,

        [Display(ENG_: "608 No.1CXNo.2C Clash", ZHTW_: "608 1號天車與2號天車碰撞")]
        [AlarmInfo(608, 097)]
        M608 = 0x0000_0000_0000_0100,
        [Display(ENG_: "609 No.2CXNo.3C Clash", ZHTW_: "609 2號天車與3號天車碰撞")]
        [AlarmInfo(609, 098)]
        M609 = 0x0000_0000_0000_0200,
        [Display(ENG_: "610 No.3CXNo.4C Clash", ZHTW_: "610 3號天車與4號天車碰撞")]
        [AlarmInfo(610, 099)]
        M610 = 0x0000_0000_0000_0400,
        [Display(ENG_: "611 No.4CXNo.5C Clash", ZHTW_: "611 4號天車與5號天車碰撞")]
        [AlarmInfo(611, 100)]
        M611 = 0x0000_0000_0000_0800,

        [Display(ENG_: "612 -", ZHTW_: "612 -")]
        [AlarmInfo(612)]
        M612 = 0x0000_0000_0000_1000,
        [Display(ENG_: "613 -", ZHTW_: "613 -")]
        [AlarmInfo(613)]
        M613 = 0x0000_0000_0000_2000,
        [Display(ENG_: "614 -", ZHTW_: "614 -")]
        [AlarmInfo(614)]
        M614 = 0x0000_0000_0000_4000,
        [Display(ENG_: "615 -", ZHTW_: "615 -")]
        [AlarmInfo(615)]
        M615 = 0x0000_0000_0000_8000,

        [Display(ENG_: "616 No.1C Inverter Alarm", ZHTW_: "616 1號天車變頻器異常")]
        [AlarmInfo(616, 102)]
        M616 = 0x0000_0000_0001_0000,
        [Display(ENG_: "617 No.1C Forward Over", ZHTW_: "617 1號天車前極限越位")]
        [AlarmInfo(617, 104)]
        M617 = 0x0000_0000_0002_0000,
        [Display(ENG_: "618 No.1C Reverse Over", ZHTW_: "618 1號天車後極限越位")]
        [AlarmInfo(618, 105)]
        M618 = 0x0000_0000_0004_0000,
        [Display(ENG_: "619 No.1C Double Bar", ZHTW_: "619 1號天車位置槽內已有掛架")]
        [AlarmInfo(619, 118)]
        M619 = 0x0000_0000_0008_0000,

        [Display(ENG_: "620 No.1C Stop Area Alarm", ZHTW_: "620 1號天車停止位置錯誤")]
        [AlarmInfo(620, 106)]
        M620 = 0x0000_0000_0010_0000,
        [Display(ENG_: "612 -", ZHTW_: "612 -")]
        [AlarmInfo(621)]
        M621 = 0x0000_0000_0020_0000,
        [Display(ENG_: "622 No.1C VS-1S62 Alarm", ZHTW_: "622 1號天車VS-1S62 模組異常")]
        [AlarmInfo(622, 107)]
        M622 = 0x0000_0000_0040_0000,
        [Display(ENG_: "623 No.1C Home Sensor Alarm", ZHTW_: "623 1號天車原點Sensor異常")]
        [AlarmInfo(623, 108)]
        M623 = 0x0000_0000_0080_0000,

        [Display(ENG_: "624 No.1C Hook Sensor Alarm", ZHTW_: "624 1號天車掛勾Sensor異常")]
        [AlarmInfo(624, 109)]
        M624 = 0x0000_0000_0100_0000,
        [Display(ENG_: "625 No.1C B7A Alarm", ZHTW_: "625 1號天車B7A模組異常")]
        [AlarmInfo(625, 110)]
        M625 = 0x0000_0000_0200_0000,
        [Display(ENG_: "626 No.1C Up Over", ZHTW_: "626 1號天車掛勾提升超過上極限")]
        [AlarmInfo(626, 101)]
        M626 = 0x0000_0000_0400_0000,
        [Display(ENG_: "627 No.1C Down Over", ZHTW_: "627 1號天車掛勾放下超過下極限")]
        [AlarmInfo(627, 103)]
        M627 = 0x0000_0000_0800_0000,

        [Display(ENG_: "628 No.1C Belt Alarm", ZHTW_: "628 1號天車皮帶鬆脫異常")]
        [AlarmInfo(628, 119)]
        M628 = 0x0000_0000_1000_0000,
        [Display(ENG_: "629 No.1C Foward/Reverse Time Over", ZHTW_: "629 1號天車行進超時/前後馬達")]
        [AlarmInfo(629, 113)]
        M629 = 0x0000_0000_2000_0000,
        [Display(ENG_: "630 No.1C Up/Down Time Over", ZHTW_: "630 1號天車升降超時/升降馬達")]
        [AlarmInfo(630, 114)]
        M630 = 0x0000_0000_4000_0000,
        [Display(ENG_: "631 -", ZHTW_: "631 -")]
        [AlarmInfo(631)]
        M631 = 0x0000_0000_8000_0000,

        [Display(ENG_: "632 No.2C Inverter Alarm", ZHTW_: "632 2號天車變頻器異常")]
        [AlarmInfo(632, 121)]
        M632 = 0x0000_0001_0000_0000,
        [Display(ENG_: "633 No.2C Forward Over", ZHTW_: "633 2號天車前極限越位")]
        [AlarmInfo(633, 123)]
        M633 = 0x0000_0002_0000_0000,
        [Display(ENG_: "634 No.2C Reverse Over", ZHTW_: "634 2號天車後極限越位")]
        [AlarmInfo(634, 124)]
        M634 = 0x0000_0004_0000_0000,
        [Display(ENG_: "635 No.2C Double Bar", ZHTW_: "635 2號天車位置槽內已有掛架")]
        [AlarmInfo(635, 137)]
        M635 = 0x0000_0008_0000_0000,

        [Display(ENG_: "636 No.2C Stop Area Alarm", ZHTW_: "636 2號天車停止位置錯誤")]
        [AlarmInfo(636, 125)]
        M636 = 0x0000_0010_0000_0000,
        [Display(ENG_: "637 -", ZHTW_: "637 -")]
        [AlarmInfo(637)]
        M637 = 0x0000_0020_0000_0000,
        [Display(ENG_: "638 No.2C Servo Alarm", ZHTW_: "638 2號天車VS-1S62 模組異常")]
        [AlarmInfo(638, 126)]
        M638 = 0x0000_0040_0000_0000,
        [Display(ENG_: "639 No.2C Home Sensor Alarm", ZHTW_: "639 2號天車原點Sensor異常")]
        [AlarmInfo(639, 127)]
        M639 = 0x0000_0080_0000_0000,

        [Display(ENG_: "640 No.2C Hook Sensor Alarm", ZHTW_: "640 2號天車掛勾Sensor異常")]
        [AlarmInfo(640, 128)]
        M640 = 0x0000_0100_0000_0000,
        [Display(ENG_: "641 No.2C B7A Alarm", ZHTW_: "641 2號天車B7A模組異常")]
        [AlarmInfo(641, 129)]
        M641 = 0x0000_0200_0000_0000,
        [Display(ENG_: "642 No.2C Up Over", ZHTW_: "642 2號天車掛勾提升超過上極限")]
        [AlarmInfo(642, 120)]
        M642 = 0x0000_0400_0000_0000,
        [Display(ENG_: "643 No.2C Down Over", ZHTW_: "643 2號天車掛勾放下超過下極限")]
        [AlarmInfo(643, 122)]
        M643 = 0x0000_0800_0000_0000,

        [Display(ENG_: "644 No.2C Belt Alarm", ZHTW_: "644 2號天車皮帶鬆脫異常")]
        [AlarmInfo(644, 138)]
        M644 = 0x0000_1000_0000_0000,
        [Display(ENG_: "645 No.2C Foward/Reverse Time Over", ZHTW_: "645 2號天車行進超時")]
        [AlarmInfo(645, 132)]
        M645 = 0x0000_2000_0000_0000,
        [Display(ENG_: "646 No.2C Up/Down Time Over", ZHTW_: "646 2號天車升降超時")]
        [AlarmInfo(646, 133)]
        M646 = 0x0000_4000_0000_0000,
        [Display(ENG_: "647 No.2C Pitch Alarm", ZHTW_: "647 2號天車開閉氣缸異常")]
        [AlarmInfo(647, 134)]
        M647 = 0x0000_8000_0000_0000,

        [Display(ENG_: "648 No.3C Inverter Alarm", ZHTW_: "648 2號天車變頻器異常")]
        [AlarmInfo(648, 140)]
        M648 = 0x0001_0000_0000_0000,
        [Display(ENG_: "649 No.3C Forward Over", ZHTW_: "649 2號天車前極限越位")]
        [AlarmInfo(649, 142)]
        M649 = 0x0002_0000_0000_0000,
        [Display(ENG_: "650 No.3C Reverse Over", ZHTW_: "650 2號天車後極限越位")]
        [AlarmInfo(650, 143)]
        M650 = 0x0004_0000_0000_0000,
        [Display(ENG_: "651 No.3C Double Bar", ZHTW_: "651 2號天車位置槽內已有掛架")]
        [AlarmInfo(651, 156)]
        M651 = 0x0008_0000_0000_0000,

        [Display(ENG_: "652 No.3C Stop Area Alarm",ZHTW_: "652 2號天車停止位置錯誤")]
        [AlarmInfo(652, 144)]
        M652 = 0x0010_0000_0000_0000,
        [Display(ENG_: "653 -",ZHTW_: "653 -")]
        [AlarmInfo(653)]
        M653 = 0x0020_0000_0000_0000,
        [Display(ENG_: "654 No.3C VS-1S62 Alarm",ZHTW_: "654 3號天車VS-1S62 模組異常")]
        [AlarmInfo(654, 145)]
        M654 = 0x0040_0000_0000_0000,
        [Display(ENG_: "655 No.3C Home Sensor Alarm",ZHTW_: "655 3號天車原點Sensor異常")]
        [AlarmInfo(655, 146)]
        M655 = 0x0080_0000_0000_0000,

        [Display(ENG_: "656 No.3C Hook Sensor Alarm",ZHTW_: "656 3號天車掛勾Sensor異常")]
        [AlarmInfo(656, 147)]
        M656 = 0x0100_0000_0000_0000,
        [Display(ENG_: "657 No.3C B7A Alarm",ZHTW_: "657 3號天車B7A模組異常")]
        [AlarmInfo(657, 148)]
        M657 = 0x0200_0000_0000_0000,
        [Display(ENG_: "658 No.3C Up Over",ZHTW_: "658 3號天車掛勾提升超過上極限")]
        [AlarmInfo(658, 139)]
        M658 = 0x0400_0000_0000_0000,
        [Display(ENG_: "659 No.3C Down Over",ZHTW_: "659 3號天車掛勾放下超過下極限")]
        [AlarmInfo(659, 141)]
        M659 = 0x0800_0000_0000_0000,

        [Display(ENG_: "660 No.3C Belt Alarm",ZHTW_: "660 3號天車皮帶鬆脫異常")]
        [AlarmInfo(660, 157)]
        M660 = 0x1000_0000_0000_0000,
        [Display(ENG_: "661 No.3C Foward/Reverse Time Over",ZHTW_: "661 3號天車行進超時/前後馬達")]
        [AlarmInfo(661, 151)]
        M661 = 0x2000_0000_0000_0000,
        [Display(ENG_: "662 No.3C Up/Down Time Over",ZHTW_: "662 3號天車升降超時/升降馬達")]
        [AlarmInfo(662, 152)]
        M662 = 0x4000_0000_0000_0000,
        [Display(ENG_: "663 No.3C Pitch Alarm",ZHTW_: "663 3號天車開閉氣缸異常")]
        [AlarmInfo(663, 153)]
        M663 = 0x8000_0000_0000_0000,
    }

}


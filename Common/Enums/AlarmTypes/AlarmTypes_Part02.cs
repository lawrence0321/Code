using Common.Attributes;
using System;

namespace Common.Enums
{
    [Flags]
    public enum AlarmTypes_Part02 : UInt64
    {
        None = 0x0000_0000_0000_0000,

        [Display(ENG_: "664 No.4C Inverter Alarm", ZHTW_: "664 3號天車變頻器異常")]
        [AlarmInfo(664, 159)]
        M664 = 0x0000_0000_0000_0001,

        [Display(ENG_: "665 No.4C Forward Over", ZHTW_: "665 3號天車前極限越位")]
        [AlarmInfo(665, 161)]
        M665 = 0x0000_0000_0000_0002,

        [Display(ENG_: "666 No.4C Reverse Over", ZHTW_: "666 3號天車後極限越位")]
        [AlarmInfo(666, 162)]
        M666 = 0x0000_0000_0000_0004,

        [Display(ENG_: "667 No.4C Double Bar", ZHTW_: "667 3號天車位置槽內已有掛架")]
        [AlarmInfo(667, 175)]
        M667 = 0x0000_0000_0000_0008,


        [Display(ENG_:"668 No.4C Stop Area Alarm", ZHTW_: "668 3號天車停止位置錯誤")]
        [AlarmInfo(668, 163)]
        M668 = 0x0000_0000_0000_0010,
        
        [Display(ENG_: "669 -", ZHTW_: "669 -")]
        [AlarmInfo(669)]
        M669 = 0x0000_0000_0000_0020,

        [Display(ENG_: "670 No.4C VS-1S62 Alarm", ZHTW_: "670 4號天車VS-1S62 模組異常")]
        [AlarmInfo(670, 164)]
        M670 = 0x0000_0000_0000_0040,

        [Display(ENG_: "671 No.4C Home Sensor Alarm", ZHTW_: "671 4號天車原點Sensor異常")]
        [AlarmInfo(671, 165)]
        M671 = 0x0000_0000_0000_0080,


        [Display(ENG_: "672 No.4C Hook Sensor Alarm", ZHTW_: "672 4號天車掛勾Sensor異常")]
        [AlarmInfo(672, 166)]
        M672 = 0x0000_0000_0000_0100,

        [Display(ENG_: "673 No.4C B7A Alarm", ZHTW_: "673 4號天車B7A模組異常")]
        [AlarmInfo(673, 167)]
        M673 = 0x0000_0000_0000_0200,

        [Display(ENG_: "674 No.4C Up Over", ZHTW_: "674 4號天車掛勾提升超過上極限")]
        [AlarmInfo(674, 158)]
        M674 = 0x0000_0000_0000_0400,

        [Display(ENG_: "675 No.4C Down Over", ZHTW_: "675 4號天車掛勾放下超過下極限")]
        [AlarmInfo(675, 176)]
        M675 = 0x0000_0000_0000_0800,


        [Display(ENG_: "676 No.4C Belt Alarm", ZHTW_: "676 4號天車皮帶鬆脫異常")]
        [AlarmInfo(676, 176)]
        M676 = 0x0000_0000_0000_1000,

        [Display(ENG_: "677 No.4C Foward/Reverse Time Over", ZHTW_: "677 4號天車行進超時/前後馬達")]
        [AlarmInfo(677, 170)]
        M677 = 0x0000_0000_0000_2000,

        [Display(ENG_: "678 No.4C Up/Down Time Over", ZHTW_: "678 4號天車升降超時/升降馬達")]
        [AlarmInfo(678, 171)]
        M678 = 0x0000_0000_0000_4000,

        [Display(ENG_: "679 No.4C Pitch Alarm", ZHTW_: "679 4號天車開閉氣缸異常")]
        [AlarmInfo(679, 172)]
        M679 = 0x0000_0000_0000_8000,


        [Display(ENG_: "680 No.5C Inverter Alarm", ZHTW_: "680 4號天車變頻器異常")]
        [AlarmInfo(680, 178)]
        M680 = 0x0000_0000_0001_0000,

        [Display(ENG_: "681 No.5C Forward Over", ZHTW_: "681 4號天車前極限越位")]
        [AlarmInfo(681, 180)]
        M681 = 0x0000_0000_0002_0000,

        [Display(ENG_: "682 No.5C Reverse Over", ZHTW_: "682 4號天車後極限越位")]
        [AlarmInfo(682, 181)]
        M682 = 0x0000_0000_0004_0000,

        [Display(ENG_: "683 No.5C Double Bar", ZHTW_: "683 4號天車位置槽內已有掛架")]
        [AlarmInfo(683, 194)]
        M683 = 0x0000_0000_0008_0000,


        [Display(ENG_: "684 No.5C Stop Area Alarm", ZHTW_: "684 4號天車停止位置錯誤")]
        [AlarmInfo(684, 182)]
        M684 = 0x0000_0000_0010_0000,

        [Display(ENG_: "685 -", ZHTW_: "685 -")]
        [AlarmInfo(685)]
        M685 = 0x0000_0000_0020_0000,

        [Display(ENG_: "686 No.5C VS-1S62 Alarm", ZHTW_: "686 5號天車VS-1S62 模組異常")]
        [AlarmInfo(686, 183)]
        M686 = 0x0000_0000_0040_0000,

        [Display(ENG_: "687 No.5C Home Sensor Alarm", ZHTW_: "687 5號天車原點Sensor異常")]
        [AlarmInfo(687, 184)]
        M687 = 0x0000_0000_0080_0000,


        [Display(ENG_: "688 No.5C Hook Sensor Alarm", ZHTW_: "688 5號天車掛勾Sensor異常")]
        [AlarmInfo(688, 185)]
        M688 = 0x0000_0000_0100_0000,

        [Display(ENG_: "689 No.5C B7A Alarm", ZHTW_: "689 5號天車B7A模組異常")]
        [AlarmInfo(689, 186)]
        M689 = 0x0000_0000_0200_0000,

        [Display(ENG_: "690 No.5C Up Over", ZHTW_: "690 5號天車掛勾提升超過上極限")]
        [AlarmInfo(690, 177)]
        M690 = 0x0000_0000_0400_0000,

        [Display(ENG_: "691 No.5C Down Over", ZHTW_: "691 5號天車掛勾放下超過下極限")]
        [AlarmInfo(691, 179)]
        M691 = 0x0000_0000_0800_0000,


        [Display(ENG_: "692 No.5C Belt Alarm", ZHTW_: "692 5號天車皮帶鬆脫異常")]
        [AlarmInfo(692, 195)]
        M692 = 0x0000_0000_1000_0000,

        [Display(ENG_: "693 No.5C Foward/Reverse Time Over", ZHTW_: "693 5號天車行進超時/前後馬達")]
        [AlarmInfo(693, 189)]
        M693 = 0x0000_0000_2000_0000,

        [Display(ENG_: "694 No.5C Up/Down Time Over", ZHTW_: "694 5號天車升降超時/升降馬達")]
        [AlarmInfo(694, 190)]
        M694 = 0x0000_0000_4000_0000,

        [Display(ENG_: "695 -", ZHTW_: "695 -")]
        [AlarmInfo(695)]
        M695 = 0x0000_0000_8000_0000,


        [Display(ENG_: "696 Rocking1 Inverter Alarm", ZHTW_: "696 搖擺1變頻器異常")]
        [AlarmInfo(696, 201)]
        M696 = 0x0000_0001_0000_0000,

        [Display(ENG_: "697 Rocking2 Inverter Alarm", ZHTW_: "697 搖擺2變頻器異常")]
        [AlarmInfo(697, 202)]
        M697 = 0x0000_0002_0000_0000,

        [Display(ENG_: "698 Rocking3 Inverter Alarm", ZHTW_: "698 搖擺3變頻器異常")]
        [AlarmInfo(698, 203)]
        M698 = 0x0000_0004_0000_0000,

        [Display(ENG_: "699 Rocking4 Inverter Alarm", ZHTW_: "699 搖擺4變頻器異常")]
        [AlarmInfo(699, 204)]
        M699 = 0x0000_0008_0000_0000,


        [Display(ENG_: "700 Rocking1 Stop Area Alarm", ZHTW_: "700 搖擺1止位置錯誤")]
        [AlarmInfo(700, 197)]
        M700 = 0x0000_0010_0000_0000,

        [Display(ENG_: "701 Rocking2 Stop Area Alarm", ZHTW_: "701 搖擺2止位置錯誤")]
        [AlarmInfo(701, 198)]
        M701 = 0x0000_0020_0000_0000,

        [Display(ENG_: "702 Rocking3 Stop Area Alarm", ZHTW_: "702 搖擺3止位置錯誤")]
        [AlarmInfo(702, 199)]
        M702 = 0x0000_0040_0000_0000,

        [Display(ENG_: "703 Rocking4 Stop Area Alarm", ZHTW_: "703 搖擺4止位置錯誤")]
        [AlarmInfo(703, 200)]
        M703 = 0x0000_0080_0000_0000,


        [Display(ENG_: "704 No.1 Carrier Bar Shock Alarm", ZHTW_: "704 1號天車掛架衝擊器缸異常")]
        [AlarmInfo(704, 116)]
        M704 = 0x0000_0100_0000_0000,

        [Display(ENG_: "705 No.2 Carrier Bar Shock Alarm", ZHTW_: "705 2號天車掛架衝擊器缸異常")]
        [AlarmInfo(705, 135)]
        M705 = 0x0000_0200_0000_0000,

        [Display(ENG_: "706 No.3 Carrier Bar Shock Alarm", ZHTW_: "706 3號天車掛架衝擊器缸異常")]
        [AlarmInfo(706, 154)]
        M706 = 0x0000_0400_0000_0000,

        [Display(ENG_: "707 No.4 Carrier Bar Shock Alarm", ZHTW_: "707 4號天車掛架衝擊器缸異常")]
        [AlarmInfo(707, 173)]
        M707 = 0x0000_0800_0000_0000,


        [Display(ENG_: "708 No.5 Carrier Bar Shock Alarm", ZHTW_: "708 5號天車掛架衝擊器缸異常")]
        [AlarmInfo(708, 192)]
        M708 = 0x0000_1000_0000_0000,

        [Display(ENG_: "709 -", ZHTW_: "709 -")]
        [AlarmInfo(709)]
        M709 = 0x0000_2000_0000_0000,

        [Display(ENG_: "710 -", ZHTW_: "710 -")]
        [AlarmInfo(710)]
        M710 = 0x0000_4000_0000_0000,

        [Display(ENG_: "711 -", ZHTW_: "711 -")]
        [AlarmInfo(711)]
        M711 = 0x0000_8000_0000_0000,


        [Display(ENG_: "712 Cycle Time Over", ZHTW_: "712 上下板動作超時")]
        [AlarmInfo(712, 009)]
        M712 = 0x0001_0000_0000_0000,

        [Display(ENG_: "713 PLC Battely Alarm", ZHTW_: "713 PLC電池異常")]
        [AlarmInfo(713, 010)]
        M713 = 0x0002_0000_0000_0000,

        [Display(ENG_: "714 PC Handshake Alarm(IN)", ZHTW_: "714 電腦離線異常(IN)")]
        [AlarmInfo(714, 012)]
        M714 = 0x0004_0000_0000_0000,

        [Display(ENG_: "715 PC(RF) Handshake Alarm", ZHTW_: "715 電腦(RF)離線異常")]
        [AlarmInfo(715, 011)]
        M715 = 0x0008_0000_0000_0000,


        [Display(ENG_: "716 Bar No Alarm", ZHTW_: "716 掛架編碼異常")]
        [AlarmInfo(716, 013)]
        M716 = 0x0010_0000_0000_0000,

        [Display(ENG_: "717 PC Handshake Alarm(VB)", ZHTW_: "717 電腦離線異常(VB)")]
        [AlarmInfo(717, 014)]
        M717 = 0x0020_0000_0000_0000,

        [Display(ENG_: "718 -", ZHTW_: "718 -")]
        [AlarmInfo(718)]
        M718 = 0x0040_0000_0000_0000,

        [Display(ENG_: "719 -", ZHTW_: "719 -")]
        [AlarmInfo(719, 000)]
        M719 = 0x0080_0000_0000_0000,


        [Display(ENG_: "720 Load Up Alarm", ZHTW_: "720 下料機上升氣缸異常")]
        [AlarmInfo(720, 015)]
        M720 = 0x0100_0000_0000_0000,

        [Display(ENG_: "721 Load Down Alarm", ZHTW_: "721 下料機下降氣缸異常")]
        [AlarmInfo(721, 016)]
        M721 = 0x0200_0000_0000_0000,

        [Display(ENG_: "722 Load Out Alarm", ZHTW_: "722 下料機出料移動異常")]
        [AlarmInfo(722, 017)]
        M722 = 0x0400_0000_0000_0000,

        [Display(ENG_: "723 Load In Alarm", ZHTW_: "723 下料機入料移動異常")]
        [AlarmInfo(723, 018)]
        M723 = 0x0800_0000_0000_0000,


        [Display(ENG_: "724 Ni-Tank Select Alarm", ZHTW_: "724 鎳槽選擇異常")]
        [AlarmInfo(724, 019)]
        M724 = 0x1000_0000_0000_0000,

        [Display(ENG_: "725 -", ZHTW_: "725 -")]
        [AlarmInfo(725)]
        M725 = 0x2000_0000_0000_0000,

        [Display(ENG_: "726 -", ZHTW_: "726 -")]
        [AlarmInfo(726)]
        M726 = 0x4000_0000_0000_0000,

        [Display(ENG_: "727 -", ZHTW_: "727 -")]
        [AlarmInfo(727)]
        M727 = 0x8000_0000_0000_0000,
    }
}


using Common.Attributes;
using Common.Enums;
using Common.Extension;
using Common.Interface;
using System;

namespace Common.DTO
{

    /// <summary>
    /// LoadData 
    /// <para>單位:一車</para>
    /// </summary>
    public class LoadDataDTO : IDTO
    {
        /// <summary>
        /// ID
        /// </summary>
        [Display()]
        public string ID { get; set; }

        /// <summary>
        /// 編號 
        /// <para>Load進PLC十的時間戳記</para>
        /// </summary>
        [Display()]
        public string Code { get; set; }


        /// <summary>
        /// 排序用時間
        /// </summary>
        [Display()]
        public long SortTimeTicks { get; set; }
        [Display()]
        public DateTime SortDateTime => new DateTime(SortTimeTicks);
        [Display()]
        public String SortDateTimeString => SortDateTime.GetString();
        /// <summary>
        /// 系統log
        /// </summary>
        [Display()]
        public string SystemLog { get; set; }

        /// <summary>
        /// 創建來源
        /// </summary>
        [Display("創建來源")]
        public LoadSourceTypes LoadSourceType { get; set; }

        /// <summary>
        /// 創建時間
        /// </summary>
        [Display()]
        public long CreateTimeTicks { get; set; }
        /// <summary>
        /// 創建時間
        /// </summary>
        [Display()]
        public DateTime CreateDateTime => new DateTime(CreateTimeTicks);
        /// <summary>
        /// 創建時間
        /// </summary>
        [Display("創建時間")]
        public string CreateDateTimeString => CreateDateTime.GetString();

        /// <summary>
        /// 結案時間
        /// </summary>
        [Display()]
        public long FinishTimeTicks { get; set; }
        /// <summary>
        /// 結案時間
        /// </summary>
        [Display()]
        public DateTime FinishDateTime => new DateTime(FinishTimeTicks);
        /// <summary>
        /// 結案時間
        /// </summary>
        [Display("結案時間")]
        public string FinishDateTimeString => FinishDateTime.GetString();

        /// <summary>
        /// 是否正常結束
        /// </summary>
        [Display("是否正常結束")]
        public bool IsNormalFinish { get; set; }

        /// <summary>
        /// 工號
        /// </summary>
        [Display("工號")]
        public string EditorID { get; set; }

        /// <summary>
        /// 有效值
        /// </summary>
        [Display()]
        public bool Enabled { get; set; }

        /// <summary>
        ///  第一掛 是否為空掛
        /// </summary>
        [Display()]
        public bool First_IsEmpty { get; set; }

        /// <summary>
        ///  第二掛 是否為空掛
        /// </summary>
        [Display()]
        public bool Second_IsEmpty { get; set; }



        /// <summary>
        ///  第一掛 生產批號
        /// </summary>
        [Display("LotNo")]
        public string First_LotCode { get; set; }

        /// <summary>
        ///  第一掛 配方編號
        /// </summary>
        [Display("PanelCode")]
        public string First_RecipeCode { get; set; }

        /// <summary>
        /// 第一掛 生產模式
        /// </summary>
        [Display("PMode")]
        public string First_PMode { get; set; }

        /// <summary>
        /// 第一掛 生產片數
        /// </summary>
        [Display("Quantity")]
        public int First_Quantity { get; set; }

        /// <summary>
        /// 第一掛 尺寸
        /// </summary>
        [Display("Size")]
        public string First_Size { get; set; }

        /// <summary>
        /// 第一掛 厚度
        /// </summary>
        [Display("Thickness")]
        public long First_Thickness { get; set; }

        /// <summary>
        /// 第一掛 正面面積
        /// </summary>
        [Display("WBArea")]
        public long First_WBArea { get; set; }

        /// <summary>
        /// 第一掛 背面面積
        /// </summary>
        [Display("BArea")]
        public long First_BArea { get; set; }

        /// <summary>
        /// 第一掛 鎳 正面電流值
        /// </summary>
        [Display("Ni(W/B)")]
        public double First_Ni_WB_Current { get; set; }

        /// <summary>
        /// 第一掛 鎳 背面電流值
        /// </summary>
        [Display("Ni(B)")]
        public double First_Ni_B_Current { get; set; }

        /// <summary>
        /// 第一掛 金 正面電流值
        /// </summary>
        [Display("Au(W/B)")]
        public double First_Au_WB_Current { get; set; }

        /// <summary>
        /// 第一掛 金 背面電流值
        /// </summary>
        [Display("Au(B)")]
        public double First_Au_B_Current { get; set; }

        /// <summary>
        /// 第一掛 預鍍金 電流值
        /// </summary>
        [Display("AuSt")]
        public double First_AuSt_Current { get; set; }

        /// <summary>
        /// 第一掛 鎳 作業時間
        /// </summary>
        [Display("Ni PTime")]
        public long First_Ni_PTime { get; set; }

        /// <summary>
        /// 第一掛 金 作業時間
        /// </summary>
        [Display("Au PTime")]
        public long First_Au_PTime { get; set; }

        /// <summary>
        /// 第一掛 預鍍金 作業時間
        /// </summary>
        [Display("AuSt PTime")]
        public long First_AuSt_PTime { get; set; }


        ///  第二掛 生產批號
        /// </summary>
        [Display("LotNo")]
        public string Second_LotCode { get; set; }

        /// <summary>
        ///  第二掛 配方編號
        /// </summary>
        [Display("PanelCode")]
        public string Second_RecipeCode { get; set; }


        /// <summary>
        /// 第二掛 生產模式
        /// </summary>
        [Display("PMode")]
        public string Second_PMode { get; set; }

        /// <summary>
        /// 第二掛 生產片數
        /// </summary>
        [Display("Quantity")]
        public int Second_Quantity { get; set; }

        /// <summary>
        /// 第二掛 尺寸
        /// </summary>
        [Display("Size")]
        public string Second_Size { get; set; }

        /// <summary>
        /// 第二掛 厚度
        /// </summary>
        [Display("Thickness")]
        public long Second_Thickness { get; set; }

        /// <summary>
        /// 第二掛 正面面積
        /// </summary>
        [Display("WBArea")]
        public long Second_WBArea { get; set; }

        /// <summary>
        /// 第二掛 背面面積
        /// </summary>
        [Display("BArea")]
        public long Second_BArea { get; set; }

        /// <summary>
        /// 第二掛 鎳 正面電流值
        /// </summary>
        [Display("Ni(W/B)")]
        public double Second_Ni_WB_Current { get; set; }

        /// <summary>
        /// 第二掛 鎳 背面電流值
        /// </summary>
        [Display("Ni(B)")]
        public double Second_Ni_B_Current { get; set; }

        /// <summary>
        /// 第二掛 金 正面電流值
        /// </summary>
        [Display("Au(W/B)")]
        public double Second_Au_WB_Current { get; set; }

        /// <summary>
        /// 第二掛 金 背面電流值
        /// </summary>
        [Display("Au(B)")]
        public double Second_Au_B_Current { get; set; }

        /// <summary>
        /// 第二掛 預鍍金 電流值
        /// </summary>
        [Display("AuSt")]
        public double Second_AuSt_Current { get; set; }

        /// <summary>
        /// 第二掛 鎳 作業時間
        /// </summary>
        [Display("Ni PTime")]
        public long Second_Ni_PTime { get; set; }

        /// <summary>
        /// 第二掛 金 作業時間
        /// </summary>
        [Display("Au PTime")]
        public long Second_Au_PTime { get; set; }

        /// <summary>
        /// 第二掛 預鍍金 作業時間
        /// </summary>
        [Display("AuSt PTime")]
        public long Second_AuSt_PTime { get; set; }
    }

}

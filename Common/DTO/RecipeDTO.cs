using Common.Attributes;
using Common.Extension;
using Common.Interface;
using System;

namespace Common.DTO
{
    public class RecipeDTO : IDTO
    {
        /// <summary>
        /// [PK]ID
        /// </summary>
        [Display()]
        public string ID { get; set; }

        /// <summary>
        /// 創建時間
        /// </summary>
        [Display()]
        public long CreateTimeTicks { get; set; }
        /// <summary>
        /// 創建時間
        /// </summary>
        [Display()]
        public DateTime CreateDateTime => new DateTime(this.CreateTimeTicks);
        /// <summary>
        /// 創建時間
        /// </summary>
        [Display("創建時間")]
        public string CreateDateTimeString => CreateDateTime.GetString();

        /// <summary>
        /// 有效值 
        /// </summary>
        [Display()]
        public bool Enabeld { get; set; }
        /// <summary>
        /// 創建時間
        /// </summary>
        [Display("有效值")]
        public string EnabeldString => this.Enabeld ? "有效" : "無效";

        /// <summary>
        /// 最後一個操作者
        /// </summary>
        [Display()]
        public string EditorID { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        [Display("備註")]
        public string Remarks { get; set; }

        ///// <summary>
        ///// 備註
        ///// </summary>
        //[Display("備註")]
        //public string VeiwRemarks => String.Format(
        //    "<{0:00}/{1:00}/{2:0000} {3:00}:{4:00} (M/D/Y_H:M)>{5}",
        //    CreateDateTime.Month,
        //    CreateDateTime.Day,
        //    CreateDateTime.Year,
        //    CreateDateTime.Hour,
        //    CreateDateTime.Minute,
        //    Remarks
        //    );

        /// <summary>
        /// 系統紀錄
        /// </summary>
        [Display("系統紀錄")]
        public string SystemLog { get; set; }


        /// <summary>
        /// 料號碼
        /// </summary>
        [Display(false,ZHTW_:"料號碼", ENG_: "PanelCode")]
        public string PanelCode { get; set; }

        /// <summary>
        /// 料號碼
        /// </summary>
        [Display("料號碼", ENG_: "PanelCode")]
        public string DisplayCode { get; set; }

        /// <summary>
        /// 片數
        /// </summary>
        [Display("片數", ENG_: "Quantity")]
        public int Quantity { get; set; }


        /// <summary>
        /// 正面面積
        /// </summary>
        [Display("正面面積", ENG_: "W/B")]
        public long WBArea { get; set; }

        /// <summary>
        /// 背面面積
        /// </summary>
        [Display("背面面積", ENG_: "B")]
        public long BArea { get; set; }

        /// <summary>
        /// Ni 正面電流密度
        /// </summary>
        [Display("Ni 正面電流密度",ENG_: "Ni(W/B)")]
        public double Ni_WB_Adm2 { get; set; }

        /// <summary>
        /// Ni 背面電流密度
        /// </summary>
        [Display("Ni 背面電流密度", ENG_: "Ni(B)")]
        public double Ni_B_Adm2 { get; set; }

        /// <summary>
        /// Ni 電鍍時間
        /// </summary>
        [Display("Ni 電鍍時間", ENG_: "Ni PTime")]
        public int Ni_PlatingTime { get; set; }

        /// <summary>
        /// Au 正面電流密度
        /// </summary>
        [Display("Au 正面電流密度", ENG_: "Au(W/B)")]
        public double Au_WB_Adm2 { get; set; }

        /// <summary>
        /// Au 背面電流密度
        /// </summary>
        [Display("Au 背面電流密度", ENG_: "Au(B)")]
        public double Au_B_Adm2 { get; set; }

        /// <summary>
        /// Au 電鍍時間
        /// </summary>
        [Display("Au 電鍍時間", ENG_: "Au PTime")]
        public int Au_PlatingTime { get; set; }

        /// <summary>
        /// AuSt 電流密度
        /// </summary>
        [Display("AuSt 電流密度", ENG_: "AuSt")]
        public double AuSt_Adm2 { get; set; }

        /// <summary>
        /// AuSt 電鍍時間
        /// </summary>
        [Display("AuSt 電鍍時間", ENG_: "AuSt PTime")]
        public int AuSt_PlatingTime { get; set; }

        /// <summary>
        /// 流程類型
        /// </summary>
        [Display("流程類型", ENG_: "PMode")]
        public string PMode { get; set; }

        /// <summary>
        /// 尺寸
        /// </summary>
        [Display("尺寸", ENG_: "Size")]
        public string Size { get; set; }

        /// <summary>
        /// 厚度
        /// </summary>
        [Display("厚度", ENG_: "Thickness")]
        public int Thickness { get; set; }
    }
}

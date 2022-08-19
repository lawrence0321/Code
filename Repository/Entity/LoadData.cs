using Common.Interface;
using Repository.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entity
{
    public class LoadData :IEntity
    {
        /// <summary>
        /// [PK]ID
        /// </summary>
        [Key]
        [MaxLength(36)]
        [Column(nameof(ID), Order = 1, TypeName = nameof(DataBaseDataType.CHAR))]
        public string ID { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        [Required]
        [MaxLength(100)]
        [Column(TypeName = nameof(DataBaseDataType.VARCHAR))]
        public string Code { get; set; }

        /// <summary>
        /// LogTimeTicks
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.BIGINT))]
        public long CreateTimeTicks { get; set; }

        /// <summary>
        /// LogTime
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.BIGINT))]
        public long SortTimeTicks { get; set; }

        /// <summary>
        /// LogTimeTicks
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.BIGINT))]

        public long FinishTimeTicks { get; set; }

        /// <summary>
        /// 是否正常結束
        /// </summary>
        [Column()]
        public bool IsNormalFinish { get; set; }

        /// <summary>
        /// 工號
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.LONGTEXT))]
        public string EditorID { get; set; }

        /// <summary>
        /// 系統Log
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.LONGTEXT))]
        public string SystemLog { get; set; }

        /// <summary>
        /// 創建來源
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.INT))]
        public int SourceTypeNo { get; set; }

        /// <summary>
        /// 有效值
        /// </summary>
        [Required]
        public bool Enabled { get; set; }


        /// <summary>
        ///  第一掛 是否為空掛
        /// </summary>
        [Column()]
        public bool First_IsEmpty { get; set; }

        /// <summary>
        ///  第二掛 是否為空掛
        /// </summary>
        [Column()]
        public bool Second_IsEmpty { get; set; }


        /// <summary>
        ///  第一掛 生產批號
        /// </summary>
        [MaxLength(100)]
        [Column(TypeName = nameof(DataBaseDataType.VARCHAR))]
        public string First_LotCode { get; set; }

        /// <summary>
        ///  第一掛 配方編號
        /// </summary>
        [MaxLength(100)]
        [Column(TypeName = nameof(DataBaseDataType.VARCHAR))]
        public string First_RecipeCode { get; set; }

        /// <summary>
        /// 第一掛 生產模式
        /// </summary>
        [MaxLength(100)]
        [Column(TypeName = nameof(DataBaseDataType.VARCHAR))]
        public string First_PMode { get; set; }

        /// <summary>
        /// 第一掛 生產片數
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.INT))]
        public int First_Quantity { get; set; }

        /// <summary>
        /// 第一掛 尺寸
        /// </summary>
        [MaxLength(100)]
        [Column(TypeName = nameof(DataBaseDataType.VARCHAR))]
        public string First_Size { get; set; }

        /// <summary>
        /// 第一掛 厚度
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.BIGINT))]
        public long First_Thickness { get; set; }

        /// <summary>
        /// 第一掛 正面面積
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.BIGINT))]
        public long First_WBArea { get; set; }

        /// <summary>
        /// 第一掛 背面面積
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.BIGINT))]
        public long First_BArea { get; set; }

        /// <summary>
        /// 第一掛 鎳 正面電流值
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double First_Ni_WB_Current { get; set; }

        /// <summary>
        /// 第一掛 鎳 背面電流值
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double First_Ni_B_Current { get; set; }

        /// <summary>
        /// 第一掛 鎳 作業時間
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.BIGINT))]
        public long First_Ni_PTime { get; set; }

        /// <summary>
        /// 第一掛 金 正面電流值
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double First_Au_WB_Current { get; set; }

        /// <summary>
        /// 第一掛 金 背面電流值
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double First_Au_B_Current { get; set; }

        /// <summary>
        /// 第一掛 金 作業時間
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.BIGINT))]
        public long First_Au_PTime { get; set; }

        /// <summary>
        /// 第一掛 預鍍金 電流值
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double First_AuSt_Current { get; set; }

        /// <summary>
        /// 第一掛 預鍍金 作業時間
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public long First_AuSt_PTime { get; set; }


        ///  第二掛 生產批號
        /// </summary>
        [MaxLength(100)]
        [Column(TypeName = nameof(DataBaseDataType.VARCHAR))]
        public string Second_LotCode { get; set; }

        /// <summary>
        ///  第二掛 配方編號
        /// </summary>
        [MaxLength(100)]
        [Column(TypeName = nameof(DataBaseDataType.VARCHAR))]
        public string Second_RecipeCode { get; set; }


        /// <summary>
        /// 第二掛 生產模式
        /// </summary>
        [MaxLength(100)]
        [Column(TypeName = nameof(DataBaseDataType.VARCHAR))]
        public string Second_PMode { get; set; }

        /// <summary>
        /// 第二掛 生產片數
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.INT))]
        public int Second_Quantity { get; set; }

        /// <summary>
        /// 第二掛 尺寸
        /// </summary>
        [MaxLength(100)]
        [Column(TypeName = nameof(DataBaseDataType.VARCHAR))]
        public string Second_Size { get; set; }

        /// <summary>
        /// 第二掛 厚度
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.BIGINT))]
        public long Second_Thickness { get; set; }

        /// <summary>
        /// 第二掛 正面面積
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.BIGINT))]
        public long Second_WBArea { get; set; }

        /// <summary>
        /// 第二掛 背面面積
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.BIGINT))]
        public long Second_BArea { get; set; }

        /// <summary>
        /// 第二掛 鎳 正面電流值
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Second_Ni_WB_Current { get; set; }

        /// <summary>
        /// 第二掛 鎳 背面電流值
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Second_Ni_B_Current { get; set; }

        /// <summary>
        /// 第二掛 鎳 作業時間
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public long Second_Ni_PTime { get; set; }

        /// <summary>
        /// 第二掛 金 正面電流值
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Second_Au_WB_Current { get; set; }

        /// <summary>
        /// 第二掛 金 背面電流值
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Second_Au_B_Current { get; set; }

        /// <summary>
        /// 第二掛 金 作業時間
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public long Second_Au_PTime { get; set; }

        /// <summary>
        /// 第二掛 預鍍金 電流值
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Second_AuSt_Current { get; set; }
            
        /// <summary>
        /// 第二掛 預鍍金 作業時間
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public long Second_AuSt_PTime { get; set; }
    }
}

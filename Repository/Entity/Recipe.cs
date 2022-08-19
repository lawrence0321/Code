using Common.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Repository.Enums;
using System;

namespace Repository.Entity
{ 
    /// <summary>
    /// 生產配方資訊
    /// </summary>
    [Table(nameof(Recipe))]
    public class Recipe : IEntity
    {
        /// <summary>
        /// [PK]ID
        /// </summary>
        [Key]
        [MaxLength(36)]
        [Column(nameof(ID), Order = 1, TypeName = nameof(DataBaseDataType.CHAR))]
        public string ID { get; set; }

        /// <summary>
        /// [FK]操作者
        /// </summary>
        [Required]
        [MaxLength(100)]
        [Column(nameof(EditorID), TypeName = nameof(DataBaseDataType.CHAR))]
        public string EditorID { get; set; }

        /// <summary>
        /// 有效值 
        /// </summary>
        [Required]
        [Column(nameof(Enabeld))]
        public bool Enabeld { get; set; }

        /// <summary>
        /// 創建時間
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.BIGINT))]
        public long CreateTimeTicks { get; set; }

        /// <summary>
        /// 料號碼
        /// </summary>
        [Required]
        [MaxLength(100)]
        [Column(TypeName = nameof(DataBaseDataType.VARCHAR))]
        public string DisplayCode { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.LONGTEXT))]
        public string Remarks { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.LONGTEXT))]
        public string SystemLog { get; set; }

        /// <summary>
        /// 料號碼
        /// </summary>
        [Required]
        [MaxLength(100)]
        [Column(TypeName = nameof(DataBaseDataType.VARCHAR))]
        public string PanelCode { get; set; }

        /// <summary>
        /// 預設數量
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.INT))]
        public int Quantity { get; set; }

        /// <summary>
        /// 流程類型
        /// </summary>
        [Required]
        [MaxLength(3)]
        [Column(TypeName = nameof(DataBaseDataType.VARCHAR))]
        public string PMode { get; set; }

        /// <summary>
        /// 尺寸
        /// </summary>
        [Required]
        [MaxLength(10)]
        [Column(TypeName = nameof(DataBaseDataType.VARCHAR))]
        public string Size { get; set; }

        /// <summary>
        /// 厚度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.INT))]
        public int Thickness { get; set; }

        /// <summary>
        /// 正面面積
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.BIGINT))]
        public long WBArea { get; set; }

        /// <summary>
        /// 背面面積
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.BIGINT))]
        public long BArea { get; set; }

        /// <summary>
        /// Ni 正面電流密度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_WB_Adm2 { get; set; }

        /// <summary>
        /// Ni 背面電流密度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_B_Adm2 { get; set; }

        /// <summary>
        /// Ni 電鍍時間
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.INT))]
        public int Ni_PlatingTime { get; set; }

        /// <summary>
        /// Au 正面電流密度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_WB_Adm2 { get; set; }

        /// <summary>
        /// Au 背面電流密度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_B_Adm2 { get; set; }

        /// <summary>
        /// Au 電鍍時間
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.INT))]
        public int Au_PlatingTime { get; set; }

        /// <summary>
        /// AuSt 電流密度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double AuSt_Adm2 { get; set; }

        /// <summary>
        /// Au 電鍍時間
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.INT))]
        public int AuSt_PlatingTime { get; set; }
    }
}
using Common.Interface;
using Repository.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entity
{
    [Table(nameof(UnLoadDataLog))]
    public class UnLoadDataLog :IEntity
    {
        /// <summary>
        /// [PK]rowid
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(nameof(Rowid), Order = 1, TypeName = nameof(DataBaseDataType.BIGINT))]
        public long Rowid { get; set; }


        /// <summary>
        /// 掛架編號
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.LONGTEXT))]
        public string Code { get; set; }

        /// <summary>
        /// 掛架編號
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.LONGTEXT))]
        public string ShelfCode { get; set; }

        /// <summary>
        /// LogTime
        /// </summary>
        //[Required]`
        [Column(TypeName = nameof(DataBaseDataType.BIGINT))]
        public long LogTimeTicks { get; set; }

        /// <summary>
        /// 入料時間(字串)
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.LONGTEXT))]
        public string LoadTimeString { get; set; }

        /// <summary>
        /// 出料時間(字串)
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.LONGTEXT))]
        public string UpLoadTimeString { get; set; }


        /// <summary>
        /// 生產批次號
        /// </summary>
        //[Required]
        [MaxLength(100)]
        [Column(nameof(LotNo), TypeName = nameof(DataBaseDataType.VARCHAR))]
        public string LotNo { get; set; }

        /// <summary>
        /// 料號碼
        /// </summary>
        //[Required]
        [MaxLength(100)]
        [Column(TypeName = nameof(DataBaseDataType.VARCHAR))]
        public string PanelCode { get; set; }

        /// <summary>
        /// 片數
        /// </summary>
        //[Required]
        [Column(TypeName = nameof(DataBaseDataType.INT))]
        public int Quantity { get; set; }

        /// <summary>
        /// 流程類型
        /// </summary>
        //[Required]
        [MaxLength(30)]
        [Column(TypeName = nameof(DataBaseDataType.VARCHAR))]
        public string PMode { get; set; }

        /// <summary>
        /// Ni 背面設定的電流值
        /// </summary>
        //[Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_B_SetECurrent { get; set; }

        /// <summary>
        /// Ni 正面設定的電流值
        /// </summary>
        //[Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_WB_SetECurrent { get; set; }

        /// <summary>
        /// Ni 設定的電鍍時間
        /// </summary>
        //[Required]
        [Column(TypeName = nameof(DataBaseDataType.INT))]
        public int Ni_SetPlatingTime { get; set; }

        /// <summary>
        /// Au 背面設定的電流值
        /// </summary>
        //[Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_B_SetECurrent { get; set; }

        /// <summary>
        /// Au 正面設定的電流值
        /// </summary>
        //[Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_WB_SetECurrent { get; set; }

        /// <summary>
        /// Au 設定的電鍍時間
        /// </summary>
        //[Required]
        [Column(TypeName = nameof(DataBaseDataType.INT))]
        public int Au_SetPlatingTime { get; set; }


        /// <summary>
        /// AuSt 正面設定的電流值
        /// </summary>
        //[Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double AuSt_SetECurrent { get; set; }

        /// <summary>
        /// Au 電鍍時間
        /// </summary>
        //[Required]
        [Column(TypeName = nameof(DataBaseDataType.INT))]
        public int AuSt_SetPlatingTime { get; set; }


        /// <summary>
        /// Ni 背面實際的電流值
        /// </summary>
        //[Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_B_AveECurrent { get; set; }

        /// <summary>
        /// Ni 正面實際的電流值
        /// </summary>
        //[Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_WB_AveECurrent { get; set; }

        /// <summary>
        /// Ni 正面實際的伏特值
        /// </summary>
        //[Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_WB_AveVoltage { get; set; }

        /// <summary>
        /// Ni 背面實際的伏特值
        /// </summary>
        //[Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_B_AveVoltage { get; set; }

        /// <summary>
        /// Mi 溫度
        /// </summary>
        //[Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_Temp { get; set; }

        /// <summary>
        /// Ni 背面發生錯誤電流值
        /// </summary>
        //[Required]
        [Column(nameof(Ni_B_Err_A))]
        public bool Ni_B_Err_A { get; set; }

        /// <summary>
        /// Ni 背面發生錯誤伏特值
        /// </summary>
        //[Required]
        [Column(nameof(Ni_B_Err_V))]
        public bool Ni_B_Err_V { get; set; }

        /// <summary>
        /// Ni 背面發生錯誤溫度
        /// </summary>
        //[Required]
        [Column(nameof(Ni_B_Err_T))]
        public bool Ni_B_Err_T { get; set; }

        /// <summary>
        /// Ni 正面發生錯誤電流值
        /// </summary>
        //[Required]
        [Column(nameof(Ni_WB_Err_A))]
        public bool Ni_WB_Err_A { get; set; }

        /// <summary>
        /// Ni 正面發生錯誤伏特值
        /// </summary>
        //[Required]
        [Column(nameof(Ni_WB_Err_V))]
        public bool Ni_WB_Err_V { get; set; }

        /// <summary>
        /// Ni 正面發生錯誤溫度值
        /// </summary>
        //[Required]
        [Column(nameof(Ni_WB_Err_T))]
        public bool Ni_WB_Err_T { get; set; }

        /// <summary>
        /// Ni_???
        /// </summary>
        //[Required]
        [MaxLength(100)]
        [Column(TypeName = nameof(DataBaseDataType.VARCHAR))]
        public string Ni_StageNo { get; set; }

        /// <summary>
        /// Ni_???
        /// </summary>
        //[Required]
        [Column(TypeName = nameof(DataBaseDataType.INT))]
        public int Ni_DipTime { get; set; }


        /// <summary>
        /// AuSt 實際的電流值
        /// </summary>
        //[Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double AuSt_AveECurrent { get; set; }

        /// <summary>
        /// AuSt 實際的伏特值
        /// </summary>
        //[Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double AuSt_AveVoltage { get; set; }


        /// <summary>
        /// AuSt 溫度
        /// </summary>
        //[Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double AuSt_Temp { get; set; }
        /// <summary>
        /// AuSt 發生錯誤電流值
        /// </summary>
        //[Required]
        [Column(nameof(AuSt_Err_A))]
        public bool AuSt_Err_A { get; set; }

        /// <summary>
        /// AuSt 發生錯誤伏特值
        /// </summary>
        //[Required]
        [Column(nameof(AuSt_Err_V))]
        public bool AuSt_Err_V { get; set; }

        /// <summary>
        /// AuSt 發生錯誤溫度值
        /// </summary>
        //[Required]
        [Column(nameof(AuSt_Err_T))]
        public bool AuSt_Err_T { get; set; }

        /// <summary>
        /// AuSt_???
        /// </summary>
        //[Required]
        [Column(TypeName = nameof(DataBaseDataType.INT))]
        public int AuSt_DipTime { get; set; }

        /// <summary>
        /// Au 背面實際的電流值
        /// </summary>
        //[Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_B_AveECurrent { get; set; }

        /// <summary>
        /// Au 正面實際的電流值
        /// </summary>
        //[Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_WB_AveECurrent { get; set; }

        /// <summary>
        /// Au 正面實際的伏特值
        /// </summary>
        //[Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_WB_AveVoltage { get; set; }

        /// <summary>
        /// Au 背面實際的伏特值
        /// </summary>
        //[Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_B_AveVoltage { get; set; }

        /// <summary>
        /// Mi 溫度
        /// </summary>
        //[Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_Temp { get; set; }

        /// <summary>
        /// Au 背面發生錯誤電流值
        /// </summary>
        //[Required]
        [Column(nameof(Au_B_Err_A))]
        public bool Au_B_Err_A { get; set; }

        /// <summary>
        /// Au 背面發生錯誤伏特值
        /// </summary>
        //[Required]
        [Column(nameof(Au_B_Err_V))]
        public bool Au_B_Err_V { get; set; }

        /// <summary>
        /// Au 背面發生錯誤溫度
        /// </summary>
        //[Required]
        [Column(nameof(Au_B_Err_T))]
        public bool Au_B_Err_T { get; set; }

        /// <summary>
        /// Au 正面發生錯誤電流值
        /// </summary>
        //[Required]
        [Column(nameof(Au_WB_Err_A))]
        public bool Au_WB_Err_A { get; set; }

        /// <summary>
        /// Au 正面發生錯誤伏特值
        /// </summary>
        //[Required]
        [Column(nameof(Au_WB_Err_V))]
        public bool Au_WB_Err_V { get; set; }

        /// <summary>
        /// Au 正面發生錯誤溫度值
        /// </summary>
        //[Required]
        [Column(nameof(Au_WB_Err_T))]
        public bool Au_WB_Err_T { get; set; }

        /// <summary>
        /// Au_???
        /// </summary>
        //[Required]
        [MaxLength(100)]
        [Column(TypeName = nameof(DataBaseDataType.VARCHAR))]
        public string Au_StageNo { get; set; }

        /// <summary>
        /// Au_???
        /// </summary>
        //[Required]
        [Column(TypeName = nameof(DataBaseDataType.INT))]
        public int Au_DipTime { get; set; }

        //[Required]
        [MaxLength(100)]
        [Column(TypeName = nameof(DataBaseDataType.VARCHAR))]
        public string RealProcess { get; set; }


    }
}

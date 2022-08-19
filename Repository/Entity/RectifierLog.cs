using Common.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Repository.Enums;
using System;
using Common.Extension;

namespace Repository.Entity
{
    /// <summary>
    /// 整流器紀錄
    /// </summary>
    [Table(nameof(RectifierLog))]
    public class RectifierLog : IEntity
    {
        /// <summary>IExRectifierLog
        /// [PK]rowid
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(nameof(Rowid), Order = 1, TypeName = nameof(DataBaseDataType.BIGINT))]
        public long Rowid { get; set; }

        /// <summary>
        /// LogTime
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.BIGINT))]
        public long LogTimeTicks { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_01_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_01_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_01_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_02_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_02_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_02_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_03_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_03_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_03_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_04_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_04_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_04_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_05_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_05_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_05_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_06_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_06_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_06_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_07_FbA { get; set; }

        public double Ni_07_FbV { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_07_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_08_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_08_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_08_SetA { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_09_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_09_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_09_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_10_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_10_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_10_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_11_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_11_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_11_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_12_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_12_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_12_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_13_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_13_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_13_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_14_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_14_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_14_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_15_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_15_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_15_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_16_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_16_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_16_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_17_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_17_FbV { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_17_SetA { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_18_FbA { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_18_FbV { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_18_SetA { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_19_FbA { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_19_FbV { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_19_SetA { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_20_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_20_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_20_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_21_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_21_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_21_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_22_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_22_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_22_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_23_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_23_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_23_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_24_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_24_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_24_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_25_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_25_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_25_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_26_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_26_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_26_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_27_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_27_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_27_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_28_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_28_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_28_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_29_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_29_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_29_SetA { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_30_FbA { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_30_FbV { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_30_SetA { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_31_FbA { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_31_FbV { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_31_SetA { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_32_FbA { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_32_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_32_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_33_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_33_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_33_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_34_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_34_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_34_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_35_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_35_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_35_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_36_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_36_FbV { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_36_SetA { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_37_FbA { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_37_FbV { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_37_SetA { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_38_FbA { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_38_FbV { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_38_SetA { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_39_FbA { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_39_FbV { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_39_SetA { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_40_FbA { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_40_FbV { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_40_SetA { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_41_FbA { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_41_FbV { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_41_SetA { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]

        public double Ni_42_FbA { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_42_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_42_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_43_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_43_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_43_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_44_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_44_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_44_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_45_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_45_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_45_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_46_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_46_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_46_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_47_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_47_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_47_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_48_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_48_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Ni_48_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double AuSt_01_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double AuSt_01_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double AuSt_01_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double AuSt_02_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double AuSt_02_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double AuSt_02_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_01_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_01_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_01_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_02_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_02_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_02_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_03_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_03_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_03_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_04_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_04_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_04_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_05_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_05_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_05_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_06_FbA { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_06_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_06_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_07_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_07_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_07_SetA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_08_FbA { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_08_FbV { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_08_SetA { get; set; }    
    }


}

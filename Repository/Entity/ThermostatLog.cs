using Common.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Repository.Enums;
using System;
using Common.Extension;

namespace Repository.Entity
{
    /// <summary>
    /// 溫控器紀錄
    /// </summary>
    [Table(nameof(ThermostatLog))]
    public class ThermostatLog : IEntity
    {
        /// <summary>
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


        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC01 { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC02 { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC03 { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC04 { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC05 { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC06 { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC07 { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC08 { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC09 { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC10 { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC11 { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC12 { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC13 { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC14 { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC15 { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC16 { get; set; }


        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC01_Set { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC02_Set { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC03_Set { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC04_Set { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC05_Set { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC06_Set { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC07_Set { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC08_Set { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC09_Set { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC10_Set { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC11_Set { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC12_Set { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC13_Set { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC14_Set { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC15_Set { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC16_Set { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC01_UpLw { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC02_UpLw { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC03_UpLw { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC04_UpLw { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC05_UpLw { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC06_UpLw { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC07_UpLw { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC08_UpLw { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC09_UpLw { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC10_UpLw { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC11_UpLw { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC12_UpLw { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC13_UpLw { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC14_UpLw { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC15_UpLw { get; set; }

        /// <summary>
        /// 目前溫度
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double TC16_UpLw { get; set; }

    }

}

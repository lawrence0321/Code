using Common.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Repository.Enums;
using System;


namespace Repository.Entity
{
    [Table(nameof(Modbus32Log))]

    public class Modbus32Log:IEntity
    {
        /// <summary>
        /// [PK]rowid
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(nameof(Rowid), Order = 1, TypeName = nameof(DataBaseDataType.BIGINT))]
        public long Rowid { get; set; }
        /// <summary>
        /// LogTimeTicks
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.BIGINT))]
        public long LogTimeTicks { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_1 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_2 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Au_Strike { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel3_1 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel3_2 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel3_3 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel3_Air_1 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel3_Air_2 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel3_Air_3 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel3_Air_4 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel3_Air_5 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel3_Air_6 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel4_1 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel4_2 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel4_3 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel4_Air_1 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel4_Air_2 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel4_Air_3 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel4_Air_4 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel4_Air_5 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel4_Air_6 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Water10 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Water6 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Water7 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Water8 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Water9 { get; set; }
    }
}
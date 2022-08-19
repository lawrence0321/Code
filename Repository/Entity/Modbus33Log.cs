using Common.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Repository.Enums;
using System;

namespace Repository.Entity
{
    [Table(nameof(Modbus33Log))]
    public class Modbus33Log :IEntity
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
        public double Rinse_EC { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Rinse_Flow1 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Rinse_Flow2 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Rinse_Flow3 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Rinse_Flow4 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Rinse1 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Rinse10 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Rinse11 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Rinse12 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Rinse13 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Rinse2 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Rinse3 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Rinse4 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Rinse5 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Rinse6 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Rinse7 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Rinse8 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Rinse9 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Water11 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Water12 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Water13 { get; set; }
    }

}

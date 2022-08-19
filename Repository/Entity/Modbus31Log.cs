using Common.Interface;
using Repository.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Repository.Entity
{
    [Table(nameof(Modbus31Log))]
    public class Modbus31Log:IEntity
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
        public double ACID1 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Blower { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Clean { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Microerching { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel1_1 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel1_2 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel1_3 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel1_Air_1 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel1_Air_2 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel1_Air_3 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel1_Air_4 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel1_Air_5 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel1_Air_6 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel2_1 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel2_2 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel2_3 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel2_Air_1 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel2_Air_2 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel2_Air_3 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel2_Air_4 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel2_Air_5 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Nickel2_Air_6 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Water1 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Water2 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Water3 { get; set; }
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Water4 { get; set; }
    }

}

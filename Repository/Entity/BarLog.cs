using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Interface;
using Repository.Enums;

namespace Repository.Entity
{
    /// <summary>
    /// 整流器紀錄
    /// </summary>
    [Table(nameof(BarLog))]
    public class BarLog : IEntity
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
        /// SlotCode
        /// </summary>
        [Required]
        [MaxLength(10)]
        [Column(TypeName = nameof(DataBaseDataType.CHAR))]
        public string SlotCode { get; set; }

        /// <summary>
        /// BarCode
        /// </summary>
        [Required]
        [MaxLength(10)]
        [Column(TypeName = nameof(DataBaseDataType.CHAR))]
        public string BarCode { get; set; }
    }

}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Interface;
using Repository.Enums;

namespace Repository.Entity
{
    /// <summary>
    /// 整流器紀錄
    /// </summary>
    [Table(nameof(AlarmLog))]
    public class AlarmLog : IEntity
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
        /// LogTime
        /// </summary>
        [Column(TypeName = nameof(DataBaseDataType.BIGINT))]
        public long FinishTimeTicks { get; set; }

        /// <summary>
        /// [FK]AlarmNo
        /// </summary>
        [Required]
        [ForeignKey(nameof(AlarmObj))]
        [Column(TypeName = nameof(DataBaseDataType.INT))]
        public int AlarmNo { get; set; }
        public virtual Alarm AlarmObj { get; set; }
    }
}

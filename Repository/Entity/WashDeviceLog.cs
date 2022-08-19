using Common.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Repository.Enums;
using System;

namespace Repository.Entity
{
    [Table(nameof(WashDeviceLog))]
    public class WashDeviceLog : IEntity
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
        public double Speed { get; set; }

        [Required]
        [Column(TypeName = nameof(DataBaseDataType.DOUBLE))]
        public double Temperature { get; set; }
    }

}

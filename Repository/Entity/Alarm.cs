using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Interface;
using Repository.Enums;

namespace Repository.Entity
{
    /// <summary>
    /// Alarm類型
    /// </summary>
    [Table(nameof(Alarm))]
    public class Alarm : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 1, TypeName = nameof(DataBaseDataType.INT))]
        public int No { get; set; }

        /// <summary>
        /// ThermostatName
        /// </Name>
        [Required]
        [MaxLength(100)]
        [Column(TypeName = nameof(DataBaseDataType.VARCHAR))]
        public string Name { get; set; }

        /// <summary>
        /// ThermostatName
        /// </Name>
        [Required]
        [MaxLength(100)]
        [Column(TypeName = nameof(DataBaseDataType.VARCHAR))]
        public string ChiName { get; set; }
    }


    
}

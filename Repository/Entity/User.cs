using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Interface;
using Repository.Enums;

namespace Repository.Entity
{
    /// <summary>
    /// WhiteList
    /// </summary>
    [Table(nameof(User))]
    public class User : IEntity
    {
        [Key]
        [MaxLength(100)]
        [Column(Order = 1, TypeName = nameof(DataBaseDataType.CHAR))]
        public string ID { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(TypeName = nameof(DataBaseDataType.VARCHAR))]
        public string Password { get; set; }

        /// <summary>
        /// LogTimeTicks
        /// </summary>
        [Required]
        [Column(TypeName = nameof(DataBaseDataType.BIGINT))]
        public long LogTimeTicks { get; set; }
    }


    
}

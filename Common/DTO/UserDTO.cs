using Common.Interface;

namespace Common.DTO
{
    /// <summary>
    /// WhiteList
    /// </summary>

    public class UserDTO : IDTO
    {

        public string ID { get; set; }

        public string Password { get; set; }

        public long LogTimeTicks { get; set; }
    }
}

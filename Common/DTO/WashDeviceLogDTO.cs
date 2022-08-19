using Common.Extension;
using Common.Interface;
using System;

namespace Common.DTO
{
    public class WashDeviceLogDTO : IDTO
    {
        public long Rowid { get; set; }

        public long LogTimeTicks { get; set; }
        public DateTime LogDateTime => new DateTime(LogTimeTicks);

        public string LogDateTimeString => LogDateTime.GetString();

        public double Speed { get; set; }

        public double Temperature { get; set; }
    }

}

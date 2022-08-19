using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Device.Enums
{
    [Flags]
    public enum PCStatuses : UInt16
    {
        none                = 0x0000,
        Empty000            = 0x0001,
        Empty001            = 0x0002,
        Empty002            = 0x0004,
        Empty003            = 0x0008,
        ReplyAskLoadData    = 0x0010,
        ReplyProduce        = 0x0020,
        Empty006            = 0x0040,
        Empty007            = 0x0080,
        ReplyUnLoad         = 0x0100,
        Empty009            = 0x0200,
        Empty010            = 0x0400,
        Empty011            = 0x0800,
        BackupUnloading     = 0x1000,
        BackupUnloadFinish  = 0x2000,
        Empty014            = 0x4000,
        Empty015            = 0x8000,
    }
}

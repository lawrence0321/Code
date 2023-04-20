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
        Empty000            = 0x0001,//0
        Empty001            = 0x0002,//1
        Empty002            = 0x0004,//2
        Empty003            = 0x0008,//3
        ReplyAskLoadData    = 0x0010,//4
        ReplyProduce        = 0x0020,//5
        Empty006            = 0x0040,//6
        Empty007            = 0x0080,//7
        ReplyUnLoad         = 0x0100,//8
        Empty009            = 0x0200,//9
        Empty010            = 0x0400,//A
        LoadDataTimeAlarm   = 0x0800,//B
        BackupUnloading     = 0x1000,//C
        BackupUnloadFinish  = 0x2000,//D
        ChangeLotNotify     = 0x4000,//E
        DataCountError      = 0x8000,//F
    }
}

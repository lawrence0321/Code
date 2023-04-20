using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum ExceptionTypes
    {
        [Description("無")]
        none = 0X000000,
        /// <summary>
        /// 無此ID
        /// </summary>
        [Description("輸入內容-無此ID")]
        UnKnown = 0x001001,
        /// <summary>
        /// 重複ID
        /// </summary>
        [Description("輸入內容-重複ID")]
        Duplicate = 0x001002,
        /// <summary>
        /// 尚有空內容
        /// </summary>
        [Description("輸入內容-尚有空內容")]
        EmptyContent = 0x002001,
        /// <summary>
        /// 無此紀錄
        /// </summary>
        [Description("庫存邏輯-無此紀錄")]
        NoRecorded = 0x003001,
        /// <summary>
        /// 負數數量
        /// </summary>
        [Description("庫存邏輯-負數數量")]
        IncorrectAmount = 0x003002,
        /// <summary>
        /// 數量不足
        /// </summary>
        [Description("庫存邏輯-數量不足")]
        InsufficientAmount = 0x003003,
        /// <summary>
        /// 程式錯誤
        /// </summary>
        [Description("PLC通訊-傳送指令失敗")]
        FailSendCommand = 0x004001,
        /// <summary>
        /// 程式錯誤
        /// </summary>
        [Description("PLC通訊-傳送指令錯誤")]
        WrongCommand = 0x004002,
        /// <summary>
        /// 登入錯誤
        /// </summary>
        [Description("使用者相關-登入錯誤")]
        ConfirmError = 0x005001,
        /// <summary>
        /// 登入錯誤
        /// </summary>
        [Description("使用者相關-其他錯誤")]
        UserOtherError = 0x005002,
        /// <summary>
        /// 登入錯誤
        /// </summary>
        [Description("任務相關-無新任務")]
        UnHaveNewTask = 0x006001,
        /// <summary>
        /// MES相關-Type01-沒有該筆Recipe內容
        /// </summary>
        [Description("MES相關-沒有該筆Recipe內容")]
        EmptyRecipe = 0x007001,
        /// <summary>
        /// MES相關-Type02-此批未上機
        /// </summary>
        [Description("MES相關-此批未上機")]
        LotNotOnline = 0x007002,
        /// <summary>
        /// MES相關-Type03-無此無塵衣ID紀錄
        /// </summary>
        [Description("MES相關-無此無塵衣ID紀錄")]
        WrongUserID = 0x007003,
        /// <summary>
        /// MES相關-Type04-發生錯誤回報
        /// </summary>
        [Description("MES相關-發生錯誤回報")]
        ErrorMsg = 0x007004,
        /// <summary>
        /// 程式錯誤
        /// </summary>
        [Description("程式錯誤")]
        ProgramError = 0xFFF001,
    }
}

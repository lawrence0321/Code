using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Enums
{
    internal enum DataBaseDataType
    {
        /// <summary>
        /// 整數
        /// </summary>
        INT ,
        /// <summary>
        /// 長整數
        /// </summary>
        BIGINT,
        /// <summary>
        /// 8Int 常用於儲存布林值
        /// </summary>
        TINYINT,
        /// <summary>
        /// 字元
        /// </summary>
        CHAR,
        /// <summary>
        /// 動態長度字元
        /// </summary>
        VARCHAR,
        /// <summary>
        /// 長字串
        /// </summary>
        LONGTEXT,
        /// <summary>
        /// 雙精倍數
        /// </summary>
        DOUBLE,
    }
}

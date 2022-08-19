using Common.DTO;
using System;

namespace Common.Extension
{

    public static class ExtensionNumber
    {
        public static double ExRound(this double Value, int Index)
            => Math.Truncate(Value * Math.Pow(10, Index) + 0.5) / Math.Pow(10, Index);

        /// <summary>
        /// 秒數轉換成時間字串
        /// <para></para>
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Index"></param>
        /// <returns></returns>
        public static string ToTimeString(this UInt64 Secend_)
        {
            var sec = Secend_ % 60;
            var min = Secend_  / 60 % 60;
            var hour = Secend_ / 60 / 60;
            return String.Format("{0:00}:{1:00}:{2:00}",hour,min,sec);
        }
    }

}

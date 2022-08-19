using System;

namespace Common.Extension
{
    public static class ExtensionDateTime
    {
        public enum OutputTypes
        {
            /// <summary>
            ///  yyyy-MM-dd HH:mm:ss
            /// </summary>
            TypeA,
            /// <summary>
            ///  yyyyMMddHHmmss
            /// </summary>
            TypeB,
            /// <summary>
            ///  HHmmss
            /// </summary>
            TypeC,
        }

        /// <summary>
        /// 預設輸出格式 : yyyy-MM-dd HH:mm:ss
        /// </summary>
        public static string GetString(this DateTime DT_, OutputTypes OutputType_ = OutputTypes.TypeA)
        {
            switch (OutputType_)
            {
                case OutputTypes.TypeA:
                    return DT_.ToString("yyyy-MM-dd HH:mm:ss");
                case OutputTypes.TypeB:
                    return DT_.ToString("yyyyMMddHHmmss");
                case OutputTypes.TypeC:
                    return DT_.ToString("HH:mm:ss");
                default:
                    throw new Exception("Not Support this Type.");
            }
        }
    }

}

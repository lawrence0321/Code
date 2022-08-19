using Common.Attributes;
using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Common.Extension
{
    public class EnumValue
    {
        public int Value { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public EnumValue(int Value_, string Name_, string Description_ = "")
        {
            this.Value = Value_;
            this.Name = Name_;
            this.Description = Description_;

            
        }
    }

    public static class ExtensionEnum
    {
        /// <summary>
        /// 取得 Enum 列舉 Attribute Description 設定值
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string GetDescription<T>(this T source) where T : System.Enum
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
             typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
                return attributes[0].Description;
            else
                return source.ToString();
        }

        /// <summary>
        /// 取得 Enum 列舉 AlarmInfoAttribute 設定值
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static AlarmInfoAttribute GetInfo<T>(this T source) where T : System.Enum
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());
            AlarmInfoAttribute[] attributes = (AlarmInfoAttribute[])fi.GetCustomAttributes(
             typeof(AlarmInfoAttribute), false);
            if (attributes.Length > 0)
                return attributes[0];
            else
                return null;
        }

        /// <summary>
        /// 取得 Enum 列舉 AlarmInfoAttribute 設定值
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DisplayAttribute GetDisplay<T>(this T source) where T : System.Enum
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());
            DisplayAttribute[] attributes = (DisplayAttribute[])fi.GetCustomAttributes(
             typeof(DisplayAttribute), false);
            if (attributes.Length > 0)
                return attributes[0];
            else
                return new DisplayAttribute() ;
        }

        /// <summary>
        /// 取得 Enum 內容資訊
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<EnumValue> GetEnumValues<T>() where T : System.Enum
        => System.Enum.GetValues(typeof(T)).Cast<T>().ToList<T>()
            .Select(
                p => new EnumValue(Convert.ToInt32(p), p.ToString(), p.GetDescription<T>())
            )
            .ToList();

        public static IEnumerable<System.Enum> GetFlags(this System.Enum e)
            => System.Enum.GetValues(e.GetType()).Cast<System.Enum>().Where(e.HasFlag);

        public static bool ContainsKey(this System.Enum e, System.Enum Key)
            => e.GetFlags().Contains(Key);

    }
}

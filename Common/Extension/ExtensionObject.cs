using Common.Attributes;
using Common.Interface;
using Newtonsoft.Json;
using System;
using System.Reflection;

namespace Common.Extension
{
    public static class ExtensionObject
    {
        public static string ToJson<T>(this T Object_)
        {
            try
            {
                return JsonConvert.SerializeObject(Object_);
            }
            catch
            {
                return "轉換Json失敗";
            }
        }
    }

}

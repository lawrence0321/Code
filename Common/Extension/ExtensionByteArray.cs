using System;
using System.Linq;

namespace Common.Extension
{
    public static class ExtensionByteArray
    {
        public static string ToBitString(this byte[] Values_)
        {
            var list = Values_.ToList();
            list.Reverse();
            var str = String.Empty;
            foreach (var value in list)
                str += (Convert.ToInt32(value) != 0) ? Convert.ToString(value, 2).PadLeft(8, '0') : new string('0', 8);
            return str;
        }

    }

}

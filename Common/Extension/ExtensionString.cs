using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Common.Extension
{
    public static class ExtensionString
    {
        private const string DefaultKey = "Raden23277176";

        public static string GetSHA256(this string Message_, string Key_)
        {
            var encoding = new System.Text.UTF8Encoding();
            byte[] keyByte = encoding.GetBytes(Key_);
            byte[] messageBytes = encoding.GetBytes(Message_);
            using (var hmacSHA256 = new HMACSHA256(keyByte))
            {
                byte[] hashMessage = hmacSHA256.ComputeHash(messageBytes);
                return BitConverter.ToString(hashMessage).Replace("-", "").ToUpper();
            }
        }

        public static string GetSHA256(this string Message_)
            => GetSHA256(Message_, DefaultKey);

        public static bool IsEmpty(this string Message_)
            => Message_.Replace(" ","").Replace("　","") == String.Empty;



        public static string[] Split(this string Value_, int Length_)
        {
            if (Value_.Length < Length_)
                throw new Exception("Value's Length is shorter then Length_.");

            var maxlength = Convert.ToInt32(Math.Ceiling((double)Value_.Length / Length_));
            var values = new String[maxlength];

            for (int index = 0; index < maxlength; index++)
                values[index] = Value_.Substring(index * Length_, Length_);

            return values;
        }


        public static string OffsetBit(this string bitString_, int Digit_)
        {
            if (bitString_.Length < Digit_)
                throw new Exception("bitString is too short.");
            if (Digit_ < 0)
                throw new Exception("StartIndex is negative or zero.");

            var newstring = bitString_.Substring(0, bitString_.Length - Digit_);
            newstring = newstring.PadLeft(bitString_.Length, '0');

            return newstring;
        }

        public static byte[] GetByteArray(this IEnumerable<string> Strings_)
        {
            var list = new List<byte>();

            foreach (var str in Strings_)
                list.Add(Convert.ToByte(str, 2));

            return list.ToArray();
        }

    }

}

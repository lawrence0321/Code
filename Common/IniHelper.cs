using Common;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Common
{
    public class IniHelper
    {
        [DllImport("kernel32")]//回傳0表示失敗，非0為成功
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]//回傳取得字串緩沖區的長度
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// 讀取ini檔案
        /// </summary>
        /// <param name="Section">名稱</param>
        /// <param name="Key">關鍵字</param>
        /// <param name="defaultText">默認值</param>
        /// <param name="iniFilePath">ini檔案地址</param>
        /// <returns></returns>
        public static ActResult<T> GetValue<T>(string Section, string Key, T defaultValue, string iniFilePath)
        {
            try
            {
                StringBuilder temp = new StringBuilder(1024);
                GetPrivateProfileString(Section, Key, defaultValue.ToString(), temp, 1024, iniFilePath);
                object obj;
                switch (typeof(T).Name)
                {
                    case (nameof(Double)):
                        obj = Convert.ToDouble(temp.ToString());
                        break;
                    case (nameof(String)):
                        obj = temp.ToString();
                        break;
                    case (nameof(Int32)):
                        obj = Convert.ToInt32(temp.ToString());
                        break;
                    default:
                        throw new Exception("Do not support this type.");
                }
                return new ActResult<T>((T)obj);
            }
            catch (Exception Ex)
            {
                return new ActResult<T>(Ex);
            }
        }

        /// <summary>
        /// 寫入ini檔案
        /// </summary>
        /// <param name="Section">名稱</param>
        /// <param name="Key">關鍵字</param>
        /// <param name="defaultText">默認值</param>
        /// <param name="iniFilePath">ini檔案地址</param>
        /// <returns></returns>
        public static ActResult SetValue(string Section, string Key, string Value, string iniFilePath)
        {
            try
            {
                var pat = Path.GetDirectoryName(iniFilePath);
                if (Directory.Exists(pat) == false)
                {
                    Directory.CreateDirectory(pat);
                }
                if (File.Exists(iniFilePath) == false)
                {
                    File.Create(iniFilePath).Close();
                }
                long OpStation = WritePrivateProfileString(Section, Key, Value, iniFilePath);

                if (OpStation == 0)
                    throw new Exception("Fail to set value.");
                else
                    return new ActResult(true);
            }
            catch (Exception Ex)
            {
                return new ActResult(Ex);
            }
        }
    }
}

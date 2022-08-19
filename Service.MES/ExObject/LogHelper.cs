using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.MES.ExObject
{
    public static class LogHelper
    {
        static object Token = new object();
        public static void Log(String LogMsg_)
        {
            try
            {
                lock (Token)
                {
                    string today = String.Format("{0:0000}{1:00}{2:00}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    string path = String.Format("D:\\MESLog\\{0}", today);
                    var filepath = String.Format("{0}\\MESLog.txt", path);
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    var value = String.Empty;

                    if (File.Exists(filepath))
                    {
                        //Pass the filepath and filename to the StreamWriter Constructor
                        using (StreamReader sr = new StreamReader(String.Format("{0}\\MESLog.txt", path)))
                        {
                            value += sr.ReadToEnd();
                        }
                    }

                    //Pass the filepath and filename to the StreamWriter Constructor
                    using (StreamWriter sw = new StreamWriter(String.Format("{0}\\MESLog.txt", path)))
                    {
                        value += String.Format("{0}:{1}:{2}=>{3}\r\n", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, LogMsg_);
                        sw.WriteLine(value);
                    }
                }
            }
            catch (Exception e)
            {

            }

        }
    }

}

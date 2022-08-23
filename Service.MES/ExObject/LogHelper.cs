using Common;
using Common.Extension;
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
        readonly static object Token = new object();
        readonly static string FolderPath = String.Format(@"{0}\Log\MESService\", System.Environment.CurrentDirectory);
        public static void Log(String LogMsg_)
        {
            lock (Token)
            {
                try
                {
                    List<string> datas = new List<string>();

                    DateTime nowDateTime = DateTime.Now;
                    var forlderPath = String.Format(@"{0}{1:0000}{2:00}", FolderPath, nowDateTime.Year, nowDateTime.Month, nowDateTime.Day);
                    string fileName = String.Format(@"{0}\{1:0000}{2:00}{3:00}Log.csv", forlderPath, nowDateTime.Year, nowDateTime.Month, nowDateTime.Day);

                    if (!Directory.Exists(forlderPath)) Directory.CreateDirectory(forlderPath);

                    if (!File.Exists(fileName))
                    {
                        string column = String.Format("DateTime,Message");
                        datas.Add(column);
                    }

                    string str = String.Format("{0},{1}", DateTime.Now.GetString(), LogMsg_);
                    datas.Add(str);

                    using (FileStream FileStream = new FileStream(fileName, FileMode.Append))
                    {
                        StreamWriter sw = new StreamWriter(FileStream, System.Text.Encoding.UTF8);

                        foreach (var data in datas)
                            sw.WriteLine(data);

                        //清空緩衝區
                        sw.Flush();
                        //關閉流
                        sw.Close();
                        FileStream.Close();
                    }
                }
                catch (Exception Ex)
                {
                }
            }
        }
    }

}

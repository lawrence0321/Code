using Common;
using Common.Interface;
using Service.CSV.Implement;
using Service.CSV.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CSV
{
    public static class CSVServiceFactory
    {
        internal static string BasicFolderPath = @"D:\CSVLog\";

        public static T Get<T>() where T : class, IService
        {
            object obj;

            switch (typeof(T).Name)
            {
                case nameof(ICSVAlarmLogService):
                    obj = new CSVAlarmLogService();
                    break;
                case nameof(ICSVLoadDataService):
                    obj = new CSVLoadDataService();
                    break;
                case nameof(ICSVUnLoadDataService):
                    obj = new CSVUnLoadDataService();
                    break;
                case nameof(ICSVModbus31LogService):
                    obj = new CSVModbus31LogService();
                    break;
                case nameof(ICSVModbus32LogService):
                    obj = new CSVModbus32LogService();
                    break;
                case nameof(ICSVModbus33LogService):
                    obj = new CSVModbus33LogService();
                    break;
                default:
                    throw new Exception(String.Format("Not Support {0}.", typeof(T).Name));
            }
            return (T)obj;
        }

        internal static void WriteFile(string FileName_,List<string> Datas_)
        {
            using (FileStream FileStream = new FileStream(FileName_, FileMode.Append))
            {
                StreamWriter sw = new StreamWriter(FileStream, System.Text.Encoding.UTF8);

                foreach(var data in Datas_)
                    sw.WriteLine(data);

                //清空緩衝區
                sw.Flush();
                //關閉流
                sw.Close();
                FileStream.Close();
            }
        }
    }

}

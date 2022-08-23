using Common;
using Common.Extension;
using Service.CSV.Interface;
using System;
using System.Collections.Generic;
using System.IO;


namespace Service.CSV.Implement
{
    internal class CSVExceptionService : ICSVExceptionService
    {
        readonly string FolderPath = String.Format(@"{0}\log\Exception\", System.Environment.CurrentDirectory);

        static readonly object Token = new object();

        public ActResult Log(Exception Ex_, string Source_)
            => this.Log(Ex_.Message, Source_);

        public ActResult Log(string Message_, string Source_)
        {
            lock (Token)
            {
                try
                {
                    List<string> data = new List<string>();

                    DateTime nowDateTime = DateTime.Now;
                    var forlderPath = String.Format(@"{0}{1:0000}{2:00}", FolderPath, nowDateTime.Year, nowDateTime.Month, nowDateTime.Day);
                    string fileName = String.Format(@"{0}\{1:0000}{2:00}{3:00}Log.csv", forlderPath, nowDateTime.Year, nowDateTime.Month, nowDateTime.Day);

                    if (!Directory.Exists(forlderPath)) Directory.CreateDirectory(forlderPath);

                    if (!File.Exists(fileName))
                    {
                        string column = String.Format("DateTime,Execption,Source");
                        data.Add(column);
                    }

                    string str = String.Format("{0},{1},{2}", DateTime.Now.GetString(), Message_, Source_);
                    data.Add(str);
                    CSVServiceFactory.WriteFile(fileName, data);

                    return new ActResult(true);
                }
                catch (Exception Ex)
                {
                    return new ActResult(Ex);
                }
            }
        }
    }

}

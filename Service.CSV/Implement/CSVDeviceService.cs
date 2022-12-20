using Common;
using Common.Extension;
using Service.CSV.Interface;
using System;
using System.Collections.Generic;
using System.IO;


namespace Service.CSV.Implement
{
    internal class CSVDeviceService : ICSVDeviceService
    {
        readonly string FolderPath = CSVServiceFactory.BasicFolderPath + @"DeviceLog\";

        static readonly object Token = new object();


        public ActResult Log(DeviceLogSourceTypes DeviceLogSourceType_, string MemoryAddress_, bool Value_, string Remarks_ = "")
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
                        string column = String.Format("{0},{1},{2},{3},{4}","DateTime", "Source", "MemoryAddress", "Value", "Remarks");
                        data.Add(column);
                    }
                    var value = Value_ ? "ON" : "OFF";
                    data.Add(String.Format("{0},{1,3},{2,3},{3},{4}",DateTime.Now.GetString(), DeviceLogSourceType_.ToString(), MemoryAddress_, value, Remarks_));

                    CSVServiceFactory.WriteFile(fileName, data);

                    return new ActResult(true);
                }
                catch (Exception Ex)
                {
                    return new ActResult(Ex);
                }
            }
        }

        public ActResult CatchLog(string Msg_)
        {
            lock (Token)
            {
                try
                {
                    List<string> data = new List<string>();

                    DateTime nowDateTime = DateTime.Now;
                    var forlderPath = String.Format(@"{0}{1:0000}{2:00}", FolderPath, nowDateTime.Year, nowDateTime.Month, nowDateTime.Day);
                    string fileName = String.Format(@"{0}\{1:0000}{2:00}{3:00}catchLog.csv", forlderPath, nowDateTime.Year, nowDateTime.Month, nowDateTime.Day);

                    if (!Directory.Exists(forlderPath)) Directory.CreateDirectory(forlderPath);

                    if (!File.Exists(fileName))
                    {
                        string column = String.Format("{0},{1}", "DateTime", "Msg");
                        data.Add(column);
                    }
                    data.Add(String.Format("{0},{1}", DateTime.Now.GetString(), Msg_));

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

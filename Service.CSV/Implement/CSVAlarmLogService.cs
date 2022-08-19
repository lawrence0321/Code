using Common;
using Common.Extension;
using Service.CSV.Interface;
using System;
using System.Collections.Generic;
using System.IO;

namespace Service.CSV.Implement
{
    internal class CSVAlarmLogService : ICSVAlarmLogService
    {
        readonly string FolderPath = CSVServiceFactory.BasicFolderPath + @"AlarmLog\";

        static readonly object Token = new object();
        public ActResult DisMissLog(int EnumValue)
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
                        data.Add(String.Format("Type,發生時間,AlarmCode", nowDateTime.GetString(), EnumValue));


                    data.Add(String.Format("[解除],{0},{1}", nowDateTime.GetString(), EnumValue));

                    CSVServiceFactory.WriteFile(fileName, data);

                    return new ActResult(true);
                }
                catch (Exception Ex)
                {
                    return new ActResult(Ex);
                }
            }
        }

        public ActResult HappenLog(int EnumValue)
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
                        data.Add(String.Format("Type,發生時間,AlarmCode", nowDateTime.GetString(), EnumValue));

                    data.Add(String.Format("[發生],{0},{1}", nowDateTime.GetString(), EnumValue));

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

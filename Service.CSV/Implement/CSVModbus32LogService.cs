using Common;
using Common.Attributes;
using Common.DTO;
using Service.CSV.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Service.CSV.Implement
{
    internal class CSVModbus32LogService : ICSVModbus32LogService
    {
        readonly string FolderPath = CSVServiceFactory.BasicFolderPath + @"Modbus32Log\";

        static readonly object Token = new object();

        public ActResult Log(Modbus32LogDTO Modbus32Log_)
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
                        string column = String.Empty;
                        foreach (var par in typeof(Modbus32LogDTO).GetProperties())
                        {
                            DisplayAttribute display = (DisplayAttribute)par.GetCustomAttribute(typeof(DisplayAttribute));
                            if (display.Visible)
                                column += String.Format(",{0}", display.ZHTW);
                        }
                        column = column.Substring(1);
                        data.Add(column);
                    }

                    string str = String.Empty;
                    foreach (var par in typeof(Modbus32LogDTO).GetProperties())
                    {
                        DisplayAttribute display = (DisplayAttribute)par.GetCustomAttribute(typeof(DisplayAttribute));
                        if (display.Visible)
                        {
                            try
                            {
                                str += string.Format(",{0}", par.GetValue(Modbus32Log_).ToString());
                            }
                            catch
                            {
                                str += string.Format(",{0}", "-");
                            }
                        }
                    }
                    str = str.Substring(1);

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

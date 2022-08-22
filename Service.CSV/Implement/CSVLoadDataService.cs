﻿using Common;
using Common.Attributes;
using Common.DTO;
using Common.Extension;
using Service.CSV.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;


namespace Service.CSV.Implement
{
    internal class ExceptionService : ICSVExceptionService
    {
        readonly string FolderPath = CSVServiceFactory.BasicFolderPath + @"Exception\";

        static readonly object Token = new object();

        public ActResult Log(Exception Ex_)
            => this.Log(Ex_.Message);

        public ActResult Log(string Message_)
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
                        string column = String.Format("DateTime,Execption");
                        data.Add(column);
                    }

                    string str = String.Format("{0},{1}", DateTime.Now.GetString(), Message_);
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


    internal class CSVLoadDataService : ICSVLoadDataService
    {
        readonly string FolderPath = CSVServiceFactory.BasicFolderPath + @"LoadLog\";

        static readonly object Token = new object();

        public ActResult Log(LoadDataDTO LoadData_)
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
                        foreach (var par in typeof(LoadDataDTO).GetProperties())
                        {
                            DisplayAttribute display = (DisplayAttribute)par.GetCustomAttribute(typeof(DisplayAttribute));
                            if (display.Visible)
                                column += String.Format(",{0}", display.ZHTW);
                        }
                        column = column.Substring(1);
                        data.Add(column);
                    }

                    string str = String.Empty;
                    foreach (var par in typeof(LoadDataDTO).GetProperties())
                    {
                        DisplayAttribute display = (DisplayAttribute)par.GetCustomAttribute(typeof(DisplayAttribute));
                        if (display.Visible)
                        {
                            try
                            {
                                str += string.Format(",{0}", par.GetValue(LoadData_).ToString());
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

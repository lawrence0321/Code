using Common;
using Common.Attributes;
using Common.DTO;
using Common.Enums;
using Common.Interface;
using Controller.Interface;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Controller.Implement
{
    public class ExportController : AbstractDisposable, IExportController
    {
        const int MaxColumnCount = 65000;

        public bool Enabled { get; private set; }

        ISearchController SearchController => ControllerFactory.Get<ISearchController>();

        const string BasicFolderPath = "D:\\Export";
        public ExportController()
        {
            this.Enabled = true;

            ThreadPool.QueueUserWorkItem(AutoExport);
        }

        void AutoExport(object state)
        {
            while (this.Enabled)
            {

                var yesterday = DateTime.Now.AddDays(-1);
                var yStart = new DateTime(yesterday.Year, yesterday.Month, yesterday.Day, 0, 0, 1).Ticks;
                var yEnd = new DateTime(yesterday.Year, yesterday.Month, yesterday.Day, 23, 59, 59).Ticks;

                var forlderPath = String.Format("{0}\\{1:0000}{2:00}", BasicFolderPath, yesterday.Year, yesterday.Month);
                if (!Directory.Exists(forlderPath)) Directory.CreateDirectory(forlderPath);

                var unloaddatalog = String.Format("{1:0000}{2:00}{3:00}_UnLoadDatalog_(Security C).xls", forlderPath, yesterday.Year, yesterday.Month, yesterday.Day);
                if (!File.Exists(String.Format("{0}\\{1}", forlderPath, unloaddatalog)))
                    Export<UnLoadDataLogDTO>(EmptyAction, forlderPath, unloaddatalog, yStart, yEnd,999999);

                var alarmlog = String.Format("{1:0000}{2:00}{3:00}_AlarmLog_(Security C).xls", forlderPath, yesterday.Year, yesterday.Month, yesterday.Day);
                if (!File.Exists(String.Format("{0}\\{1}", forlderPath, alarmlog)))
                    Export<AlarmLogDTO>(EmptyAction, forlderPath, alarmlog, yStart, yEnd, 999999);

                var thermostatLog = String.Format("{1:0000}{2:00}{3:00}_ThermostatLog_(Security C).xls", forlderPath, yesterday.Year, yesterday.Month, yesterday.Day);
                if (!File.Exists(String.Format("{0}\\{1}", forlderPath, thermostatLog)))
                    Export<ThermostatLogDTO>(EmptyAction, forlderPath, thermostatLog, yStart, yEnd, 999999);

                var rectifierLog = String.Format("{1:0000}{2:00}{3:00}_RectifierLog_(Security C).xls", forlderPath, yesterday.Year, yesterday.Month, yesterday.Day);
                if (!File.Exists(String.Format("{0}\\{1}", forlderPath, rectifierLog)))
                    Export<RectifierLogDTO>(EmptyAction, forlderPath, rectifierLog, yStart, yEnd, 999999);

                var loadLog = String.Format("{1:0000}{2:00}{3:00}_LoadDataLog_(Security C).xls", forlderPath, yesterday.Year, yesterday.Month, yesterday.Day);
                if (!File.Exists(String.Format("{0}\\{1}", forlderPath, loadLog)))
                    Export<LoadDataDTO>(EmptyAction, forlderPath, loadLog, yStart, yEnd, 999999);

                // 1天檢查一次
                Thread.Sleep(1000 * 60 * 30);
            }
        }

        void EmptyAction(ActResult ActResult_){}

        public void Export<T>(ExportAction ExportAction_, string ForlderPath_, string FileName_, long StartTicks_, long EndTicks_, long Limit_, LanguageTypes LanguageType_ = LanguageTypes.ZHTW) where T : IDTO
        {
            var r1 = SearchController.GetLogs<T>(StartTicks_, EndTicks_, Limit_);

            if (!r1.Result)
            {
                var r2 = new ActResult(new Exception(String.Format("取得{0}失敗，{1}", typeof(T).Name, r1.Exception.Message)));
                ExportAction_.Invoke(r2);
                return;
            }
            Export<T>(ExportAction_, ForlderPath_, FileName_, r1.Value, LanguageType_);

            return;
        }

        public void Export<T>(ExportAction ExportAction_, string ForlderPath_, string FileName_, string LotNo_, long Limit_, LanguageTypes LanguageType_ = LanguageTypes.ZHTW) where T : IDTO
        {
            var r1 = SearchController.GetLogs<T>(LotNo_, Limit_);

            if (!r1.Result)
            {
                var r2 = new ActResult(new Exception(String.Format("取得{0}失敗，{1}", typeof(T).Name, r1.Exception.Message)));
                ExportAction_.Invoke(r2);
                return;
            }
            Export<T>(ExportAction_, ForlderPath_, FileName_, r1.Value, LanguageType_);

            return;
        }

        public void Export<T>(ExportAction ExportAction_, string ForlderPath_, string FileName_, List<T> Logs_, LanguageTypes LanguageType_ = LanguageTypes.ZHTW) where T : IDTO
        {
            ThreadPool.QueueUserWorkItem((object state) =>
            {
                try
                {
                    IWorkbook wb = new HSSFWorkbook();
                    //在該檔案創建一個新的工作表 
                    Dictionary<long, ISheet> sheets = new Dictionary<long, ISheet>();

                    for (int index = 0; index <= Logs_.Count / MaxColumnCount; index++)
                    {
                        ISheet ws = wb.CreateSheet(String.Format("{0:00}", index + 1));
                        sheets.Add(index, ws);
                    }
                    if (sheets.Count==0)
                        sheets.Add(0,wb.CreateSheet(String.Format("{0:00}",1)));

                    int cellNo = 0;
                    foreach (var property in typeof(T).GetProperties())
                    {
                        if (property.GetCustomAttribute<DisplayAttribute>().Visible == false) continue;
                        foreach (var sheet in sheets.Values)
                        {
                            if (sheet.GetRow(0) is null) sheet.CreateRow(0);

                            var headtext = "-";
                            switch (LanguageType_)
                            {
                                case LanguageTypes.ZHTW:
                                    headtext = property.GetCustomAttribute<DisplayAttribute>().ZHTW;
                                    break;
                                case LanguageTypes.ZHCN:
                                    headtext = property.GetCustomAttribute<DisplayAttribute>().ZHCN;
                                    break;
                                case LanguageTypes.ENG:
                                    headtext = property.GetCustomAttribute<DisplayAttribute>().ENG;
                                    break;
                            }
                            sheet.GetRow(0).CreateCell(cellNo).SetCellValue(headtext);
                        }
                        long index = 0;
                        foreach (var item in Logs_)
                        {
                            var sheet = sheets[index / MaxColumnCount];
                            int rowno = (int)index % MaxColumnCount;

                            if (sheet.GetRow(rowno + 1) is null) sheet.CreateRow(rowno + 1);

                            var value = property.GetValue(item);
                            sheet.GetRow(rowno + 1).CreateCell(cellNo).SetCellValue((value is null) ? "NULL" : value.ToString());
                            index++;
                        }
                        cellNo++;
                    }
                    if (Directory.Exists(ForlderPath_) == false) Directory.CreateDirectory(ForlderPath_);

                    //產生檔案
                    var file = new FileStream(String.Format("{0}\\{1}", ForlderPath_, FileName_), FileMode.Create);
                    //寫入檔案
                    wb.Write(file);
                    //關閉檔案
                    file.Close();
                    
                    ExportAction_.Invoke(new ActResult(true));
                }
                catch (Exception Ex)
                {
                    ExportAction_.Invoke(new ActResult(Ex));
                }
            });
            return;
        }

        protected override void DisposeManagedObject()
        {
            Enabled = false;
        }
    }
}


//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using Common;
//using Common.DTO;
//using Common.Extension;
//using Repository.Entity;
//using Service.Interface;

//namespace View.ExportLogic
//{
//    public static class ExportController
//    {
//        public static bool IsExported(int Year_, int Month_)
//        {
//            var myList = new List<string>();

//            // 執行檔路徑下的 MyDir 資料夾
//            string folderName = @"D:\\Export";

//            if (!System.IO.Directory.Exists(folderName)) System.IO.Directory.CreateDirectory(folderName);

//            // 取得資料夾內所有檔案
//            foreach (string fname in System.IO.Directory.GetFiles(folderName))
//            {
//                FileInfo info = new FileInfo(fname);
//                myList.Add(info.Name);
//            }
//            return myList.Where(p => p == String.Format("Export-{0:0000},{1}", Year_, Month_)).Count() != 0;
//        }


//        public static void Export()
//        {
//            //try
//            //{
//                var year = DateTime.Now.Year;
//                var mounth = DateTime.Now.Month;
//                var startTicks = new DateTime(year, mounth, 1, 0, 0, 0).Ticks;
//                var endTicks = new DateTime(year, mounth, DateTime.DaysInMonth(year, mounth), 23, 59, 59).Ticks;
//                var pLogs = AutofacConfig.Resolve<IProduceLotService>().Gets(StartTimeTicks_: startTicks, EndTimeTicks_: endTicks);
//                var aLogs = AutofacConfig.Resolve<IAlarmLogService>().Gets(startTicks, endTicks);
//                var rLogs = AutofacConfig.Resolve<IRectifierLogService>().Gets(startTicks, endTicks,true);
//                var tLogs = AutofacConfig.Resolve<IThermostatLogService>().Gets(startTicks, endTicks,true);

//                if (pLogs.Result && aLogs.Result && rLogs.Result && tLogs.Result)
//                {
//                    var top10Alarms = aLogs.Value.GroupBy(p => p.Code).Take(10).Select(p => p.Key).ToList();
//                    var top10logs = aLogs.Value.Where(p => top10Alarms.Contains(p.Code)).ToList().OrderBy(p =>p.Code).ThenByDescending(p=>p.StartLogDateTime).ToList();

//                    var pDT = pLogs.Value.ToDataTable();
//                    var aDT = aLogs.Value.ToDataTable();
//                    var rDT = rLogs.Value.ToDataTable();
//                    var tDT = tLogs.Value.ToDataTable();
//                    var Top10DT = top10logs.ToDataTable();

//                    pDT.TableName = "LoadData Log";
//                    aDT.TableName = "Alarm Log";
//                    rDT.TableName = "整流器 Log";
//                    tDT.TableName = "溫控器 Log";
//                    Top10DT.TableName = "Alarm Top10";

//                    pDT.Columns[nameof(ProduceLotLog.LoadTimeString)].ColumnName = "上料時間";
//                    pDT.Columns[nameof(ProduceLotLog.UpLoadTimeString)].ColumnName = "下料時間";
//                    pDT.Columns[nameof(ProduceLotLog.PanelCode)].ColumnName = "參數";
//                    pDT.Columns[nameof(ProduceLotLog.LotNo)].ColumnName = "批號";
//                    pDT.Columns[nameof(ProduceLotLog.Quantity)].ColumnName = "上掛數量";

//                    aDT.Columns[nameof(AlarmLogDTO.Code)].ColumnName = "Alarm編號";
//                    aDT.Columns[nameof(AlarmLogDTO.StartLogDateTime)].ColumnName = "發生時間";
//                    aDT.Columns[nameof(AlarmLogDTO.FinishDateTime)].ColumnName = "復歸時間";
//                    aDT.Columns[nameof(AlarmLogDTO.Name)].ColumnName = "英文名稱";
//                    aDT.Columns[nameof(AlarmLogDTO.ZhName)].ColumnName = "中文名稱";

//                    Top10DT.Columns[nameof(AlarmLogDTO.Code)].ColumnName = "Alarm編號";
//                    Top10DT.Columns[nameof(AlarmLogDTO.StartLogDateTime)].ColumnName = "發生時間";
//                    Top10DT.Columns[nameof(AlarmLogDTO.FinishDateTime)].ColumnName = "復歸時間";
//                    Top10DT.Columns[nameof(AlarmLogDTO.Name)].ColumnName = "英文名稱";
//                    Top10DT.Columns[nameof(AlarmLogDTO.ZhName)].ColumnName = "中文名稱";

//                    rDT.Columns[nameof(RectifierLogDTO.LogDateTimeString)].ColumnName = "發生時間";
//                    rDT.Columns[nameof(RectifierLogDTO.EqiName)].ColumnName = "設備名稱";
//                    rDT.Columns[nameof(RectifierLogDTO.FbA)].ColumnName = "電流值";
//                    rDT.Columns[nameof(RectifierLogDTO.FbV)].ColumnName = "電壓值";
//                    rDT.Columns[nameof(RectifierLogDTO.SetA)].ColumnName = "設定電流值";

//                    tDT.Columns[nameof(ThermostatLogDTO.LogDateTimeString)].ColumnName = "發生時間";
//                    tDT.Columns[nameof(ThermostatLogDTO.EqiName)].ColumnName = "設備名稱";
//                    tDT.Columns[nameof(ThermostatLogDTO.Value)].ColumnName = "數值";

//                    var folderPath = String.Format(@"D:\\LotLog\\{0}\\", DateTime.Now.ToString("yyyyyMMdd"));

//                    var bol = ExportExcel.Export(
//                        String.Format(@"D:\\Export\"),
//                        String.Format("Export-{0:0000},{1}", year, mounth),
//                        new System.Data.DataTable[] { pDT, aDT, rDT, tDT, Top10DT }
//                    );

//                }
//            //}
//            //catch(Exception Ex)
//            //{ 
//            //}

//        }
//    }
    
//}


using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 處理Excel 讀取與寫入
    /// </summary>
    public static class ExportExcel
    {
        //http://smlboby.blogspot.com/2013/07/npoi-20.html 範例
        /// <summary>
        /// 匯出Excel
        /// <para>　filelocation: 檔案位置</para>
        /// <para>　pathfile: 檔案名稱</para>
        /// <para>　DT: 資料來源</para>
        /// <para>　Mod:輸出格式(T:xls  F:xlsx)</para>
        /// </summary>
        /// <param name="filelocation">檔案位置</param>
        /// <param name="pathfile">檔案名稱</param>
        /// <param name="DT">資料來源</param>
        /// <param name="Mod">T:xls  F:xlsx</param>
        /// <returns></returns>
        public static bool Export(string filelocation, string pathfile, DataTable DT)
        {
            IWorkbook wb  = new HSSFWorkbook();
            //在該檔案創建一個新的工作表 
            ISheet ws = wb.CreateSheet("workbook");

            ws.CreateRow(0);//創建一個新行
            //第一行為欄位名稱
            for (int i = 0; i < DT.Columns.Count; i++)
            {
                ws.GetRow(0).CreateCell(i).SetCellValue(DT.Columns[i].ColumnName);
            }
            //輸入資料
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                ws.CreateRow(i + 1);
                for (int j = 0; j < DT.Columns.Count; j++)
                {
                    //起始
                    ws.GetRow(i + 1).CreateCell(j).SetCellValue(DT.Rows[i][j].ToString());
                }
            }
            try
            {
                if (!Directory.Exists(filelocation)) //如果預設路徑沒此資料夾就創建一個新的
                {
                    Directory.CreateDirectory(filelocation);
                }
                //產生檔案
                FileStream file = new FileStream(filelocation + pathfile + ".xls", FileMode.Create);
                //寫入檔案
                wb.Write(file);
                //關閉檔案
                file.Close();
                //成功建立 回傳true
                return true;
            }
            catch
            {
                //建立失敗 回傳false
                return false;
            }

        }


        public static bool Export(string filelocation, string pathfile, DataTable[] DTs)
        {
            IWorkbook wb = new HSSFWorkbook();

            foreach(var DT in DTs)
            {
                //在該檔案創建一個新的工作表 
                ISheet ws = wb.CreateSheet(DT.TableName);

                ws.CreateRow(0);//創建一個新行
                                //第一行為欄位名稱
                for (int i = 0; i < DT.Columns.Count; i++)
                {
                    
                    ws.GetRow(0).CreateCell(i).SetCellValue(DT.Columns[i].ColumnName);
                }
                //輸入資料
                for (int i = 0; i < DT.Rows.Count && i < 65535; i++)
                {
                    ws.CreateRow(i + 1);
                    for (int j = 0; j < DT.Columns.Count; j++)
                    {
                        //起始
                        ws.GetRow(i + 1).CreateCell(j).SetCellValue(DT.Rows[i][j].ToString());
                    }
                }

            }

            try
            {
                if (!Directory.Exists(filelocation)) //如果預設路徑沒此資料夾就創建一個新的
                {
                    Directory.CreateDirectory(filelocation);
                }
                //產生檔案
                FileStream file = new FileStream(filelocation + pathfile + ".xls", FileMode.Create);
                //寫入檔案
                wb.Write(file);
                //關閉檔案
                file.Close();
                //成功建立 回傳true
                return true;
            }
            catch
            {
                //建立失敗 回傳false
                return false;
            }

        }

    }
}

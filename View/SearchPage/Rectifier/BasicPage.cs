using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Extention;
using Common.DTO;
using Common;
using Common.Extension;
using Controller.Interface;
using Controller;

namespace View.SearchPage.Rectifier
{
    public partial class BasicPage : UserControl
    {
        ISearchController SearchController => ControllerFactory.Get<ISearchController>();
        IExportController ExportController => ControllerFactory.Get<IExportController>();

        readonly List<RectifierLogDTO> RectifierLogs = new List<RectifierLogDTO>();
        readonly string folderPath = "D:\\Export\\Search";

        long Limit => (long)NumUpDown_Limit.Value;
        long StartTimeTicks => DTPicker_Start.Value.Ticks;
        long EndTimeTicks => DTPicker_End.Value.Ticks;
        bool IsUseLotNo => RBtn_UseLotNo.Checked;
        string LotNo => TextBox_LotNo.Text;

        int Interval => (int)NumUpDown_Interval.Value;

        public BasicPage()
        {
            InitializeComponent();
            InitializeDGV();
            RBtn_UseDateRange.Checked = true;
            RBtn_ALL.Checked = true;

            var now = DateTime.Now;
            var yesterdaty = now.AddDays(-1);
            this.DTPicker_Start.Value = new DateTime(yesterdaty.Year, yesterdaty.Month, yesterdaty.Day, 0, 0, 0);
            this.DTPicker_End.Value = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);
        }

        private void RBtn_CheckedChanged(object sender, EventArgs e)
        {
            switch ((sender as Control).Name)
            {
                case nameof(RBtn_ALL):
                    NumUpDown_Interval.Value = 1;
                    break;
                case nameof(RBtn_Ni):
                    NumUpDown_Interval.Value = 30;
                    break;
                case nameof(RBtn_AuSt):
                    NumUpDown_Interval.Value = 1;
                    break;
                case nameof(RBtn_Au):
                    NumUpDown_Interval.Value = 5;
                    break;
            }
            InitializeDGV();
            Search();
        }

        private void Btn_Search_Click(object sender, EventArgs e) 
            => Search();

        void Search()
        {
            ActResult<List<RectifierLogDTO>> r1;
            if (IsUseLotNo)
            {
                if (LotNo.IsEmpty())
                {
                    ExMessagePage.Show("警告", "尚未輸入LotNo作為關鍵字查詢");
                    return;
                }
                r1 = SearchController.GetRectifierLogs(LotNo,Limit ,Interval);
            }
            else
            {
                r1 = SearchController.GetRectifierLogs(StartTimeTicks, EndTimeTicks, Limit ,Interval );
            }

            if (!r1.Result)
            {
                ExMessagePage.Show("取得機台整流器紀錄失敗", r1.Exception.Message);
                return;
            }
            RectifierLogs.Clear();
            RectifierLogs.AddRange(r1.Value);

            UpdateDGV();
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e) 
            => Search();

        Dictionary<Type, DataGridView> DGVs = new Dictionary<Type, DataGridView>(); 
        void InitializeDGV()
        {
            DGV.DataSource = null;
            DGV.DataSource = RectifierLogs;
            DGV.MakeDoubleBuffered();
            DGV.ColumnHeadersHeight = 36;
            DGV.RowTemplate.Height = 36;
            foreach (DataGridViewColumn column in DGV.Columns) column.Visible = false;

            DGV.Columns[nameof(RectifierLogDTO.LogDateTimeString)].Visible = true;
            DGV.Columns[nameof(RectifierLogDTO.LogDateTimeString)].DisplayIndex = 0;
            DGV.Columns[nameof(RectifierLogDTO.LogDateTimeString)].HeaderText = "紀錄時間";
            DGV.Columns[nameof(RectifierLogDTO.LogDateTimeString)].Width = 250;

            int displayIndex = 1;
            foreach (DataGridViewColumn column in DGV.Columns)
            {
                if (column.Name.Contains("_FbA")|| column.Name.Contains("_FbV")|| column.Name.Contains("_SetA"))
                {
                    column.Visible = true;
                    column.DisplayIndex = displayIndex;
                    displayIndex++;

                    if (RBtn_Au.Checked)
                    { 
                        if (column.Name.Contains("Ni") || column.Name.Contains("AuSt"))
                            column.Visible = false;
                    }
                    else if (RBtn_Ni.Checked)
                    {
                        if (column.Name.Contains("Au") || column.Name.Contains("AuSt"))
                            column.Visible = false;
                    }
                    else if (RBtn_AuSt.Checked)
                    {
                        if (!column.Name.Contains("AuSt"))
                            column.Visible = false;
                    }

                }

                if (column.Name.Contains("_FbA"))
                {
                    var str = column.Name;
                    str = str.Replace("_FbA", "");
                    str = str.Replace("_", "#");
                    str += "電流值";
                    column.HeaderText = str; 
                    column.Width = 200;
                }
                else if (column.Name.Contains("_FbV"))
                {
                    var str = column.Name;
                    str = str.Replace("_FbV", "");
                    str = str.Replace("_", "#");
                    str += "電壓值";
                    column.HeaderText = str;
                    column.Width = 200;
                }
                else if (column.Name.Contains("_SetA"))
                {
                    var str = column.Name;
                    str = str.Replace("_SetA", "");
                    str = str.Replace("_", "#");
                    str += "設定電流值";
                    column.HeaderText = str;
                    column.Width = 225;
                }                    
            }
        }

        void UpdateDGV()
        {
            CurrencyManager cm1 = (CurrencyManager)this.DGV.BindingContext[RectifierLogs];
            if (cm1 != null) cm1.Refresh();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            var fileName = String.Format("{0}{1}_(Security C).xls", "RectifierLogSearch", DateTime.Now.GetString(ExtensionDateTime.OutputTypes.TypeB));
            ExportController.Export(ExportAction, folderPath, fileName, RectifierLogs);
        }

        void ExportAction(ActResult ActResult_)
        {
            if (ActResult_.Result) System.Diagnostics.Process.Start(folderPath);
            //ExMessagePage.Show(
            //    String.Format("結果{0}",ActResult_.Result?"成功":"失敗"),
            //    ActResult_.Result?"": ActResult_.Exception.Message);
        }
    }

}

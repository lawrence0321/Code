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
using Common.Attributes;
using System.Reflection;

namespace View.SearchPage.Thermostat
{
    public partial class BasicPage : UserControl
    {
        ISearchController SearchController => ControllerFactory.Get<ISearchController>();
        IExportController ExportController => ControllerFactory.Get<IExportController>();

        readonly List<ThermostatLogDTO> ThermostatLogs = new List<ThermostatLogDTO>();
        readonly string folderPath = "D:\\Export\\Search";

        long Limit => (long)NumUpDown_Limit.Value;
        long StartTimeTicks => DTPicker_Start.Value.Ticks;
        long EndTimeTicks => DTPicker_End.Value.Ticks;
        bool IsUseLotNo => RBtn_UseLotNo.Checked;
        string LotNo => TextBox_LotNo.Text;

        bool IsViewSet => CheckBox_IsViewSet.Checked;
        bool IsViewUpLw => CheckBox_IsViewUpLw.Checked;


        public BasicPage()
        {
            InitializeComponent();
            InitializeDGV();
            RBtn_UseDateRange.Checked = true;

            var now = DateTime.Now;
            var yesterdaty = now.AddDays(-1);
            this.DTPicker_Start.Value = new DateTime(yesterdaty.Year, yesterdaty.Month, yesterdaty.Day, 0, 0, 0);
            this.DTPicker_End.Value = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);
        }

        private void Btn_Search_Click(object sender, EventArgs e) => Search();

        void Search()
        {
            ActResult<List<ThermostatLogDTO>> r1;
            if (IsUseLotNo)
            {
                if (LotNo.IsEmpty())
                {
                    ExMessagePage.Show("警告", "尚未輸入LotNo作為關鍵字查詢");
                    return;
                }
                r1 = SearchController.GetThermostatLogs(LotNo, Limit);
            }
            else
            {
                r1 = SearchController.GetThermostatLogs(StartTimeTicks, EndTimeTicks, Limit);
            }

            if (!r1.Result)
            {
                ExMessagePage.Show("取得機台溫控器紀錄失敗", r1.Exception.Message);
                return;
            }
            ThermostatLogs.Clear();
            ThermostatLogs.AddRange(r1.Value);

            UpdateDGV();
        }

        private void CheckBox_LotNo_CheckedChanged(object sender, EventArgs e) 
            => Search();

        Dictionary<Type, DataGridView> DGVs = new Dictionary<Type, DataGridView>(); 
        void InitializeDGV()
        {
            DGV.DataSource = null;
            DGV.DataSource = ThermostatLogs;
            DGV.MakeDoubleBuffered();
            DGV.ColumnHeadersHeight = 36;
            DGV.RowTemplate.Height = 36;
            foreach (DataGridViewColumn column in DGV.Columns) column.Visible = false;

            DGV.Columns[nameof(ThermostatLogDTO.LogDateTimeString)].Visible = true;
            DGV.Columns[nameof(ThermostatLogDTO.LogDateTimeString)].DisplayIndex = 0;
            DGV.Columns[nameof(ThermostatLogDTO.LogDateTimeString)].HeaderText = "發生時間";
            DGV.Columns[nameof(ThermostatLogDTO.LogDateTimeString)].Width = 250;


            foreach (var property in typeof(ThermostatLogDTO).GetProperties())
            {
                if (!property.Name.Contains("TC")) continue;

                DGV.Columns[property.Name].HeaderText = property.GetCustomAttribute<DisplayAttribute>().ZHTW;
                DGV.Columns[property.Name].Visible = true;
                DGV.Columns[property.Name].Width = 150;

                if (!IsViewSet && property.Name.Contains("Set"))
                    DGV.Columns[property.Name].Visible = false;

                if (!IsViewUpLw && property.Name.Contains("UpLw"))
                    DGV.Columns[property.Name].Visible = false;
            }

        }

        void UpdateDGV()
        {
            CurrencyManager cm1 = (CurrencyManager)this.DGV.BindingContext[ThermostatLogs];
            if (cm1 != null) cm1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var fileName = String.Format("{0}{1}_(Security C).xls", "ThermostatLogSearch", DateTime.Now.GetString(ExtensionDateTime.OutputTypes.TypeB));
            ExportController.Export(ExportAction, folderPath, fileName, ThermostatLogs);
        }

        void ExportAction(ActResult ActResult_)
        {
            if (ActResult_.Result) System.Diagnostics.Process.Start(folderPath);
            //ExMessagePage.Show(
            //    String.Format("結果{0}",ActResult_.Result?"成功":"失敗"),
            //    ActResult_.Result?"": ActResult_.Exception.Message);
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
            => InitializeDGV();

    }

}

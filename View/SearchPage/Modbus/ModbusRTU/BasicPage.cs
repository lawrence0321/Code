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

namespace View.SearchPage.ModbusRTU
{
    public partial class BasicPage : UserControl
    {
        ISearchController SearchController => ControllerFactory.Get<ISearchController>();

        readonly List<WashDeviceLogDTO> WashDeviceLogs = new List<WashDeviceLogDTO>();

        long StartTimeTicks => DTPicker_Start.Value.Ticks;
        long EndTimeTicks => DTPicker_End.Value.Ticks;
        bool IsUseLotNo => RBtn_UseLotNo.Checked;
        string LotNo => TextBox_LotNo.Text;

        int Limit => Convert.ToInt32(NumUpDown_Limit.Value);

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
            ActResult<List<WashDeviceLogDTO>> r1;
            if (IsUseLotNo)
            {
                if (LotNo.IsEmpty())
                {
                    ExMessagePage.Show("警告", "尚未輸入LotNo作為關鍵字查詢");
                    return;
                }
                r1 = SearchController.GetWashDeviceLogs(LotNo, Limit);
            }
            else
                r1 = SearchController.GetWashDeviceLogs(StartTimeTicks, EndTimeTicks, Limit);

            if (!r1.Result)
            {
                ExMessagePage.Show("取得Modbus31紀錄失敗", r1.Exception.Message);
                return;
            }
            WashDeviceLogs.Clear();
            WashDeviceLogs.AddRange(r1.Value);

            UpdateDGV();
        }

        private void CheckBox_LotNo_CheckedChanged(object sender, EventArgs e) 
            => Search();

        Dictionary<Type, DataGridView> DGVs = new Dictionary<Type, DataGridView>(); 
        void InitializeDGV()
        {
            DGV.DataSource = null;
            DGV.DataSource = WashDeviceLogs;
            DGV.MakeDoubleBuffered();
            DGV.ColumnHeadersHeight = 36;
            DGV.RowTemplate.Height = 36;
            foreach (DataGridViewColumn column in DGV.Columns) column.Visible = false;

            DGV.Columns[nameof(WashDeviceLogDTO.LogDateTimeString)].Visible = true;
            DGV.Columns[nameof(WashDeviceLogDTO.LogDateTimeString)].DisplayIndex = 0;
            DGV.Columns[nameof(WashDeviceLogDTO.LogDateTimeString)].HeaderText = "紀錄時間";            
            DGV.Columns[nameof(WashDeviceLogDTO.LogDateTimeString)].Width = 250;

            DGV.Columns[nameof(WashDeviceLogDTO.Speed)].Visible = true;
            DGV.Columns[nameof(WashDeviceLogDTO.Speed)].DisplayIndex = 1;
            DGV.Columns[nameof(WashDeviceLogDTO.Speed)].HeaderText = "水洗機線速";
            DGV.Columns[nameof(WashDeviceLogDTO.Speed)].Width = 250;

            DGV.Columns[nameof(WashDeviceLogDTO.Temperature)].Visible = true;
            DGV.Columns[nameof(WashDeviceLogDTO.Temperature)].DisplayIndex = 2;
            DGV.Columns[nameof(WashDeviceLogDTO.Temperature)].HeaderText = "水洗機溫度";
            DGV.Columns[nameof(WashDeviceLogDTO.Temperature)].Width = 250;
        }

        void UpdateDGV()
        {
            CurrencyManager cm1 = (CurrencyManager)this.DGV.BindingContext[WashDeviceLogs];
            if (cm1 != null) cm1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }

}

using Common;
using Common.DTO;
using Common.Extension;
using Controller;
using Controller.Interface;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using View.Extention;

namespace View.SearchPage.Modbus32
{
    public partial class BasicPage : UserControl
    {
        ISearchController SearchController => ControllerFactory.Get<ISearchController>();

        readonly List<Modbus32LogDTO> Modbus31Logs = new List<Modbus32LogDTO>();

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
            ActResult<List<Modbus32LogDTO>> r1;
            if (IsUseLotNo)
            {
                if (LotNo.IsEmpty())
                {
                    ExMessagePage.Show("警告", "尚未輸入LotNo作為關鍵字查詢");
                    return;
                }
                r1 = SearchController.GetModbus32Logs(LotNo, Limit);
            }
            else
                r1 = SearchController.GetModbus32Logs(StartTimeTicks, EndTimeTicks, Limit);

            if (!r1.Result)
            {
                ExMessagePage.Show("取得Modbus31紀錄失敗", r1.Exception.Message);
                return;
            }
            Modbus31Logs.Clear();
            Modbus31Logs.AddRange(r1.Value);

            UpdateDGV();
        }

        private void CheckBox_LotNo_CheckedChanged(object sender, EventArgs e) 
            => Search();

        Dictionary<Type, DataGridView> DGVs = new Dictionary<Type, DataGridView>(); 
        void InitializeDGV()
        {
            DGV.DataSource = null;
            DGV.DataSource = Modbus31Logs;
            DGV.MakeDoubleBuffered();
            DGV.ColumnHeadersHeight = 36;
            DGV.RowTemplate.Height = 36;
            foreach (DataGridViewColumn column in DGV.Columns) column.Visible = false;

            DGV.Columns[nameof(Modbus32LogDTO.LogDateTimeString)].Visible = true;
            DGV.Columns[nameof(Modbus32LogDTO.LogDateTimeString)].DisplayIndex = 0;
            DGV.Columns[nameof(Modbus32LogDTO.LogDateTimeString)].HeaderText = "紀錄時間";
            DGV.Columns[nameof(Modbus32LogDTO.LogDateTimeString)].Width = 250;

            DGV.Columns[nameof(Modbus32LogDTO.Water6)].Visible = true;
            DGV.Columns[nameof(Modbus32LogDTO.Water6)].DisplayIndex = 1;
            DGV.Columns[nameof(Modbus32LogDTO.Water6)].HeaderText = "水洗12流量計";
            DGV.Columns[nameof(Modbus32LogDTO.Water6)].Width = 250;

            DGV.Columns[nameof(Modbus32LogDTO.Water7)].Visible = true;
            DGV.Columns[nameof(Modbus32LogDTO.Water7)].DisplayIndex = 2;
            DGV.Columns[nameof(Modbus32LogDTO.Water7)].HeaderText = "水洗15流量計";
            DGV.Columns[nameof(Modbus32LogDTO.Water7)].Width = 250;

            DGV.Columns[nameof(Modbus32LogDTO.Water8)].Visible = true;
            DGV.Columns[nameof(Modbus32LogDTO.Water8)].DisplayIndex = 3;
            DGV.Columns[nameof(Modbus32LogDTO.Water8)].HeaderText = "水洗17流量計";
            DGV.Columns[nameof(Modbus32LogDTO.Water8)].Width = 250;

            DGV.Columns[nameof(Modbus32LogDTO.Water9)].Visible = true;
            DGV.Columns[nameof(Modbus32LogDTO.Water9)].DisplayIndex = 4;
            DGV.Columns[nameof(Modbus32LogDTO.Water9)].HeaderText = "水洗22流量計";
            DGV.Columns[nameof(Modbus32LogDTO.Water9)].Width = 250;

            DGV.Columns[nameof(Modbus32LogDTO.Water10)].Visible = true;
            DGV.Columns[nameof(Modbus32LogDTO.Water10)].DisplayIndex = 5;
            DGV.Columns[nameof(Modbus32LogDTO.Water10)].HeaderText = "水洗25流量計";
            DGV.Columns[nameof(Modbus32LogDTO.Water10)].Width = 250;

            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_1)].Visible = true;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_1)].DisplayIndex = 6;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_1)].HeaderText = "鎳金3-1";
            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_1)].Width = 250;

            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_2)].Visible = true;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_2)].DisplayIndex = 7;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_2)].HeaderText = "鎳金3-2";
            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_2)].Width = 250;

            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_3)].Visible = true;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_3)].DisplayIndex = 8;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_3)].HeaderText = "鎳金3-3";
            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_3)].Width = 250;

            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_1)].Visible = true;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_1)].DisplayIndex = 9;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_1)].HeaderText = "鎳金4-1";
            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_1)].Width = 250;

            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_2)].Visible = true;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_2)].DisplayIndex = 10;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_2)].HeaderText = "鎳金4-2";
            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_2)].Width = 250;

            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_3)].Visible = true;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_3)].DisplayIndex = 11;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_3)].HeaderText = "鎳金4-3";
            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_3)].Width = 250;

            DGV.Columns[nameof(Modbus32LogDTO.Au_Strike)].Visible = true;
            DGV.Columns[nameof(Modbus32LogDTO.Au_Strike)].DisplayIndex = 9;
            DGV.Columns[nameof(Modbus32LogDTO.Au_Strike)].HeaderText = "預鍍金過濾罐";
            DGV.Columns[nameof(Modbus32LogDTO.Au_Strike)].Width = 250;

            DGV.Columns[nameof(Modbus32LogDTO.Au_1)].Visible = true;
            DGV.Columns[nameof(Modbus32LogDTO.Au_1)].DisplayIndex = 10;
            DGV.Columns[nameof(Modbus32LogDTO.Au_1)].HeaderText = "金1過濾罐";
            DGV.Columns[nameof(Modbus32LogDTO.Au_1)].Width = 250;

            DGV.Columns[nameof(Modbus32LogDTO.Au_2)].Visible = true;
            DGV.Columns[nameof(Modbus32LogDTO.Au_2)].DisplayIndex = 11;
            DGV.Columns[nameof(Modbus32LogDTO.Au_2)].HeaderText = "金2過濾罐";
            DGV.Columns[nameof(Modbus32LogDTO.Au_2)].Width = 250;

            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_Air_1)].Visible = true;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_Air_1)].DisplayIndex = 12;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_Air_1)].HeaderText = "鎳金3空氣流量計1";
            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_Air_1)].Width = 250;

            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_Air_2)].Visible = true;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_Air_2)].DisplayIndex = 13;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_Air_2)].HeaderText = "鎳金3空氣流量計2";
            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_Air_2)].Width = 250;

            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_Air_3)].Visible = true;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_Air_3)].DisplayIndex = 14;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_Air_3)].HeaderText = "鎳金3空氣流量計3";
            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_Air_3)].Width = 250;

            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_Air_4)].Visible = true;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_Air_4)].DisplayIndex = 15;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_Air_4)].HeaderText = "鎳金3空氣流量計4";
            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_Air_4)].Width = 250;

            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_Air_5)].Visible = true;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_Air_5)].DisplayIndex = 16;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_Air_5)].HeaderText = "鎳金3空氣流量計5";
            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_Air_5)].Width = 250;

            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_Air_6)].Visible = true;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_Air_6)].DisplayIndex = 17;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_Air_6)].HeaderText = "鎳金3空氣流量計6";
            DGV.Columns[nameof(Modbus32LogDTO.Nickel3_Air_6)].Width = 250;

            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_Air_1)].Visible = true;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_Air_1)].DisplayIndex = 18;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_Air_1)].HeaderText = "鎳金3空氣流量計1";
            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_Air_1)].Width = 250;

            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_Air_2)].Visible = true;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_Air_2)].DisplayIndex = 19;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_Air_2)].HeaderText = "鎳金3空氣流量計2";
            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_Air_2)].Width = 250;

            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_Air_3)].Visible = true;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_Air_3)].DisplayIndex = 20;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_Air_3)].HeaderText = "鎳金3空氣流量計3";
            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_Air_3)].Width = 250;

            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_Air_4)].Visible = true;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_Air_4)].DisplayIndex = 21;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_Air_4)].HeaderText = "鎳金3空氣流量計4";
            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_Air_4)].Width = 250;

            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_Air_5)].Visible = true;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_Air_5)].DisplayIndex = 22;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_Air_5)].HeaderText = "鎳金3空氣流量計5";
            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_Air_5)].Width = 250;

            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_Air_6)].Visible = true;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_Air_6)].DisplayIndex = 23;
            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_Air_6)].HeaderText = "鎳金3空氣流量計6";
            DGV.Columns[nameof(Modbus32LogDTO.Nickel4_Air_6)].Width = 250;
        }

        void UpdateDGV()
        {
            CurrencyManager cm1 = (CurrencyManager)this.DGV.BindingContext[Modbus31Logs];
            if (cm1 != null) cm1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }

}

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

namespace View.SearchPage.Modbus31
{
    public partial class BasicPage : UserControl
    {
        ISearchController SearchController => ControllerFactory.Get<ISearchController>();

        readonly List<Modbus31LogDTO> Modbus31Logs = new List<Modbus31LogDTO>();

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
            ActResult<List<Modbus31LogDTO>> r1;
            if (IsUseLotNo)
            {
                if (LotNo.IsEmpty())
                {
                    ExMessagePage.Show("警告", "尚未輸入LotNo作為關鍵字查詢");
                    return;
                }
                r1 = SearchController.GetModbus31Logs(LotNo, Limit);
            }
            else
                r1 = SearchController.GetModbus31Logs(StartTimeTicks, EndTimeTicks, Limit);

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

            DGV.Columns[nameof(Modbus31LogDTO.LogDateTimeString)].Visible = true;
            DGV.Columns[nameof(Modbus31LogDTO.LogDateTimeString)].DisplayIndex = 0;
            DGV.Columns[nameof(Modbus31LogDTO.LogDateTimeString)].HeaderText = "紀錄時間";
            DGV.Columns[nameof(Modbus31LogDTO.LogDateTimeString)].Width = 250;

            DGV.Columns[nameof(Modbus31LogDTO.Water1)].Visible = true;
            DGV.Columns[nameof(Modbus31LogDTO.Water1)].DisplayIndex = 1;
            DGV.Columns[nameof(Modbus31LogDTO.Water1)].HeaderText = "熱水洗3流量計";
            DGV.Columns[nameof(Modbus31LogDTO.Water1)].Width = 250;

            DGV.Columns[nameof(Modbus31LogDTO.Water2)].Visible = true;
            DGV.Columns[nameof(Modbus31LogDTO.Water2)].DisplayIndex = 2;
            DGV.Columns[nameof(Modbus31LogDTO.Water2)].HeaderText = "水洗4流量計";
            DGV.Columns[nameof(Modbus31LogDTO.Water2)].Width = 250;

            DGV.Columns[nameof(Modbus31LogDTO.Water3)].Visible = true;
            DGV.Columns[nameof(Modbus31LogDTO.Water3)].DisplayIndex = 3;
            DGV.Columns[nameof(Modbus31LogDTO.Water3)].HeaderText = "水洗7流量計";
            DGV.Columns[nameof(Modbus31LogDTO.Water3)].Width = 250;

            DGV.Columns[nameof(Modbus31LogDTO.Water4)].Visible = true;
            DGV.Columns[nameof(Modbus31LogDTO.Water4)].DisplayIndex = 4;
            DGV.Columns[nameof(Modbus31LogDTO.Water4)].HeaderText = "水洗9流量計";
            DGV.Columns[nameof(Modbus31LogDTO.Water4)].Width = 250;

            DGV.Columns[nameof(Modbus31LogDTO.Blower)].Visible = true;
            DGV.Columns[nameof(Modbus31LogDTO.Blower)].DisplayIndex = 5;
            DGV.Columns[nameof(Modbus31LogDTO.Blower)].HeaderText = "鼓風機壓力";
            DGV.Columns[nameof(Modbus31LogDTO.Blower)].Width = 250;

            DGV.Columns[nameof(Modbus31LogDTO.Clean)].Visible = true;
            DGV.Columns[nameof(Modbus31LogDTO.Clean)].DisplayIndex = 6;
            DGV.Columns[nameof(Modbus31LogDTO.Clean)].HeaderText = "脫脂過濾罐";
            DGV.Columns[nameof(Modbus31LogDTO.Clean)].Width = 250;

            DGV.Columns[nameof(Modbus31LogDTO.Microerching)].Visible = true;
            DGV.Columns[nameof(Modbus31LogDTO.Microerching)].DisplayIndex = 7;
            DGV.Columns[nameof(Modbus31LogDTO.Microerching)].HeaderText = "微蝕刻過濾罐";
            DGV.Columns[nameof(Modbus31LogDTO.Microerching)].Width = 250;

            DGV.Columns[nameof(Modbus31LogDTO.ACID1)].Visible = true;
            DGV.Columns[nameof(Modbus31LogDTO.ACID1)].DisplayIndex = 8;
            DGV.Columns[nameof(Modbus31LogDTO.ACID1)].HeaderText = "酸1過濾罐";
            DGV.Columns[nameof(Modbus31LogDTO.ACID1)].Width = 250;

            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_1)].Visible = true;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_1)].DisplayIndex = 9;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_1)].HeaderText = "鎳金1-1";
            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_1)].Width = 250;

            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_2)].Visible = true;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_2)].DisplayIndex = 10;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_2)].HeaderText = "鎳金1-2";
            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_2)].Width = 250;

            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_3)].Visible = true;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_3)].DisplayIndex = 11;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_3)].HeaderText = "鎳金1-3";
            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_3)].Width = 250;

            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_1)].Visible = true;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_1)].DisplayIndex = 9;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_1)].HeaderText = "鎳金2-1";
            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_1)].Width = 250;

            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_2)].Visible = true;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_2)].DisplayIndex = 10;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_2)].HeaderText = "鎳金2-2";
            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_2)].Width = 250;

            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_3)].Visible = true;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_3)].DisplayIndex = 11;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_3)].HeaderText = "鎳金2_3";
            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_3)].Width = 250;

            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_Air_1)].Visible = true;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_Air_1)].DisplayIndex = 12;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_Air_1)].HeaderText = "鎳金1空氣流量計1";
            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_Air_1)].Width = 250;

            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_Air_2)].Visible = true;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_Air_2)].DisplayIndex = 13;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_Air_2)].HeaderText = "鎳金1空氣流量計2";
            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_Air_2)].Width = 250;

            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_Air_3)].Visible = true;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_Air_3)].DisplayIndex = 14;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_Air_3)].HeaderText = "鎳金1空氣流量計3";
            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_Air_3)].Width = 250;

            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_Air_4)].Visible = true;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_Air_4)].DisplayIndex = 15;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_Air_4)].HeaderText = "鎳金1空氣流量計4";
            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_Air_4)].Width = 250;

            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_Air_5)].Visible = true;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_Air_5)].DisplayIndex = 16;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_Air_5)].HeaderText = "鎳金1空氣流量計5";
            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_Air_5)].Width = 250;

            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_Air_6)].Visible = true;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_Air_6)].DisplayIndex = 17;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_Air_6)].HeaderText = "鎳金1空氣流量計6";
            DGV.Columns[nameof(Modbus31LogDTO.Nickel1_Air_6)].Width = 250;

            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_Air_1)].Visible = true;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_Air_1)].DisplayIndex = 18;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_Air_1)].HeaderText = "鎳金2空氣流量計1";
            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_Air_1)].Width = 250;

            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_Air_2)].Visible = true;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_Air_2)].DisplayIndex = 19;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_Air_2)].HeaderText = "鎳金2空氣流量計2";
            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_Air_2)].Width = 250;

            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_Air_3)].Visible = true;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_Air_3)].DisplayIndex = 20;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_Air_3)].HeaderText = "鎳金2空氣流量計3";
            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_Air_3)].Width = 250;

            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_Air_4)].Visible = true;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_Air_4)].DisplayIndex = 21;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_Air_4)].HeaderText = "鎳金2空氣流量計4";
            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_Air_4)].Width = 250;

            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_Air_5)].Visible = true;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_Air_5)].DisplayIndex = 22;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_Air_5)].HeaderText = "鎳金2空氣流量計5";
            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_Air_5)].Width = 250;

            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_Air_6)].Visible = true;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_Air_6)].DisplayIndex = 23;
            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_Air_6)].HeaderText = "鎳金2空氣流量計6";
            DGV.Columns[nameof(Modbus31LogDTO.Nickel2_Air_6)].Width = 250;
        }

        void UpdateDGV()
        {
            CurrencyManager cm1 = (CurrencyManager)this.DGV.BindingContext[Modbus31Logs];
            if (cm1 != null) cm1.Refresh();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }

}

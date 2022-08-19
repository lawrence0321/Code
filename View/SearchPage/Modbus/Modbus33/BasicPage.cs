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

namespace View.SearchPage.Modbus33
{
    public partial class BasicPage : UserControl
    {
        ISearchController SearchController => ControllerFactory.Get<ISearchController>();

        readonly List<Modbus33LogDTO> Modbus33Logs = new List<Modbus33LogDTO>();

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
            ActResult<List<Modbus33LogDTO>> r1;
            if (IsUseLotNo)
            {
                if (LotNo.IsEmpty())
                {
                    ExMessagePage.Show("警告", "尚未輸入LotNo作為關鍵字查詢");
                    return;
                }
                r1 = SearchController.GetModbus33Logs(LotNo, Limit);
            }
            else
                r1 = SearchController.GetModbus33Logs(StartTimeTicks, EndTimeTicks, Limit);

            if (!r1.Result)
            {
                ExMessagePage.Show("取得Modbus31紀錄失敗", r1.Exception.Message);
                return;
            }
            Modbus33Logs.Clear();
            Modbus33Logs.AddRange(r1.Value);

            UpdateDGV();
        }

        private void CheckBox_LotNo_CheckedChanged(object sender, EventArgs e) 
            => Search();

        Dictionary<Type, DataGridView> DGVs = new Dictionary<Type, DataGridView>(); 
        void InitializeDGV()
        {
            DGV.DataSource = null;
            DGV.DataSource = Modbus33Logs;
            DGV.MakeDoubleBuffered();
            DGV.ColumnHeadersHeight = 36;
            DGV.RowTemplate.Height = 36;
            foreach (DataGridViewColumn column in DGV.Columns) column.Visible = false;

            DGV.Columns[nameof(Modbus33LogDTO.LogDateTimeString)].Visible = true;
            DGV.Columns[nameof(Modbus33LogDTO.LogDateTimeString)].DisplayIndex = 0;
            DGV.Columns[nameof(Modbus33LogDTO.LogDateTimeString)].HeaderText = "紀錄時間";            
            DGV.Columns[nameof(Modbus33LogDTO.LogDateTimeString)].Width = 250;

            DGV.Columns[nameof(Modbus33LogDTO.Water11)].Visible = true;
            DGV.Columns[nameof(Modbus33LogDTO.Water11)].DisplayIndex = 1;
            DGV.Columns[nameof(Modbus33LogDTO.Water11)].HeaderText = "水洗機1流量計";
            DGV.Columns[nameof(Modbus33LogDTO.Water11)].Width = 250;

            DGV.Columns[nameof(Modbus33LogDTO.Water12)].Visible = true;
            DGV.Columns[nameof(Modbus33LogDTO.Water12)].DisplayIndex = 2;
            DGV.Columns[nameof(Modbus33LogDTO.Water12)].HeaderText = "水洗機2流量計";
            DGV.Columns[nameof(Modbus33LogDTO.Water12)].Width = 250;

            DGV.Columns[nameof(Modbus33LogDTO.Water13)].Visible = true;
            DGV.Columns[nameof(Modbus33LogDTO.Water13)].DisplayIndex = 3;
            DGV.Columns[nameof(Modbus33LogDTO.Water13)].HeaderText = "水洗機3流量計";
            DGV.Columns[nameof(Modbus33LogDTO.Water13)].Width = 250;

            DGV.Columns[nameof(Modbus33LogDTO.Rinse1)].Visible = true;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse1)].DisplayIndex = 4;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse1)].HeaderText = "水洗機水洗槽噴壓1";
            DGV.Columns[nameof(Modbus33LogDTO.Rinse1)].Width = 250;

            DGV.Columns[nameof(Modbus33LogDTO.Rinse2)].Visible = true;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse2)].DisplayIndex = 5;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse2)].HeaderText = "水洗機水洗槽噴壓2";
            DGV.Columns[nameof(Modbus33LogDTO.Rinse2)].Width = 250;

            DGV.Columns[nameof(Modbus33LogDTO.Rinse3)].Visible = true;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse3)].DisplayIndex = 6;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse3)].HeaderText = "水洗機水洗槽噴壓3";
            DGV.Columns[nameof(Modbus33LogDTO.Rinse3)].Width = 250;

            DGV.Columns[nameof(Modbus33LogDTO.Rinse4)].Visible = true;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse4)].DisplayIndex = 7;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse4)].HeaderText = "水洗機水洗槽噴壓4";
            DGV.Columns[nameof(Modbus33LogDTO.Rinse4)].Width = 250;

            DGV.Columns[nameof(Modbus33LogDTO.Rinse5)].Visible = true;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse5)].DisplayIndex = 8;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse5)].HeaderText = "水洗機水洗槽噴壓5";
            DGV.Columns[nameof(Modbus33LogDTO.Rinse5)].Width = 250;

            DGV.Columns[nameof(Modbus33LogDTO.Rinse6)].Visible = true;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse6)].DisplayIndex = 9;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse6)].HeaderText = "水洗機水洗槽噴壓6";
            DGV.Columns[nameof(Modbus33LogDTO.Rinse6)].Width = 250;

            DGV.Columns[nameof(Modbus33LogDTO.Rinse7)].Visible = true;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse7)].DisplayIndex = 10;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse7)].HeaderText = "水洗機水洗槽噴壓7";
            DGV.Columns[nameof(Modbus33LogDTO.Rinse7)].Width = 250;

            DGV.Columns[nameof(Modbus33LogDTO.Rinse8)].Visible = true;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse8)].DisplayIndex = 11;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse8)].HeaderText = "水洗機水洗槽噴壓8";
            DGV.Columns[nameof(Modbus33LogDTO.Rinse8)].Width = 250;

            DGV.Columns[nameof(Modbus33LogDTO.Rinse9)].Visible = true;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse9)].DisplayIndex = 9;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse9)].HeaderText = "水洗機水洗槽噴壓9";
            DGV.Columns[nameof(Modbus33LogDTO.Rinse9)].Width = 250;

            DGV.Columns[nameof(Modbus33LogDTO.Rinse10)].Visible = true;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse10)].DisplayIndex = 10;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse10)].HeaderText = "水洗機水洗槽噴壓10";
            DGV.Columns[nameof(Modbus33LogDTO.Rinse10)].Width = 250;

            DGV.Columns[nameof(Modbus33LogDTO.Rinse11)].Visible = true;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse11)].DisplayIndex = 11;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse11)].HeaderText = "水洗機水洗槽噴壓11";
            DGV.Columns[nameof(Modbus33LogDTO.Rinse11)].Width = 250;

            DGV.Columns[nameof(Modbus33LogDTO.Rinse12)].Visible = true;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse12)].DisplayIndex = 12;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse12)].HeaderText = "水洗機水洗槽噴壓12";
            DGV.Columns[nameof(Modbus33LogDTO.Rinse12)].Width = 250;

            DGV.Columns[nameof(Modbus33LogDTO.Rinse13)].Visible = true;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse13)].DisplayIndex = 13;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse13)].HeaderText = "水洗機水洗槽噴壓13";
            DGV.Columns[nameof(Modbus33LogDTO.Rinse13)].Width = 250;

            DGV.Columns[nameof(Modbus33LogDTO.Rinse_Flow1)].Visible = true;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse_Flow1)].DisplayIndex = 14;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse_Flow1)].HeaderText = "水洗機風量1";
            DGV.Columns[nameof(Modbus33LogDTO.Rinse_Flow1)].Width = 250;

            DGV.Columns[nameof(Modbus33LogDTO.Rinse_Flow2)].Visible = true;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse_Flow2)].DisplayIndex = 15;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse_Flow2)].HeaderText = "水洗機風量2";
            DGV.Columns[nameof(Modbus33LogDTO.Rinse_Flow2)].Width = 250;

            DGV.Columns[nameof(Modbus33LogDTO.Rinse_Flow3)].Visible = true;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse_Flow3)].DisplayIndex = 16;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse_Flow3)].HeaderText = "水洗機風量3";
            DGV.Columns[nameof(Modbus33LogDTO.Rinse_Flow3)].Width = 250;

            DGV.Columns[nameof(Modbus33LogDTO.Rinse_EC)].Visible = true;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse_EC)].DisplayIndex = 17;
            DGV.Columns[nameof(Modbus33LogDTO.Rinse_EC)].HeaderText = "水洗機電導度";
            DGV.Columns[nameof(Modbus33LogDTO.Rinse_EC)].Width = 250;
        }

        void UpdateDGV()
        {
            CurrencyManager cm1 = (CurrencyManager)this.DGV.BindingContext[Modbus33Logs];
            if (cm1 != null) cm1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }

}

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


namespace View.UnLoadDataLog
{
    public partial class BasicPage : UserControl
    {
        ISearchController SearchController => ControllerFactory.Get<ISearchController>();
        IExportController ExportController => ControllerFactory.Get<IExportController>();

        readonly List<UnLoadDataLogDTO> UnLoadDataLogs = new List<UnLoadDataLogDTO>();
        readonly string folderPath = "D:\\Export\\Search";

        long StartTimeTicks
        {
            get 
            {
                return DTPicker_Start.Value.Ticks;
            }
        }
        long EndTimeTicks
        {
            get
            {
                return DTPicker_End.Value.Ticks;
            }
        }
        bool IsUseLotNo => RBtn_UseLotNo.Checked;
        bool IsUseDateRange => RBtn_UseDateRange.Checked;
        string LotNo => TextBox_LotNo.Text;

        int Limit =>  Convert.ToInt32(NumUpDown_Limit.Value);

        public BasicPage()
        {
            InitializeComponent();
            InitializeDGV();
            DTPicker_Start.Value = DateTime.Now.AddDays(-1);
            DTPicker_End.Value = DateTime.Now;

        }
        void InitializeDGV()
        {
            DGV.DataSource = null;
            DGV.DataSource = UnLoadDataLogs;
            DGV.MakeDoubleBuffered();
            DGV.ColumnHeadersHeight = 36;
            DGV.RowTemplate.Height = 36;
            foreach (DataGridViewColumn column in DGV.Columns) column.Visible = false;

            DGV.Columns[nameof(UnLoadDataLogDTO.LoadTimeString)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.LoadTimeString)].DisplayIndex = 0;
            DGV.Columns[nameof(UnLoadDataLogDTO.LoadTimeString)].HeaderText = "上料時間";
            DGV.Columns[nameof(UnLoadDataLogDTO.LoadTimeString)].Width = 250;

            DGV.Columns[nameof(UnLoadDataLogDTO.UpLoadTimeString)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.UpLoadTimeString)].DisplayIndex = 1;
            DGV.Columns[nameof(UnLoadDataLogDTO.UpLoadTimeString)].HeaderText = "下料時間";
            DGV.Columns[nameof(UnLoadDataLogDTO.UpLoadTimeString)].Width = 250;

            DGV.Columns[nameof(UnLoadDataLogDTO.LotNo)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.LotNo)].HeaderText = "批號";  
            DGV.Columns[nameof(UnLoadDataLogDTO.LotNo)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.PanelCode)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.PanelCode)].HeaderText = "生產參數";
            DGV.Columns[nameof(UnLoadDataLogDTO.PanelCode)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Quantity)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Quantity)].HeaderText = "上掛數量";
            DGV.Columns[nameof(UnLoadDataLogDTO.Quantity)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_WB_SetECurrent)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_WB_SetECurrent)].HeaderText = "Ni(W/B) SetECurrent";
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_WB_SetECurrent)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_B_SetECurrent)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_B_SetECurrent)].HeaderText = "Ni(B) SetECurrent";
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_B_SetECurrent)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_SetPlatingTime)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_SetPlatingTime)].HeaderText = "Ni Set PlatingTime";
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_SetPlatingTime)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Au_WB_SetECurrent)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_WB_SetECurrent)].HeaderText = "Au(W/B) SetECurrent";
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_WB_SetECurrent)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Au_B_SetECurrent)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_B_SetECurrent)].HeaderText = "Au(B) SetECurrent";
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_B_SetECurrent)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Au_SetPlatingTime)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_SetPlatingTime)].HeaderText = "Au Set PlatingTime";
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_SetPlatingTime)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.AuSt_SetECurrent)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.AuSt_SetECurrent)].HeaderText = "AuSt SetECurrent";
            DGV.Columns[nameof(UnLoadDataLogDTO.AuSt_SetECurrent)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.AuSt_SetPlatingTime)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.AuSt_SetPlatingTime)].HeaderText = "AuSt Set PlatingTime";
            DGV.Columns[nameof(UnLoadDataLogDTO.AuSt_SetPlatingTime)].Width = 150;

            #region Ni Ave Column
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_WB_AveECurrent)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_WB_AveECurrent)].HeaderText = "Ni(W/B) AveECurrent";
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_WB_AveECurrent)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_B_AveECurrent)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_B_AveECurrent)].HeaderText = "Ni(B) AveECurrent";
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_B_AveECurrent)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_WB_AveVoltage)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_WB_AveVoltage)].HeaderText = "Ni(W/B) AveVoltage";
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_WB_AveVoltage)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_B_AveVoltage)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_B_AveVoltage)].HeaderText = "Ni(B) AveVoltage";
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_B_AveVoltage)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_Temp)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_Temp)].HeaderText = "Ni Temp";
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_Temp)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_WB_Err_A)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_WB_Err_A)].HeaderText = "Ni(W/B) Err A";
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_WB_Err_A)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_WB_Err_V)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_WB_Err_V)].HeaderText = "Ni(W/B) Err V";
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_WB_Err_V)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_WB_Err_T)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_WB_Err_T)].HeaderText = "Ni(W/B) Err T";
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_WB_Err_T)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_B_Err_A)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_B_Err_A)].HeaderText = "Ni(B) Err A";
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_B_Err_A)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_B_Err_V)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_B_Err_V)].HeaderText = "Ni(B) Err V";
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_B_Err_V)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_B_Err_T)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_B_Err_T)].HeaderText = "Ni(B) Err T";
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_B_Err_T)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_StageNo)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_StageNo)].HeaderText = "Ni StageNo";
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_StageNo)].Width = 200;

            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_DipTime)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_DipTime)].HeaderText = "Ni DipTime";
            DGV.Columns[nameof(UnLoadDataLogDTO.Ni_DipTime)].Width = 200;
            #endregion

            #region AuSt Ave Column
            DGV.Columns[nameof(UnLoadDataLogDTO.AuSt_AveECurrent)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.AuSt_AveECurrent)].HeaderText = "AuSt_AveECurrent";
            DGV.Columns[nameof(UnLoadDataLogDTO.AuSt_AveECurrent)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.AuSt_AveVoltage)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.AuSt_AveVoltage)].HeaderText = "AuSt AveVoltage";
            DGV.Columns[nameof(UnLoadDataLogDTO.AuSt_AveVoltage)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.AuSt_Temp)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.AuSt_Temp)].HeaderText = "AuSt Temp";
            DGV.Columns[nameof(UnLoadDataLogDTO.AuSt_Temp)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.AuSt_Err_A)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.AuSt_Err_A)].HeaderText = "AuSt Err A";
            DGV.Columns[nameof(UnLoadDataLogDTO.AuSt_Err_A)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.AuSt_Err_V)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.AuSt_Err_V)].HeaderText = "AuSt Err V";
            DGV.Columns[nameof(UnLoadDataLogDTO.AuSt_Err_V)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.AuSt_Err_T)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.AuSt_Err_T)].HeaderText = "AuSt Err T";
            DGV.Columns[nameof(UnLoadDataLogDTO.AuSt_Err_T)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.AuSt_DipTime)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.AuSt_DipTime)].HeaderText = "AuSt DipTime";
            DGV.Columns[nameof(UnLoadDataLogDTO.AuSt_DipTime)].Width = 200;
            #endregion

            #region Au Ave Column
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_B_AveECurrent)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_B_AveECurrent)].HeaderText = "Au(B) AveECurrent";
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_B_AveECurrent)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Au_WB_AveECurrent)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_WB_AveECurrent)].HeaderText = "Au(WB) AveECurrent";
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_WB_AveECurrent)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Au_B_AveVoltage)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_B_AveVoltage)].HeaderText = "Au(B) AveVoltage";
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_B_AveVoltage)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Au_WB_AveVoltage)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_WB_AveVoltage)].HeaderText = "Au(W/B) AveVoltage";
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_WB_AveVoltage)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Au_Temp)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_Temp)].HeaderText = "Au Temp";
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_Temp)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Au_WB_Err_A)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_WB_Err_A)].HeaderText = "Au(W/B) Err A";
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_WB_Err_A)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Au_WB_Err_V)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_WB_Err_V)].HeaderText = "Au(W/B) Err V";
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_WB_Err_V)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Au_WB_Err_T)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_WB_Err_T)].HeaderText = "Au(W/B) Err T";
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_WB_Err_T)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Au_B_Err_A)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_B_Err_A)].HeaderText = "Au(B) Err A";
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_B_Err_A)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Au_B_Err_V)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_B_Err_V)].HeaderText = "Au(B) Err V";
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_B_Err_V)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Au_B_Err_T)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_B_Err_T)].HeaderText = "Au(B) Err T";
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_B_Err_T)].Width = 150;

            DGV.Columns[nameof(UnLoadDataLogDTO.Au_StageNo)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_StageNo)].HeaderText = "Au StageNo";
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_StageNo)].Width = 200;

            DGV.Columns[nameof(UnLoadDataLogDTO.Au_DipTime)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_DipTime)].HeaderText = "Au DipTime";
            DGV.Columns[nameof(UnLoadDataLogDTO.Au_DipTime)].Width = 200;
            #endregion

            DGV.Columns[nameof(UnLoadDataLogDTO.PMode)].DisplayIndex = DGV.Columns.Count - 1;
            DGV.Columns[nameof(UnLoadDataLogDTO.PMode)].Visible = true;
            DGV.Columns[nameof(UnLoadDataLogDTO.PMode)].HeaderText = nameof(UnLoadDataLogDTO.PMode);
            DGV.Columns[nameof(UnLoadDataLogDTO.PMode)].Width = 200;

        }

        void UpdateDGV()
        {
            CurrencyManager cm1 = (CurrencyManager)this.DGV.BindingContext[UnLoadDataLogs];
            if (cm1 != null) cm1.Refresh();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            var fileName = String.Format("{0}{1}_(Security C).xls", "UnLoadDataLogSearch", DateTime.Now.GetString(ExtensionDateTime.OutputTypes.TypeB));
            ExportController.Export(ExportAction, folderPath, fileName, UnLoadDataLogs);
        }

        void ExportAction(ActResult ActResult_)
        {
            if (ActResult_.Result) System.Diagnostics.Process.Start(folderPath);
            //ExMessagePage.Show(
            //    String.Format("結果{0}",ActResult_.Result?"成功":"失敗"),
            //    ActResult_.Result?"": ActResult_.Exception.Message);
        }

        private void Btn_Search_Click_1(object sender, EventArgs e)
        {
            ActResult<List<UnLoadDataLogDTO>> r1;
            if (IsUseLotNo)
            {
                if (LotNo.IsEmpty())
                {
                    ExMessagePage.Show("警告", "尚未輸入LotNo作為關鍵字查詢");
                    return;
                }
                r1 = SearchController.GetLogs<UnLoadDataLogDTO>(LotNo, Limit);
            }
            else
                r1 = SearchController.GetLogs<UnLoadDataLogDTO>(StartTimeTicks, EndTimeTicks, Limit);

            if (!r1.Result)
            {
                ExMessagePage.Show("取得UnLoadData紀錄失敗", r1.Exception.Message);
                return;
            }
            UnLoadDataLogs.Clear();
            UnLoadDataLogs.AddRange(r1.Value);

            UpdateDGV();
        }

    }
}

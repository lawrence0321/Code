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

namespace View.SearchPage.Alarm
{
    public partial class BasicPage : UserControl
    {
        ISearchController SearchController => ControllerFactory.Get<ISearchController>();
        IExportController ExportController => ControllerFactory.Get<IExportController>();
        IRecipeController RecipeController => ControllerFactory.Get<IRecipeController>();

        readonly List<AlarmLogDTO> AlarmLogs = new List<AlarmLogDTO>();
        readonly string folderPath = "D:\\Export\\Search";

        long StartTimeTicks => DTPicker_Start.Value.Ticks;
        long EndTimeTicks => DTPicker_End.Value.Ticks;
        bool IsUseLotNo => RBtn_UseLotNo.Checked;
        string LotNo => TextBox_LotNo.Text;
        
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
            ActResult<List<AlarmLogDTO>> r1;
            if (IsUseLotNo)
            {
                if (LotNo.IsEmpty())
                {
                    ExMessagePage.Show("警告", "尚未輸入LotNo作為關鍵字查詢");
                    return;
                }
                r1 = SearchController.GetAlarmLogs(LotNo);
            }
            else 
            {
                r1 = SearchController.GetAlarmLogs(StartTimeTicks, EndTimeTicks);
            }

            if (!r1.Result)
            {
                ExMessagePage.Show("取得機台Alarm紀錄失敗", r1.Exception.Message);
                return;
            }
            AlarmLogs.Clear();
            AlarmLogs.AddRange(r1.Value);

            UpdateDGV();
        }

        private void CheckBox_LotNo_CheckedChanged(object sender, EventArgs e) 
            => Search();

        Dictionary<Type, DataGridView> DGVs = new Dictionary<Type, DataGridView>(); 
        void InitializeDGV()
        {
            DGV.DataSource = null;
            DGV.DataSource = AlarmLogs;
            DGV.MakeDoubleBuffered();
            DGV.ColumnHeadersHeight = 36;
            DGV.RowTemplate.Height = 36;
            foreach (DataGridViewColumn column in DGV.Columns) column.Visible = false;

            DGV.Columns[nameof(AlarmLogDTO.StartLogDateTimeString)].Visible = true;
            DGV.Columns[nameof(AlarmLogDTO.StartLogDateTimeString)].DisplayIndex = 0;
            DGV.Columns[nameof(AlarmLogDTO.StartLogDateTimeString)].HeaderText = "發生時間";
            DGV.Columns[nameof(AlarmLogDTO.StartLogDateTimeString)].Width = 250;

            DGV.Columns[nameof(AlarmLogDTO.FinishDateTimeString)].Visible = true;
            DGV.Columns[nameof(AlarmLogDTO.FinishDateTimeString)].DisplayIndex = 1;
            DGV.Columns[nameof(AlarmLogDTO.FinishDateTimeString)].HeaderText = "解除時間";
            DGV.Columns[nameof(AlarmLogDTO.FinishDateTimeString)].Width = 250;

            DGV.Columns[nameof(AlarmLogDTO.Code)].Visible = true;
            DGV.Columns[nameof(AlarmLogDTO.Code)].DisplayIndex = 2;
            DGV.Columns[nameof(AlarmLogDTO.Code)].HeaderText = "Alarm編號";
            DGV.Columns[nameof(AlarmLogDTO.Code)].Width = 150;

            DGV.Columns[nameof(AlarmLogDTO.ZhName)].Visible = true;
            DGV.Columns[nameof(AlarmLogDTO.ZhName)].DisplayIndex = 3;
            DGV.Columns[nameof(AlarmLogDTO.ZhName)].HeaderText = "Alarm中文說明";
            DGV.Columns[nameof(AlarmLogDTO.ZhName)].Width = 800;

            DGV.Columns[nameof(AlarmLogDTO.Name)].Visible = true;
            DGV.Columns[nameof(AlarmLogDTO.Name)].DisplayIndex = 4;
            DGV.Columns[nameof(AlarmLogDTO.Name)].HeaderText = "Alarm說明";
            DGV.Columns[nameof(AlarmLogDTO.Name)].Width = 800;

        }

        void UpdateDGV()
        {
            CurrencyManager cm1 = (CurrencyManager)this.DGV.BindingContext[AlarmLogs];
            if (cm1 != null) cm1.Refresh();
        }

        IRecipeController recipeController => ControllerFactory.Get<IRecipeController>();

        private void button2_Click(object sender, EventArgs e)
        {
            var r1 = RecipeController.Search("", Common.Enums.PModeTypes.All,true);
            var fileName1 = String.Format("{0}{1}_(Security C).xls", "Recipe", DateTime.Now.GetString(ExtensionDateTime.OutputTypes.TypeB));
            if (r1.Result)
                ExportController.Export(ExportAction, folderPath, fileName1, r1.Value);


            var fileName = String.Format("{0}{1}_(Security C).xls", "AlarmLogSearch",DateTime.Now.GetString( ExtensionDateTime.OutputTypes.TypeB));
            ExportController.Export(ExportAction, folderPath, fileName, AlarmLogs);
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

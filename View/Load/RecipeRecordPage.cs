using Common.DTO;
using Controller;
using Controller.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Extention;

namespace View.Load
{
    public partial class RecipeRecordPage : Form
    {
        readonly List<RecipeDTO> SearchRecipes = new List<RecipeDTO>(); 
        IRecipeController RecipeController => ControllerFactory.Get<IRecipeController>();

        public RecipeRecordPage(string PanelCode_)
        {
            InitializeComponent();
            SetSearchRecipeDGV();
            var r1 = RecipeController.GetRecord(PanelCode_);
            if (!r1.Result)
            {
                ExMessagePage.Show("查詢Recipen所有修改紀錄失敗", r1.Exception.Message);
                return;
            }
            SearchRecipes.AddRange(r1.Value);
            UpdateDGV();
        }

        void UpdateDGV()
        {
            CurrencyManager cm1 = (CurrencyManager)this.DGV.BindingContext[SearchRecipes];
            if (cm1 != null) cm1.Refresh();
        }

        void SetSearchRecipeDGV()
        {
            DGV.DataSource = this.SearchRecipes;
            DGV.MakeDoubleBuffered();
            DGV.ColumnHeadersHeight = 36;
            DGV.RowTemplate.Height = 36;
            foreach (DataGridViewColumn column in DGV.Columns) column.Visible = false;

            DGV.Columns[nameof(RecipeDTO.ID)].Visible = false;

            //DGV.Columns[nameof(RecipeDTO.CreateDateTimeString)].DisplayIndex = 0;
            DGV.Columns[nameof(RecipeDTO.CreateDateTimeString)].Visible = true;
            DGV.Columns[nameof(RecipeDTO.CreateDateTimeString)].Width = 280;
            DGV.Columns[nameof(RecipeDTO.CreateDateTimeString)].HeaderText = "創建時間";

            //DGV.Columns[nameof(RecipeDTO.EnabeldString)].DisplayIndex = 1;
            DGV.Columns[nameof(RecipeDTO.EnabeldString)].Visible = true;
            DGV.Columns[nameof(RecipeDTO.EnabeldString)].Width = 200;
            DGV.Columns[nameof(RecipeDTO.EnabeldString)].HeaderText = "是否有效";

            //DGV.Columns[nameof(RecipeDTO.PanelCode)].DisplayIndex = 2;
            DGV.Columns[nameof(RecipeDTO.PanelCode)].Visible = true;
            DGV.Columns[nameof(RecipeDTO.PanelCode)].Width = 280;
            DGV.Columns[nameof(RecipeDTO.PanelCode)].HeaderText = nameof(RecipeDTO.PanelCode);

            //DGV.Columns[nameof(RecipeDTO.Quantity)].DisplayIndex = 3;
            DGV.Columns[nameof(RecipeDTO.Quantity)].Visible = true;
            DGV.Columns[nameof(RecipeDTO.Quantity)].Width = 100;
            DGV.Columns[nameof(RecipeDTO.Quantity)].HeaderText = nameof(RecipeDTO.Quantity);

            //DGV.Columns[nameof(RecipeDTO.WBArea)].DisplayIndex = 4;
            DGV.Columns[nameof(RecipeDTO.WBArea)].Visible = true;
            DGV.Columns[nameof(RecipeDTO.WBArea)].Width = 120;
            DGV.Columns[nameof(RecipeDTO.WBArea)].HeaderText = "WB";

            //DGV.Columns[nameof(RecipeDTO.BArea)].DisplayIndex = 5;
            DGV.Columns[nameof(RecipeDTO.BArea)].Visible = true;
            DGV.Columns[nameof(RecipeDTO.BArea)].Width = 120;
            DGV.Columns[nameof(RecipeDTO.BArea)].HeaderText = "B";

            //DGV.Columns[nameof(RecipeDTO.Ni_WB_Adm2)].DisplayIndex = 6;
            DGV.Columns[nameof(RecipeDTO.Ni_WB_Adm2)].Visible = true;
            DGV.Columns[nameof(RecipeDTO.Ni_WB_Adm2)].Width = 120;
            DGV.Columns[nameof(RecipeDTO.Ni_WB_Adm2)].HeaderText = "Ni(W/B)";

            //DGV.Columns[nameof(RecipeDTO.Ni_B_Adm2)].DisplayIndex = 7;
            DGV.Columns[nameof(RecipeDTO.Ni_B_Adm2)].Visible = true;
            DGV.Columns[nameof(RecipeDTO.Ni_B_Adm2)].Width = 120;
            DGV.Columns[nameof(RecipeDTO.Ni_B_Adm2)].HeaderText = "Ni(B)";

            //DGV.Columns[nameof(RecipeDTO.Au_WB_Adm2)].DisplayIndex = 8;
            DGV.Columns[nameof(RecipeDTO.Au_WB_Adm2)].Visible = true;
            DGV.Columns[nameof(RecipeDTO.Au_WB_Adm2)].Width = 120;
            DGV.Columns[nameof(RecipeDTO.Au_WB_Adm2)].HeaderText = "Au(W/B)";

            //DGV.Columns[nameof(RecipeDTO.Au_B_Adm2)].DisplayIndex = 9;
            DGV.Columns[nameof(RecipeDTO.Au_B_Adm2)].Visible = true;
            DGV.Columns[nameof(RecipeDTO.Au_B_Adm2)].Width = 120;
            DGV.Columns[nameof(RecipeDTO.Au_B_Adm2)].HeaderText = "Au(B)";

            //DGV.Columns[nameof(RecipeDTO.AuSt_Adm2)].DisplayIndex = 10;
            DGV.Columns[nameof(RecipeDTO.AuSt_Adm2)].Visible = true;
            DGV.Columns[nameof(RecipeDTO.AuSt_Adm2)].Width = 120;
            DGV.Columns[nameof(RecipeDTO.AuSt_Adm2)].HeaderText = "AuSt";

            //DGV.Columns[nameof(RecipeDTO.Ni_PlatingTime)].DisplayIndex =11;
            DGV.Columns[nameof(RecipeDTO.Ni_PlatingTime)].Visible = true;
            DGV.Columns[nameof(RecipeDTO.Ni_PlatingTime)].Width = 200;
            DGV.Columns[nameof(RecipeDTO.Ni_PlatingTime)].HeaderText = "Ni PTime(sec)";

            //DGV.Columns[nameof(RecipeDTO.Au_PlatingTime)].DisplayIndex = 12;
            DGV.Columns[nameof(RecipeDTO.Au_PlatingTime)].Visible = true;
            DGV.Columns[nameof(RecipeDTO.Au_PlatingTime)].Width = 200;
            DGV.Columns[nameof(RecipeDTO.Au_PlatingTime)].HeaderText = "Au PTime(sec)";

            //DGV.Columns[nameof(RecipeDTO.AuSt_PlatingTime)].DisplayIndex = 13;
            DGV.Columns[nameof(RecipeDTO.AuSt_PlatingTime)].Visible = true;
            DGV.Columns[nameof(RecipeDTO.AuSt_PlatingTime)].Width = 200;
            DGV.Columns[nameof(RecipeDTO.AuSt_PlatingTime)].HeaderText = "AuSt PTime(sec)";

            //DGV.Columns[nameof(RecipeDTO.PMode)].DisplayIndex = 14;
            DGV.Columns[nameof(RecipeDTO.PMode)].Visible = true;
            DGV.Columns[nameof(RecipeDTO.PMode)].Width = 100;
            DGV.Columns[nameof(RecipeDTO.PMode)].HeaderText = "PMode";

            //DGV.Columns[nameof(RecipeDTO.Size)].DisplayIndex = 15;
            DGV.Columns[nameof(RecipeDTO.Size)].Visible = true;
            DGV.Columns[nameof(RecipeDTO.Size)].Width = 100;
            DGV.Columns[nameof(RecipeDTO.Size)].HeaderText = "Size";

            //DGV.Columns[nameof(RecipeDTO.Thickness)].DisplayIndex = 16;
            DGV.Columns[nameof(RecipeDTO.Thickness)].Visible = true;
            DGV.Columns[nameof(RecipeDTO.Thickness)].Width = 200;
            DGV.Columns[nameof(RecipeDTO.Thickness)].HeaderText = "Thickness";

            //DGV.Columns[nameof(RecipeDTO.Remarks)].DisplayIndex = 17;
            DGV.Columns[nameof(RecipeDTO.Remarks)].Visible = true;
            DGV.Columns[nameof(RecipeDTO.Remarks)].Width = 500;
            DGV.Columns[nameof(RecipeDTO.Remarks)].HeaderText = "備註";
        }

    }
}

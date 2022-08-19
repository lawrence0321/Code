using Common;
using Common.Attributes;
using Common.DTO;
using Common.Enums;
using Common.Extension;
using Controller;
using Controller.ExObject;
using Controller.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using View.ExForm;
using View.Extention;
using View.Load;
using static View.ExForm.MessageYesNoPage;
using static View.Load.BasicPage;


namespace View.Recipe
{
    public partial class BasicPage : UserControl
    {
        ILoadController LoadController => ControllerFactory.Get<ILoadController>();
        IRecipeController RecipeController => ControllerFactory.Get<IRecipeController>();
        IUserController UserController => ControllerFactory.Get<IUserController>();


        readonly List<RecipeDTO> SearchRecipes = new List<RecipeDTO>();

        RecipeDTO SelectRecipe;

        string UID => UserController.NowUID;
        bool IsShowShelf => CheckBox_IsShowShelf.Checked;
        string PartRecipeCode => TextBox_Search_PanelCode.Text;
        PModeTypes SelectPMode => (PModeTypes)ComboBox_ProcessMode.SelectedItem;

        public BasicPage()
        {
            InitializeComponent();
            SetSearchRecipeDGV();
            List<PModeTypes> items = new List<PModeTypes>();
            foreach (var item in Enum.GetValues(typeof(PModeTypes))) items.Add((PModeTypes)item);
            ComboBox_ProcessMode.DataSource = items;
            SearchRecipe();
        }

        void SearchRecipe()
        {
            SelectRecipe = null;
            TextBox_DataCount.Text = "-";
            ReSetRecipeDisplay();
            var r1 = RecipeController.Search(PartRecipeCode, SelectPMode, IsShowShelf);
            if (!r1.Result)
            {
                ExMessagePage.Show("查詢Recipe失敗", r1.Exception.Message);
                return;
            }
            var recipes = r1.Value;

            SearchRecipes.Clear();
            SearchRecipes.AddRange(recipes);
            TextBox_DataCount.Text = SearchRecipes.Count.ToString();
            UpdateDGV();
        }

        void SetSearchRecipeDGV()
        {
            DGV.DataSource = this.SearchRecipes;
            DGV.MakeDoubleBuffered();
        }

        void SetColumn()
        {
            DGV.ColumnHeadersHeight = 36;
            DGV.RowTemplate.Height = 36;
            foreach (var property in typeof(RecipeDTO).GetProperties())
            {
                DGV.Columns[property.Name].HeaderText = property.GetCustomAttribute<DisplayAttribute>().ENG;
                DGV.Columns[property.Name].Visible = true;

                switch (property.Name)
                {
                    case nameof(RecipeDTO.DisplayCode):
                        DGV.Columns[property.Name].Width = 280;
                        break;
                    case nameof(RecipeDTO.Quantity):
                        DGV.Columns[property.Name].Width = 100;
                        break;
                    case nameof(RecipeDTO.WBArea):
                        DGV.Columns[property.Name].Width = 120;
                        break;
                    case nameof(RecipeDTO.BArea):
                        DGV.Columns[property.Name].Width = 120;
                        break;
                    case nameof(RecipeDTO.Ni_WB_Adm2):
                        DGV.Columns[property.Name].Width = 120;
                        break;
                    case nameof(RecipeDTO.Ni_B_Adm2):
                        DGV.Columns[property.Name].Width = 120;
                        break;
                    case nameof(RecipeDTO.Au_WB_Adm2):
                        DGV.Columns[property.Name].Width = 120;
                        break;
                    case nameof(RecipeDTO.Au_B_Adm2):
                        DGV.Columns[property.Name].Width = 120;
                        break;
                    case nameof(RecipeDTO.AuSt_Adm2):
                        DGV.Columns[property.Name].Width = 120;
                        break;
                    case nameof(RecipeDTO.Ni_PlatingTime):
                        DGV.Columns[property.Name].Width = 200;
                        break;
                    case nameof(RecipeDTO.Au_PlatingTime):
                        DGV.Columns[property.Name].Width = 200;
                        break;
                    case nameof(RecipeDTO.AuSt_PlatingTime):
                        DGV.Columns[property.Name].Width = 200;
                        break;
                    case nameof(RecipeDTO.PMode):
                        DGV.Columns[property.Name].Width = 100;
                        break;
                    case nameof(RecipeDTO.Size):
                        DGV.Columns[property.Name].Width = 100;
                        break;
                    case nameof(RecipeDTO.Thickness):
                        DGV.Columns[property.Name].Width = 100;
                        break;
                    default:
                        DGV.Columns[property.Name].Visible = false;
                        break;
                }
            }
        }

        void UpdateDGV()
        {
            CurrencyManager cm1 = (CurrencyManager)this.DGV.BindingContext[SearchRecipes];
            if (cm1 != null) cm1.Refresh();
            SetColumn();
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV.SelectedRows.Count == 0) return;

            string panelCode = DGV.SelectedRows[0].Cells[nameof(RecipeDTO.PanelCode)].Value.ToString();

            var r1 = RecipeController.Get(panelCode);
            if (!r1.Result)
            {
                ExMessagePage.Show("取得Recipe失敗", r1.Exception.Message);
                return;
            }

            var recipe = r1.Value;
            SelectRecipe = recipe;
            UpDateRecipeDisplay(recipe);
        }

        #region RecipeDisplay
        void UpDateRecipeDisplay(RecipeDTO Recipe_)
        {
            this.TextBox_PanelCode.Text = Recipe_.PanelCode;
            this.TextBox_PMode.Text = Recipe_.PMode;
            this.TextBox_Size.Text = Recipe_.Size;
            this.TextBox_Remarks.Text = Recipe_.Remarks;

            this.NumUpDown_Quantity.Value = Recipe_.Quantity;
            this.NumUpDown_Thickness.Value = Recipe_.Thickness;
            this.NumUpDown_WB.Value = Recipe_.WBArea;
            this.NumUpDown_B.Value = Recipe_.BArea;

            this.NumUpDown_NI_WB_Adm2.Value = Convert.ToDecimal(Recipe_.Ni_WB_Adm2);
            this.NumUpDown_NI_B_Adm2.Value = Convert.ToDecimal(Recipe_.Ni_B_Adm2);
            this.TextBox_Ni_PT.Text = Convert.ToUInt64(Recipe_.Ni_PlatingTime).ToTimeString();

            this.NumUpDown_AuSt_Adm2.Value = Convert.ToDecimal(Recipe_.AuSt_Adm2);
            this.TextBox_AuSt_PT.Text = Convert.ToUInt64(Recipe_.AuSt_PlatingTime).ToTimeString();

            this.NumUpDown_AU_WB_Adm2.Value = Convert.ToDecimal(Recipe_.Au_WB_Adm2);
            this.NumUpDown_AU_B_Adm2.Value = Convert.ToDecimal(Recipe_.Au_B_Adm2);
            this.TextBox_Au_PT.Text = Convert.ToUInt64(Recipe_.Au_PlatingTime).ToTimeString();


            this.NumUpDown_NI_WB.Value = Convert.ToDecimal(LoadDataLogic.GetCurrent(Recipe_, LoadDataLogic.CurrentTypes.Ni, LoadDataLogic.AreaTypes.WB));
            this.NumUpDown_NI_B.Value = Convert.ToDecimal(LoadDataLogic.GetCurrent(Recipe_, LoadDataLogic.CurrentTypes.Ni, LoadDataLogic.AreaTypes.B));
            this.NumUpDown_AuSt.Value = Convert.ToDecimal(LoadDataLogic.GetCurrent(Recipe_, LoadDataLogic.CurrentTypes.AuSt, LoadDataLogic.AreaTypes.none));
            this.NumUpDown_Au_WB.Value = Convert.ToDecimal(LoadDataLogic.GetCurrent(Recipe_, LoadDataLogic.CurrentTypes.Au, LoadDataLogic.AreaTypes.WB));
            this.NumUpDown_Au_B.Value = Convert.ToDecimal(LoadDataLogic.GetCurrent(Recipe_, LoadDataLogic.CurrentTypes.Au, LoadDataLogic.AreaTypes.B));

        }

        void ReSetRecipeDisplay()
        {
            this.TextBox_PanelCode.Text = String.Empty;
            this.TextBox_PMode.Text = String.Empty;
            this.TextBox_Size.Text = String.Empty;
            this.TextBox_Remarks.Text = String.Empty;

            this.NumUpDown_Quantity.Value = 0;
            this.NumUpDown_Thickness.Value = 0;
            this.NumUpDown_WB.Value = 0;
            this.NumUpDown_B.Value = 0;

            this.NumUpDown_NI_WB_Adm2.Value = 0;
            this.NumUpDown_NI_B_Adm2.Value = 0;
            this.TextBox_Ni_PT.Text = "00:00:00";

            this.NumUpDown_AuSt_Adm2.Value = 0;
            this.TextBox_AuSt_PT.Text = "00:00:00";

            this.NumUpDown_AU_WB_Adm2.Value = 0;
            this.NumUpDown_AU_B_Adm2.Value = 0;
            this.TextBox_Au_PT.Text = "00:00:00";

            this.NumUpDown_NI_WB.Value = 0;
            this.NumUpDown_NI_B.Value = 0;
            this.NumUpDown_AuSt.Value = 0;
            this.NumUpDown_Au_WB.Value = 0;
            this.NumUpDown_Au_B.Value = 0;
        }
        #endregion


        static MessageYesNoPage _MessageYesNoPage;
        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            if (SelectRecipe is null)
            {
                ExMessagePage.Show("警告", "尚未選擇Recipe");
                return;
            }
            if (_MessageYesNoPage != null)
            {
                _MessageYesNoPage.Close();
                _MessageYesNoPage.Dispose();
                _MessageYesNoPage = null;
            }

            _MessageYesNoPage = new MessageYesNoPage("警告", String.Format("是否要刪除{0}此Recipe.", SelectRecipe.PanelCode), DeleteSelectReback);
            _MessageYesNoPage.Show();
        }
        void DeleteSelectReback(YesNo YesNo_)
        {
            if (YesNo_ == YesNo.Yes)
            {
                var r1 = RecipeController.Remove(SelectRecipe.PanelCode, UID);
                if (!r1.Result)
                    ExMessagePage.Show("刪除Recipe失敗", r1.Exception.Message);
                else
                    ExMessagePage.Show("刪除Recipe成功", String.Format("[{0}]Recipe 已被刪除.", SelectRecipe.PanelCode));

                SearchRecipe();
            }
        }

        static EditRecipePage EditRecipePage;
        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            if (SelectRecipe is null)
            {
                ExMessagePage.Show("警告", "尚未選擇Recipe");
                return;
            }
            if (EditRecipePage != null)
            {
                EditRecipePage.Close();
                EditRecipePage.Dispose();
                EditRecipePage = null;
            }
            EditRecipePage = new EditRecipePage(SelectRecipe.PanelCode, UID, SearchRecipe);
            EditRecipePage.Show();
        }

        private void Btn_Copy_Click(object sender, EventArgs e)
        {
            if (SelectRecipe is null)
            {
                ExMessagePage.Show("警告", "尚未選擇Recipe");
                return;
            }
            if (EditRecipePage != null)
            {
                EditRecipePage.Close();
                EditRecipePage.Dispose();
                EditRecipePage = null;
            }
            EditRecipePage = new EditRecipePage(SelectRecipe, UID, SearchRecipe);
            EditRecipePage.Show();
        }

        private void Btn_Create_Click(object sender, EventArgs e)
        {
            if (EditRecipePage != null)
            {
                EditRecipePage.Close();
                EditRecipePage.Dispose();
                EditRecipePage = null;
            }
            EditRecipePage = new EditRecipePage(UID, SearchRecipe);
            EditRecipePage.Show();
        }


        static RecipeRecordPage _RecipeRecordPage;
        private void Btn_EditLog_Click(object sender, EventArgs e)
        {
            if (SelectRecipe is null)
            {
                ExMessagePage.Show("警告", "尚未選擇Recipe");
                return;
            }
            if (!(_RecipeRecordPage is null))
            {
                _RecipeRecordPage.Close();
                _RecipeRecordPage.Dispose();
                _RecipeRecordPage = null;
            }
            _RecipeRecordPage = new RecipeRecordPage(SelectRecipe.PanelCode);
            _RecipeRecordPage.Show();
        }

        private void TextBox_Search_PanelCode_TextChanged(object sender, EventArgs e) => SearchRecipe();

        private void ComboBox_ProcessMode_SelectedIndexChanged(object sender, EventArgs e) => SearchRecipe();

        private void CheckBox_IsShowShelf_CheckedChanged(object sender, EventArgs e) => SearchRecipe();

    }
}

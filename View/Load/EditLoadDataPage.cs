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
using static View.ExForm.MessageYesNoPage;
using static View.Load.BasicPage;

namespace View.Load
{
    public partial class EditLoadDataPage : Form
    {
        const string DummyLot = "(RackOnly)";

        readonly string UID;
        readonly string OrgLoadDataID;
        readonly string OrgLoadDataCode;
        readonly long OrgSortTimeTicks;

        readonly List<RecipeDTO> SearchRecipes = new List<RecipeDTO>();

        LoadDataDTO LoadData;
        RecipeDTO SelectRecipe;

        ILoadController LoadController => ControllerFactory.Get<ILoadController>();
        IRecipeController RecipeController => ControllerFactory.Get<IRecipeController>();

        string PartRecipeCode => TextBox_Search_PanelCode.Text;
        PModeTypes SelectPMode => (PModeTypes)ComboBox_ProcessMode.SelectedItem;
        bool IsShowShelf => CheckBox_IsShowShelf.Checked;

        public EditLoadDataPage(string LoadDataID_, string UID_)
        {
            InitializeComponent();
            SetSearchRecipeDGV();
            List<PModeTypes> items = new List<PModeTypes>();
            foreach (var item in Enum.GetValues(typeof(PModeTypes))) items.Add((PModeTypes)item);
            ComboBox_ProcessMode.DataSource = items;


            var r1 = LoadController.Get(LoadDataID_);
            if (!r1.Result)
            {
                ExMessagePage.Show("取得LoadData失敗", r1.Exception.Message);
                this.Close();
                return;
            }
            LoadData = r1.Value;
            OrgLoadDataID = LoadData.ID;
            OrgLoadDataCode = LoadData.Code;
            OrgSortTimeTicks = LoadData.SortTimeTicks;
            UID = UID_;
            UpdateViewLoadData();

            SearchRecipe();
        }

        private void Btn_1_GetData_Click(object sender, EventArgs e)
        {
            if (SelectRecipe == null)
            {
                ExMessagePage.Show("警告", "尚未選擇Recipe.");
                return;
            }
            RecipeDTO secondRecipe;
            if (LoadData.Second_RecipeCode != RecipeController.DummyRecipe.PanelCode)
            {
                var r1 = RecipeController.Get(LoadData.Second_RecipeCode);
                if (!r1.Result)
                {
                    ExMessagePage.Show("取得第二掛Recipe發生錯誤", r1.Exception.Message);
                    return;
                }
                secondRecipe = r1.Value;
            }
            else
            {
                secondRecipe = RecipeController.DummyRecipe;
            }

            if (this.LoadData.First_IsEmpty) this.LoadData.First_LotCode = String.Empty;
            
            this.LoadData = LoadDataLogic.Create(LoadSourceTypes.Custom, UID, LoadData.First_LotCode, SelectRecipe, LoadData.Second_LotCode, secondRecipe);
            UpdateViewLoadData();
        }

        private void Btn_2_GetData_Click(object sender, EventArgs e)
        {
            if (SelectRecipe == null)
            {
                ExMessagePage.Show("警告", "尚未選擇Recipe.");
                return;
            }
            RecipeDTO firstRecipe;
            if (LoadData.First_RecipeCode != RecipeController.DummyRecipe.PanelCode)
            {
                var r1 = RecipeController.Get(LoadData.First_RecipeCode);
                if (!r1.Result)
                {
                    ExMessagePage.Show("取得第一掛Recipe發生錯誤", r1.Exception.Message);
                    return;
                }
                firstRecipe = r1.Value;
            }
            else
            {
                firstRecipe = RecipeController.DummyRecipe;
            }

            if (this.LoadData.Second_IsEmpty) this.LoadData.Second_LotCode = String.Empty;
            
            this.LoadData = LoadDataLogic.Create(LoadSourceTypes.Custom, UID, LoadData.First_LotCode, firstRecipe, LoadData.Second_LotCode, SelectRecipe);
            UpdateViewLoadData();
        }


        private void CheckBox_1_Empty_CheckedChanged(object sender, EventArgs e)
        {
            this.Btn_CopyFormBot.Enabled = !CheckBox_1_Empty.Checked;
            this.Btn_1_GetData.Enabled = !CheckBox_1_Empty.Checked;

            if (CheckBox_1_Empty.Checked)
            {
                RecipeDTO secondRecipe;
                if (LoadData.Second_RecipeCode != RecipeController.DummyRecipe.PanelCode)
                {
                    var r1 = RecipeController.Get(LoadData.Second_RecipeCode);
                    if (!r1.Result)
                    {
                        ExMessagePage.Show("取得第二掛Recipe發生錯誤", r1.Exception.Message);
                        return;
                    }
                    secondRecipe = r1.Value;
                }
                else
                {
                    secondRecipe = RecipeController.DummyRecipe;
                }

                this.LoadData = LoadDataLogic.Create(LoadSourceTypes.Custom, UID, DummyLot, RecipeController.DummyRecipe, LoadData.Second_LotCode, secondRecipe);
            }
            UpdateViewLoadData();
        }

        private void CheckBox_2_Empty_CheckedChanged(object sender, EventArgs e)
        {
            this.Btn_CopyFormTop.Enabled = !CheckBox_2_Empty.Checked;
            this.Btn_2_GetData.Enabled = !CheckBox_2_Empty.Checked;

            if (CheckBox_2_Empty.Checked)
            {
                RecipeDTO firstRecipe;
                if (LoadData.First_RecipeCode != RecipeController.DummyRecipe.PanelCode)
                {
                    var r1 = RecipeController.Get(LoadData.First_RecipeCode);
                    if (!r1.Result)
                    {
                        ExMessagePage.Show("取得第一掛Recipe發生錯誤", r1.Exception.Message);
                        return;
                    }
                    firstRecipe = r1.Value;
                }
                else
                {
                    firstRecipe = RecipeController.DummyRecipe;
                }

                this.LoadData = LoadDataLogic.Create(LoadSourceTypes.Custom, UID, LoadData.First_LotCode,firstRecipe, DummyLot, RecipeController.DummyRecipe);
            }
            UpdateViewLoadData();
        }

        private void Btn_CopyFormBot_Click(object sender, EventArgs e)
        {
            this.LoadData.Second_LotCode = TextBox_2_LotNo.Text;

            var properties = typeof(LoadDataDTO).GetProperties().Where(p => p.Name.Contains("Second_")).ToList();

            foreach (var property in properties)
                typeof(LoadDataDTO).GetProperty(property.Name.Replace("Second_", "First_")).SetValue(this.LoadData, property.GetValue(this.LoadData));

            //var r1 = RecipeController.Get(LoadData.Second_RecipeCode);
            //if (!r1.Result)
            //{
            //    ExMessagePage.Show("取得第二掛Recipe發生錯誤", r1.Exception.Message);
            //    return;
            //}
            //var secondRecipe = r1.Value;    

            //this.LoadData = LoadDataLogic.Create(LoadSourceTypes.Custom, UID, LoadData.Second_LotCode, secondRecipe, LoadData.Second_LotCode, secondRecipe);
            UpdateViewLoadData();
        }

        private void Btn_CopyFormTop_Click(object sender, EventArgs e)
        {
            this.LoadData.First_LotCode = TextBox_1_LotNo.Text;

            var properties = typeof(LoadDataDTO).GetProperties().Where(p => p.Name.Contains("First_")).ToList();

            foreach (var property in properties)
                typeof(LoadDataDTO).GetProperty(property.Name.Replace("First_", "Second_")).SetValue(this.LoadData, property.GetValue(this.LoadData));

            //var r1 = RecipeController.Get(LoadData.First_RecipeCode);
            //if (!r1.Result)
            //{
            //    ExMessagePage.Show("取得第一掛Recipe發生錯誤", r1.Exception.Message);
            //    return;
            //}
            //var firstRecipe = r1.Value;

            //this.LoadData = LoadDataLogic.Create(LoadSourceTypes.Custom, UID, LoadData.First_LotCode, firstRecipe, LoadData.First_LotCode, firstRecipe);
            UpdateViewLoadData();
        }

        public void UpdateViewLoadData()
        {
            LoadDataDTO loadData = LoadData;

            TextBox_1_LotNo.Text = loadData.First_LotCode;
            TextBox_1_PanelCode.Text = loadData.First_RecipeCode;
            TextBox_1_PMode.Text = loadData.First_PMode;
            TextBox_1_Quantity.Text = loadData.First_Quantity.ToString();

            TextBox_WB_Au_1.Text = loadData.First_Au_WB_Current.ToString();
            TextBox_B_Au_1.Text = loadData.First_Au_B_Current.ToString();
            TextBox_PTime_Au_1.Text = loadData.First_Au_PTime.ToString();

            TextBox_WB_Ni_1.Text = loadData.First_Ni_WB_Current.ToString();
            TextBox_B_Ni_1.Text = loadData.First_Ni_B_Current.ToString();
            TextBox_PTime_Ni_1.Text = loadData.First_Ni_PTime.ToString();

            TextBox_AuSt_1.Text = loadData.First_AuSt_Current.ToString();
            TextBox_PTime_AuSt_1.Text = loadData.First_AuSt_PTime.ToString();

            TextBox_2_LotNo.Text = loadData.Second_LotCode;
            TextBox_2_PanelCode.Text = loadData.Second_RecipeCode;
            TextBox_2_PMode.Text = loadData.Second_PMode;
            TextBox_2_Quantity.Text = loadData.Second_Quantity.ToString();

            TextBox_WB_Au_2.Text = loadData.Second_Au_WB_Current.ToString();
            TextBox_B_Au_2.Text = loadData.Second_Au_B_Current.ToString();
            TextBox_PTime_Au_2.Text = loadData.Second_Au_PTime.ToString();

            TextBox_WB_Ni_2.Text = loadData.Second_Ni_WB_Current.ToString();
            TextBox_B_Ni_2.Text = loadData.Second_Ni_B_Current.ToString();
            TextBox_PTime_Ni_2.Text = loadData.Second_Ni_PTime.ToString();

            TextBox_AuSt_2.Text = loadData.Second_AuSt_Current.ToString();
            TextBox_PTime_AuSt_2.Text = loadData.Second_AuSt_PTime.ToString();
        }


        private void Btn_Enter_Click(object sender, EventArgs e)
        {
            LoadData.ID = OrgLoadDataID;
            LoadData.Code = OrgLoadDataCode;
            LoadData.SortTimeTicks = OrgSortTimeTicks;
            LoadData.First_LotCode = TextBox_1_LotNo.Text;
            LoadData.Second_LotCode = TextBox_2_LotNo.Text;

            if (LoadData.First_LotCode.IsEmpty())
            {
                ExMessagePage.Show("警告", "第一掛尚未輸入LotCode.");
                return;
            }
            if (LoadData.Second_LotCode.IsEmpty())
            {
                ExMessagePage.Show("警告", "第二掛尚未輸入LotCode.");
                return;
            }
            var r1 = LoadController.EditLoadData(LoadData, UID);
            if (!r1.Result)
            {
                ExMessagePage.Show("編輯LoadData失敗", r1.Exception.Message);
                return;
            }
            this.Close();
        }

        private void TextBox_Search_PanelCode_TextChanged(object sender, EventArgs e) => SearchRecipe();
        private void CheckBox_IsShowShelf_CheckedChanged(object sender, EventArgs e) => SearchRecipe();
        private void ComboBox_ProcessMode_SelectedIndexChanged(object sender, EventArgs e) => SearchRecipe();

        void SearchRecipe()
        {
            this.Btn_Close.Enabled = true;

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
            DGV.ColumnHeadersHeight = 36;
            DGV.RowTemplate.Height = 36;
        }

        void SetColumn()
        {
            foreach (var property in typeof(RecipeDTO).GetProperties())
            {
                DGV.Columns[property.Name].HeaderText = property.GetCustomAttribute<DisplayAttribute>().ENG;
                DGV.Columns[property.Name].Visible = true;

                switch (property.Name)
                {
                    case nameof(RecipeDTO.PanelCode):
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
            this.NumUpDown_AU_B_Adm2.Value = Convert.ToDecimal(Recipe_.Au_WB_Adm2);
            this.TextBox_Au_PT.Text = Convert.ToUInt64(Recipe_.Au_PlatingTime).ToTimeString();
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
            this.Btn_Close.Enabled = false;
            _MessageYesNoPage = new MessageYesNoPage("警告", String.Format("是否要刪除{0}此Recipe.", SelectRecipe.PanelCode), DeleteSelectReback);
            _MessageYesNoPage.Show();
        }
        void DeleteSelectReback(YesNo YesNo_)
        {
            this.Btn_Close.Enabled = true;

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
            this.Btn_Close.Enabled = false;

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

            this.Btn_Close.Enabled = false;

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

            this.Btn_Close.Enabled = false;

            EditRecipePage = new EditRecipePage(UID, SearchRecipe);
            EditRecipePage.Show();
        }

        private void Btn_Close_Click(object sender, EventArgs e)
            => this.Close();
    }
}

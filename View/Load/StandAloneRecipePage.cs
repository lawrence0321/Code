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
    public partial class StandAloneRecipePage : Form
    {
        readonly AddLoadDataTypes AddLoadDataType;
        readonly long AfterLoadDataSortTimeTicks;
        readonly string UID;

        static RecipeRecordPage RecipeRecordPage;
        IMESController MESController => ControllerFactory.Get<IMESController>();
        IUserController WhiteListController => ControllerFactory.Get<IUserController>();
        ILoadController LoadController => ControllerFactory.Get<ILoadController>();
        IRecipeController RecipeController => ControllerFactory.Get<IRecipeController>();

        bool IsdRackOnly = false;
        bool IsSpecialMode => CheckBox_SpecialCrane.Checked;
        bool IsShowShelf => CheckBox_IsShowShelf.Checked;
        int CraneQuantity => Convert.ToInt32(NumUpDown_CarQuantity.Value);
        int TotalQuantity => Convert.ToInt32(NumUpDown_TotalQuantity.Value);
        string LotCode => TextBox_LotNo.Text;
        string PartRecipeCode => TextBox_Search_PanelCode.Text;
        PModeTypes SelectPMode => (PModeTypes)ComboBox_ProcessMode.SelectedItem;

        readonly List<RecipeDTO> SearchRecipes = new List<RecipeDTO>();

        RecipeDTO SelectRecipe;

        public StandAloneRecipePage()
        {
            InitializeComponent();
            SetSearchRecipeDGV();
            List<PModeTypes> items = new List<PModeTypes>();
            foreach (var item in Enum.GetValues(typeof(PModeTypes))) items.Add((PModeTypes)item);
            ComboBox_ProcessMode.DataSource = items;
            SearchRecipe();
        }

        public StandAloneRecipePage(long afterLoadDataSortTimeTicks_, string UID_) : this()
        {
            AddLoadDataType = AddLoadDataTypes.PlugIn;
            AfterLoadDataSortTimeTicks = afterLoadDataSortTimeTicks_;
            UID = UID_;
            this.Label_ShowMod.Text = "插入模式";
        }
        public StandAloneRecipePage(string UID_) : this()
        {
            AddLoadDataType = AddLoadDataTypes.Enqueue;
            AfterLoadDataSortTimeTicks = 0;
            UID = UID_;
            this.Label_ShowMod.Text = "加入模式(新增在最後一筆)";
        }

        private void CheckBox_RockOnly_CheckedChanged(object sender, EventArgs e)
        {
            this.IsdRackOnly = CheckBox_RockOnly.Checked;
            if (CheckBox_RockOnly.Checked)
            {
                this.TextBox_LotNo.Text = "Rack Only";
                this.TextBox_LotNo.ReadOnly = CheckBox_RockOnly.Checked;
                this.Size = new System.Drawing.Size(1799, 137);
                this.MaximumSize = new System.Drawing.Size(1799, 137);
            }
            else
            {
                this.TextBox_LotNo.Text = String.Empty;
                this.TextBox_LotNo.ReadOnly = CheckBox_RockOnly.Checked;
                this.MaximumSize = new System.Drawing.Size(1799, 1021);
                this.Size = new System.Drawing.Size(1799, 1021);
            }

            this.Label_TotalQuantity.Visible = !CheckBox_RockOnly.Checked;
            this.NumUpDown_TotalQuantity.Visible = !CheckBox_RockOnly.Checked;
            this.CheckBox_SpecialCrane.Visible = !CheckBox_RockOnly.Checked;

            this.Label_CarQuantity.Visible = CheckBox_RockOnly.Checked;
            this.NumUpDown_CarQuantity.Visible = CheckBox_RockOnly.Checked;

            this.panel4.SetEnabled(!CheckBox_RockOnly.Checked);

        }
        private void Btn_AutoEnter_Click(object sender, EventArgs e)
        {
            if (IsdRackOnly == false)
            {
                var sendADC = MESController.SendATC(LotCode, SelectRecipe.PanelCode);
                if (!sendADC.Result)
                {
                    ExMessagePage.Show("警告", String.Format("※發送ADC資訊失敗或ARMS檢測奧規，拒絕後續操作。失敗原因:{0}", sendADC.Exception.Message));
                    return;
                }
                else
                {
                    _Btn_AutoEnter_Click(sender, e);
                }
            }
            else
            {
                _Btn_AutoEnter_Click(sender, e);
            }
        }


        private void _Btn_AutoEnter_Click(object sender, EventArgs e)
        {
            if (IsdRackOnly == false)
            {
                if (LotCode == String.Empty)
                {
                    ExMessagePage.Show("警告", "尚未輸入LotNo.");
                    return;
                }
                if (SelectRecipe == null)
                {
                    ExMessagePage.Show("警告", "尚未選擇Recipe.");
                    return;
                }
            }

            if (IsdRackOnly)
            {
                if (CraneQuantity == 0)
                {
                    ExMessagePage.Show("警告", "總車數為0.");
                    return;
                }
            }
            else
            {
                if (LotCode == String.Empty)
                {
                    ExMessagePage.Show("警告", "尚未輸入LotNo.");
                    return;
                }
                if (SelectRecipe == null)
                {
                    ExMessagePage.Show("警告", "尚未選擇Recipe.");
                    return;
                }
                if (TotalQuantity == 0)
                {
                    ExMessagePage.Show("警告", "總掛數為0.");
                    return;
                }
                if (SelectRecipe.Quantity!= 4 && SelectRecipe.Quantity != TotalQuantity)
                {
                    ExMessagePage.Show("警告", "選擇Recipe數量不為4片且總片數與Recipe數量不合.");
                    return;
                }

                if (DGV.SelectedRows.Count > 0)
                {
                    var dgvSelectPanelCode = DGV.SelectedRows[0].Cells[nameof(RecipeDTO.PanelCode)].Value.ToString();
                    var viewSelectPanelCode = SelectRecipe.PanelCode;

                    if (dgvSelectPanelCode != viewSelectPanelCode)
                    {
                        var message = MessageBox.Show("清單上選擇的項目與左邊顯示的不同，左邊顯示的Recipe是否就是下料Recipe?", "警告", MessageBoxButtons.YesNo);
                        if (message == DialogResult.No)
                            return;
                    }
                }
            }

            List<LoadDataDTO> loadDatas;
            if (IsdRackOnly)
            {
                var r1 = LoadController.CreateDummyLoadData(CraneQuantity, UID);
                if (!r1.Result)
                {
                    ExMessagePage.Show("產生空掛LoadData失敗", r1.Exception.Message);
                    return;
                }
                loadDatas = r1.Value;
            }
            else
            {
                var r1 = LoadController.CreateLoadDataByCustom(IsSpecialMode, TotalQuantity, LotCode, UID, SelectRecipe);
                if (!r1.Result)
                {
                    ExMessagePage.Show("產生LoadData失敗", r1.Exception.Message);
                    return;
                }
                loadDatas = r1.Value;
            }

            ActResult r2;
            switch (AddLoadDataType)
            {
                case AddLoadDataTypes.Enqueue:
                    r2 = LoadController.Enqueue(loadDatas, UID);
                    break;
                case AddLoadDataTypes.PlugIn:
                    r2 = LoadController.PlugIn(loadDatas, AfterLoadDataSortTimeTicks, UID);
                    break;
                default:
                    r2 = new ActResult(new Exception(String.Format("尚未支援此作業類型:{0}", AddLoadDataType.ToString())));
                    return;
            }
            if (!r2.Result)
            {
                ExMessagePage.Show(String.Format("{0}LoadData失敗", AddLoadDataType == AddLoadDataTypes.Enqueue ? "加入" : "插入"), r2.Exception.Message);
                return;
            }
            this.Close();
        }

        private void TextBox_Search_PanelCode_TextChanged(object sender, EventArgs e) => SearchRecipe();
        private void ComboBox_ProcessMode_SelectedIndexChanged(object sender, EventArgs e) => SearchRecipe();
        private void CheckBox_IsShowShelf_CheckedChanged(object sender, EventArgs e) => SearchRecipe();

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
            this.Btn_Close.Enabled = true;
            CurrencyManager cm1 = (CurrencyManager)this.DGV.BindingContext[SearchRecipes];
            if (cm1 != null) cm1.Refresh();
            SetColumn();
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV.SelectedRows.Count == 0) return;

            string panelCode = DGV.SelectedRows[0].Cells[nameof(RecipeDTO.PanelCode)].Value.ToString();

            var r1  = RecipeController.Get(panelCode);
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


        private void Btn_EditLog_Click(object sender, EventArgs e)
        {
            if (SelectRecipe is null)
            {
                ExMessagePage.Show("警告","尚未選擇Recipe");
                return;
            }
            if(! (RecipeRecordPage is null))
            {
                RecipeRecordPage.Close();
                RecipeRecordPage.Dispose();
                RecipeRecordPage = null;
            }
            RecipeRecordPage = new RecipeRecordPage(SelectRecipe.PanelCode);
            RecipeRecordPage.Show();
        }


        static MessageYesNoPage _MessageYesNoPage;
        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            if (!WhiteListController.Certification(UserAuthority.EditRecipe))
            {
                ExMessagePage.Show("警告", "工號權限不足");
                return;
            }

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

            _MessageYesNoPage = new MessageYesNoPage("警告",String.Format("是否要刪除{0}此Recipe.",SelectRecipe.PanelCode), DeleteSelectReback);
            _MessageYesNoPage.Show();
            this.Btn_Close.Enabled = false;
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
            if (!WhiteListController.Certification(UserAuthority.EditRecipe))
            {
                ExMessagePage.Show("警告", "工號權限不足");
                return;
            }

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
            EditRecipePage = new EditRecipePage(SelectRecipe.PanelCode,UID, SearchRecipe);
            EditRecipePage.Show();
            this.Btn_Close.Enabled = false;
        }

        private void Btn_Copy_Click(object sender, EventArgs e)
        {
            if (!WhiteListController.Certification(UserAuthority.EditRecipe))
            {
                ExMessagePage.Show("警告", "工號權限不足");
                return;
            }

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
            this.Btn_Close.Enabled = false;
        }

        private void Btn_Create_Click(object sender, EventArgs e)
        {
            if (!WhiteListController.Certification(UserAuthority.EditRecipe))
            {
                ExMessagePage.Show("警告", "工號權限不足");
                return;
            }

            if (EditRecipePage != null)
            {
                EditRecipePage.Close();
                EditRecipePage.Dispose();
                EditRecipePage = null;
            }
            EditRecipePage = new EditRecipePage(UID, SearchRecipe);
            EditRecipePage.Show();
            this.Btn_Close.Enabled =false;
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

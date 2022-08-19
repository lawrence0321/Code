using Common;
using Common.DTO;
using Common.Enums;
using Common.Extension;
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
using View.ExForm;
using static View.ExForm.MessageYesNoPage;

namespace View.Load
{

    public partial class EditRecipePage : Form
    {
        public enum EditMode
        {
            Insert,
            Edit,
            Copy,
        }
        IRecipeController RecipeController => ControllerFactory.Get<IRecipeController>();
        IMESController MESController => ControllerFactory.Get<IMESController>();

        readonly EditMode NowEditMode;
        readonly Action ReSearchRecipe;
        readonly RecipeDTO Recipe;
        readonly string UID;

        //const double AuSt_Adm2 = 1.8;
        //const int Ni_PTime = 2010;
        //const int Au_PTime = 290;
        //const int AuSt_PTime = 20;

        EditRecipePage()
        {
            InitializeComponent();
            InitializeCombox();

            this.label16.Text = "( AuSt )電流值 = (正面面積+背面面積) x 4 x "+ RecipeController .NowCurrentConfig.AuSt_Current.ToString()+ "(電流密度) ÷ 10000";
            this.TextBox_AuSt_Adm2.Text = RecipeController.NowCurrentConfig.AuSt_Current.ToString();
        }

        void InitializeCombox()
        {
            this.ComboBox_ProcessMode.Items.Clear();
            this.ComboBox_Size.Items.Clear();

            foreach (PModeTypes value in Enum.GetValues(typeof(PModeTypes)))
            {
                if (value == PModeTypes.All) continue;
                this.ComboBox_ProcessMode.Items.Add(value.ToString());
            }

            foreach (SizeTypes value in Enum.GetValues(typeof(SizeTypes)))
            {
                this.ComboBox_Size.Items.Add(value.ToString());
            }
        }

        public EditRecipePage(string RecipeCode_,string UID_,Action ReSearchRecipe_):this()
        {
            var r1 = RecipeController.Get(RecipeCode_);
            if (!r1.Result)
            {
                ExMessagePage.Show(String.Format("取得{0}Recipe資料失敗", RecipeCode_), r1.Exception.Message);
                Btn_Cancel.PerformClick();
            }
            this.TextBox_PanelCode.ReadOnly = true;
            NowEditMode = EditMode.Edit;
            ReSearchRecipe = ReSearchRecipe_;
            Recipe = r1.Value;
            UID = UID_;
            ChangeTitle();
            UpdateView();
        }


        public EditRecipePage(RecipeDTO Recipe_, string UID_, Action ReSearchRecipe_) : this()
        {
            NowEditMode = EditMode.Copy;
            ReSearchRecipe = ReSearchRecipe_;
            Recipe = Recipe_;
            UID = UID_;
            ChangeTitle();
            UpdateView();
        }

        public EditRecipePage(string UID_, Action ReSearchRecipe_) : this()
        {
            NowEditMode = EditMode.Insert;
            ReSearchRecipe = ReSearchRecipe_;
            Recipe = new RecipeDTO()
            {
                PMode = PModeTypes.A.ToString(),
                Size = SizeTypes.SMALL.ToString(),
                Ni_PlatingTime = RecipeController.NowProcessConfig.ProcessA_AuSt,
                Au_PlatingTime = RecipeController.NowProcessConfig.ProcessA_Au, 
                AuSt_Adm2 = RecipeController.NowCurrentConfig.AuSt_Current, 
                AuSt_PlatingTime = RecipeController.NowProcessConfig.ProcessA_AuSt
            };
            UID = UID_;
            ChangeTitle();
            UpdateView();
        }

        void ChangeTitle()
        {
            switch (NowEditMode)
            {
                case EditMode.Copy:
                    this.label_ViewMode.Text = "複製新增";
                    break;
                case EditMode.Edit:
                    this.label_ViewMode.Text = "編輯";
                    break;
                case EditMode.Insert:
                    this.label_ViewMode.Text = "新增";
                    break;
            }
        }
        private void Btn_OK_Click(object sender, EventArgs e)
        {
            UpdateRecipe();
            switch (NowEditMode)
            {
                case EditMode.Insert:
                    var r1 = RecipeController.Create(Recipe, UID);
                    if (!r1.Result)
                    {
                        ExMessagePage.Show("新增Recipe 失敗", r1.Exception.Message);
                        return;
                    }
                    else
                    {
                        var r0 = MESController.SendCreateRecipeNotify(Recipe);
                        if (!r0.Result)
                            ExMessagePage.Show("通知", String.Format("上拋Recipe至MES失敗,原因:{0}", r0.Exception.Message));
                        else
                            ExMessagePage.Show("通知", "上拋Recipe至MES成功");
                    }
                    ExMessagePage.Show("新增Recipe 成功", "");
                    Btn_Close.PerformClick();
                    break;
                case EditMode.Copy:
                    var r2 = RecipeController.Create(Recipe, UID);
                    if (!r2.Result)
                    {
                        ExMessagePage.Show("創建Recipe 失敗", r2.Exception.Message);
                        return;
                    }
                    else
                    {
                        var r0 = MESController.SendCreateRecipeNotify(Recipe);
                        if (!r0.Result)
                            ExMessagePage.Show("通知", String.Format("上拋Recipe至MES失敗,原因:{0}", r0.Exception.Message));
                        else
                            ExMessagePage.Show("通知", "上拋Recipe至MES成功");
                    }
                    ExMessagePage.Show("複製Recipe 成功", "");
                    Btn_Close.PerformClick();
                    break;
                case EditMode.Edit:
                    var r3 = RecipeController.Edit(Recipe, UID);
                    if (!r3.Result)
                    {
                        ExMessagePage.Show("修改Recipe 失敗", r3.Exception.Message);
                        return;
                    }
                    else
                    {
                        ExMessagePage.Show("修改Recipe 成功", "");

                        if (_MessageYesNoPage != null)
                        {
                            _MessageYesNoPage.Close();
                            _MessageYesNoPage.Dispose();
                            _MessageYesNoPage = null;
                        }
                        _MessageYesNoPage = new MessageYesNoPage("警告", String.Format("是否要上傳此Recipe至MES."), UploadSelectReback);
                        _MessageYesNoPage.Show();
                    }
                    break;
            }
        }


        static MessageYesNoPage _MessageYesNoPage;
        void UploadSelectReback(YesNo YesNo_)
        {
            if (YesNo_ == YesNo.Yes)
            {
                var r0 = MESController.SendCreateRecipeNotify(Recipe);
                if (!r0.Result)
                    ExMessagePage.Show("通知", String.Format("上拋Recipe至MES失敗,原因:{0}", r0.Exception.Message));
                else
                    ExMessagePage.Show("通知", "上拋Recipe至MES成功");
            }
            Btn_Close.PerformClick();
        }


        void UpdateRecipe()
        {
            var panelCode = TextBox_PanelCode.Text;
            var pMode = ComboBox_ProcessMode.SelectedItem.ToString();
            var size = ComboBox_Size.SelectedItem.ToString();
            var thickness = Convert.ToInt32(NumUpDown_Thickness.Value);
            var quantity = Convert.ToInt32(NumUpDown_Quantity.Value);

            var wbArea = Convert.ToInt64(NumUpDown_WB.Value);
            var bArea = Convert.ToInt64(NumUpDown_B.Value);

            var ni_WB = Convert.ToDouble(NumUpDown_NI_WB.Value);
            var ni_B = Convert.ToDouble(NumUpDown_NI_B.Value);
            var ni_PTime = 
                (pMode == PModeTypes.A.ToString())?RecipeController.NowProcessConfig.ProcessA_Ni:
                (pMode == PModeTypes.B.ToString()) ? RecipeController.NowProcessConfig.ProcessB_Ni:
                 RecipeController.NowProcessConfig.ProcessC_Ni;

            var au_WB = Convert.ToDouble(NumUpDown_AU_WB.Value);
            var au_B = Convert.ToDouble(NumUpDown_AU_B.Value);
            var au_Ptime =
                (pMode == PModeTypes.A.ToString()) ? RecipeController.NowProcessConfig.ProcessA_Au :
                (pMode == PModeTypes.B.ToString()) ? RecipeController.NowProcessConfig.ProcessB_Au :
                 RecipeController.NowProcessConfig.ProcessC_Au;

            var aust_Current = RecipeController.NowCurrentConfig.AuSt_Current;
            var aust_PTime =
                (pMode == PModeTypes.A.ToString()) ? RecipeController.NowProcessConfig.ProcessA_AuSt :
                (pMode == PModeTypes.B.ToString()) ? RecipeController.NowProcessConfig.ProcessB_AuSt :
                 RecipeController.NowProcessConfig.ProcessC_AuSt;

            var Remarks = TextBox_Remarks.Text;

            this.Recipe.PanelCode = panelCode;
            this.Recipe.PMode = pMode;
            this.Recipe.Size= size;
            this.Recipe.Thickness= thickness;
            this.Recipe.Quantity = quantity;
            this.Recipe.WBArea = wbArea;
            this.Recipe.BArea = bArea;
            this.Recipe.Ni_WB_Adm2 = ni_WB;
            this.Recipe.Ni_B_Adm2 = ni_B;
            this.Recipe.Ni_PlatingTime = ni_PTime;
            this.Recipe.Au_WB_Adm2= au_WB;
            this.Recipe.Au_B_Adm2= au_B;
            this.Recipe.Au_PlatingTime= au_Ptime;
            this.Recipe.AuSt_Adm2= aust_Current;
            this.Recipe.AuSt_PlatingTime = aust_PTime;
            this.Recipe.Remarks = Remarks;
        }

        void UpdateView()
        {
            TextBox_PanelCode.Text = Recipe.PanelCode ; 
            ComboBox_ProcessMode.SelectedItem = Recipe.PMode.ToUpper();
            ComboBox_Size.SelectedItem = Recipe.Size.ToUpper();

            NumUpDown_Thickness.Value = Recipe.Thickness;
            NumUpDown_Quantity.Value= Recipe.Quantity;

            NumUpDown_WB.Value = Recipe.WBArea;
            NumUpDown_B.Value = Recipe.BArea;

            NumUpDown_NI_WB.Value = Convert.ToDecimal(Recipe.Ni_WB_Adm2);
            NumUpDown_NI_B.Value = Convert.ToDecimal(Recipe.Ni_B_Adm2);;
            TextBox_NiPtime.Text = Convert.ToUInt64(Recipe.Ni_PlatingTime).ToTimeString();

            NumUpDown_AU_WB.Value = Convert.ToDecimal(Recipe.Au_WB_Adm2);
            NumUpDown_AU_B.Value = Convert.ToDecimal(Recipe.Au_B_Adm2);
            TextBox_AuPtime.Text = Convert.ToUInt64(Recipe.Au_PlatingTime).ToTimeString();

            TextBox_AuSt_Adm2.Text = RecipeController.NowCurrentConfig.AuSt_Current.ToString();
            TextBox_AuStPtime.Text = Convert.ToUInt64(Recipe.AuSt_PlatingTime).ToTimeString();

            TextBox_Remarks.Text = Recipe.Remarks;
            TextBox_LastChangeDateTime.Text = Recipe.CreateDateTimeString;
        }


        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Btn_Close.PerformClick();
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
            ReSearchRecipe.Invoke();
        }

        private void ComboBox_ProcessMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ComboBox_ProcessMode.SelectedItem.ToString())
            {
                case nameof(PModeTypes.A):
                    TextBox_NiPtime.Text = new DateTime((long)RecipeController.NowProcessConfig.ProcessA_Ni * 10000000).GetString(ExtensionDateTime.OutputTypes.TypeC);
                    TextBox_AuPtime.Text = new DateTime((long)RecipeController.NowProcessConfig.ProcessA_Au * 10000000).GetString(ExtensionDateTime.OutputTypes.TypeC);
                    TextBox_AuStPtime.Text = new DateTime((long)RecipeController.NowProcessConfig.ProcessA_AuSt * 10000000).GetString(ExtensionDateTime.OutputTypes.TypeC);
                    break;
                case nameof(PModeTypes.B):
                    TextBox_NiPtime.Text = new DateTime((long)RecipeController.NowProcessConfig.ProcessB_Ni * 10000000).GetString(ExtensionDateTime.OutputTypes.TypeC);
                    TextBox_AuPtime.Text = new DateTime((long)RecipeController.NowProcessConfig.ProcessB_Au * 10000000).GetString(ExtensionDateTime.OutputTypes.TypeC);
                    TextBox_AuStPtime.Text = new DateTime((long)RecipeController.NowProcessConfig.ProcessB_AuSt * 10000000).GetString(ExtensionDateTime.OutputTypes.TypeC);

                    break;
                case nameof(PModeTypes.C):
                    TextBox_NiPtime.Text = new DateTime((long)RecipeController.NowProcessConfig.ProcessC_Ni * 10000000).GetString(ExtensionDateTime.OutputTypes.TypeC);
                    TextBox_AuPtime.Text = new DateTime((long)RecipeController.NowProcessConfig.ProcessC_Au * 10000000).GetString(ExtensionDateTime.OutputTypes.TypeC);
                    TextBox_AuStPtime.Text = new DateTime((long)RecipeController.NowProcessConfig.ProcessC_AuSt * 10000000).GetString(ExtensionDateTime.OutputTypes.TypeC);
                    break;
            }
        }
    }
}

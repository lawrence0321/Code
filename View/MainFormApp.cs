using System;
using Common.DTO;
using Common.Enums;
using System.Threading;
using System.Collections;
using Common.Extension;
using System.Windows.Forms;
using Controller;
using Controller.Interface;
using FormTimer = System.Windows.Forms.Timer;
using System.Collections.Generic;
using System.IO;
using View.Setting;

namespace View
{
    public partial class MainFormApp : Form
    {
        public static string IniPath = String.Format(@"{0}\\sys.ini", System.Environment.CurrentDirectory);
            
        IDeviceController DeviceController => ControllerFactory.Get<IDeviceController>();
        IMESController MESController => ControllerFactory.Get<IMESController>();
        IUserController UserController => ControllerFactory.Get<IUserController>();
        ISettingController SettingController => ControllerFactory.Get<ISettingController>();
        IExportController ExportController => ControllerFactory.Get<IExportController>();
        IRecipeController RecipeController => ControllerFactory.Get<IRecipeController>();




        readonly FormTimer UpdateConnectTimer = new FormTimer();
        readonly FormTimer UpdateViewTimeTimer = new FormTimer();
        readonly FormTimer UpdateADCAlarmMsgs = new FormTimer();

        readonly FormTimer ClearTimer = new FormTimer();

        readonly Dictionary<string, UserControl> Pages = new Dictionary<string, UserControl>();

        UserControl NowFormPage;

        public MainFormApp()
        {
            InitializeComponent();
            var exEnabled =  ExportController.Enabled;

            if (!File.Exists(IniPath))
            {
                ExMessagePage.Show("警告", "sys.ini遺失，將重新建立參考預設值。請前往設定頁面確認當前檢查值為何。");
                SettingController.CreateBasicIni(IniPath);
            }

            var r1 = SettingController.GetCheckItemValue(MainFormApp.IniPath);
            if (!r1.Result)
                ExMessagePage.Show("警告", "取得檢查項目失敗將使用預設值。 請前往設定頁面確認當前檢查值為何。");
            else
            {
                try
                {
                    var v1 = r1.Value;
                    MESController.SetCheckItem(v1);
                }
                catch (Exception Ex)
                {
                    ExMessagePage.Show("警告", "載入檢查項目發生錯誤將使用預設值。" + Ex.Message);
                }
            }

            var r2 = SettingController.GetADCConfigValue(MainFormApp.IniPath);
            if (!r2.Result)
                ExMessagePage.Show("警告", "取得ADC比對值失敗將使用預設值。");
            else
            {
                try
                {
                    var v1 = r2.Value;
                    MESController.SetADCConfig(v1);
                }
                catch (Exception Ex)
                {
                    ExMessagePage.Show("警告", "載入ADC比對值發生錯誤將加入預設值。" + Ex.Message);
                }
            }
            
            var r3 = SettingController.GetCurrentConfigValue(MainFormApp.IniPath);
            if (!r3.Result)
                ExMessagePage.Show("警告", "取得Aust固定電流值失敗將使用預設值。");
            else
            {
                try
                {
                    var v1 = r3.Value;
                    RecipeController.SetCurrentConfig(v1);
                }
                catch (Exception Ex)
                {
                    ExMessagePage.Show("警告", "載入Aust固定電流值發生錯誤將加入預設值。" + Ex.Message);
                }
            }

            var r4 = SettingController.GetConvertConfigValue(MainFormApp.IniPath);
            if (!r4.Result)
                ExMessagePage.Show("警告", "取得面積權重值失敗將使用預設值。");
            else
            {
                try
                {
                    var v1 = r4.Value;
                    RecipeController.SetConvertConfig(v1);
                }
                catch (Exception Ex)
                {
                    ExMessagePage.Show("警告", "載入面積權重值發生錯誤將加入預設值。" + Ex.Message);
                }
            }

            var r5 = SettingController.GetProcessConfigValue(MainFormApp.IniPath);
            if (!r5.Result)
                ExMessagePage.Show("警告", "取得流程秒數失敗將使用預設值。");
            else
            {
                try
                {
                    var v1 = r5.Value;
                    RecipeController.SetProcessConfig(v1);
                }
                catch (Exception Ex)
                {
                    ExMessagePage.Show("警告", "載入流程秒數發生錯誤將加入預設值。" + Ex.Message);
                }
            }


            UpdateConnectTimer.Interval = 250;
            UpdateConnectTimer.Tick += UpdateConnectTimer_Tick;
            UpdateConnectTimer.Start();

            UpdateViewTimeTimer.Interval = 1000;
            UpdateViewTimeTimer.Tick += UpdateViewTimeTimer_Tick;
            UpdateViewTimeTimer.Start();

            UpdateADCAlarmMsgs.Interval = 1000;
            UpdateADCAlarmMsgs.Tick += UpdateADCAlarmMsgs_Tick;
            UpdateADCAlarmMsgs.Start();

            ClearTimer.Interval = 1000*60*60;
            ClearTimer.Tick += ClearTimer_Tick; ;
            ClearTimer.Start();

            MESController.Connect();

            NowFormPage = new UserControl();
            PageBtn_Click(this.Btn_LoadPage,null);
        }

        private void ClearTimer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.DayOfWeek != DayOfWeek.Monday) return;
            if (DateTime.Now.Hour != 12) return;

            //DeviceController.Clear();
        }

        private void UpdateViewTimeTimer_Tick(object sender, EventArgs e)
            => Label_ViewTime.Text = DateTime.Now.GetString(ExtensionDateTime.OutputTypes.TypeC);

        private void UpdateConnectTimer_Tick(object sender, EventArgs e)
        {
            Label_PLC1_IsConnect.Text = DeviceController.IsConnectPLC1 ? "已連線" : "未連線";
            Label_PLC2_IsConnect.Text = DeviceController.IsConnectPLC2 ? "已連線" : "未連線";
            Label_MES_IsConnect.Text = MESController.IsConnect ? "已連線" : "未連線";
        }

        private void Btn_LogIn_Click(object sender, EventArgs e)
        {
            if (!UserController.IsLogging)
            {
                var uID = TextBox_UID.Text.Replace("　", "").Replace(" ", "");
                if (String.IsNullOrEmpty(uID))
                {
                    ExMessagePage.Show("警告", "尚未輸入工號");
                    return;
                }

                var r0 = UserController.IsOnList(uID);

                if (r0 == false)
                {
                    var r1 = UserController.LogIn(uID);
                    if (!r1.Result)
                    {
                        ExMessagePage.Show("警告", "登入失敗" + r1.Exception.Message);
                        return;
                    }
                }
                else
                {
                    if (EnterPassWordPage != null)
                    {
                        EnterPassWordPage.Close();
                        EnterPassWordPage.Dispose();
                    }
                    EnterPassWordPage = new EnterPassWordPage(uID, EnterPwSuccessCallBack_LogIn);
                    EnterPassWordPage.Show();
                }
            }
            else
            {
                TextBox_UID.Clear();
                UserController.LogOut();

                this.Btn_LoadPage.PerformClick();
            }

            this.Btn_LogIn.Text = UserController.IsLogging ? "登出" : "登入";
            this.TextBox_UID.ReadOnly = UserController.IsLogging;
        }

        public void EnterPwSuccessCallBack_LogIn()
        {
            var uID = TextBox_UID.Text.Replace("　", "").Replace(" ", "");
            var r1 = UserController.LogIn(uID);
            if (!r1.Result)
                ExMessagePage.Show("警告", "登入失敗" + r1.Exception.Message);

            this.Btn_LogIn.Text = UserController.IsLogging ? "登出" : "登入";
            this.TextBox_UID.ReadOnly = UserController.IsLogging;
        }




        static EnterPassWordPage EnterPassWordPage;

        private void PageBtn_Click(object sender, EventArgs e)
        {
            bool isChangePage = false;
            UserControl newFormPage = null;

            switch ((sender as Button).Name)
            {
                case nameof(Btn_LoadPage):
                    if (NowFormPage.GetType()!= typeof(Load.BasicPage))
                    {
                        isChangePage = true;
                        newFormPage = GetPage((sender as Button));
                    }
                    break;
                case nameof(Btn_LotLog):
                    if (NowFormPage.GetType() != typeof(View.UnLoadDataLog.BasicPage))
                    {
                        isChangePage = true;
                        newFormPage = GetPage((sender as Button));
                    }
                    break;
                case nameof(Btn_SearchLog):
                    if (NowFormPage.GetType() != typeof(View.SearchPage.BasicPage))
                    {
                        isChangePage = true;
                        newFormPage = GetPage((sender as Button));
                    }
                    break;
                case nameof(Btn_Setting):
                    if (!UserController.IsLogging)
                    {
                        ExMessagePage.Show("警告", "尚未輸入工號");
                        return;
                    }
                    if (!UserController.Certification(UserAuthority.SettingPage))
                    {
                        ExMessagePage.Show("警告", "工號權限不足");
                        return;
                    }

                    if (EnterPassWordPage != null)
                    {
                        EnterPassWordPage.Close();
                        EnterPassWordPage.Dispose();
                    }
                    EnterPassWordPage = new EnterPassWordPage(this.UserController.NowUID, EnterPwSuccessCallBack);
                    EnterPassWordPage.Show();


                    //if (NowFormPage.GetType() != typeof(View.Setting.BasicPage))
                    //{
                    //    isChangePage = true;
                    //    newFormPage = GetPage((sender as Button));
                    //}
                    break;
                case nameof(Btn_Recipe):
                    if (!UserController.IsLogging)
                    {
                        ExMessagePage.Show("警告", "尚未輸入工號");
                        return;
                    }
                    if (!UserController.Certification(UserAuthority.EditRecipe))
                    {
                        ExMessagePage.Show("警告", "工號權限不足");
                        return;
                    }

                    if (NowFormPage.GetType() != typeof(View.Recipe.BasicPage))
                    {
                        isChangePage = true;
                        newFormPage = GetPage((sender as Button));
                    }
                    break;
                case nameof(Btn_SendEDC):
                    var r1 = MESController.SendEDC();

                    if (!r1.Result)
                    {
                        var form = new ExForm.MessagePage("失敗", r1.Exception.Message);
                        form.Show();
                    }
                    else
                    {
                        var form = new ExForm.MessagePage("通知", "發送EDC成功");
                        form.Show();
                    }
                    break;

            }

            if (isChangePage)
            {
                this.SplitContainerItem.Panel2.Controls.Clear();
                NowFormPage =newFormPage;
                this.SplitContainerItem.Panel2.Controls.Add(NowFormPage);
            }
        }

        public void EnterPwSuccessCallBack()
        {
            this.SplitContainerItem.Panel2.Controls.Clear();
            NowFormPage = GetPage((this.Btn_Setting));
            this.SplitContainerItem.Panel2.Controls.Add(NowFormPage);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var r1 = MESController.SendATC("TESTADC","TESTADC");

            if (!r1.Result)
            {
                var form = new ExForm.MessagePage("失敗", r1.Exception.Message);
                form.Show();
            }
        }

        UserControl GetPage(Button Btn_)
        {
            UserControl page = null;

            if (!Pages.ContainsKey(Btn_.Name))
            {
                switch (Btn_.Name)
                {
                    case nameof(Btn_LoadPage):
                        if (NowFormPage.GetType() != typeof(Load.BasicPage))
                            page = new View.Load.BasicPage();
                        break;
                    case nameof(Btn_LotLog):
                        if (NowFormPage.GetType() != typeof(View.UnLoadDataLog.BasicPage))
                            page = new View.UnLoadDataLog.BasicPage();
                        break;
                    case nameof(Btn_SearchLog):
                        if (NowFormPage.GetType() != typeof(View.SearchPage.BasicPage))
                            page = new View.SearchPage.BasicPage();
                        break;
                    case nameof(Btn_Setting):
                        if (NowFormPage.GetType() != typeof(View.Setting.BasicPage))
                            page = new View.Setting.BasicPage();
                        break;
                    case nameof(Btn_Recipe):
                        if (NowFormPage.GetType() != typeof(View.Recipe.BasicPage))
                            page = new View.Recipe.BasicPage();
                        break;
                }
                Pages.Add(Btn_.Name,page);
            }
            return Pages[Btn_.Name];
        }


        private delegate void InvokeUpdateState(Label Label_, string sMsg);
        private void UpdateLabel(Label Label_, string sMsg)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new InvokeUpdateState(UpdateLabel), new object[] { Label_, sMsg });
                return;
            }
            Label_.Text = sMsg;
        }

        private void TextBox_UID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) || !char.IsLetter(e.KeyChar))//如果不是字符 也不是数字
            {
                e.Handled = false; //当前输入处理置为已处理。即文本框不再显示当前按键信息
            }
        }

        private void UpdateADCAlarmMsgs_Tick(object sender, EventArgs e)
        {
            if (MESController.IsADCHappenAlarm)
            {
                var msgStr = String.Empty;
                var alarmmsgs = MESController.AlarmMsgs;
                foreach (var alarmMsg in alarmmsgs)
                {
                    msgStr += String.Format("名稱:{0} 當前數值:{1} Max值:{2} Min值:{3}\r\n", alarmMsg.Name, alarmMsg.RealValue, alarmMsg.MaxLimit, alarmMsg.MinLimit);
                }

                ExMessagePage.Show("執行ADC發現奧規參數", msgStr);
            }
        }

        private void SplitContainerItem_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TextBox_UID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

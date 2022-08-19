using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.DTO;
using Common.Enums;
using Common.Extension;
using Controller;
using Controller.Interface;

namespace View.Setting
{
    public partial class EditUserPage : Form
    {
        ISettingController SettingController => ControllerFactory.Get<ISettingController>();

        public enum Mod
        {
            Edit,
            Create
        }

        public readonly Mod NowMod;

        public readonly UserItemDTO UserItemDTO;


        public readonly UserDTO UserDTO;

        public string ID { get; private set; }

        public Action ReSearchUserList;


        public UserAuthority UserAuthority { get; private set; }

        public EditUserPage(Action ReSearchUserList_)
        {
            InitializeComponent();

            ReSearchUserList = ReSearchUserList_;

            NowMod = Mod.Create;
            UserItemDTO = new UserItemDTO();

            this.Btn_AccessSetting.BackgroundImage = UserItemDTO.SettingPage ? global::View.Properties.Resources.iconfinder_sign_check_299110 : global::View.Properties.Resources.Cancel_48;
            this.Btn_EditREcipe.BackgroundImage = UserItemDTO.EditRecipe ? global::View.Properties.Resources.iconfinder_sign_check_299110 : global::View.Properties.Resources.Cancel_48;
            this.Btn_UseCustom.BackgroundImage = UserItemDTO.UseCustomMod ? global::View.Properties.Resources.iconfinder_sign_check_299110 : global::View.Properties.Resources.Cancel_48;

            this.TextBox_PW.Text = "-";
            this.TextBox_PWAgin.Text = "-";
            this.TextBox_PW.Enabled = UserItemDTO.SettingPage;
            this.TextBox_PWAgin.Enabled = UserItemDTO.SettingPage;

            this.Btn_Action.Text = "新增";
        }

        public EditUserPage( Action ReSearchUserList_, UserItemDTO UserItemDTO_)
        {
            InitializeComponent();

            ReSearchUserList = ReSearchUserList_;
            UserItemDTO = UserItemDTO_;
            NowMod = Mod.Edit;
            this.TextBox_ID.Text = UserItemDTO_.UserID;
            this.Btn_AccessSetting.BackgroundImage = UserItemDTO.SettingPage? global::View.Properties.Resources.iconfinder_sign_check_299110 : global::View.Properties.Resources.Cancel_48;
            this.Btn_EditREcipe.BackgroundImage = UserItemDTO.EditRecipe ? global::View.Properties.Resources.iconfinder_sign_check_299110 : global::View.Properties.Resources.Cancel_48;
            this.Btn_UseCustom.BackgroundImage = UserItemDTO.UseCustomMod ? global::View.Properties.Resources.iconfinder_sign_check_299110 : global::View.Properties.Resources.Cancel_48;

            this.TextBox_ID.ReadOnly = true;
            this.TextBox_ID.Enabled = false;

            this.Btn_Action.Text = "修改";
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) || !char.IsLetter(e.KeyChar))//如果不是字符 也不是数字
            {
                e.Handled = false; //当前输入处理置为已处理。即文本框不再显示当前按键信息
            }
        }


        private void Btn_EditREcipe_Click(object sender, EventArgs e)
        {
            UserItemDTO.EditRecipe = !UserItemDTO.EditRecipe;

            this.Btn_EditREcipe.BackgroundImage = UserItemDTO.EditRecipe ? global::View.Properties.Resources.iconfinder_sign_check_299110 : global::View.Properties.Resources.Cancel_48;
        }

        private void Btn_UseCustom_Click(object sender, EventArgs e)
        {
            UserItemDTO.UseCustomMod = !UserItemDTO.UseCustomMod;

            this.Btn_UseCustom.BackgroundImage = UserItemDTO.UseCustomMod ? global::View.Properties.Resources.iconfinder_sign_check_299110 : global::View.Properties.Resources.Cancel_48;
        }

        private void Btn_AccessSetting_Click(object sender, EventArgs e)
        {
            UserItemDTO.SettingPage = !UserItemDTO.SettingPage;

            this.Btn_AccessSetting.BackgroundImage = UserItemDTO.SettingPage ? global::View.Properties.Resources.iconfinder_sign_check_299110 : global::View.Properties.Resources.Cancel_48;


            if (!UserItemDTO.SettingPage)
            {
                this.TextBox_PW.Text = "-";
                this.TextBox_PWAgin.Text = "-";

                ExMessagePage.Show("通知", "若無開放設定訪問權限密碼皆為 - ");
            }

            this.TextBox_PW.Enabled = UserItemDTO.SettingPage;
            this.TextBox_PWAgin.Enabled = UserItemDTO.SettingPage;

        }

        private void Btn_Insert_Click(object sender, EventArgs e)
        {

            var id = this.TextBox_ID.Text.Replace(" ", "").Replace("　 ", "");
            if (id == String.Empty)
            {
                ExMessagePage.Show("警告", "尚未填寫無塵衣編號");
                return;
            }
            var pwfirst = this.TextBox_PW.Text;
            var pwsecend = this.TextBox_PWAgin.Text;

            if (pwfirst == String.Empty)
            {
                ExMessagePage.Show("警告", "尚未填寫密碼");
                return;
            }
            if (pwsecend == String.Empty)
            {
                ExMessagePage.Show("警告", "尚未填寫再次輸入密碼");
                return;
            }
            if (pwfirst != pwsecend)
            {
                ExMessagePage.Show("警告", "密碼不相同");
                return;
            }

            var pw = pwfirst.GetSHA256();

            switch (NowMod)
            {
                case Mod.Create:
                    this.UserItemDTO.UserID = id;

                    var r1 = SettingController.AddUser(id,pw);

                    if (!r1.Result)
                    {
                        ExMessagePage.Show("警告", "新增使用者至資料庫失敗"+ r1.Exception.Message);
                        return;
                    }

                    var r2 = SettingController.AddUserAuthority(UserItemDTO);
                    if (!r2.Result)
                    {
                        ExMessagePage.Show("警告", "新增使用者權限至資料庫失敗" + r2.Exception.Message);
                        return;
                    }

                    ExMessagePage.Show("通知", "成功!");
                    Btn_Delete.PerformClick();
                    break;
                case Mod.Edit:

                    var r3 = SettingController.EditUser(id, pw);

                    if (!r3.Result)
                    {
                        ExMessagePage.Show("警告", "修改使用者至資料庫失敗" + r3.Exception.Message);
                        return;
                    }

                    var r4 = SettingController.EditUserAuthority(UserItemDTO);
                    if (!r4.Result)
                    {
                        ExMessagePage.Show("警告", "修改使用者權限至資料庫失敗" + r4.Exception.Message);
                        return;
                    }

                    ExMessagePage.Show("通知", "成功!");
                    Btn_Delete.PerformClick();
                    break;

            }
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            this.Close();

            ReSearchUserList.Invoke();
        }

    }
}

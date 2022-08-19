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
using Controller;
using Controller.Interface;
using View.ExForm;
using static View.ExForm.MessageYesNoPage;

namespace View.Setting
{
    public partial class UserItem : UserControl
    {
        ISettingController SettingController => ControllerFactory.Get<ISettingController>();

        public EditUserPage EditUserPage;
        public Action ReSearchPage;
        public UserItemDTO UserItemDTO { get; set; }

        public Action OpenEdit;

        public Action DeleteItem;

        public UserItem(UserItemDTO UserItemDTO_ , Action ReSearchPage_ ,EditUserPage EditUserPage_)
        {
            InitializeComponent();

            UserItemDTO = UserItemDTO_;
            ReSearchPage = ReSearchPage_;
            EditUserPage = EditUserPage_;

            Label_UserID.Text = UserItemDTO_.UserID;

            this.PictureBox_SettingPage.BackgroundImage = (UserItemDTO_.SettingPage) ? global::View.Properties.Resources.iconfinder_sign_check_299110 : global::View.Properties.Resources.Cancel_48;
            this.PictureBox_EditRecipe.BackgroundImage = (UserItemDTO_.EditRecipe) ? global::View.Properties.Resources.iconfinder_sign_check_299110 : global::View.Properties.Resources.Cancel_48;
            this.PictureBox_CustomMod.BackgroundImage = (UserItemDTO_.UseCustomMod) ? global::View.Properties.Resources.iconfinder_sign_check_299110 : global::View.Properties.Resources.Cancel_48;

        }

        private void UserItem_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            if (EditUserPage != null)
            {
                EditUserPage.Close();
                EditUserPage.Dispose();
                EditUserPage = null;
            }

            EditUserPage = new EditUserPage(ReSearchPage,UserItemDTO);
            EditUserPage.Show();
        }

        static MessageYesNoPage _MessageYesNoPage;
        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            if (_MessageYesNoPage != null)
            {
                _MessageYesNoPage.Close();
                _MessageYesNoPage.Dispose();
                _MessageYesNoPage = null;
            }

            _MessageYesNoPage = new MessageYesNoPage("警告", String.Format("是否要刪除此使用者."), DeleteSelectReback);
            _MessageYesNoPage.Show();
        }
        void DeleteSelectReback(YesNo YesNo_)
        {
            if (YesNo_ == YesNo.Yes)
            {
                var r1 = SettingController.DeleteUser(UserItemDTO.UserID);
                if (!r1.Result)
                    ExMessagePage.Show("刪除使用者失敗", r1.Exception.Message);
                else
                    ExMessagePage.Show("刪除使用者成功", String.Format("{0} 已被刪除.",UserItemDTO.UserID));

                ReSearchPage.Invoke();
            }
        }

    }
}

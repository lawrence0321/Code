using Common.Attributes;
using Common.Enums;
using Common.Extension;
using Controller;
using Controller.Interface;
using System;
using System.Reflection;
using System.Windows.Forms;
using View.ExForm;

namespace View.Setting
{
    public partial class BasicPage : UserControl
    {
        IUserController WhiteListController => ControllerFactory.Get<IUserController>();
        IMESController MESController => ControllerFactory.Get<IMESController>();
        ISettingController SettingController => ControllerFactory.Get<ISettingController>();

        //string SelectUID => listBox1.SelectedItem.ToString();
        //string NewUID => textBox1.Text;
        public BasicPage()
        {
            InitializeComponent();
            InitializeListView();
            InitializeCheckTypePenal();

            ReSearchList();
        }

        void InitializeListView()
        {
            var r1 = WhiteListController.Gets();
            if (!r1.Result)
            {
                ExMessagePage.Show("取得白名單失敗", r1.Exception.Message);
                return;
            }
            //this.listBox1.DataSource = null;
            //this.listBox1.DataSource = r1.Value;
        }

        void InitializeCheckTypePenal()
        {
            this.FLPanelCheckType.Controls.Clear();

            foreach (var propertyInfo in typeof(CheckItemObject).GetProperties())
            {
                var checkBox = GetBasicCheckBox(propertyInfo);
                this.FLPanelCheckType.Controls.Add(checkBox);
            }
        }

        CheckBox GetBasicCheckBox(PropertyInfo propertyInfo_)
        {
            var checkBox = new CheckBox
            {
                AutoSize = true,
                Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136))),
                Location = new System.Drawing.Point(3, 3),
                Name = propertyInfo_.Name,
                Size = new System.Drawing.Size(168, 38),
                TabIndex = 1,
                Text = propertyInfo_.GetCustomAttribute<DisplayAttribute>().ZHTW,
                UseVisualStyleBackColor = true,
                Checked = (bool)propertyInfo_.GetValue(MESController.CheckItem),
            };
            return checkBox;
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
            //_MessageYesNoPage = new MessageYesNoPage("警告", String.Format("是否要刪除{0}此工號.", SelectUID), DeleteSelectReback);
            _MessageYesNoPage.Show();
        }

        void DeleteSelectReback(MessageYesNoPage.YesNo YesNo_)
        {
            if (YesNo_ == MessageYesNoPage.YesNo.Yes)
            {
                //var r1 = WhiteListController.DeleteWhiteList(SelectUID);
                //if (!r1.Result)
                //    ExMessagePage.Show("刪除工號失敗", r1.Exception.Message);
                //else
                //    InitializeListView();
            }
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            //var r1 = WhiteListController.AddWhiteList(NewUID, "-");
            //if (!r1.Result)
            //{
            //    ExMessagePage.Show(String.Format("加入{0}工號失敗", NewUID), r1.Exception.Message);
            //    return;
            //}
            //else
            //    InitializeListView();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var newCheckItem = new CheckItemObject();

            foreach (var ctrl in FLPanelCheckType.Controls)
            {
                if (ctrl.GetType() != typeof(CheckBox)) continue;

                CheckBox checkbox = (CheckBox)ctrl;

                foreach (var propertyInfo in typeof(CheckItemObject).GetProperties())
                {
                    if (propertyInfo.Name == checkbox.Name)
                        propertyInfo.SetValue(newCheckItem, checkbox.Checked);
                }
            }
            MESController.SetCheckItem(newCheckItem);

            var path = MainFormApp.IniPath;

            var r1 = SettingController.SetCheckItemValue(path, newCheckItem);

            if (!r1.Result)
                ExMessagePage.Show("警告", "新增設定值至INI設定檔失敗。");

            InitializeCheckTypePenal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MESController.DisConnect();

            var r1 =  MESController.Connect();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MESController.DisConnect();
        }

        private void CheckBox_SelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked == false) return;
            foreach (var ctrl in FLPanelCheckType.Controls)
            {
                if (ctrl.GetType() != typeof(CheckBox)) continue;
                CheckBox checkbox = (CheckBox)ctrl;
                checkbox.Checked = true;
            }
            (sender as CheckBox).Checked = false;
        }

        private void CheckBox_SelectNone_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked == false) return;
            foreach (var ctrl in FLPanelCheckType.Controls)
            {
                if (ctrl.GetType() != typeof(CheckBox)) continue;
                CheckBox checkbox = (CheckBox)ctrl;
                checkbox.Checked = false;
            }
            (sender as CheckBox).Checked = false;
        }
        EditUserPage _EditUserPage;
        private void Btn_Insert_Click(object sender, EventArgs e)
        {
            if (!(_EditUserPage is null))
            {
                _EditUserPage.Close();
                _EditUserPage.Dispose();
                _EditUserPage = null;
            }
            _EditUserPage = new EditUserPage(ReSearchList);
            _EditUserPage.Show();
        }

        static EditUserPage EditUserPage;

        private void ReSearchList()
        {
            flowLayoutPanel1.Controls.Clear();

            var r1 = SettingController.GetUserItems();
            if (!r1.Result)
            {
                ExMessagePage.Show("警告","載入使用者發生錯誤"+r1.Exception.Message);
                return;
            }
            foreach (var ctrl in r1.Value)
            {
                flowLayoutPanel1.Controls.Add(new UserItem(ctrl, ReSearchList, EditUserPage)); ;
            }
        }
    }
}

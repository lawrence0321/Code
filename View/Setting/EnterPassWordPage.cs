using View.ExForm;
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

namespace View.Setting
{
    public partial class EnterPassWordPage : Form
    {
        IUserController UserController => ControllerFactory.Get<IUserController>();

        readonly string UID;

        string Pw => textBox1.Text;

        readonly Action EnterPwSuccessMthod;

        public EnterPassWordPage(string UID_,Action EnterPwSuccessMthod_)
        {
            InitializeComponent();

            UID = UID_;
            EnterPwSuccessMthod = EnterPwSuccessMthod_;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var r1 = UserController.Certification(UID, Pw);

            if (!r1.Result)
            {
                ExMessagePage.Show("警告", "密碼錯誤");
                return;
            }
            ExMessagePage.Show("通知", "登入成功");

            EnterPwSuccessMthod.Invoke();

            this.Close();
        }
    }
}

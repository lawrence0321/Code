using System;
using System.Windows.Forms;

namespace View.ExForm
{
    public partial class MessageYesNoPage : Form
    {
        public enum YesNo
        { 
            Yes,
            No
        }

        public delegate void YesNoMeesage(YesNo YesNo_);

        YesNoMeesage _YesNoMeesage;

        public MessageYesNoPage(string TitleTxt_,string Message_, YesNoMeesage YesNoMeesage_)
        {
            InitializeComponent();
            label_TitleTxt.Text = TitleTxt_;
            TextBox_MessageTxt.Text = Message_;
            _YesNoMeesage = YesNoMeesage_;
        }

        private void Btn_Yes_Click(object sender, EventArgs e)
        {
            this.Close();
            _YesNoMeesage(YesNo.Yes);
        }

        private void Btn_No_Click(object sender, EventArgs e)
        {
            this.Close();
            _YesNoMeesage(YesNo.No);
        }

        private void Btn_Close_Click(object sender, EventArgs e)
            => this.Close();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.ExForm
{
    public partial class MessagePage : Form
    {
        public MessagePage(string TitleTxt_,string Message_)
        {
            InitializeComponent();
            label_TitleTxt.Text = TitleTxt_;
            TextBox_MessageTxt.Text = Message_;
        }

        private void Btn_Close_Click(object sender, EventArgs e)
            =>this.Close();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.Load
{
    public delegate void InvokeUpdateState(string Msg_);

    public partial class CommunicationLogForm : Form
    {
        public CommunicationLogForm()
        {
            InitializeComponent();
            this.TopLevel = true;
        }

        public void wriLog(string Msg_)
        {
            Show();
            if (InvokeRequired)
            {
                BeginInvoke(new InvokeUpdateState(wriLog), new object[] { Msg_ });
                return;
            }
            string lv_sMsg = String.Format("[{0}] - {1}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Msg_);
            TextBox_Log.AppendText(lv_sMsg);
            this.TopLevel = true;
        }
    }
}

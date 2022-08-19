using System;
using System.Reflection;
using System.Windows.Forms;

namespace View.Extention
{
    public delegate void InvokeUpdateState(Label Label_,string Text_);
    public static class ControlExtentions
    {
        public static void MakeDoubleBuffered(this Control control, bool setting = true)
        {
            Type controlType = control.GetType();
            PropertyInfo pi = controlType.GetProperty("DoubleBuffered",
            BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(control, setting, null);
        }

        public static void SetEnabled(this Control Control_, bool Value)
        {
            Control_.Enabled = Value;
            if (Control_.Controls.Count != 0)
                foreach (Control ctrl in Control_.Controls) SetEnabled(ctrl, Value);
        }
    }
}

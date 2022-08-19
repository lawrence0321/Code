using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Extention;
using Common.DTO;
using Common;
using Common.Extension;
using Controller.Interface;
using Controller;


namespace View.SearchPage
{
    public partial class BasicPage : UserControl
    {
        readonly Dictionary<string, UserControl> Pages = new Dictionary<string, UserControl>();

        UserControl NowFormPage;

        public BasicPage()
        {
            InitializeComponent();
            NowFormPage = new UserControl();
            Btn_AlarmLog.PerformClick();
        }

        private void PageBtn_Click(object sender, EventArgs e)
        {
            bool isChangePage = false;
            UserControl newFormPage = null;

            switch ((sender as Button).Name)
            {
                case nameof(Btn_AlarmLog):
                    if (NowFormPage.GetType() != typeof(View.SearchPage.Alarm.BasicPage))
                    {
                        isChangePage = true;
                        newFormPage = GetPage((sender as Button));
                    }
                    break;
                case nameof(Btn_RectifiertLog):
                    if (NowFormPage.GetType() != typeof(View.SearchPage.Rectifier.BasicPage))
                    {
                        isChangePage = true;
                        newFormPage = GetPage((sender as Button));
                    }
                    break;
                case nameof(Btn_ThermostatLogs):
                    if (NowFormPage.GetType() != typeof(View.SearchPage.Thermostat.BasicPage))
                    {
                        isChangePage = true;
                        newFormPage = GetPage((sender as Button));
                    }
                    break;
                case nameof(Btn_Modbus31Log):
                    if (NowFormPage.GetType() != typeof(View.SearchPage.Modbus31.BasicPage))
                    {
                        isChangePage = true;
                        newFormPage = GetPage((sender as Button));
                    }
                    break;
                case nameof(Btn_Modbus32Log):
                    if (NowFormPage.GetType() != typeof(View.SearchPage.Modbus32.BasicPage))
                    {
                        isChangePage = true;
                        newFormPage = GetPage((sender as Button));
                    }
                    break;
                case nameof(Btn_Modbus33Log):
                    if (NowFormPage.GetType() != typeof(View.SearchPage.Modbus33.BasicPage))
                    {
                        isChangePage = true;
                        newFormPage = GetPage((sender as Button));
                    }
                    break;
                case nameof(Btn_ModbusRTULog):
                    if (NowFormPage.GetType() != typeof(View.SearchPage.ModbusRTU.BasicPage))
                    {
                        isChangePage = true;
                        newFormPage = GetPage((sender as Button));
                    }
                    break;
            }
            if (isChangePage)
            {
                this.Panel_ViewPage.Controls.Clear();
                NowFormPage = newFormPage;
                this.Panel_ViewPage.Controls.Add(NowFormPage);
            }
        }

        UserControl GetPage(Button Btn_)
        {
            UserControl page = null;

            if (!Pages.ContainsKey(Btn_.Name))
            {
                switch (Btn_.Name)
                {
                    case nameof(Btn_AlarmLog):
                        if (NowFormPage.GetType() != typeof(View.SearchPage.Alarm.BasicPage))
                            page = new View.SearchPage.Alarm.BasicPage();
                        break;
                    case nameof(Btn_RectifiertLog):
                        if (NowFormPage.GetType() != typeof(View.SearchPage.Rectifier.BasicPage))
                            page = new View.SearchPage.Rectifier.BasicPage();
                        break;
                    case nameof(Btn_ThermostatLogs):
                        if (NowFormPage.GetType() != typeof(View.SearchPage.Thermostat.BasicPage))
                            page = new View.SearchPage.Thermostat.BasicPage();
                        break;
                    case nameof(Btn_Modbus31Log):
                        if (NowFormPage.GetType() != typeof(View.SearchPage.Modbus31.BasicPage))
                            page = new View.SearchPage.Modbus31.BasicPage();
                        break;
                    case nameof(Btn_Modbus32Log):
                        if (NowFormPage.GetType() != typeof(View.SearchPage.Modbus32.BasicPage))
                            page = new View.SearchPage.Modbus32.BasicPage();
                        break;
                    case nameof(Btn_Modbus33Log):
                        if (NowFormPage.GetType() != typeof(View.SearchPage.Modbus33.BasicPage))
                            page = new View.SearchPage.Modbus33.BasicPage();
                        break;
                    case nameof(Btn_ModbusRTULog):
                        if (NowFormPage.GetType() != typeof(View.SearchPage.ModbusRTU.BasicPage))
                            page = new View.SearchPage.ModbusRTU.BasicPage();
                        break;

                }
                Pages.Add(Btn_.Name, page);
            }
            return Pages[Btn_.Name];
        }
    }
}

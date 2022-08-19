using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.ExForm;

namespace View
{
    public static class ExMessagePage
    {
        private static MessagePage _MessagePage;

        public static void Show(string TitleTxt_, string MessageTxt_)
        {
            if (_MessagePage != null)
            {
                _MessagePage.Close();
                _MessagePage.Dispose();
                _MessagePage = null;
            }
            _MessagePage = new MessagePage(TitleTxt_, MessageTxt_)
            {
                TopLevel = true,
                TopMost = true
            };
            _MessagePage.Show();
        }

    }
}

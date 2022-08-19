using Common.Interface;
using Controller.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public static class ControllerFactory
    {
        public static T Get<T>() where T : class, IController
        {
            return  AutofacConfig.Resolve<T>();
        }

    }
}

using Autofac;
using Autofac.Core;
using Common.Interface;
using Controller.Implement;
using Controller.Interface;
using System;

namespace Controller
{
    internal class AutofacConfig
    {
        readonly static object Token = new object();


        static IContainer Container
        {
            get
            {
                if (_Container is null)
                    lock (Token)
                        if (_Container is null) Register();

                return _Container;
            }
        }
        static IContainer _Container;

        public static void Register()
        {
            // 容器建立者
            var Builder = new ContainerBuilder();


            Builder.Register(p => new DeviceController()).As<IDeviceController>().SingleInstance();
            Builder.Register(p => new LoadController()).As<ILoadController>().SingleInstance();
            Builder.Register(p => new RecipeController()).As<IRecipeController>().SingleInstance();
            Builder.Register(p => new SearchController()).As<ISearchController>().SingleInstance();
            Builder.Register(p => new SettingController()).As<ISettingController>().SingleInstance();
            Builder.Register(p => new MESController()).As<IMESController>().SingleInstance();
            Builder.Register(p => new UserController()).As<IUserController>().SingleInstance();
            Builder.Register(p => new ExportController()).As<IExportController>().SingleInstance();

            // 建立容器
            _Container = Builder.Build();
        }

        public static T Resolve<T>()where T:IController
        {
            if (Container.IsRegistered<T>())
                return Container.Resolve<T>();
            else
                throw new Exception(String.Format("This {0} is not Registered", typeof(T).FullName));
        }

        public static T Resolve<T>(Parameter[] Parameters_)
        {
            if (Container.IsRegistered<T>())
                return Container.Resolve<T>(Parameters_);
            else
                throw new Exception(String.Format("This {0} is not Registered", typeof(T).FullName));
        }

    }

}

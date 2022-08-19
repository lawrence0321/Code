using Service.Device.Interface;

namespace Service.Device
{
    public static class DeviceServiceFactory
    {
        static IDeviceService DeviceService;

        static object AccessToken = new object();
        public static IDeviceService Get(bool UseTest_ = false)
        {
            if (DeviceService is null)
                lock (AccessToken)
                    if (DeviceService is null)
                    {
                        if (UseTest_)
                            DeviceService = new Test.DeviceService();
                        else
                            DeviceService = new Implement._DeviceService();
                    }

            return (IDeviceService)DeviceService;
        }
    }

}

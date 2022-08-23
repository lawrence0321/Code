using Service.MES.Interface;

namespace Service.MES
{
    public static class MESServiceFactory
    {
        static IMESService _Service;
        readonly static object AccessToken = new object();
        public static IMESService Get(bool UseTest_ = false) 
        {
            if (_Service is null)
            {
                lock (AccessToken)
                {
                    if (_Service is null)
                    {
                        if (UseTest_)
                            _Service = new Test.MESService();
                        else
                            _Service = new Implement.MESService();
                    }
                }
            }
            return _Service;
        }
    }

}

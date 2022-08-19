using Common;
using Common.Interface;

namespace Service.DataBase.Interface
{
    public interface ISettingService :IService
    {
        ActResult<ulong> GetCheckValue();
        ActResult SetCheckValue(ulong Value_);
    }
}
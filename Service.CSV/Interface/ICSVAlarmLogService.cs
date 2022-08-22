using Common;
using Common.DTO;
using Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CSV.Interface
{
    public interface ICSVAlarmLogService : IService
    {
        ActResult HappenLog(int AlarmCode_);

        ActResult DisMissLog(int AlarmCode_);
    }
    public interface ICSVExceptionService : IService
    {
        ActResult Log(Exception Ex_);
        ActResult Log(string Ex_);
    }
    public interface ICSVLoadDataService : IService
    {
        ActResult Log(LoadDataDTO LoadData_);
    }

    public interface ICSVUnLoadDataService : IService
    {
        ActResult Log(UnLoadDataLogDTO UnLoadDataLog_);
    }

    public interface ICSVModbus31LogService : IService
    {
        ActResult Log(Modbus31LogDTO Modbus31LogDTO_);
    }

    public interface ICSVModbus32LogService : IService
    {
        ActResult Log(Modbus32LogDTO Modbus32LogDTO_);
    }

    public interface ICSVModbus33LogService :IService
    {
        ActResult Log(Modbus33LogDTO Modbus33LogDTO_);
    }


}

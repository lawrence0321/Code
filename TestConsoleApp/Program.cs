using Service.CSV.Interface;
using Service.CSV;
using Service.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.DataBase.Interface;
using Service.MES.Interface;
using Service.MES;
using Common.Enums;
using Common.DTO;
using System.IO;
using System.Threading;
using Repository.Entity;
using Common.ExConfig;
using Controller.Interface;
using Controller;
using Service.MES.ExObject;
using Newtonsoft.Json;
using Common;
using Service.Device;

namespace TestConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            var deviceService = DeviceServiceFactory.Get(false);

            while (!deviceService.IsConnect_PLC1)
            {

                Thread.Sleep(100);
            }

            //deviceService.UpdatePCStatuses(Service.Device.Enums.PCStatuses.LoadDataTimeAlarm, true);
            //return;

            deviceService.UpdatePCStatuses(Service.Device.Enums.PCStatuses.DataCountError, true);
            return;


            var CSVservice = CSVServiceFactory.Get<ICSVDeviceService>();
            CSVservice.Log(DeviceLogSourceTypes.PC, "22000.1", true);
            CSVservice.Log(DeviceLogSourceTypes.PLC, "22008.1", false, "TestRemarks");

            return;

            var LoadDataService = Service.DataBase.DBServiceFactory.Get<ILoadDataService>();
            var UnLoadService = Service.DataBase.DBServiceFactory.Get<IUnLoadService>();
            UnLoadService.GetLastLotNo();
            //var getlastLotNoResult = unLoadService.GetLastLotNo();
            //var getUnloadtLotCountResult = loadDataService.GetLotCount("L221028012");
            //var getloadLotCountResult = unLoadService.GetLotCount("L221028012");


            //Console.WriteLine(String.Format("LastLotNo:{0}", getlastLotNoResult.Value));
            //var lastLotNo = "L221028012";
            //Console.WriteLine(String.Format("{0} 's LoadData Count :{1}", lastLotNo, getloadLotCountResult.Value));
            //Console.WriteLine(String.Format("{0} 's UnLoadData Count :{1}", lastLotNo, getUnloadtLotCountResult.Value));


            var r1 = new ActResult<UnLoadDataLogDTO>(new UnLoadDataLogDTO() { LotNo = "AAA" });
            var r2 = new ActResult<UnLoadDataLogDTO>(new UnLoadDataLogDTO() { LotNo = "AAA" });

            #region 下料LotNo比對 
            var newUnloadLotNo = (r1.Value.LotNo != "DummyLotCode") ? r1.Value.LotNo : r2.Value.LotNo;
            var lastLotNoResult = UnLoadService.GetLastLotNo();
            if (lastLotNoResult.Result)
            {
                //var lastUnloadLotNo = lastLotNoResult.Value;
                //var lastUnloadLotNo = "DummyLotCode";
                //var lastUnloadLotNo = "L221028012";
                var lastUnloadLotNo = "L220926064";
                if (lastUnloadLotNo != newUnloadLotNo)
                {
                    //DeviceService.UpdatePCStatuses(PCStatuses.ChangeLotNotify, true);
                    //如果前次lotNo == DummyLotCode 不做總數比對判斷
                    if (lastUnloadLotNo != "DummyLotCode")
                    {
                        var getLoadDataCountResult = LoadDataService.GetLotCount(lastUnloadLotNo);
                        var getUnLoadDataCountResult = UnLoadService.GetLotCount(lastUnloadLotNo);

                        if (getLoadDataCountResult.Result && getUnLoadDataCountResult.Result)
                        {
                            var loadDataCount = getLoadDataCountResult.Value;
                            var unLoadDataCountResult = getUnLoadDataCountResult.Value;

                            if (loadDataCount != unLoadDataCountResult)
                            {
                                var alarmCode = 0000;

                                Console.WriteLine(String.Format("LastLotNo:{0} NG", lastUnloadLotNo));

                                //ThreadPool.QueueUserWorkItem(p => MESService.SendAlarmNotify(alarmCode));
                                //CSVAlarmLogService.HappenLog(alarmCode);
                                //CSVAlarmLogService.DisMissLog(alarmCode);
                            }
                            else
                                Console.WriteLine(String.Format("LastLotNo:{0} OK", lastUnloadLotNo));
                        }//判斷取得該LotNo LoadData及UnLoadData 數量是否成功
                        else
                        {

                        }
                    }
                }//判斷本次LotNo 是否與前次LotNo 是否不一致
            }//判斷取得lastunloadlotNo是否成功判斷
            else
            {

            }

            #endregion


            Console.ReadKey();
        }
    }

}

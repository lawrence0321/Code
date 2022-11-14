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

namespace TestConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            //var service = MESServiceFactory.Get();
            var service = CSVServiceFactory.Get<ICSVAlarmLogService>();

            var r1 = service.HappenLog(123);
            var r2 = service.DisMissLog(123);


        }
    }

}

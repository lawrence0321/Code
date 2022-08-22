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

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = MESServiceFactory.Get();
            var lotcode = "";
            var opid = "";
            var chitem = new CheckItemObject(); foreach (var pro in typeof(CheckItemObject).GetProperties()) if (pro.PropertyType.Name == nameof(Boolean)) pro.SetValue(chitem, true);
            var therm = new ThermostatLogDTO(); foreach (var pro in typeof(ThermostatLogDTO).GetProperties()) { if (pro.PropertyType.Name == nameof(Double)) pro.SetValue(therm, 100); }
            var mos31 = new Modbus31LogDTO(); foreach (var pro in typeof(Modbus31LogDTO).GetProperties()) { if (pro.PropertyType.Name == nameof(Double)) pro.SetValue(mos31, 100); }
            var mos32 = new Modbus32LogDTO(); foreach (var pro in typeof(Modbus32LogDTO).GetProperties()) { if (pro.PropertyType.Name == nameof(Double)) pro.SetValue(mos32, 100); }
            var mos33 = new Modbus33LogDTO(); foreach (var pro in typeof(Modbus33LogDTO).GetProperties()) { if (pro.PropertyType.Name == nameof(Double)) pro.SetValue(mos33, 100); }
            var ws = new WashDeviceLogDTO() { Speed = 100, Temperature = 10 };

            var adc = new ADCConfig();
            foreach (var pro in typeof(ADCConfig).GetProperties()) if (pro.Name.Contains("Max")) pro.SetValue(adc, 10000);
            foreach (var pro in typeof(ADCConfig).GetProperties()) if (pro.Name.Contains("Min")) pro.SetValue(adc, -10000);
            adc.Nickel4_Air_1_MaxValue = 200;
            adc.Nickel4_Air_1_MinValue = 150;
            adc.Nickel4_Air_2_MaxValue = 200;
            adc.Nickel4_Air_2_MinValue = 150;
            adc.Nickel4_Air_3_MaxValue = 200;
            adc.Nickel4_Air_3_MinValue = 150;
            adc.Nickel4_Air_4_MaxValue = 200;
            adc.Nickel4_Air_4_MinValue = 150;
            adc.Nickel4_Air_5_MaxValue = 200;
            adc.Nickel4_Air_5_MinValue = 150;
            adc.Nickel4_Air_6_MaxValue = 200;
            adc.Nickel4_Air_6_MinValue = 150;

            service.SetADCConfig(adc);

            var r1  = service.ParamterComparison(
                lotcode
                , opid
                , chitem
                , therm
                , mos31
                , mos32
                , mos33
                , ws
            );

        }
    }

}

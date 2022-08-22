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

namespace TestConsoleApp
{
    class Program
    {
        public static string IniPath = String.Format(@"{0}\\sys.ini", System.Environment.CurrentDirectory);

        static void Main(string[] args)
        {
            ISettingController SettingController = ControllerFactory.Get<ISettingController>();

            if (!File.Exists(IniPath))
            {
                Console.Write("警告", "sys.ini遺失，將重新建立參考預設值。請前往設定頁面確認當前檢查值為何。");
                SettingController.CreateBasicIni(IniPath);
            }

            var r1 = SettingController.GetCheckItemValue(IniPath);
            if (!r1.Result)
                Console.Write("警告", "取得檢查項目失敗將使用預設值。 請前往設定頁面確認當前檢查值為何。");


            var r2 = SettingController.GetADCConfigValue(IniPath);
            if (!r2.Result)
                Console.Write("警告", "取得ADC比對值失敗將使用預設值。");


            var r3 = SettingController.GetCurrentConfigValue(IniPath);
            if (!r3.Result)
                Console.Write("警告", "取得Aust固定電流值失敗將使用預設值。");


            var r4 = SettingController.GetConvertConfigValue(IniPath);
            if (!r4.Result)
                Console.Write("警告", "取得面積權重值失敗將使用預設值。");


            var r5 = SettingController.GetProcessConfigValue(IniPath);
            if (!r5.Result)
                Console.Write("警告", "取得流程秒數失敗將使用預設值。");


            var checkItem = r1.Value;



            var service = MESServiceFactory.Get();


            service.SetADCConfig(r2.Value);


            var lotcode = "";
            var opid = "";
            var therm = new ThermostatLogDTO(); foreach (var pro in typeof(ThermostatLogDTO).GetProperties()) { if (pro.PropertyType.Name == nameof(Double)) pro.SetValue(therm, 100); }
            var mos31 = new Modbus31LogDTO(); foreach (var pro in typeof(Modbus31LogDTO).GetProperties()) { if (pro.PropertyType.Name == nameof(Double)) pro.SetValue(mos31, 100); }
            var mos32 = new Modbus32LogDTO(); foreach (var pro in typeof(Modbus32LogDTO).GetProperties()) { if (pro.PropertyType.Name == nameof(Double)) pro.SetValue(mos32, 100); }
            var mos33 = new Modbus33LogDTO(); foreach (var pro in typeof(Modbus33LogDTO).GetProperties()) { if (pro.PropertyType.Name == nameof(Double)) pro.SetValue(mos33, 100); }
            var ws = new WashDeviceLogDTO() { Speed = 100, Temperature = 10 };


            var isfail = service.ParamterComparison(lotcode, opid, checkItem, therm, mos31, mos32, mos33, ws);

            var AlarmMsgs = new List<AlarmMsgDTO>();

            var exmsg = String.Empty;


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

        }
    }

}

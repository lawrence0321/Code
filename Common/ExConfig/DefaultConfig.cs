using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ExConfig
{
    public static class DefaultConfig
    {
        public static CurrentConfig CurrentConfig
        {
            get
            {
                if (_CurrentConfig is null)
                {
                    _CurrentConfig = new CurrentConfig
                    {
                        AuSt_Current = 1.8
                    };
                }
                return _CurrentConfig;
            }
        }
        static CurrentConfig _CurrentConfig;

        public static ProcessConfig ProcessConfig
        {
            get
            {
                if (_ProcessConfig is null)
                {
                    _ProcessConfig = new ProcessConfig
                    {
                        ProcessA_Ni = 2010,
                        ProcessA_Au = 290,
                        ProcessA_AuSt = 20,

                        ProcessB_Ni = 2010,
                        ProcessB_Au = 290,
                        ProcessB_AuSt = 20,

                        ProcessC_Ni = 2010,
                        ProcessC_Au = 290,
                        ProcessC_AuSt = 20,
                    };
                }
                return _ProcessConfig;
            }
        }
        static ProcessConfig _ProcessConfig;

        public static ConvertConfig ConvertConfig
        {
            get
            {
                if (_ConvertConfig is null)
                {
                    _ConvertConfig = new ConvertConfig
                    {
                        Area_5000_10000_Quantity_1 = 2.0,
                        Area_5000_10000_Quantity_2 = 1.4,
                        Area_5000_10000_Quantity_3 = 1.3,

                        Area_10001_20000_Quantity_1 = 1.5,
                        Area_10001_20000_Quantity_2 = 1.3,
                        Area_10001_20000_Quantity_3 = 1.2,

                        Area_20001_40000_Quantity_1 = 1.4,
                        Area_20001_40000_Quantity_2 = 1.2,
                        Area_20001_40000_Quantity_3 = 1.1,

                        Area_40001_60000_Quantity_1 = 1.2,
                        Area_40001_60000_Quantity_2 = 1.1,
                        Area_40001_60000_Quantity_3 = 1.05,

                        Area_60001_80000_Quantity_1 = 1.15,
                        Area_60001_80000_Quantity_2 = 1.1,
                        Area_60001_80000_Quantity_3 = 1,

                        Area_80001_100000_Quantity_1 = 1.1,
                        Area_80001_100000_Quantity_2 = 1.05,
                        Area_80001_100000_Quantity_3 = 1,

                        Area_100001_Quantity_1 = 1.1,
                        Area_100001_Quantity_2 = 1.05,
                        Area_100001_Quantity_3 = 1,
                    };
                }
                return _ConvertConfig;
            }
        }
        static ConvertConfig _ConvertConfig;

        public static ADCConfig ADCConfig
        {
            get
            {
                if (_ADCConfig is null)
                {
                    _ADCConfig = new ADCConfig()
                    {
                        HDIR_1_Temp_MaxValue = 55,
                        HDIR_1_Temp_MinValue = 45,
                        HDIR_2_Temp_MaxValue = 55,
                        HDIR_2_Temp_MinValue = 45,

                        Clean_MaxValue = 10,
                        Clean_MinValue = 01,
                        Cleaner_Temp_MaxValue = 45,
                        Cleaner_Temp_MinValue = 35,

                        NiEtch_Temp_MaxValue = 29,
                        NiEtch_Temp_MinValue = 25,
                        Microerching_MaxValue = 15,
                        Microerching_MinValue = 04,

                        ACID1_MaxValue = 15,
                        ACID1_MinValue = 04,

                        Ni1_Temp_MaxValue = 54,
                        Ni1_Temp_MinValue = 50,
                        Nickel1_1_MaxValue = 35,
                        Nickel1_1_MinValue = 10,
                        Nickel1_2_MaxValue = 35,
                        Nickel1_2_MinValue = 10,
                        Nickel1_3_MaxValue = 35,
                        Nickel1_3_MinValue = 10,
                        Nickel1_Air_1_MaxValue = 200,
                        Nickel1_Air_1_MinValue = 150,
                        Nickel1_Air_2_MaxValue = 200,
                        Nickel1_Air_2_MinValue = 150,
                        Nickel1_Air_3_MaxValue = 200,
                        Nickel1_Air_3_MinValue = 150,
                        Nickel1_Air_4_MaxValue = 200,
                        Nickel1_Air_4_MinValue = 150,
                        Nickel1_Air_5_MaxValue = 200,
                        Nickel1_Air_5_MinValue = 150,
                        Nickel1_Air_6_MaxValue = 200,
                        Nickel1_Air_6_MinValue = 150,

                        Ni2_Temp_MaxValue = 54,
                        Ni2_Temp_MinValue = 50,
                        Nickel2_1_MaxValue = 35,
                        Nickel2_1_MinValue = 10,
                        Nickel2_2_MaxValue = 35,
                        Nickel2_2_MinValue = 10,
                        Nickel2_3_MaxValue = 35,
                        Nickel2_3_MinValue = 10,
                        Nickel2_Air_1_MaxValue = 200,
                        Nickel2_Air_1_MinValue = 150,
                        Nickel2_Air_2_MaxValue = 200,
                        Nickel2_Air_2_MinValue = 150,
                        Nickel2_Air_3_MaxValue = 200,
                        Nickel2_Air_3_MinValue = 150,
                        Nickel2_Air_4_MaxValue = 200,
                        Nickel2_Air_4_MinValue = 150,
                        Nickel2_Air_5_MaxValue = 200,
                        Nickel2_Air_5_MinValue = 150,
                        Nickel2_Air_6_MaxValue = 200,
                        Nickel2_Air_6_MinValue = 150,

                        Ni3_Temp_MaxValue = 54,
                        Ni3_Temp_MinValue = 50,
                        Nickel3_1_MaxValue = 54,
                        Nickel3_1_MinValue = 50,
                        Nickel3_2_MaxValue = 54,
                        Nickel3_2_MinValue = 50,
                        Nickel3_3_MaxValue = 54,
                        Nickel3_3_MinValue = 50,
                        Nickel3_Air_1_MaxValue = 200,
                        Nickel3_Air_1_MinValue = 150,
                        Nickel3_Air_2_MaxValue = 200,
                        Nickel3_Air_2_MinValue = 150,
                        Nickel3_Air_3_MaxValue = 200,
                        Nickel3_Air_3_MinValue = 150,
                        Nickel3_Air_4_MaxValue = 200,
                        Nickel3_Air_4_MinValue = 150,
                        Nickel3_Air_5_MaxValue = 200,
                        Nickel3_Air_5_MinValue = 150,
                        Nickel3_Air_6_MaxValue = 200,
                        Nickel3_Air_6_MinValue = 150,

                        Ni4_Temp_MaxValue = 54,
                        Ni4_Temp_MinValue = 50,
                        Nickel4_1_MaxValue = 54,
                        Nickel4_1_MinValue = 50,
                        Nickel4_2_MaxValue = 54,
                        Nickel4_2_MinValue = 50,
                        Nickel4_3_MaxValue = 54,
                        Nickel4_3_MinValue = 50,
                        Nickel4_Air_1_MaxValue = 200,
                        Nickel4_Air_1_MinValue = 150,
                        Nickel4_Air_2_MaxValue = 200,
                        Nickel4_Air_2_MinValue = 150,
                        Nickel4_Air_3_MaxValue = 200,
                        Nickel4_Air_3_MinValue = 150,
                        Nickel4_Air_4_MaxValue = 200,
                        Nickel4_Air_4_MinValue = 150,
                        Nickel4_Air_5_MaxValue = 200,
                        Nickel4_Air_5_MinValue = 150,
                        Nickel4_Air_6_MaxValue = 200,
                        Nickel4_Air_6_MinValue = 150,

                        AuSt_Temp_MaxValue = 60,
                        AuSt_Temp_MinValue = 50,
                        AuSt_MaxValue = 25,
                        AuSt_MinValue = 10,

                        Au_1_Temp_MaxValue = 70,
                        Au_1_Temp_MinValue = 60,
                        Au_1_MaxValue = 25,
                        Au_1_MinValue = 10,

                        Au_2_Temp_MaxValue = 70,
                        Au_2_Temp_MinValue = 60,
                        Au_2_MaxValue = 25,
                        Au_2_MinValue = 10,

                        HotRinse_1_Temp_MaxValue = 55,
                        HotRinse_1_Temp_MinValue = 45,
                        HotRinse_2_Temp_MaxValue = 55,
                        HotRinse_2_Temp_MinValue = 45,

                        Water11_MaxValue = 8,
                        Water11_MinValue = 4,
                        Water12_MaxValue = 8,
                        Water12_MinValue = 4,
                        Water13_MaxValue = 8,
                        Water13_MinValue = 4,

                        Rinse01_MaxValue = 2.1,
                        Rinse01_MinValue = 1.4,
                        Rinse02_MaxValue = 2.1,
                        Rinse02_MinValue = 1.4,
                        Rinse03_MaxValue = 2.1,
                        Rinse03_MinValue = 1.4,
                        Rinse04_MaxValue = 2.1,
                        Rinse04_MinValue = 1.4,
                        Rinse05_MaxValue = 2.1,
                        Rinse05_MinValue = 1.4,
                        Rinse06_MaxValue = 2.1,
                        Rinse06_MinValue = 1.4,
                        Rinse07_MaxValue = 2.1,
                        Rinse07_MinValue = 1.4,
                        Rinse08_MaxValue = 2.1,
                        Rinse08_MinValue = 1.4,
                        Rinse09_MaxValue = 2.1,
                        Rinse09_MinValue = 1.4,
                        Rinse10_MaxValue = 2.1,
                        Rinse10_MinValue = 1.4,
                        Rinse11_MaxValue = 2.1,
                        Rinse11_MinValue = 1.4,
                        Rinse12_MaxValue = 2.1,
                        Rinse12_MinValue = 1.4,
                        Rinse13_MaxValue = 2.1,
                        Rinse13_MinValue = 1.4,
                        
                        Rinse_Flow1_MaxValue = 6,
                        Rinse_Flow1_MinValue = 4,
                        Rinse_Flow2_MaxValue = 6,
                        Rinse_Flow2_MinValue = 4,
                        Rinse_Flow3_MaxValue = 6,
                        Rinse_Flow3_MinValue = 4,
                        Rinse_Flow4_MaxValue = 6,
                        Rinse_Flow4_MinValue = 4,

                        Rinse_EC_MaxValue = 99999,
                        Rinse_EC_MinValue = 1,
                        WM_LineSpeed_MaxValue = 2.7,
                        WM_LineSpeed_MinValue = 2.3,
                        WM_Temperature_MaxValue = 90,
                        WM_Temperature_MinValue = 70,
                    };
                }
                return _ADCConfig;
            }
        }

        static ADCConfig _ADCConfig;

    }

}

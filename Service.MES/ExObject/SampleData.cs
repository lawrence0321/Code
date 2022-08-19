using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.MES
{


    public static class SampleData
    {
        public static string AE2TalkObjectValue = @"{
""Eqp_Name"":""M0000802"",
""RMSName"":""GOLDEN_RECIPE_AUNI_E_PLATING"",
""Mach_Type"":""A040002"",
""StepId"":null,
""StepName"":null,
""ResultFlag"":true,
""ResultMessage"":"""",
""RecipeName"":""9723-N51W022028-V0054"",
""Version"":""0"",""Machine_Descript"":null,
""Items"":[
{""Id"":""1000002382"",""Name"":""鍍鎳 (W/B)"",""ParameterName"":""Ni plated (W/B)"",""Value"":""1.22"",""Unit"":""ASD"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11001"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""2.20"",""NumberMin"":""0"",""RMSClass"":""RMS"",""ChiDesc"":""鍍鎳 (W/B)"",""MaxValue"":""1.42"",""MinValue"":""1.02"",""Remark"":""1.05"",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":""0"",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002383"",""Name"":""鍍鎳 (B)"",""ParameterName"":""Ni plated (B)"",""Value"":""0"",""Unit"":""ASD"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11002"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""2.20"",""NumberMin"":""0"",""RMSClass"":""RMS"",""ChiDesc"":""鍍鎳 (B)"",""MaxValue"":""0"",""MinValue"":""0"",""Remark"":""0"",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":""0"",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002384"",""Name"":""預鍍金 (A)"",""ParameterName"":""Au strike (A)"",""Value"":""1.8"",""Unit"":""A"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11003"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""50"",""NumberMin"":""0"",""RMSClass"":""RMS"",""ChiDesc"":""預鍍金 (A)"",""MaxValue"":""20.6"",""MinValue"":""20.4"",""Remark"":""20.5"",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":""0"",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002385"",""Name"":""鍍金 (W/B)"",""ParameterName"":""Au plated (W/B)"",""Value"":""0.143"",""Unit"":""ASD"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11004"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""2"",""NumberMin"":""0"",""RMSClass"":""RMS"",""ChiDesc"":""鍍金 (W/B)"",""MaxValue"":""0.158"",""MinValue"":""0.128"",""Remark"":""0.155"",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":""0"",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002386"",""Name"":""鍍金 (B)"",""ParameterName"":""Au plated (B)"",""Value"":""0"",""Unit"":""ASD"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11005"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""2"",""NumberMin"":""0"",""RMSClass"":""RMS"",""ChiDesc"":""鍍金 (B)"",""MaxValue"":""0"",""MinValue"":""0"",""Remark"":""0"",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":""0"",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002390"",""Name"":""前熱水洗(1) 溫度"",""ParameterName"":""Pre-Hot rinse (1) Temperature"",""Value"":""50"",""Unit"":""℃"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11006"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""55"",""NumberMin"":""45"",""RMSClass"":""RMS"",""ChiDesc"":""前熱水洗(1) 溫度"",""MaxValue"":""55"",""MinValue"":""45"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002391"",""Name"":""前熱水洗(2) 溫度"",""ParameterName"":""Pre-Hot rinse (2) Temperature"",""Value"":""50"",""Unit"":""℃"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11007"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""55"",""NumberMin"":""45"",""RMSClass"":""RMS"",""ChiDesc"":""前熱水洗(2) 溫度"",""MaxValue"":""55"",""MinValue"":""45"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002392"",""Name"":""脫脂 壓力"",""ParameterName"":""Clean Pressure"",""Value"":""5.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11008"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""10"",""NumberMin"":""1"",""RMSClass"":""RMS"",""ChiDesc"":""脫脂 壓力"",""MaxValue"":""10"",""MinValue"":""1"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002393"",""Name"":""脫脂 溫度"",""ParameterName"":""Clean Temperature"",""Value"":""40"",""Unit"":""℃"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11009"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""45"",""NumberMin"":""35"",""RMSClass"":""RMS"",""ChiDesc"":""脫脂 溫度"",""MaxValue"":""45"",""MinValue"":""35"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002394"",""Name"":""微蝕 溫度"",""ParameterName"":""Microetching Temperature"",""Value"":""27"",""Unit"":""℃"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11010"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""29"",""NumberMin"":""25"",""RMSClass"":""RMS"",""ChiDesc"":""微蝕 溫度"",""MaxValue"":""29"",""MinValue"":""25"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002395"",""Name"":""微蝕 壓力"",""ParameterName"":""Microetching Pressure"",""Value"":""9.5"",""Unit"":""℃"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11011"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""15"",""NumberMin"":""4"",""RMSClass"":""RMS"",""ChiDesc"":""微蝕 壓力"",""MaxValue"":""15"",""MinValue"":""4"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002396"",""Name"":""酸洗(1) 壓力"",""ParameterName"":""Acid (1) Pressure"",""Value"":""9.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11012"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""15"",""NumberMin"":""4"",""RMSClass"":""RMS"",""ChiDesc"":""酸洗(1) 壓力"",""MaxValue"":""15"",""MinValue"":""4"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002397"",""Name"":""鎳(1) 溫度"",""ParameterName"":""Nickel (1) Temperature"",""Value"":""52"",""Unit"":""℃"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11013"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""54"",""NumberMin"":""50"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(1) 溫度"",""MaxValue"":""54"",""MinValue"":""50"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002398"",""Name"":""鎳(1) 壓力(1)"",""ParameterName"":""Nickel (1) Pressure (1)"",""Value"":""22.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11014"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""35"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(1) 壓力(1)"",""MaxValue"":""35"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002399"",""Name"":""鎳(1) 壓力(2)"",""ParameterName"":""Nickel (1) Pressure (2)"",""Value"":""22.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11015"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""35"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(1) 壓力(2)"",""MaxValue"":""35"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002400"",""Name"":""鎳(1) 壓力(3)"",""ParameterName"":""Nickel (1) Pressure (3)"",""Value"":""22.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11016"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""35"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(1) 壓力(3)"",""MaxValue"":""35"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002401"",""Name"":""鎳(1) 空氣流量 1-1"",""ParameterName"":""Nickel (1) Air flow 1-1"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11017"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(1) 空氣流量 1-1"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002402"",""Name"":""鎳(1) 空氣流量 1-2"",""ParameterName"":""Nickel (1) Air flow 1-2"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11018"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(1) 空氣流量 1-2"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002403"",""Name"":""鎳(1) 空氣流量 1-3"",""ParameterName"":""Nickel (1) Air flow 1-3"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11019"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(1) 空氣流量 1-3"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002404"",""Name"":""鎳(1) 空氣流量 1-4"",""ParameterName"":""Nickel (1) Air flow 1-4"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11020"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(1) 空氣流量 1-4"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002405"",""Name"":""鎳(1) 空氣流量 1-5"",""ParameterName"":""Nickel (1) Air flow 1-5"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11021"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(1) 空氣流量 1-5"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002406"",""Name"":""鎳(1) 空氣流量 1-6"",""ParameterName"":""Nickel (1) Air flow 1-6"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11022"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(1) 空氣流量 1-6"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002407"",""Name"":""鎳(2) 溫度"",""ParameterName"":""Nickel (2) Temperature"",""Value"":""52"",""Unit"":""℃"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11023"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""54"",""NumberMin"":""50"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(2) 溫度"",""MaxValue"":""54"",""MinValue"":""50"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002408"",""Name"":""鎳(2) 壓力(1)"",""ParameterName"":""Nickel (2) Pressure (1)"",""Value"":""22.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11024"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""35"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(2) 壓力(1)"",""MaxValue"":""35"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002409"",""Name"":""鎳(2) 壓力(2)"",""ParameterName"":""Nickel (2) Pressure (2)"",""Value"":""22.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11025"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""35"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(2) 壓力(2)"",""MaxValue"":""35"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002410"",""Name"":""鎳(2) 壓力(3)"",""ParameterName"":""Nickel (2) Pressure (3)"",""Value"":""22.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11026"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""35"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(2) 壓力(3)"",""MaxValue"":""35"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002411"",""Name"":""鎳(2) 空氣流量 2-1"",""ParameterName"":""Nickel (2) Air flow 2-1"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11027"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(2) 空氣流量 2-1"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002412"",""Name"":""鎳(2) 空氣流量 2-2"",""ParameterName"":""Nickel (2) Air flow 2-2"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11028"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(2) 空氣流量 2-2"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002413"",""Name"":""鎳(2) 空氣流量 2-3"",""ParameterName"":""Nickel (2) Air flow 2-3"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11029"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(2) 空氣流量 2-3"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002414"",""Name"":""鎳(2) 空氣流量 2-4"",""ParameterName"":""Nickel (2) Air flow 2-4"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11030"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(2) 空氣流量 2-4"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002415"",""Name"":""鎳(2) 空氣流量 2-5"",""ParameterName"":""Nickel (2) Air flow 2-5"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11031"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(2) 空氣流量 2-5"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002416"",""Name"":""鎳(2) 空氣流量 2-6"",""ParameterName"":""Nickel (2) Air flow 2-6"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11032"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(2) 空氣流量 2-6"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002417"",""Name"":""鎳(3) 溫度"",""ParameterName"":""Nickel (3) Temperature"",""Value"":""52"",""Unit"":""℃"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11033"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""54"",""NumberMin"":""50"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(3) 溫度"",""MaxValue"":""54"",""MinValue"":""50"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002418"",""Name"":""鎳(3) 壓力(1)"",""ParameterName"":""Nickel (3) Pressure (1)"",""Value"":""22.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11034"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""35"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(3) 壓力(1)"",""MaxValue"":""35"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002419"",""Name"":""鎳(3) 壓力(2)"",""ParameterName"":""Nickel (3) Pressure (2)"",""Value"":""22.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11035"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""35"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(3) 壓力(2)"",""MaxValue"":""35"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002420"",""Name"":""鎳(3) 壓力(3)"",""ParameterName"":""Nickel (3) Pressure (3)"",""Value"":""22.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11036"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""35"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(3) 壓力(3)"",""MaxValue"":""35"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002421"",""Name"":""鎳(3) 空氣流量 3-1"",""ParameterName"":""Nickel (3) Air flow 3-1"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11037"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(3) 空氣流量 3-1"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002422"",""Name"":""鎳(3) 空氣流量 3-2"",""ParameterName"":""Nickel (3) Air flow 3-2"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11038"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(3) 空氣流量 3-2"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002423"",""Name"":""鎳(3) 空氣流量 3-3"",""ParameterName"":""Nickel (3) Air flow 3-3"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11039"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(3) 空氣流量 3-3"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002424"",""Name"":""鎳(3) 空氣流量 3-4"",""ParameterName"":""Nickel (3) Air flow 3-4"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11040"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(3) 空氣流量 3-4"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002425"",""Name"":""鎳(3) 空氣流量 3-5"",""ParameterName"":""Nickel (3) Air flow 3-5"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11041"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(3) 空氣流量 3-5"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002426"",""Name"":""鎳(3) 空氣流量 3-6"",""ParameterName"":""Nickel (3) Air flow 3-6"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11042"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(3) 空氣流量 3-6"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002427"",""Name"":""鎳(4) 溫度"",""ParameterName"":""Nickel (4) Temperature"",""Value"":""52"",""Unit"":""℃"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11043"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""54"",""NumberMin"":""50"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(4) 溫度"",""MaxValue"":""54"",""MinValue"":""50"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002428"",""Name"":""鎳(4) 壓力(1)"",""ParameterName"":""Nickel (4) Pressure (1)"",""Value"":""22.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11044"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""35"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(4) 壓力(1)"",""MaxValue"":""35"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002431"",""Name"":""鎳(4) 壓力(2)"",""ParameterName"":""Nickel (4) Pressure (2)"",""Value"":""22.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11045"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""35"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(4) 壓力(2)"",""MaxValue"":""35"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002432"",""Name"":""鎳(4) 壓力(3)"",""ParameterName"":""Nickel (4) Pressure (3)"",""Value"":""22.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11046"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""35"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(4) 壓力(3)"",""MaxValue"":""35"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002433"",""Name"":""鎳(4) 空氣流量 4-1"",""ParameterName"":""Nickel (4) Air flow 4-1"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11047"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(4) 空氣流量 4-1"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002434"",""Name"":""鎳(4) 空氣流量 4-2"",""ParameterName"":""Nickel (4) Air flow 4-2"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11048"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(4) 空氣流量 4-2"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002435"",""Name"":""鎳(4) 空氣流量 4-3"",""ParameterName"":""Nickel (4) Air flow 4-3"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11049"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(4) 空氣流量 4-3"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002436"",""Name"":""鎳(4) 空氣流量 4-4"",""ParameterName"":""Nickel (4) Air flow 4-4"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11050"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(4) 空氣流量 4-4"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002437"",""Name"":""鎳(4) 空氣流量 4-5"",""ParameterName"":""Nickel (4) Air flow 4-5"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11051"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(4) 空氣流量 4-5"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002438"",""Name"":""鎳(4) 空氣流量 4-6"",""ParameterName"":""Nickel (4) Air flow 4-6"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11052"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(4) 空氣流量 4-6"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002440"",""Name"":""預金 溫度"",""ParameterName"":""Strike Au Temperature"",""Value"":""55"",""Unit"":""℃"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11053"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""60"",""NumberMin"":""50"",""RMSClass"":""RMS"",""ChiDesc"":""預金 溫度"",""MaxValue"":""60"",""MinValue"":""50"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002441"",""Name"":""預金 壓力"",""ParameterName"":""Strike Au Pressure"",""Value"":""17.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11054"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""25"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""預金 壓力"",""MaxValue"":""25"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002442"",""Name"":""金(1) 溫度"",""ParameterName"":""Au (1) Temperature"",""Value"":""65"",""Unit"":""℃"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11055"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""70"",""NumberMin"":""60"",""RMSClass"":""RMS"",""ChiDesc"":""金(1) 溫度"",""MaxValue"":""70"",""MinValue"":""60"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002443"",""Name"":""金(1) 壓力"",""ParameterName"":""Au (1) Pressure"",""Value"":""17.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11056"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""25"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""金(1) 壓力"",""MaxValue"":""25"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002444"",""Name"":""金(2) 溫度"",""ParameterName"":""Au (2) Temperature"",""Value"":""65"",""Unit"":""℃"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11057"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""70"",""NumberMin"":""60"",""RMSClass"":""RMS"",""ChiDesc"":""金(2) 溫度"",""MaxValue"":""70"",""MinValue"":""60"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002445"",""Name"":""金(2) 壓力"",""ParameterName"":""Au (2) Pressure"",""Value"":""17.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11058"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""25"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""金(2) 壓力"",""MaxValue"":""25"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002446"",""Name"":""後熱水洗(1) 溫度"",""ParameterName"":"" Post-Hot rinse (1) Temperature"",""Value"":""50"",""Unit"":""℃"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11059"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""55"",""NumberMin"":""45"",""RMSClass"":""RMS"",""ChiDesc"":""後熱水洗(1) 溫度"",""MaxValue"":""55"",""MinValue"":""45"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002447"",""Name"":""後熱水洗(2) 溫度"",""ParameterName"":"" Post-Hot rinse (2) Temperature"",""Value"":""50"",""Unit"":""℃"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11060"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""55"",""NumberMin"":""45"",""RMSClass"":""RMS"",""ChiDesc"":""後熱水洗(2) 溫度"",""MaxValue"":""55"",""MinValue"":""45"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000004167"",""Name"":""電鍍面積(Top)"",""ParameterName"":""Plated area(Top)"",""Value"":""25338"",""Unit"":""mm"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11061"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""150000"",""NumberMin"":""0"",""RMSClass"":""RMS"",""ChiDesc"":""電鍍面積(Top)"",""MaxValue"":""25338"",""MinValue"":""25338"",""Remark"":""25338"",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":""0"",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000004170"",""Name"":""電鍍面積(Bottom)"",""ParameterName"":""Plated area(Bottom)"",""Value"":""25338"",""Unit"":""mm"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11062"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""150000"",""NumberMin"":""0"",""RMSClass"":""RMS"",""ChiDesc"":""電鍍面積(Bottom)"",""MaxValue"":""3128"",""MinValue"":""3128"",""Remark"":""25338"",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":""0"",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""}]
,""RecipeNames"":null,""IsMultiRecipe"":false,""TypeStatus"":""ACTIVE"",""RecipeStatus"":""ACTIVE"",""Creator"":null}";

        public static string AE2TalkObjectV2Value = @"{
""Eqp_Name"":""M0000802"",
""LotNo"":""123456789"",
""RMSName"":""GOLDEN_RECIPE_AUNI_E_PLATING"",
""Mach_Type"":""A040002"",
""StepId"":null,
""StepName"":null,
""ResultFlag"":true,
""ResultMessage"":"""",
""RecipeName"":""9723-N51W022028-V0054"",
""Version"":""0"",""Machine_Descript"":null,
""Items"":[
{""Id"":""1000002382"",""Name"":""鍍鎳 (W/B)"",""ParameterName"":""Ni plated (W/B)"",""Value"":""1.22"",""Unit"":""ASD"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11001"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""2.20"",""NumberMin"":""0"",""RMSClass"":""RMS"",""ChiDesc"":""鍍鎳 (W/B)"",""MaxValue"":""1.42"",""MinValue"":""1.02"",""Remark"":""1.05"",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":""0"",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002383"",""Name"":""鍍鎳 (B)"",""ParameterName"":""Ni plated (B)"",""Value"":""0"",""Unit"":""ASD"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11002"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""2.20"",""NumberMin"":""0"",""RMSClass"":""RMS"",""ChiDesc"":""鍍鎳 (B)"",""MaxValue"":""0"",""MinValue"":""0"",""Remark"":""0"",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":""0"",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002384"",""Name"":""預鍍金 (A)"",""ParameterName"":""Au strike (A)"",""Value"":""1.8"",""Unit"":""A"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11003"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""50"",""NumberMin"":""0"",""RMSClass"":""RMS"",""ChiDesc"":""預鍍金 (A)"",""MaxValue"":""20.6"",""MinValue"":""20.4"",""Remark"":""20.5"",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":""0"",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002385"",""Name"":""鍍金 (W/B)"",""ParameterName"":""Au plated (W/B)"",""Value"":""0.143"",""Unit"":""ASD"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11004"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""2"",""NumberMin"":""0"",""RMSClass"":""RMS"",""ChiDesc"":""鍍金 (W/B)"",""MaxValue"":""0.158"",""MinValue"":""0.128"",""Remark"":""0.155"",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":""0"",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002386"",""Name"":""鍍金 (B)"",""ParameterName"":""Au plated (B)"",""Value"":""0"",""Unit"":""ASD"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11005"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""2"",""NumberMin"":""0"",""RMSClass"":""RMS"",""ChiDesc"":""鍍金 (B)"",""MaxValue"":""0"",""MinValue"":""0"",""Remark"":""0"",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":""0"",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002390"",""Name"":""前熱水洗(1) 溫度"",""ParameterName"":""Pre-Hot rinse (1) Temperature"",""Value"":""50"",""Unit"":""℃"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11006"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""55"",""NumberMin"":""45"",""RMSClass"":""RMS"",""ChiDesc"":""前熱水洗(1) 溫度"",""MaxValue"":""55"",""MinValue"":""45"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002391"",""Name"":""前熱水洗(2) 溫度"",""ParameterName"":""Pre-Hot rinse (2) Temperature"",""Value"":""50"",""Unit"":""℃"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11007"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""55"",""NumberMin"":""45"",""RMSClass"":""RMS"",""ChiDesc"":""前熱水洗(2) 溫度"",""MaxValue"":""55"",""MinValue"":""45"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002392"",""Name"":""脫脂 壓力"",""ParameterName"":""Clean Pressure"",""Value"":""5.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11008"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""10"",""NumberMin"":""1"",""RMSClass"":""RMS"",""ChiDesc"":""脫脂 壓力"",""MaxValue"":""10"",""MinValue"":""1"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002393"",""Name"":""脫脂 溫度"",""ParameterName"":""Clean Temperature"",""Value"":""40"",""Unit"":""℃"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11009"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""45"",""NumberMin"":""35"",""RMSClass"":""RMS"",""ChiDesc"":""脫脂 溫度"",""MaxValue"":""45"",""MinValue"":""35"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002394"",""Name"":""微蝕 溫度"",""ParameterName"":""Microetching Temperature"",""Value"":""27"",""Unit"":""℃"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11010"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""29"",""NumberMin"":""25"",""RMSClass"":""RMS"",""ChiDesc"":""微蝕 溫度"",""MaxValue"":""29"",""MinValue"":""25"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002395"",""Name"":""微蝕 壓力"",""ParameterName"":""Microetching Pressure"",""Value"":""9.5"",""Unit"":""℃"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11011"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""15"",""NumberMin"":""4"",""RMSClass"":""RMS"",""ChiDesc"":""微蝕 壓力"",""MaxValue"":""15"",""MinValue"":""4"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002396"",""Name"":""酸洗(1) 壓力"",""ParameterName"":""Acid (1) Pressure"",""Value"":""9.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11012"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""15"",""NumberMin"":""4"",""RMSClass"":""RMS"",""ChiDesc"":""酸洗(1) 壓力"",""MaxValue"":""15"",""MinValue"":""4"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002397"",""Name"":""鎳(1) 溫度"",""ParameterName"":""Nickel (1) Temperature"",""Value"":""52"",""Unit"":""℃"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11013"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""54"",""NumberMin"":""50"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(1) 溫度"",""MaxValue"":""54"",""MinValue"":""50"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002398"",""Name"":""鎳(1) 壓力(1)"",""ParameterName"":""Nickel (1) Pressure (1)"",""Value"":""22.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11014"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""35"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(1) 壓力(1)"",""MaxValue"":""35"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002399"",""Name"":""鎳(1) 壓力(2)"",""ParameterName"":""Nickel (1) Pressure (2)"",""Value"":""22.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11015"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""35"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(1) 壓力(2)"",""MaxValue"":""35"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002400"",""Name"":""鎳(1) 壓力(3)"",""ParameterName"":""Nickel (1) Pressure (3)"",""Value"":""22.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11016"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""35"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(1) 壓力(3)"",""MaxValue"":""35"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002401"",""Name"":""鎳(1) 空氣流量 1-1"",""ParameterName"":""Nickel (1) Air flow 1-1"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11017"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(1) 空氣流量 1-1"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002402"",""Name"":""鎳(1) 空氣流量 1-2"",""ParameterName"":""Nickel (1) Air flow 1-2"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11018"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(1) 空氣流量 1-2"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002403"",""Name"":""鎳(1) 空氣流量 1-3"",""ParameterName"":""Nickel (1) Air flow 1-3"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11019"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(1) 空氣流量 1-3"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002404"",""Name"":""鎳(1) 空氣流量 1-4"",""ParameterName"":""Nickel (1) Air flow 1-4"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11020"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(1) 空氣流量 1-4"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002405"",""Name"":""鎳(1) 空氣流量 1-5"",""ParameterName"":""Nickel (1) Air flow 1-5"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11021"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(1) 空氣流量 1-5"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002406"",""Name"":""鎳(1) 空氣流量 1-6"",""ParameterName"":""Nickel (1) Air flow 1-6"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11022"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(1) 空氣流量 1-6"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002407"",""Name"":""鎳(2) 溫度"",""ParameterName"":""Nickel (2) Temperature"",""Value"":""52"",""Unit"":""℃"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11023"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""54"",""NumberMin"":""50"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(2) 溫度"",""MaxValue"":""54"",""MinValue"":""50"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002408"",""Name"":""鎳(2) 壓力(1)"",""ParameterName"":""Nickel (2) Pressure (1)"",""Value"":""22.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11024"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""35"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(2) 壓力(1)"",""MaxValue"":""35"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002409"",""Name"":""鎳(2) 壓力(2)"",""ParameterName"":""Nickel (2) Pressure (2)"",""Value"":""22.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11025"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""35"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(2) 壓力(2)"",""MaxValue"":""35"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002410"",""Name"":""鎳(2) 壓力(3)"",""ParameterName"":""Nickel (2) Pressure (3)"",""Value"":""22.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11026"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""35"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(2) 壓力(3)"",""MaxValue"":""35"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002411"",""Name"":""鎳(2) 空氣流量 2-1"",""ParameterName"":""Nickel (2) Air flow 2-1"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11027"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(2) 空氣流量 2-1"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002412"",""Name"":""鎳(2) 空氣流量 2-2"",""ParameterName"":""Nickel (2) Air flow 2-2"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11028"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(2) 空氣流量 2-2"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002413"",""Name"":""鎳(2) 空氣流量 2-3"",""ParameterName"":""Nickel (2) Air flow 2-3"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11029"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(2) 空氣流量 2-3"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002414"",""Name"":""鎳(2) 空氣流量 2-4"",""ParameterName"":""Nickel (2) Air flow 2-4"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11030"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(2) 空氣流量 2-4"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002415"",""Name"":""鎳(2) 空氣流量 2-5"",""ParameterName"":""Nickel (2) Air flow 2-5"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11031"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(2) 空氣流量 2-5"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002416"",""Name"":""鎳(2) 空氣流量 2-6"",""ParameterName"":""Nickel (2) Air flow 2-6"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11032"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(2) 空氣流量 2-6"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002417"",""Name"":""鎳(3) 溫度"",""ParameterName"":""Nickel (3) Temperature"",""Value"":""52"",""Unit"":""℃"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11033"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""54"",""NumberMin"":""50"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(3) 溫度"",""MaxValue"":""54"",""MinValue"":""50"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002418"",""Name"":""鎳(3) 壓力(1)"",""ParameterName"":""Nickel (3) Pressure (1)"",""Value"":""22.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11034"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""35"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(3) 壓力(1)"",""MaxValue"":""35"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002419"",""Name"":""鎳(3) 壓力(2)"",""ParameterName"":""Nickel (3) Pressure (2)"",""Value"":""22.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11035"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""35"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(3) 壓力(2)"",""MaxValue"":""35"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002420"",""Name"":""鎳(3) 壓力(3)"",""ParameterName"":""Nickel (3) Pressure (3)"",""Value"":""22.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11036"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""35"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(3) 壓力(3)"",""MaxValue"":""35"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002421"",""Name"":""鎳(3) 空氣流量 3-1"",""ParameterName"":""Nickel (3) Air flow 3-1"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11037"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(3) 空氣流量 3-1"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002422"",""Name"":""鎳(3) 空氣流量 3-2"",""ParameterName"":""Nickel (3) Air flow 3-2"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11038"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(3) 空氣流量 3-2"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002423"",""Name"":""鎳(3) 空氣流量 3-3"",""ParameterName"":""Nickel (3) Air flow 3-3"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11039"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(3) 空氣流量 3-3"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002424"",""Name"":""鎳(3) 空氣流量 3-4"",""ParameterName"":""Nickel (3) Air flow 3-4"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11040"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(3) 空氣流量 3-4"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002425"",""Name"":""鎳(3) 空氣流量 3-5"",""ParameterName"":""Nickel (3) Air flow 3-5"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11041"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(3) 空氣流量 3-5"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002426"",""Name"":""鎳(3) 空氣流量 3-6"",""ParameterName"":""Nickel (3) Air flow 3-6"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11042"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(3) 空氣流量 3-6"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002427"",""Name"":""鎳(4) 溫度"",""ParameterName"":""Nickel (4) Temperature"",""Value"":""52"",""Unit"":""℃"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11043"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""54"",""NumberMin"":""50"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(4) 溫度"",""MaxValue"":""54"",""MinValue"":""50"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002428"",""Name"":""鎳(4) 壓力(1)"",""ParameterName"":""Nickel (4) Pressure (1)"",""Value"":""22.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11044"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""35"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(4) 壓力(1)"",""MaxValue"":""35"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002431"",""Name"":""鎳(4) 壓力(2)"",""ParameterName"":""Nickel (4) Pressure (2)"",""Value"":""22.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11045"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""35"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(4) 壓力(2)"",""MaxValue"":""35"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002432"",""Name"":""鎳(4) 壓力(3)"",""ParameterName"":""Nickel (4) Pressure (3)"",""Value"":""22.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11046"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""35"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(4) 壓力(3)"",""MaxValue"":""35"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002433"",""Name"":""鎳(4) 空氣流量 4-1"",""ParameterName"":""Nickel (4) Air flow 4-1"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11047"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(4) 空氣流量 4-1"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002434"",""Name"":""鎳(4) 空氣流量 4-2"",""ParameterName"":""Nickel (4) Air flow 4-2"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11048"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(4) 空氣流量 4-2"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002435"",""Name"":""鎳(4) 空氣流量 4-3"",""ParameterName"":""Nickel (4) Air flow 4-3"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11049"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(4) 空氣流量 4-3"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002436"",""Name"":""鎳(4) 空氣流量 4-4"",""ParameterName"":""Nickel (4) Air flow 4-4"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11050"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(4) 空氣流量 4-4"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002437"",""Name"":""鎳(4) 空氣流量 4-5"",""ParameterName"":""Nickel (4) Air flow 4-5"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11051"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(4) 空氣流量 4-5"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002438"",""Name"":""鎳(4) 空氣流量 4-6"",""ParameterName"":""Nickel (4) Air flow 4-6"",""Value"":""175"",""Unit"":""L/Min"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11052"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""200"",""NumberMin"":""150"",""RMSClass"":""RMS"",""ChiDesc"":""鎳(4) 空氣流量 4-6"",""MaxValue"":""200"",""MinValue"":""150"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002440"",""Name"":""預金 溫度"",""ParameterName"":""Strike Au Temperature"",""Value"":""55"",""Unit"":""℃"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11053"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""60"",""NumberMin"":""50"",""RMSClass"":""RMS"",""ChiDesc"":""預金 溫度"",""MaxValue"":""60"",""MinValue"":""50"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002441"",""Name"":""預金 壓力"",""ParameterName"":""Strike Au Pressure"",""Value"":""17.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11054"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""25"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""預金 壓力"",""MaxValue"":""25"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002442"",""Name"":""金(1) 溫度"",""ParameterName"":""Au (1) Temperature"",""Value"":""65"",""Unit"":""℃"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11055"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""70"",""NumberMin"":""60"",""RMSClass"":""RMS"",""ChiDesc"":""金(1) 溫度"",""MaxValue"":""70"",""MinValue"":""60"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002443"",""Name"":""金(1) 壓力"",""ParameterName"":""Au (1) Pressure"",""Value"":""17.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11056"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""25"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""金(1) 壓力"",""MaxValue"":""25"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002444"",""Name"":""金(2) 溫度"",""ParameterName"":""Au (2) Temperature"",""Value"":""65"",""Unit"":""℃"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11057"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""70"",""NumberMin"":""60"",""RMSClass"":""RMS"",""ChiDesc"":""金(2) 溫度"",""MaxValue"":""70"",""MinValue"":""60"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002445"",""Name"":""金(2) 壓力"",""ParameterName"":""Au (2) Pressure"",""Value"":""17.5"",""Unit"":""Psi"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11058"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""25"",""NumberMin"":""10"",""RMSClass"":""RMS"",""ChiDesc"":""金(2) 壓力"",""MaxValue"":""25"",""MinValue"":""10"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002446"",""Name"":""後熱水洗(1) 溫度"",""ParameterName"":"" Post-Hot rinse (1) Temperature"",""Value"":""50"",""Unit"":""℃"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11059"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""55"",""NumberMin"":""45"",""RMSClass"":""RMS"",""ChiDesc"":""後熱水洗(1) 溫度"",""MaxValue"":""55"",""MinValue"":""45"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000002447"",""Name"":""後熱水洗(2) 溫度"",""ParameterName"":"" Post-Hot rinse (2) Temperature"",""Value"":""50"",""Unit"":""℃"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11060"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""55"",""NumberMin"":""45"",""RMSClass"":""RMS"",""ChiDesc"":""後熱水洗(2) 溫度"",""MaxValue"":""55"",""MinValue"":""45"",""Remark"":"""",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":"""",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000004167"",""Name"":""電鍍面積(Top)"",""ParameterName"":""Plated area(Top)"",""Value"":""25338"",""Unit"":""mm"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11061"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""150000"",""NumberMin"":""0"",""RMSClass"":""RMS"",""ChiDesc"":""電鍍面積(Top)"",""MaxValue"":""25338"",""MinValue"":""25338"",""Remark"":""25338"",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":""0"",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""},
{""Id"":""1000004170"",""Name"":""電鍍面積(Bottom)"",""ParameterName"":""Plated area(Bottom)"",""Value"":""25338"",""Unit"":""mm"",""CheckPoint"":""TRACKIN"",""LinkType"":""VID"",""Status"":""ACTIVE"",""LinkData"":""11062"",""DataType"":""NUMBER"",""StepName"":"""",""NumberMax"":""150000"",""NumberMin"":""0"",""RMSClass"":""RMS"",""ChiDesc"":""電鍍面積(Bottom)"",""MaxValue"":""3128"",""MinValue"":""3128"",""Remark"":""25338"",""Location"":"""",""LocationType"":"""",""Separatestring"":"""",""LocationIndex"":""0"",""PreFix"":"""",""PostFix"":"""",""TCL"":"""",""UCL"":"""",""LCL"":"""",""ChamberName"":""""}]
,""RecipeNames"":null,""IsMultiRecipe"":false,""TypeStatus"":""ACTIVE"",""RecipeStatus"":""ACTIVE"",""Creator"":null}";


        public static string EDCValue = @"<?xml version=\""1.0\"" encoding=\""UTF-8\""?>
            <RECORD>
            <DB_NAME>ASEE_EDC</DB_NAME>
            <Mach_Facility>ASEE1</Mach_Facility>
            <Mach_Oper></Mach_Oper>
            <Mach_ID></Mach_ID>
            <EQP_Name>M0000802</EQP_Name>
            <Evt_Name></Evt_Name>
            <LOT_ID></LOT_ID>
            <DETAIL>
                <ROW>
                    <SVID_NAME>PreHotRinse1Temperature</SVID_NAME>""     
                    <SVID_VALUE>Pre-Hot rinse (1) Temperature 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>PreHotRinse2Temperature</SVID_NAME>""     
                    <SVID_VALUE>Pre-Hot rinse (2) Temperature 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>CleanPressure</SVID_NAME>""     
                    <SVID_VALUE>Clean Pressure 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>CleanTemperature</SVID_NAME>""     
                    <SVID_VALUE>CleanTemperature 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>MicroetchingTemperature</SVID_NAME>""     
                    <SVID_VALUE>Microetching Temperature 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>MicroetchingPressure</SVID_NAME>""     
                    <SVID_VALUE>MicroetchingPressure 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Acid1Pressure</SVID_NAME>""     
                    <SVID_VALUE>Acid1Pressure 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel1Temperature</SVID_NAME>""     
                    <SVID_VALUE>Nickel1Temperature 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel1Pressure1</SVID_NAME>""     
                    <SVID_VALUE>Nickel1Pressure1 9999/SVID_VALUE>""    //對照參數實際值
                </ROW> <ROW>
                    <SVID_NAME>Nickel1Pressure2</SVID_NAME>""     
                    <SVID_VALUE>Nickel1Pressure2 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel1Pressure3</SVID_NAME>""     
                    <SVID_VALUE>Nickel1Pressure3 9999/SVID_VALUE>""    //對照參數實際值
                </ROW> <ROW>
                    <SVID_NAME>Nickel1AirFlow1_1</SVID_NAME>""     
                    <SVID_VALUE>Nickel1AirFlow1_1 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel1AirFlow1_2</SVID_NAME>""     
                    <SVID_VALUE>Nickel1AirFlow1_2 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel1AirFlow1_3</SVID_NAME>""     
                    <SVID_VALUE>Nickel1AirFlow1_3 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel1AirFlow1_4</SVID_NAME>""     
                    <SVID_VALUE>Nickel1AirFlow1_4 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel1AirFlow1_5</SVID_NAME>""     
                    <SVID_VALUE>Nickel1AirFlow1_5 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel1AirFlow1_6</SVID_NAME>""     
                    <SVID_VALUE>Nickel1AirFlow1_6 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel2Temperature</SVID_NAME>""     
                    <SVID_VALUE>Nickel2Temperature 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel2Pressure1</SVID_NAME>""     
                    <SVID_VALUE>Nickel2Pressure1 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel2Pressure2</SVID_NAME>""     
                    <SVID_VALUE>Nickel2Pressure2 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel2Pressure3</SVID_NAME>""     
                    <SVID_VALUE>Nickel2Pressure3 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel2AirFlow2_1</SVID_NAME>""     
                    <SVID_VALUE>Nickel2AirFlow2_1 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel2AirFlow2_2</SVID_NAME>""     
                    <SVID_VALUE>Nickel2AirFlow2_2 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel2AirFlow2_3</SVID_NAME>""     
                    <SVID_VALUE>Nickel2AirFlow2_3 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel2AirFlow2_4</SVID_NAME>""     
                    <SVID_VALUE>Nickel2AirFlow2_4 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel2AirFlow2_5</SVID_NAME>""     
                    <SVID_VALUE>Nickel2AirFlow2_5 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel2AirFlow2_6</SVID_NAME>""     
                    <SVID_VALUE>Nickel2AirFlow2_6 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel3Temperature</SVID_NAME>""     
                    <SVID_VALUE>Nickel3Temperature 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel3Pressure1</SVID_NAME>""     
                    <SVID_VALUE>Nickel3Pressure1 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel3Pressure2</SVID_NAME>""     
                    <SVID_VALUE>Nickel3Pressure2 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel3Pressure3</SVID_NAME>""     
                    <SVID_VALUE>Nickel3Pressure3 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel3AirFlow3_1</SVID_NAME>""     
                    <SVID_VALUE>Nickel3AirFlow3_1 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel3AirFlow3_2</SVID_NAME>""     
                    <SVID_VALUE>Nickel3AirFlow3_2 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel3AirFlow3_3</SVID_NAME>""     
                    <SVID_VALUE>Nickel3AirFlow3_3 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel3AirFlow3_4</SVID_NAME>""     
                    <SVID_VALUE>Nickel3AirFlow3_4 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel3AirFlow3_5</SVID_NAME>""     
                    <SVID_VALUE>Nickel3AirFlow3_5 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel3AirFlow3_6</SVID_NAME>""     
                    <SVID_VALUE>Nickel3AirFlow3_6 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel4Temperature</SVID_NAME>""     
                    <SVID_VALUE>Nickel4Temperature 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel4Pressure1</SVID_NAME>""     
                    <SVID_VALUE>Nickel4Pressure1 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel4Pressure2</SVID_NAME>""     
                    <SVID_VALUE>Nickel4Pressure2 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel4Pressure3</SVID_NAME>""     
                    <SVID_VALUE>Nickel4Pressure3 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel4AirFlow4_1</SVID_NAME>""     
                    <SVID_VALUE>Nickel4AirFlow4_1 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel4AirFlow4_2</SVID_NAME>""     
                    <SVID_VALUE>Nickel4AirFlow4_2 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel4AirFlow4_3</SVID_NAME>""     
                    <SVID_VALUE>Nickel4AirFlow4_3 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel4AirFlow4_4</SVID_NAME>""     
                    <SVID_VALUE>Nickel4AirFlow4_4 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel4AirFlow4_5</SVID_NAME>""     
                    <SVID_VALUE>Nickel4AirFlow4_5 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>Nickel4AirFlow4_6</SVID_NAME>""     
                    <SVID_VALUE>Nickel4AirFlow4_6 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>StrikeAuTemperature</SVID_NAME>""     
                    <SVID_VALUE>StrikeAuTemperature 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>StrikeAuPressure</SVID_NAME>""     
                    <SVID_VALUE>StrikeAuPressure 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>StrikeAu1Temperature</SVID_NAME>""     
                    <SVID_VALUE>StrikeAu1Temperature 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>StrikeAu1Pressure</SVID_NAME>""     
                    <SVID_VALUE>StrikeAu1Pressure 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>StrikeAu2Temperature</SVID_NAME>""     
                    <SVID_VALUE>StrikeAu2Temperature 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>StrikeAu2Pressure</SVID_NAME>""     
                    <SVID_VALUE>StrikeAu2Pressure 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>PostHotRinse1Temperature</SVID_NAME>""     
                    <SVID_VALUE>PostHotRinse1Temperature 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>PostHotRinse2Temperature</SVID_NAME>""     
                    <SVID_VALUE>PostHotRinse2Temperature 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>WashMachineTemperature</SVID_NAME>""     
                    <SVID_VALUE>WashMachineTemperature 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>WashMachineLineSpeed</SVID_NAME>""     
                    <SVID_VALUE>WashMachineLineSpeed 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>WashMachine1OverFlow</SVID_NAME>""     
                    <SVID_VALUE>WashMachine1OverFlow 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>WashMachine2OverFlow</SVID_NAME>""     
                    <SVID_VALUE>WashMachine2OverFlow 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>WashMachine3OverFlow</SVID_NAME>""     
                    <SVID_VALUE>WashMachine3OverFlow 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>WashMachineWaterRinseTankPressure1</SVID_NAME>""     
                    <SVID_VALUE>WashMachineWaterRinseTankPressure1 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>WashMachineWaterRinseTankPressure2</SVID_NAME>""     
                    <SVID_VALUE>WashMachineWaterRinseTankPressure2 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>WashMachineWaterRinseTankPressure3</SVID_NAME>""     
                    <SVID_VALUE>WashMachineWaterRinseTankPressure3 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>WashMachineWaterRinseTankPressure4</SVID_NAME>""     
                    <SVID_VALUE>WashMachineWaterRinseTankPressure4 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>WashMachineWaterRinseTankPressure5</SVID_NAME>""     
                    <SVID_VALUE>WashMachineWaterRinseTankPressure5 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>WashMachineWaterRinseTankPressure6</SVID_NAME>""     
                    <SVID_VALUE>WashMachineWaterRinseTankPressure6 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>WashMachineWaterRinseTankPressure7</SVID_NAME>""     
                    <SVID_VALUE>WashMachineWaterRinseTankPressure7 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>WashMachineWaterRinseTankPressure8</SVID_NAME>""     
                    <SVID_VALUE>WashMachineWaterRinseTankPressure8 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>WashMachineWaterRinseTankPressure9</SVID_NAME>""     
                    <SVID_VALUE>WashMachineWaterRinseTankPressure9 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>WashMachineWaterRinseTankPressure10</SVID_NAME>""     
                    <SVID_VALUE>WashMachineWaterRinseTankPressure10 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>WashMachineWaterRinseTankPressure11</SVID_NAME>""     
                    <SVID_VALUE>WashMachineWaterRinseTankPressure11 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>WashMachineWaterRinseTankPressure12</SVID_NAME>""     
                    <SVID_VALUE>WashMachineWaterRinseTankPressure12 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>WashMachineWaterRinseTankPressure13</SVID_NAME>""     
                    <SVID_VALUE>WashMachineWaterRinseTankPressure13 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>WashMachineAirFlow1</SVID_NAME>""     
                    <SVID_VALUE>WashMachineAirFlow1 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>WashMachineAirFlow2</SVID_NAME>""     
                    <SVID_VALUE>WashMachineAirFlow2 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>WashMachineAirFlow3</SVID_NAME>""     
                    <SVID_VALUE>WashMachineAirFlow3 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>WashMachineAirFlow4</SVID_NAME>""     
                    <SVID_VALUE>WashMachineAirFlow4 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>WashMachineConductance</SVID_NAME>""     
                    <SVID_VALUE>WashMachineConductance 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>RinseTank3OverFlowAmount</SVID_NAME>""     
                    <SVID_VALUE>RinseTank3OverFlowAmount 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>RinseTank4OverFlowAmount</SVID_NAME>""     
                    <SVID_VALUE>RinseTank4OverFlowAmount 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>RinseTank7OverFlowAmount</SVID_NAME>""     
                    <SVID_VALUE>RinseTank7OverFlowAmount 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>RinseTank9OverFlowAmount</SVID_NAME>""     
                    <SVID_VALUE>RinseTank9OverFlowAmount 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>RinseTank12OverFlowAmount</SVID_NAME>""     
                    <SVID_VALUE>RinseTank12OverFlowAmount 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>RinseTank15OverFlowAmount</SVID_NAME>""     
                    <SVID_VALUE>RinseTank15OverFlowAmount 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>RinseTank17OverFlowAmount</SVID_NAME>""     
                    <SVID_VALUE>RinseTank17OverFlowAmount 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>RinseTank20OverFlowAmount</SVID_NAME>""     
                    <SVID_VALUE>RinseTank20OverFlowAmount 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>RinseTank22OverFlowAmount</SVID_NAME>""     
                    <SVID_VALUE>RinseTank22OverFlowAmount 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>RinseTank25OverFlowAmount</SVID_NAME>""     
                    <SVID_VALUE>RinseTank25OverFlowAmount 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <SVID_NAME>BlowerPressure</SVID_NAME>""     
                    <SVID_VALUE>BlowerPressure 9999/SVID_VALUE>""    //對照參數實際值
                </ROW>
	
   
            </DETAIL>
            </RECORD>";

        public static string ADCValue = @"//ADC Sample
            <?xml version=\""1.0\"" encoding=\""UTF-8\""?>
            <RECORD>
            <DB_NAME>9723_01</DB_NAME>
            <Mach_Facility>ASEE1</Mach_Facility>
            <Mach_Oper>9723</Mach_Oper>
            <Mach_ID>9723-A040-0002</Mach_ID>
            <EQP_Name>M0000802</EQP_Name>
            <Evt_Name></Evt_Name>
            <Lot_ID>lot</Lot_ID>
            <DETAIL>
                <ROW>
                    <NgStampUsed>11001</NgStampUsed> 
                    <Continuous_OPEN>Ni plated (W/B) 9999/Continuous_OPEN> //對照參數實際值
                </ROW>
                <ROW>
                    <NgStampUsed>11002</NgStampUsed>""     
                    <Continuous_OPEN>Ni plated (B) 9999/Continuous_OPEN>""    //對照參數實際值
                 </ROW>
	             <ROW>
                    <NgStampUsed>11003</NgStampUsed>""     
                    <Continuous_OPEN>Au strike (A) 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11004</NgStampUsed>""     
                    <Continuous_OPEN>Au plated (W/B) 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11005</NgStampUsed>""     
                    <Continuous_OPEN>Au plated (B) 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
                <ROW>
                    <NgStampUsed>11006</NgStampUsed>""     
                    <Continuous_OPEN>Pre-Hot rinse (1) Temperature 9999/Continuous_OPEN>""    //對照參數實際值
                 </ROW>
	             <ROW>
                    <NgStampUsed>11007</NgStampUsed>""     
                    <Continuous_OPEN>Pre-Hot rinse (2) Temperature 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11008</NgStampUsed>""     
                    <Continuous_OPEN>Clean Pressure 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11009</NgStampUsed>""     
                    <Continuous_OPEN>CleanTemperature 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11010</NgStampUsed>""     
                    <Continuous_OPEN>Microetching Temperature 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11011</NgStampUsed>""     
                    <Continuous_OPEN>MicroetchingPressure 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11012</NgStampUsed>""     
                    <Continuous_OPEN>Acid1Pressure 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11013e</NgStampUsed>""     
                    <Continuous_OPEN>Nickel1Temperature 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11014</NgStampUsed>""     
                    <Continuous_OPEN>Nickel1Pressure1 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW> <ROW>
                    <NgStampUsed>11015</NgStampUsed>""     
                    <Continuous_OPEN>Nickel1Pressure2 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11016</NgStampUsed>""     
                    <Continuous_OPEN>Nickel1Pressure3 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW> <ROW>
                    <NgStampUsed>11017</NgStampUsed>""     
                    <Continuous_OPEN>Nickel1AirFlow1_1 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11018</NgStampUsed>""     
                    <Continuous_OPEN>Nickel1AirFlow1_2 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11019</NgStampUsed>""     
                    <Continuous_OPEN>Nickel1AirFlow1_3 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11020</NgStampUsed>""     
                    <Continuous_OPEN>Nickel1AirFlow1_4 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11021</NgStampUsed>""     
                    <Continuous_OPEN>Nickel1AirFlow1_5 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11022</NgStampUsed>""     
                    <Continuous_OPEN>Nickel1AirFlow1_6 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11023</NgStampUsed>""     
                    <Continuous_OPEN>Nickel2Temperature 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11024</NgStampUsed>""     
                    <Continuous_OPEN>Nickel2Pressure1 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11025</NgStampUsed>""     
                    <Continuous_OPEN>Nickel2Pressure2 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11026</NgStampUsed>""     
                    <Continuous_OPEN>Nickel2Pressure3 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11027</NgStampUsed>""     
                    <Continuous_OPEN>Nickel2AirFlow2_1 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11028</NgStampUsed>""     
                    <Continuous_OPEN>Nickel2AirFlow2_2 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11029</NgStampUsed>""     
                    <Continuous_OPEN>Nickel2AirFlow2_3 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11030</NgStampUsed>""     
                    <Continuous_OPEN>Nickel2AirFlow2_4 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11031</NgStampUsed>""     
                    <Continuous_OPEN>Nickel2AirFlow2_5 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11032</NgStampUsed>""     
                    <Continuous_OPEN>Nickel2AirFlow2_6 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11033</NgStampUsed>""     
                    <Continuous_OPEN>Nickel3Temperature 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11034</NgStampUsed>""     
                    <Continuous_OPEN>Nickel3Pressure1 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11035</NgStampUsed>""     
                    <Continuous_OPEN>Nickel3Pressure2 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11036</NgStampUsed>""     
                    <Continuous_OPEN>Nickel3Pressure3 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11037</NgStampUsed>""     
                    <Continuous_OPEN>Nickel3AirFlow3_1 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11038</NgStampUsed>""     
                    <Continuous_OPEN>Nickel3AirFlow3_2 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11039</NgStampUsed>""     
                    <Continuous_OPEN>Nickel3AirFlow3_3 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11040</NgStampUsed>""     
                    <Continuous_OPEN>Nickel3AirFlow3_4 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11041</NgStampUsed>""     
                    <Continuous_OPEN>Nickel3AirFlow3_5 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11042</NgStampUsed>""     
                    <Continuous_OPEN>Nickel3AirFlow3_6 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11043</NgStampUsed>""     
                    <Continuous_OPEN>Nickel4Temperature 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11044</NgStampUsed>""     
                    <Continuous_OPEN>Nickel4Pressure1 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11045</NgStampUsed>""     
                    <Continuous_OPEN>Nickel4Pressure2 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11046</NgStampUsed>""     
                    <Continuous_OPEN>Nickel4Pressure3 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11047</NgStampUsed>""     
                    <Continuous_OPEN>Nickel4AirFlow4_1 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11048</NgStampUsed>""     
                    <Continuous_OPEN>Nickel4AirFlow4_2 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11049</NgStampUsed>""     
                    <Continuous_OPEN>Nickel4AirFlow4_3 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11050</NgStampUsed>""     
                    <Continuous_OPEN>Nickel4AirFlow4_4 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11051</NgStampUsed>""     
                    <Continuous_OPEN>Nickel4AirFlow4_5 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11052</NgStampUsed>""     
                    <Continuous_OPEN>Nickel4AirFlow4_6 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11053</NgStampUsed>""     
                    <Continuous_OPEN>StrikeAuTemperature 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11054</NgStampUsed>""     
                    <Continuous_OPEN>StrikeAuPressure 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11055</NgStampUsed>""     
                    <Continuous_OPEN>StrikeAu1Temperature 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11056</NgStampUsed>""     
                    <Continuous_OPEN>StrikeAu1Pressure 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11057</NgStampUsed>""     
                    <Continuous_OPEN>StrikeAu2Temperature 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11058</NgStampUsed>""     
                    <Continuous_OPEN>StrikeAu2Pressure 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11059</NgStampUsed>""     
                    <Continuous_OPEN>PostHotRinse1Temperature 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11060</NgStampUsed>""     
                    <Continuous_OPEN>PostHotRinse2Temperature 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11061</NgStampUsed>""     
                    <Continuous_OPEN>Plated area(Top) 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11062</NgStampUsed>""     
                    <Continuous_OPEN>Plated area(Bottom) 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>10063</NgStampUsed>""     
                    <Continuous_OPEN>WashMachineTemperature 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11064</NgStampUsed>""     
                    <Continuous_OPEN>WashMachineLineSpeed 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11065</NgStampUsed>""     
                    <Continuous_OPEN>WashMachine1OverFlow 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11066</NgStampUsed>""     
                    <Continuous_OPEN>WashMachine2OverFlow 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11067</NgStampUsed>""     
                    <Continuous_OPEN>WashMachine3OverFlow 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11068</NgStampUsed>""     
                    <Continuous_OPEN>WashMachineWaterRinseTankPressure1 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11069</NgStampUsed>""     
                    <Continuous_OPEN>WashMachineWaterRinseTankPressure2 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11070</NgStampUsed>""     
                    <Continuous_OPEN>WashMachineWaterRinseTankPressure3 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11071</NgStampUsed>""     
                    <Continuous_OPEN>WashMachineWaterRinseTankPressure4 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11072</NgStampUsed>""     
                    <Continuous_OPEN>WashMachineWaterRinseTankPressure5 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11073</NgStampUsed>""     
                    <Continuous_OPEN>WashMachineWaterRinseTankPressure6 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11074</NgStampUsed>""     
                    <Continuous_OPEN>WashMachineWaterRinseTankPressure7 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11075</NgStampUsed>""     
                    <Continuous_OPEN>WashMachineWaterRinseTankPressure8 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11076</NgStampUsed>""     
                    <Continuous_OPEN>WashMachineWaterRinseTankPressure9 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11077</NgStampUsed>""     
                    <Continuous_OPEN>WashMachineWaterRinseTankPressure10 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11078</NgStampUsed>""     
                    <Continuous_OPEN>WashMachineWaterRinseTankPressure11 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11079</NgStampUsed>""     
                    <Continuous_OPEN>WashMachineWaterRinseTankPressure12 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11080</NgStampUsed>""     
                    <Continuous_OPEN>WashMachineWaterRinseTankPressure13 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11081</NgStampUsed>""     
                    <Continuous_OPEN>WashMachineAirFlow1 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11082</NgStampUsed>""     
                    <Continuous_OPEN>WashMachineAirFlow2 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11083</NgStampUsed>""     
                    <Continuous_OPEN>WashMachineAirFlow3 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11084</NgStampUsed>""     
                    <Continuous_OPEN>WashMachineAirFlow4 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11085</NgStampUsed>""     
                    <Continuous_OPEN>WashMachineConductance 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11086</NgStampUsed>""     
                    <Continuous_OPEN>RinseTank3OverFlowAmount 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11087</NgStampUsed>""     
                    <Continuous_OPEN>RinseTank4OverFlowAmount 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11088</NgStampUsed>""     
                    <Continuous_OPEN>RinseTank7OverFlowAmount 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11089</NgStampUsed>""     
                    <Continuous_OPEN>RinseTank9OverFlowAmount 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11090</NgStampUsed>""     
                    <Continuous_OPEN>RinseTank12OverFlowAmount 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11091</NgStampUsed>""     
                    <Continuous_OPEN>RinseTank15OverFlowAmount 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11092</NgStampUsed>""     
                    <Continuous_OPEN>RinseTank17OverFlowAmount 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11093</NgStampUsed>""     
                    <Continuous_OPEN>RinseTank20OverFlowAmount 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11094</NgStampUsed>""     
                    <Continuous_OPEN>RinseTank22OverFlowAmount 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>	
	             <ROW>
                    <NgStampUsed>11095</NgStampUsed>""     
                    <Continuous_OPEN>RinseTank25OverFlowAmount 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
	             <ROW>
                    <NgStampUsed>11096</NgStampUsed>""     
                    <Continuous_OPEN>BlowerPressure 9999/Continuous_OPEN>""    //對照參數實際值
                </ROW>
            </DETAIL>
            </RECORD>
            ";
    }
}

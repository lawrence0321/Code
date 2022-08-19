using Common;
using Common.DTO;
using Common.Enums;
using Common.Extension;
using ConnectorLibrary;
using ConnectorLibrary.CommandBuilder.ME_QSeries;
using ConnectorLibrary.Connector;
using ConnectorLibrary.ExtendFunction;
using Service.Device.Enums;
using Service.Device.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace Service.Device.Implement
{
    internal class _DeviceService : AbstractDisposable, IDeviceService
    {
        public bool IsConnect_PLC1 => PLC1.IsConnect;

        public bool IsConnect_PLC2 => true;


        readonly ConnectorManager ConnectorManager = new ConnectorManager();

        bool Enabled = true;

        readonly TCPClientConnetor PLC1;
        //readonly TCPClientConnetor PLC2;

        public _DeviceService()
        {
            IPEndPointConstructorParameter MSQ1 = new IPEndPointConstructorParameter("192.168.1.1", 1025);
            //IPEndPointConstructorParameter MSQ2 = new IPEndPointConstructorParameter("192.168.1.2", 1025);

            PLC1 = (TCPClientConnetor)ConnectorManager.Create("MSQ1", EquipClasses.ME_QSeries, ConnectorClasses.TCPClient, MSQ1);
            //PLC2 = (TCPClientConnetor)ConnectorManager.Create("MSQ2", EquipClasses.ME_QSeries, ConnectorClasses.TCPClient, MSQ2);

            PLC1.AutoReConnect = true;
            //PLC2.AutoReConnect = true;

            PLC1.Open();
            //PLC2.Open();
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.RunHeartBit));
        }

        readonly object PLC1SendCommendToken = new object();
        CmdResult PLC1SendCommand(ME_QSeriesCmdBuilder CmdBuilder_)
        {
            lock (PLC1SendCommendToken)
            {
                if (!PLC1.IsConnect) return new CmdResult(new Exception("PLC1 Disconnect"));

                var cmdResult = PLC1.SendCommand(CmdBuilder_);
                if (!cmdResult.Result)
                    return cmdResult;
                else
                {
                    if (cmdResult.Response.IsSuccess(EquipClasses.ME_QSeries))
                        return cmdResult;
                    else
                        return new CmdResult(new Exception("Fail to sendCommend."));
                }
            }
        }

        public void RunHeartBit(object state)
        {
            bool HeartBit = false;
            while (Enabled)
            {
                try
                {
                    if (PLC1.IsConnect)
                    {
                        var data = (HeartBit) ? new byte[] { 1, 0 } : new byte[] { 0, 0 };
                        var result2 = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.R, 22002, 1, ref data));
                        //var result2 = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.D, 2000, 1, ref data));
                        if (!result2.Result)
                            throw new Exception("Fail Update PCStatuses");

                        HeartBit = !HeartBit;
                    }
                    Thread.Sleep(1000);
                }
                catch { }
            }
        }


        public ActResult<AlarmTypePackage> GetNowAlarmTypePackage()
        {
            var r1 = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.M, 600, 64));
            var r2 = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.M, 664, 64));
            var r3 = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.M, 728, 64));
            var r4 = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.M, 792, 64));
            
            var r5 = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.W, 448, 64));
            var r6 = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.W, 454, 64));
            var r7 = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.W, 460, 64));
            var r8 = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.W, 466, 64));


            if (r1.Result && r2.Result && r3.Result && r4.Result && r5.Result && r6.Result && r7.Result && r8.Result)
            {

                var part05 = (new byte[] { r5.Response[11], r5.Response[12], r5.Response[13], r5.Response[14], r5.Response[15], r5.Response[16], r5.Response[17], r5.Response[18], r5.Response[19] })
                    .ToBitString().OffsetBit(01).Split(8).Reverse().GetByteArray();
                var part06 = (new byte[] { r6.Response[11], r6.Response[12], r6.Response[13], r6.Response[14], r6.Response[15], r6.Response[16], r6.Response[17], r6.Response[18], r6.Response[19] })
                    .ToBitString().OffsetBit(05).Split(8).Reverse().GetByteArray();
                var part07 = (new byte[] { r7.Response[11], r7.Response[12], r7.Response[13], r7.Response[14], r7.Response[15], r7.Response[16], r7.Response[17], r7.Response[18], r7.Response[19] })
                    .ToBitString().OffsetBit(09).Split(8).Reverse().GetByteArray();
                var part08 = (new byte[] { r8.Response[11], r8.Response[12], r8.Response[13], r8.Response[14], r8.Response[15], r8.Response[16], r8.Response[17], r8.Response[18], r8.Response[19], r8.Response[20] })
                    .ToBitString().OffsetBit(13).Split(8).Reverse().GetByteArray();

                var Part01Value = (AlarmTypes_Part01)BitConverter.ToUInt64(r1.Response, 11);
                var Part02Value = (AlarmTypes_Part02)BitConverter.ToUInt64(r2.Response, 11);
                var Part03Value = (AlarmTypes_Part03)BitConverter.ToUInt64(r3.Response, 11);
                var Part04Value = (AlarmTypes_Part04)BitConverter.ToUInt64(r4.Response, 11);
                var Part05Value = (AlarmTypes_Part05)BitConverter.ToUInt64(part05, 0);
                var Part06Value = (AlarmTypes_Part06)BitConverter.ToUInt64(part06, 0);
                var Part07Value = (AlarmTypes_Part07)BitConverter.ToUInt64(part07, 0);
                var Part08Value = (AlarmTypes_Part08)BitConverter.ToUInt64(part08, 0);



                var package = new AlarmTypePackage
                {
                    Part01 = Part01Value,
                    Part02 = Part02Value,
                    Part03 = Part03Value,
                    Part04 = Part04Value,
                    Part05 = Part05Value,
                    Part06 = Part06Value,
                    Part07 = Part07Value,
                    Part08 = Part08Value,
                };

                return new ActResult<AlarmTypePackage>(package);
            }
            else
            {
                return new ActResult<AlarmTypePackage>(new Exception("Fail To Get Alarm"));
            }
        }

        public ActResult<RectifierLogDTO> GetRectifierLog()
        {
            try
            {
                var logTimeTicks = DateTime.Now.Ticks;

                Dictionary<int, double> FbAs = new Dictionary<int, double>();
                Dictionary<int, double> FbVs = new Dictionary<int, double>();
                Dictionary<int, double> SetAs = new Dictionary<int, double>();


                var r1 = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.W, 0, 64));
                if (!r1.Result) throw r1.Exmsg;
                for (int index = 1; index <= 58; index++)
                {
                    var address = 11 + ((index - 1) * 2);
                    var value = BitConverter.ToInt16(r1.Response, address) / 100.00;
                    FbAs.Add(index, value);
                }
                var r2 = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.W, 64, 64));
                if (!r2.Result) throw r2.Exmsg;
                for (int index = 1; index <= 58; index++)
                {
                    var address = 11 + ((index - 1) * 2);
                    var value = BitConverter.ToInt16(r2.Response, address) / 100.00;
                    FbVs.Add(index, value);
                }
                var r3 = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.W, 768, 64));
                if (!r3.Result) throw r3.Exmsg;
                for (int index = 1; index <= 58; index++)
                {
                    var address = 11 + ((index - 1) * 2);
                    var value = BitConverter.ToInt16(r3.Response, address) / 100.0;
                    SetAs.Add(index, value);
                }

                var log = new RectifierLogDTO()
                {
                    LogTimeTicks = logTimeTicks,
                    Ni_01_FbA = FbAs[01],
                    Ni_01_FbV = FbVs[01],
                    Ni_01_SetA = SetAs[01],
                    Ni_02_FbA = FbAs[02],
                    Ni_02_FbV = FbVs[02],
                    Ni_02_SetA = SetAs[02],
                    Ni_03_FbA = FbAs[03],
                    Ni_03_FbV = FbVs[03],
                    Ni_03_SetA = SetAs[03],
                    Ni_04_FbA = FbAs[04],
                    Ni_04_FbV = FbVs[04],
                    Ni_04_SetA = SetAs[04],
                    Ni_05_FbA = FbAs[05],
                    Ni_05_FbV = FbVs[05],
                    Ni_05_SetA = SetAs[05],
                    Ni_06_FbA = FbAs[06],
                    Ni_06_FbV = FbVs[06],
                    Ni_06_SetA = SetAs[06],
                    Ni_07_FbA = FbAs[07],
                    Ni_07_FbV = FbVs[07],
                    Ni_07_SetA = SetAs[07],
                    Ni_08_FbA = FbAs[08],
                    Ni_08_FbV = FbVs[08],
                    Ni_08_SetA = SetAs[08],
                    Ni_09_FbA = FbAs[09],
                    Ni_09_FbV = FbVs[09],
                    Ni_09_SetA = SetAs[09],
                    Ni_10_FbA = FbAs[10],
                    Ni_10_FbV = FbVs[10],
                    Ni_10_SetA = SetAs[10],

                    Ni_11_FbA = FbAs[11],
                    Ni_11_FbV = FbVs[11],
                    Ni_11_SetA = SetAs[11],
                    Ni_12_FbA = FbAs[12],
                    Ni_12_FbV = FbVs[12],
                    Ni_12_SetA = SetAs[12],
                    Ni_13_FbA = FbAs[13],
                    Ni_13_FbV = FbVs[13],
                    Ni_13_SetA = SetAs[13],
                    Ni_14_FbA = FbAs[14],
                    Ni_14_FbV = FbVs[14],
                    Ni_14_SetA = SetAs[14],
                    Ni_15_FbA = FbAs[15],
                    Ni_15_FbV = FbVs[15],
                    Ni_15_SetA = SetAs[15],
                    Ni_16_FbA = FbAs[16],
                    Ni_16_FbV = FbVs[16],
                    Ni_16_SetA = SetAs[16],
                    Ni_17_FbA = FbAs[17],
                    Ni_17_FbV = FbVs[17],
                    Ni_17_SetA = SetAs[17],
                    Ni_18_FbA = FbAs[18],
                    Ni_18_FbV = FbVs[18],
                    Ni_18_SetA = SetAs[18],
                    Ni_19_FbA = FbAs[19],
                    Ni_19_FbV = FbVs[19],
                    Ni_19_SetA = SetAs[19],
                    Ni_20_FbA = FbAs[20],
                    Ni_20_FbV = FbVs[20],
                    Ni_20_SetA = SetAs[20],

                    Ni_21_FbA = FbAs[21],
                    Ni_21_FbV = FbVs[21],
                    Ni_21_SetA = SetAs[21],
                    Ni_22_FbA = FbAs[22],
                    Ni_22_FbV = FbVs[22],
                    Ni_22_SetA = SetAs[22],
                    Ni_23_FbA = FbAs[23],
                    Ni_23_FbV = FbVs[23],
                    Ni_23_SetA = SetAs[23],
                    Ni_24_FbA = FbAs[24],
                    Ni_24_FbV = FbVs[24],
                    Ni_24_SetA = SetAs[24],
                    Ni_25_FbA = FbAs[25],
                    Ni_25_FbV = FbVs[25],
                    Ni_25_SetA = SetAs[25],
                    Ni_26_FbA = FbAs[26],
                    Ni_26_FbV = FbVs[26],
                    Ni_26_SetA = SetAs[26],
                    Ni_27_FbA = FbAs[27],
                    Ni_27_FbV = FbVs[27],
                    Ni_27_SetA = SetAs[27],
                    Ni_28_FbA = FbAs[28],
                    Ni_28_FbV = FbVs[28],
                    Ni_28_SetA = SetAs[28],
                    Ni_29_FbA = FbAs[29],
                    Ni_29_FbV = FbVs[29],
                    Ni_29_SetA = SetAs[29],
                    Ni_30_FbA = FbAs[30],
                    Ni_30_FbV = FbVs[30],
                    Ni_30_SetA = SetAs[30],

                    Ni_31_FbA = FbAs[31],
                    Ni_31_FbV = FbVs[31],
                    Ni_31_SetA = SetAs[31],
                    Ni_32_FbA = FbAs[32],
                    Ni_32_FbV = FbVs[32],
                    Ni_32_SetA = SetAs[32],
                    Ni_33_FbA = FbAs[33],
                    Ni_33_FbV = FbVs[33],
                    Ni_33_SetA = SetAs[33],
                    Ni_34_FbA = FbAs[34],
                    Ni_34_FbV = FbVs[34],
                    Ni_34_SetA = SetAs[34],
                    Ni_35_FbA = FbAs[35],
                    Ni_35_FbV = FbVs[35],
                    Ni_35_SetA = SetAs[35],
                    Ni_36_FbA = FbAs[36],
                    Ni_36_FbV = FbVs[36],
                    Ni_36_SetA = SetAs[36],
                    Ni_37_FbA = FbAs[37],
                    Ni_37_FbV = FbVs[37],
                    Ni_37_SetA = SetAs[37],
                    Ni_38_FbA = FbAs[38],
                    Ni_38_FbV = FbVs[38],
                    Ni_38_SetA = SetAs[38],
                    Ni_39_FbA = FbAs[39],
                    Ni_39_FbV = FbVs[39],
                    Ni_39_SetA = SetAs[39],
                    Ni_40_FbA = FbAs[40],
                    Ni_40_FbV = FbVs[40],
                    Ni_40_SetA = SetAs[40],

                    Ni_41_FbA = FbAs[41],
                    Ni_41_FbV = FbVs[41],
                    Ni_41_SetA = SetAs[41],
                    Ni_42_FbA = FbAs[42],
                    Ni_42_FbV = FbVs[42],
                    Ni_42_SetA = SetAs[42],
                    Ni_43_FbA = FbAs[43],
                    Ni_43_FbV = FbVs[43],
                    Ni_43_SetA = SetAs[43],
                    Ni_44_FbA = FbAs[44],
                    Ni_44_FbV = FbVs[44],
                    Ni_44_SetA = SetAs[44],
                    Ni_45_FbA = FbAs[45],
                    Ni_45_FbV = FbVs[45],
                    Ni_45_SetA = SetAs[45],
                    Ni_46_FbA = FbAs[46],
                    Ni_46_FbV = FbVs[46],
                    Ni_46_SetA = SetAs[46],
                    Ni_47_FbA = FbAs[47],
                    Ni_47_FbV = FbVs[47],
                    Ni_47_SetA = SetAs[47],
                    Ni_48_FbA = FbAs[48],
                    Ni_48_FbV = FbVs[48],
                    Ni_48_SetA = SetAs[48],

                    AuSt_01_FbA = FbAs[49],
                    AuSt_01_FbV = FbVs[49],
                    AuSt_01_SetA = SetAs[49],
                    AuSt_02_FbA = FbAs[50],
                    AuSt_02_FbV = FbVs[50],
                    AuSt_02_SetA = SetAs[50],

                    Au_01_FbA = FbAs[51],
                    Au_01_FbV = FbVs[51],
                    Au_01_SetA = SetAs[51],
                    Au_02_FbA = FbAs[52],
                    Au_02_FbV = FbVs[52],
                    Au_02_SetA = SetAs[52],
                    Au_03_FbA = FbAs[53],
                    Au_03_FbV = FbVs[53],
                    Au_03_SetA = SetAs[53],
                    Au_04_FbA = FbAs[54],
                    Au_04_FbV = FbVs[54],
                    Au_04_SetA = SetAs[54],
                    Au_05_FbA = FbAs[55],
                    Au_05_FbV = FbVs[55],
                    Au_05_SetA = SetAs[55],
                    Au_06_FbA = FbAs[56],
                    Au_06_FbV = FbVs[56],
                    Au_06_SetA = SetAs[56],
                    Au_07_FbA = FbAs[57],
                    Au_07_FbV = FbVs[57],
                    Au_07_SetA = SetAs[57],
                    Au_08_FbA = FbAs[58],
                    Au_08_FbV = FbVs[58],
                    Au_08_SetA = SetAs[58],
                };


                return new ActResult<RectifierLogDTO>(log);
            }
            catch (Exception Ex)
            {
                return new ActResult<RectifierLogDTO>(Ex);
            }
        }

        public ActResult<ThermostatLogDTO> GetThermostatLog()
        {

            var logTimeTicks = DateTime.Now.Ticks;
            Dictionary<int, double> logs = new Dictionary<int, double>();
            Dictionary<int, double> setlogs = new Dictionary<int, double>();
            Dictionary<int, double> uplwlogs = new Dictionary<int, double>();

            var r1 = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.D, 3051, 64));
            if (!r1.Result)
                return new ActResult<ThermostatLogDTO>(new Exception("Fail To Get Rectifier Now Value."));

            for (int index = 1; index <= 16; index++)
            {
                int address = 11 + (index - 1) * 8;
                logs.Add(
                    index,
                    BitConverter.ToInt16(r1.Response, address) / 10.0
                );
            }

            var r2 = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.D, 3151, 64));
            if (!r2.Result)
                return new ActResult<ThermostatLogDTO>(new Exception("Fail To Get Rectifier Set Value."));

            for (int index = 1; index <= 16; index++)
            {
                int address = 11 + (index - 1) * 8;
                setlogs.Add(
                    index,
                    BitConverter.ToInt16(r2.Response, address) / 10.0
                );
            }

            var r3 = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.D, 3191, 64));
            if (!r3.Result)
                return new ActResult<ThermostatLogDTO>(new Exception("Fail To Get Rectifier UpLw Value."));

            for (int index = 1; index <= 16; index++)
            {
                int address = 11 + (index - 1) * 8;
                uplwlogs.Add(
                    index,
                    BitConverter.ToInt16(r3.Response, address) / 10.0
                );
            }

            var log = new ThermostatLogDTO()
            {
                LogTimeTicks = logTimeTicks,
                TC01 = logs[01],
                TC02 = logs[02],
                TC03 = logs[03],
                TC04 = logs[04],
                TC05 = logs[05],
                TC06 = logs[06],
                TC07 = logs[07],
                TC08 = logs[08],
                TC09 = logs[09],
                TC10 = logs[10],
                TC11 = logs[11],
                TC12 = logs[12],
                TC13 = logs[13],
                TC14 = logs[14],
                TC15 = logs[15],
                TC16 = logs[16],
                TC01_Set = setlogs[01],
                TC02_Set = setlogs[02],
                TC03_Set = setlogs[03],
                TC04_Set = setlogs[04],
                TC05_Set = setlogs[05],
                TC06_Set = setlogs[06],
                TC07_Set = setlogs[07],
                TC08_Set = setlogs[08],
                TC09_Set = setlogs[09],
                TC10_Set = setlogs[10],
                TC11_Set = setlogs[11],
                TC12_Set = setlogs[12],
                TC13_Set = setlogs[13],
                TC14_Set = setlogs[14],
                TC15_Set = setlogs[15],
                TC16_Set = setlogs[16],
                TC01_UpLw = uplwlogs[01],
                TC02_UpLw = uplwlogs[02],
                TC03_UpLw = uplwlogs[03],
                TC04_UpLw = uplwlogs[04],
                TC05_UpLw = uplwlogs[05],
                TC06_UpLw = uplwlogs[06],
                TC07_UpLw = uplwlogs[07],
                TC08_UpLw = uplwlogs[08],
                TC09_UpLw = uplwlogs[09],
                TC10_UpLw = uplwlogs[10],
                TC11_UpLw = uplwlogs[11],
                TC12_UpLw = uplwlogs[12],
                TC13_UpLw = uplwlogs[13],
                TC14_UpLw = uplwlogs[14],
                TC15_UpLw = uplwlogs[15],
                TC16_UpLw = uplwlogs[16],
            };

            return new ActResult<ThermostatLogDTO>(log);
        }

        public ActResult ReSetLoadData()
        {
            byte[] loadData_Bytes = new byte[200];

            var result1 = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.R, 20000, 100, ref loadData_Bytes));
            var result2 = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.R, 20100, 100, ref loadData_Bytes));

            if (result1.Result && result2.Result)
                return new ActResult(true);
            else
            {
                return new ActResult(new Exception("Send LoadData Fail"));
            }
        }

        public ActResult SendLoadDatas(LoadDataDTO LoadData_)
        {
            int first_startAddress = 20000;
            int second_startAddress = 20100;

            byte[] firstLoadData_Bytes = new byte[200];
            byte[] secondLoadData_Bytes = new byte[200];

            firstLoadData_Bytes[2] = LoadData_.First_IsEmpty ? (byte)0 : (byte)1;
            secondLoadData_Bytes[2] = LoadData_.Second_IsEmpty ? (byte)0 : (byte)1;

            int First_LotNo_index = 2 * 2;
            int First_PenelCode_index = 76 * 2;
            int First_Quantity_index = 14 * 2;

            var No_ = 1;

            int First_Ni_B_index = ((No_ == 1) ? 22 : 21) * 2;
            int First_Ni_WB_index = ((No_ == 1) ? 21 : 22) * 2;
            int First_Ni_PT_index = 23 * 2;

            int First_AuSt_EC_index = 19 * 2;
            int First_AuSt_PT_index = 20 * 2;

            int First_Au_B_index = ((No_ == 1) ? 17 : 16) * 2;
            int First_Au_WB_index = ((No_ == 1) ? 16 : 17) * 2;
            int First_Au_PT_index = 18 * 2;

            var lotNo_bytes = LoadData_.First_LotCode.ToArrayByUTF8();
            foreach (var value in lotNo_bytes)
            {
                firstLoadData_Bytes[First_LotNo_index] = value;
                First_LotNo_index++;
            }
            var panelCode_bytes = LoadData_.First_RecipeCode.ToArrayByUTF8();
            foreach (var value in panelCode_bytes)
            {
                firstLoadData_Bytes[First_PenelCode_index] = value;
                First_PenelCode_index++;
            }
            var quantity_bytes = BitConverter.GetBytes((UInt16)LoadData_.First_Quantity);
            foreach (var value in quantity_bytes)
            {
                firstLoadData_Bytes[First_Quantity_index] = value;
                First_Quantity_index++;
            }
            var ni_B_bytes = BitConverter.GetBytes((UInt16)Math.Floor(LoadData_.First_Ni_B_Current.ExRound(1) * 10.0));
            foreach (var value in ni_B_bytes)
            {
                firstLoadData_Bytes[First_Ni_B_index] = value;
                First_Ni_B_index++;
            }
            var ni_WB_bytes = BitConverter.GetBytes((UInt16)Math.Floor(LoadData_.First_Ni_WB_Current.ExRound(1) * 10.0));
            foreach (var value in ni_WB_bytes)
            {
                firstLoadData_Bytes[First_Ni_WB_index] = value;
                First_Ni_WB_index++;
            }
            var ni_PT_bytes = BitConverter.GetBytes((UInt16)LoadData_.First_Ni_PTime);
            foreach (var value in ni_PT_bytes)
            {
                firstLoadData_Bytes[First_Ni_PT_index] = value;
                First_Ni_PT_index++;
            }
            var aust_EC_bytes = BitConverter.GetBytes((UInt16)Math.Floor(LoadData_.First_AuSt_Current.ExRound(1) * 10.0));
            foreach (var value in aust_EC_bytes)
            {
                firstLoadData_Bytes[First_AuSt_EC_index] = value;
                First_AuSt_EC_index++;
            }
            var aust_PT_bytes = BitConverter.GetBytes((UInt16)LoadData_.First_AuSt_PTime);
            foreach (var value in aust_PT_bytes)
            {
                firstLoadData_Bytes[First_AuSt_PT_index] = value;
                First_AuSt_PT_index++;
            }
            var au_B_bytes = BitConverter.GetBytes((UInt16)Math.Floor(LoadData_.First_Au_B_Current.ExRound(2) * 100.0));
            foreach (var value in au_B_bytes)
            {
                firstLoadData_Bytes[First_Au_B_index] = value;
                First_Au_B_index++;
            }
            var au_WB_bytes = BitConverter.GetBytes((UInt16)Math.Floor(LoadData_.First_Au_WB_Current.ExRound(2) * 100.0));
            foreach (var value in au_WB_bytes)
            {
                firstLoadData_Bytes[First_Au_WB_index] = value;
                First_Au_WB_index++;
            }
            var au_PT_bytes = BitConverter.GetBytes((UInt16)LoadData_.First_Au_PTime);
            foreach (var value in au_PT_bytes)
            {
                firstLoadData_Bytes[First_Au_PT_index] = value;
                First_Au_PT_index++;
            }

            No_ = 2;
            int Second_LotNo_index = 2 * 2;
            int Second_PenelCode_index = 76 * 2;
            int Second_Quantity_index = 14 * 2;

            int Second_Ni_B_index = ((No_ == 1) ? 22 : 21) * 2;
            int Second_Ni_WB_index = ((No_ == 1) ? 21 : 22) * 2;
            int Second_Ni_PT_index = 23 * 2;

            int Second_AuSt_EC_index = 19 * 2;
            int Second_AuSt_PT_index = 20 * 2;

            int Second_Au_B_index = ((No_ == 1) ? 17 : 16) * 2;
            int Second_Au_WB_index = ((No_ == 1) ? 16 : 17) * 2;
            int Second_Au_PT_index = 18 * 2;

            lotNo_bytes = LoadData_.Second_LotCode.ToArrayByUTF8();
            foreach (var value in lotNo_bytes)
            {
                secondLoadData_Bytes[Second_LotNo_index] = value;
                Second_LotNo_index++;
            }
            panelCode_bytes = LoadData_.Second_RecipeCode.ToArrayByUTF8();
            foreach (var value in panelCode_bytes)
            {
                secondLoadData_Bytes[Second_PenelCode_index] = value;
                Second_PenelCode_index++;
            }
            quantity_bytes = BitConverter.GetBytes((UInt16)LoadData_.Second_Quantity);
            foreach (var value in quantity_bytes)
            {
                secondLoadData_Bytes[Second_Quantity_index] = value;
                Second_Quantity_index++;
            }
            ni_B_bytes = BitConverter.GetBytes((UInt16)Math.Floor(LoadData_.Second_Ni_B_Current.ExRound(1) * 10.0));
            foreach (var value in ni_B_bytes)
            {
                secondLoadData_Bytes[Second_Ni_B_index] = value;
                Second_Ni_B_index++;
            }
            ni_WB_bytes = BitConverter.GetBytes((UInt16)Math.Floor(LoadData_.Second_Ni_WB_Current.ExRound(1) * 10.0));
            foreach (var value in ni_WB_bytes)
            {
                secondLoadData_Bytes[Second_Ni_WB_index] = value;
                Second_Ni_WB_index++;
            }
            ni_PT_bytes = BitConverter.GetBytes((UInt16)LoadData_.Second_Ni_PTime);
            foreach (var value in ni_PT_bytes)
            {
                secondLoadData_Bytes[Second_Ni_PT_index] = value;
                Second_Ni_PT_index++;
            }
            aust_EC_bytes = BitConverter.GetBytes((UInt16)Math.Floor(LoadData_.Second_AuSt_Current.ExRound(1) * 10.0));
            foreach (var value in aust_EC_bytes)
            {
                secondLoadData_Bytes[Second_AuSt_EC_index] = value;
                Second_AuSt_EC_index++;
            }
            aust_PT_bytes = BitConverter.GetBytes((UInt16)LoadData_.Second_AuSt_PTime);
            foreach (var value in aust_PT_bytes)
            {
                secondLoadData_Bytes[Second_AuSt_PT_index] = value;
                Second_AuSt_PT_index++;
            }
            au_B_bytes = BitConverter.GetBytes((UInt16)Math.Floor(LoadData_.Second_Au_B_Current.ExRound(2) * 100.0));
            foreach (var value in au_B_bytes)
            {
                secondLoadData_Bytes[Second_Au_B_index] = value;
                Second_Au_B_index++;
            }
            au_WB_bytes = BitConverter.GetBytes((UInt16)Math.Floor(LoadData_.Second_Au_WB_Current.ExRound(2) * 100.0));
            foreach (var value in au_WB_bytes)
            {
                secondLoadData_Bytes[Second_Au_WB_index] = value;
                Second_Au_WB_index++;
            }
            au_PT_bytes = BitConverter.GetBytes((UInt16)LoadData_.Second_Au_PTime);
            foreach (var value in au_PT_bytes)
            {
                secondLoadData_Bytes[Second_Au_PT_index] = value;
                Second_Au_PT_index++;
            }

            var result1 = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.R, first_startAddress, 100, ref firstLoadData_Bytes));
            var result2 = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.R, second_startAddress, 100, ref secondLoadData_Bytes));
            //var result2 = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.D, 865, 1, ref pMode_Bytes));
            if (result1.Result && result2.Result)
                return new ActResult(true);
            else
            {
                return new ActResult(new Exception("Send LoadData Fail"));
            }
        }


        public ActResult<List<UnLoadDataLogDTO>> GeBackuptUnLoadDatas()
        {
            var list = new List<UnLoadDataLogDTO>();

            for (int index = 00; index <= 32; index += 2)
            {
                //var r1Address = 10000 + (index + 0) * 100;
                //var r2Address = 10000 + (index + 1) * 100;
                var r1Address = 40000 + (index + 0) * 100;
                var r2Address = 40000 + (index + 1) * 100;

                var r1 = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.ZR, r1Address, 100));
                if (!r1.Result)
                    throw new Exception("Fail Get UnLoadData");
                if (!r1.Response.IsSuccess( EquipClasses.ME_QSeries))
                    throw new Exception("Fail Get UnLoadData");
                
                var r2 = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.ZR, r2Address, 100));
                if (!r2.Result)
                    throw new Exception("Fail Get UnLoadData");
                if (!r2.Response.IsSuccess(EquipClasses.ME_QSeries))
                    throw new Exception("Fail Get UnLoadData");

                var r1dataBytes = r1.Response;
                var r2dataBytes = r2.Response;
                var r1value = Convert(r1dataBytes, true);
                var r2value = Convert(r2dataBytes, false);

                if (r1value.LotNo != string.Empty)
                    list.Add(r1value);
                if (r2value.LotNo != string.Empty)
                    list.Add(r2value);
            }

            return new ActResult<List<UnLoadDataLogDTO>>(list);
        }


        UnLoadDataLogDTO Convert(byte[] Data_,bool IsLeft_)
        {
            var isEmpty = BitConverter.ToInt16(Data_, 1 * 2 + 11) == 1 ? true : false;

            var loadY = BitConverter.ToInt16(Data_, 54 * 2 + 11);
            var loadM = BitConverter.ToInt16(Data_, 55 * 2 + 11);
            var loadD = BitConverter.ToInt16(Data_, 56 * 2 + 11);
            var loadH = BitConverter.ToInt16(Data_, 57 * 2 + 11);
            var loadm = BitConverter.ToInt16(Data_, 58 * 2 + 11);
            var loads = BitConverter.ToInt16(Data_, 59 * 2 + 11);
            var loadTimeString = String.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00}", loadY, loadM, loadD, loadH, loadm, loads);

            var upLoadY = BitConverter.ToInt16(Data_, 60 * 2 + 11);
            var upLoadM = BitConverter.ToInt16(Data_, 61 * 2 + 11);
            var upLoadD = BitConverter.ToInt16(Data_, 62 * 2 + 11);
            var upLoadH = BitConverter.ToInt16(Data_, 63 * 2 + 11);
            var upLoadm = BitConverter.ToInt16(Data_, 64 * 2 + 11);
            var upLoads = BitConverter.ToInt16(Data_, 65 * 2 + 11);
            var upLoadTimeString = String.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00}", upLoadY, upLoadM, upLoadD, upLoadH, upLoadm, upLoads);


            var LotNo = Data_.ToList().GetRange(2 * 2 + 11, 12).ToArray().ToASCII();
            var PanelCode = Data_.ToList().GetRange(76 * 2 + 11, 28).ToArray().ToASCII();
            var Quantity = BitConverter.ToInt16(Data_, 14 * 2 + 11);
            var PMode = Data_.ToList().GetRange(24 * 2 + 11, 2).ToArray().ToASCII();


            var Ni_WB_SEC_Address = IsLeft_ ? 21 : 22;
            var Ni_B_SEC_Address = IsLeft_ ? 22 : 21;
            var Ni_SPT_Address = 23;

            var Ni_B_SetECurrent = BitConverter.ToInt16(Data_, Ni_B_SEC_Address * 2 + 11) / 10.00;
            var Ni_WB_SetECurrent = BitConverter.ToInt16(Data_, Ni_WB_SEC_Address * 2 + 11) / 10.00;
            var Ni_SetPlatingTime = BitConverter.ToInt16(Data_, Ni_SPT_Address * 2 + 11);

            var Aust_SEC_Address = 19;
            var Aust_SPT_Address = 20;

            var AuSt_SetECurrent = BitConverter.ToInt16(Data_, Aust_SEC_Address * 2 + 11) / 10.00;
            var AuSt_SetPlatingTime = BitConverter.ToInt16(Data_, Aust_SPT_Address * 2 + 11);

            var Au_WB_SEC_Address = IsLeft_ ? 16 : 17;
            var Au_B_SEC_Address = IsLeft_ ? 17 : 16;
            var Au_SPT_Address = 18;

            var Au_B_SetECurrent = BitConverter.ToInt16(Data_, Au_B_SEC_Address * 2 + 11) / 100.00;
            var Au_WB_SetECurrent = BitConverter.ToInt16(Data_, Au_WB_SEC_Address * 2 + 11) / 100.00;
            var Au_SetPlatingTime = BitConverter.ToInt16(Data_, Au_SPT_Address * 2 + 11);

            var Ni_WB_AEC_Address = IsLeft_ ? 45 : 48;
            var Ni_B_AEC_Address = IsLeft_ ? 48 : 45;

            var Ni_B_AV_Address = IsLeft_ ? 49 : 46;
            var Ni_WB_AV_Address = IsLeft_ ? 46 : 49;
            var Ni_Temp_Address = 47;

            var Ni_B_AveECurrent = BitConverter.ToInt16(Data_, Ni_B_AEC_Address * 2 + 11) / 100.00;
            var Ni_WB_AveECurrent = BitConverter.ToInt16(Data_, Ni_WB_AEC_Address * 2 + 11) / 100.00;
            var Ni_B_AveVoltage = BitConverter.ToInt16(Data_, Ni_B_AV_Address * 2 + 11) / 100.00;
            var Ni_WB_AveVoltage = BitConverter.ToInt16(Data_, Ni_WB_AV_Address * 2 + 11) / 100.00;
            var Ni_Temp = BitConverter.ToInt16(Data_, Ni_Temp_Address * 2 + 11) / 10.00;

            var ni_ErrDatas = new BitArray(new byte[] { Data_[51 * 2 + 11], Data_[51 * 2 + 1 + 11] });
            var Ni_B_Err_A = ni_ErrDatas[0];
            var Ni_B_Err_V = ni_ErrDatas[1];
            var Ni_B_Err_T = ni_ErrDatas[2];
            var Ni_WB_Err_A = ni_ErrDatas[8];
            var Ni_WB_Err_V = ni_ErrDatas[9];
            var Ni_WB_Err_T = ni_ErrDatas[10];
            var Ni_StageNo = Data_.ToList().GetRange(52 * 2 + 11, 2).ToArray().ToASCII();
            var Ni_DipTime = BitConverter.ToInt16(Data_, 53 * 2 + 11);

            var AuSt_AveECurrent = BitConverter.ToInt16(Data_, 39 * 2 + 11) / 100.00;
            var AuSt_AveVoltage = BitConverter.ToInt16(Data_, 40 * 2 + 11) / 100.00;
            var AuSt_Temp = BitConverter.ToInt16(Data_, 41 * 2 + 11) / 10.00;
            var aust_ErrDatas = new BitArray(new byte[] { Data_[42 * 2 + 11], Data_[42 * 2 + 1 + 11] });
            var AuSt_Err_A = ni_ErrDatas[0];
            var AuSt_Err_V = ni_ErrDatas[1];
            var AuSt_Err_T = ni_ErrDatas[2];
            var AuSt_DipTime = BitConverter.ToInt16(Data_, 44 * 2 + 11);


            var Au_WB_AEC_Address = IsLeft_ ? 30 : 33;
            var Au_B_AEC_Address = IsLeft_ ? 33 : 30;
            var Au_WB_AV_Address = IsLeft_ ? 31 : 34;
            var Au_B_AV_Address = IsLeft_ ? 34 : 31;
            var Au_Temp_Address = 32;

            var Au_B_AveECurrent = BitConverter.ToInt16(Data_, Au_B_AEC_Address * 2 + 11) / 100.00;
            var Au_WB_AveECurrent = BitConverter.ToInt16(Data_, Au_WB_AEC_Address * 2 + 11) / 100.00;
            var Au_B_AveVoltage = BitConverter.ToInt16(Data_, Au_B_AV_Address * 2 + 11) / 100.00;
            var Au_WB_AveVoltage = BitConverter.ToInt16(Data_, Au_WB_AV_Address * 2 + 11) / 100.00;
            var Au_Temp = BitConverter.ToInt16(Data_, Au_Temp_Address * 2 + 11) / 10.00;
            var au_ErrDatas = new BitArray(new byte[] { Data_[36 * 2 + 11], Data_[36 * 2 + 1 + 11] });
            var Au_B_Err_A = au_ErrDatas[0];
            var Au_B_Err_V = au_ErrDatas[1];
            var Au_B_Err_T = au_ErrDatas[2];
            var Au_WB_Err_A = au_ErrDatas[8];
            var Au_WB_Err_V = au_ErrDatas[9];
            var Au_WB_Err_T = au_ErrDatas[10];
            var Au_StageNo = Data_.ToList().GetRange(37 * 2 + 11, 2).ToArray().ToASCII();
            var Au_DipTime = BitConverter.ToInt16(Data_, 38 * 2 + 11);
            var RealProcess = Data_.ToList().GetRange(66 * 2 + 11, 2).ToArray().ToASCII();

            var LogTimeTicks = DateTime.Now.Ticks;


            var _rtn = new UnLoadDataLogDTO
            {
                Code = String.Format("{0:00}", 0),
                LogTimeTicks = DateTime.Now.Ticks,
                UpLoadTimeString = upLoadTimeString,
                LoadTimeString = loadTimeString,

                ShelfCode = "-",

                LotNo = LotNo,
                PanelCode = PanelCode,
                Quantity = Quantity,
                PMode = PMode,
                Ni_B_SetECurrent = Ni_B_SetECurrent,
                Ni_WB_SetECurrent = Ni_WB_SetECurrent,
                Ni_SetPlatingTime = Ni_SetPlatingTime,

                Au_B_SetECurrent = Au_B_SetECurrent,
                Au_WB_SetECurrent = Au_WB_SetECurrent,
                Au_SetPlatingTime = Au_SetPlatingTime,

                AuSt_SetECurrent = AuSt_SetECurrent,
                AuSt_SetPlatingTime = AuSt_SetPlatingTime,

                Ni_B_AveECurrent = Ni_B_AveECurrent,
                Ni_WB_AveECurrent = Ni_WB_AveECurrent,
                Ni_B_AveVoltage = Ni_B_AveVoltage,
                Ni_WB_AveVoltage = Ni_WB_AveVoltage,
                Ni_Temp = Ni_Temp,

                Ni_B_Err_A = Ni_B_Err_A,
                Ni_B_Err_V = Ni_B_Err_V,
                Ni_B_Err_T = Ni_B_Err_T,
                Ni_WB_Err_A = Ni_WB_Err_A,
                Ni_WB_Err_V = Ni_WB_Err_V,
                Ni_WB_Err_T = Ni_WB_Err_T,
                Ni_StageNo = Ni_StageNo,
                Ni_DipTime = Ni_DipTime,

                AuSt_AveECurrent = AuSt_AveECurrent,
                AuSt_AveVoltage = AuSt_AveVoltage,
                AuSt_Temp = AuSt_Temp,
                AuSt_Err_A = AuSt_Err_A,
                AuSt_Err_V = AuSt_Err_V,
                AuSt_Err_T = AuSt_Err_T,
                AuSt_DipTime = AuSt_DipTime,

                Au_B_AveECurrent = Au_B_AveECurrent,
                Au_WB_AveECurrent = Au_WB_AveECurrent,
                Au_B_AveVoltage = Au_B_AveVoltage,
                Au_WB_AveVoltage = Au_WB_AveVoltage,
                Au_Temp = Au_Temp,
                Au_B_Err_A = Au_B_Err_A,
                Au_B_Err_V = Au_B_Err_V,
                Au_B_Err_T = Au_B_Err_T,
                Au_WB_Err_A = Au_WB_Err_A,
                Au_WB_Err_V = Au_WB_Err_V,
                Au_WB_Err_T = Au_WB_Err_T,
                Au_StageNo = Au_StageNo,
                Au_DipTime = Au_DipTime,
                RealProcess = RealProcess,
            };

            return _rtn;
        }

        public ActResult<UnLoadDataLogDTO> GetUnLoadData(int No_)
        {
            int startAddress = No_ == 1 ? 20200 : 20300;

            var result = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.R, startAddress, 100));
            if (!result.Result)
                throw new Exception("Fail Get UnLoadData");

            var dataBytes = result.Response;
            try
            {
                var isEmpty = BitConverter.ToInt16(dataBytes, 1 * 2 + 11) == 1 ? true : false;

                var loadY = BitConverter.ToInt16(dataBytes, 54 * 2 + 11);
                var loadM = BitConverter.ToInt16(dataBytes, 55 * 2 + 11);
                var loadD = BitConverter.ToInt16(dataBytes, 56 * 2 + 11);
                var loadH = BitConverter.ToInt16(dataBytes, 57 * 2 + 11);
                var loadm = BitConverter.ToInt16(dataBytes, 58 * 2 + 11);
                var loads = BitConverter.ToInt16(dataBytes, 59 * 2 + 11);
                var loadTimeString = String.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00}", loadY, loadM, loadD, loadH, loadm, loads);

                var upLoadY = BitConverter.ToInt16(dataBytes, 60 * 2 + 11);
                var upLoadM = BitConverter.ToInt16(dataBytes, 61 * 2 + 11);
                var upLoadD = BitConverter.ToInt16(dataBytes, 62 * 2 + 11);
                var upLoadH = BitConverter.ToInt16(dataBytes, 63 * 2 + 11);
                var upLoadm = BitConverter.ToInt16(dataBytes, 64 * 2 + 11);
                var upLoads = BitConverter.ToInt16(dataBytes, 65 * 2 + 11);
                var upLoadTimeString = String.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00}", upLoadY, upLoadM, upLoadD, upLoadH, upLoadm, upLoads);


                var LotNo = dataBytes.ToList().GetRange(2 * 2 + 11, 12).ToArray().ToASCII();
                var PanelCode = dataBytes.ToList().GetRange(76 * 2 + 11, 28).ToArray().ToASCII();
                var Quantity = BitConverter.ToInt16(dataBytes, 14 * 2 + 11);
                var PMode = dataBytes.ToList().GetRange(24 * 2 + 11, 2).ToArray().ToASCII();


                var Ni_WB_SEC_Address = (No_ == 1) ? 21 : 22;
                var Ni_B_SEC_Address = (No_ == 1) ? 22 : 21;
                var Ni_SPT_Address = 23;

                var Ni_B_SetECurrent = BitConverter.ToInt16(dataBytes, Ni_B_SEC_Address * 2 + 11) / 10.00;
                var Ni_WB_SetECurrent = BitConverter.ToInt16(dataBytes, Ni_WB_SEC_Address * 2 + 11) / 10.00;
                var Ni_SetPlatingTime = BitConverter.ToInt16(dataBytes, Ni_SPT_Address * 2 + 11);

                var Aust_SEC_Address = 19;
                var Aust_SPT_Address = 20;

                var AuSt_SetECurrent = BitConverter.ToInt16(dataBytes, Aust_SEC_Address * 2 + 11) / 10.00;
                var AuSt_SetPlatingTime = BitConverter.ToInt16(dataBytes, Aust_SPT_Address * 2 + 11);

                var Au_WB_SEC_Address = (No_ == 1) ? 16 : 17;
                var Au_B_SEC_Address = (No_ == 1) ? 17 : 16;
                var Au_SPT_Address = 18;

                var Au_B_SetECurrent = BitConverter.ToInt16(dataBytes, Au_B_SEC_Address * 2 + 11) / 100.00;
                var Au_WB_SetECurrent = BitConverter.ToInt16(dataBytes, Au_WB_SEC_Address * 2 + 11) / 100.00;
                var Au_SetPlatingTime = BitConverter.ToInt16(dataBytes, Au_SPT_Address * 2 + 11);

                var Ni_WB_AEC_Address = (No_ == 1) ? 45 : 48;
                var Ni_B_AEC_Address = (No_ == 1) ? 48 : 45;

                var Ni_B_AV_Address = (No_ == 1) ? 49 : 46;
                var Ni_WB_AV_Address = (No_ == 1) ? 46 : 49;
                var Ni_Temp_Address = 47;

                var Ni_B_AveECurrent = BitConverter.ToInt16(dataBytes, Ni_B_AEC_Address * 2 + 11) / 100.00;
                var Ni_WB_AveECurrent = BitConverter.ToInt16(dataBytes, Ni_WB_AEC_Address * 2 + 11) / 100.00;
                var Ni_B_AveVoltage = BitConverter.ToInt16(dataBytes, Ni_B_AV_Address * 2 + 11) / 100.00;
                var Ni_WB_AveVoltage = BitConverter.ToInt16(dataBytes, Ni_WB_AV_Address * 2 + 11) / 100.00;
                var Ni_Temp = BitConverter.ToInt16(dataBytes, Ni_Temp_Address * 2 + 11) / 10.00;

                var ni_ErrDatas = new BitArray(new byte[] { dataBytes[51 * 2 + 11], dataBytes[51 * 2 + 1 + 11] });
                var Ni_B_Err_A = ni_ErrDatas[0];
                var Ni_B_Err_V = ni_ErrDatas[1];
                var Ni_B_Err_T = ni_ErrDatas[2];
                var Ni_WB_Err_A = ni_ErrDatas[8];
                var Ni_WB_Err_V = ni_ErrDatas[9];
                var Ni_WB_Err_T = ni_ErrDatas[10];
                var Ni_StageNo = dataBytes.ToList().GetRange(52 * 2 + 11, 2).ToArray().ToASCII();
                var Ni_DipTime = BitConverter.ToInt16(dataBytes, 53 * 2 + 11);

                var AuSt_AveECurrent = BitConverter.ToInt16(dataBytes, 39 * 2 + 11) / 100.00;
                var AuSt_AveVoltage = BitConverter.ToInt16(dataBytes, 40 * 2 + 11) / 100.00;
                var AuSt_Temp = BitConverter.ToInt16(dataBytes, 41 * 2 + 11) / 10.00;
                var aust_ErrDatas = new BitArray(new byte[] { dataBytes[42 * 2 + 11], dataBytes[42 * 2 + 1 + 11] });
                var AuSt_Err_A = ni_ErrDatas[0];
                var AuSt_Err_V = ni_ErrDatas[1];
                var AuSt_Err_T = ni_ErrDatas[2];
                var AuSt_DipTime = BitConverter.ToInt16(dataBytes, 44 * 2 + 11);


                var Au_WB_AEC_Address = (No_ == 1) ? 30 : 33;
                var Au_B_AEC_Address = (No_ == 1) ? 33 : 30;
                var Au_WB_AV_Address = (No_ == 1) ? 31 : 34;
                var Au_B_AV_Address = (No_ == 1) ? 34 : 31;
                var Au_Temp_Address = 32;

                var Au_B_AveECurrent = BitConverter.ToInt16(dataBytes, Au_B_AEC_Address * 2 + 11) / 100.00;
                var Au_WB_AveECurrent = BitConverter.ToInt16(dataBytes, Au_WB_AEC_Address * 2 + 11) / 100.00;
                var Au_B_AveVoltage = BitConverter.ToInt16(dataBytes, Au_B_AV_Address * 2 + 11) / 100.00;
                var Au_WB_AveVoltage = BitConverter.ToInt16(dataBytes, Au_WB_AV_Address * 2 + 11) / 100.00;
                var Au_Temp = BitConverter.ToInt16(dataBytes, Au_Temp_Address * 2 + 11) / 10.00;
                var au_ErrDatas = new BitArray(new byte[] { dataBytes[36 * 2 + 11], dataBytes[36 * 2 + 1 + 11] });
                var Au_B_Err_A = au_ErrDatas[0];
                var Au_B_Err_V = au_ErrDatas[1];
                var Au_B_Err_T = au_ErrDatas[2];
                var Au_WB_Err_A = au_ErrDatas[8];
                var Au_WB_Err_V = au_ErrDatas[9];
                var Au_WB_Err_T = au_ErrDatas[10];
                var Au_StageNo = dataBytes.ToList().GetRange(37 * 2 + 11, 2).ToArray().ToASCII();
                var Au_DipTime = BitConverter.ToInt16(dataBytes, 38 * 2 + 11);
                var RealProcess = dataBytes.ToList().GetRange(66 * 2 + 11, 2).ToArray().ToASCII();

                var LogTimeTicks = DateTime.Now.Ticks;


                var _rtn = new UnLoadDataLogDTO
                {
                    Code = String.Format("{0:00}", 0),
                    LogTimeTicks = DateTime.Now.Ticks,
                    UpLoadTimeString = upLoadTimeString,
                    LoadTimeString = loadTimeString,

                    ShelfCode = "-",

                    LotNo = LotNo,
                    PanelCode = PanelCode,
                    Quantity = Quantity,
                    PMode = PMode,
                    Ni_B_SetECurrent = Ni_B_SetECurrent,
                    Ni_WB_SetECurrent = Ni_WB_SetECurrent,
                    Ni_SetPlatingTime = Ni_SetPlatingTime,

                    Au_B_SetECurrent = Au_B_SetECurrent,
                    Au_WB_SetECurrent = Au_WB_SetECurrent,
                    Au_SetPlatingTime = Au_SetPlatingTime,

                    AuSt_SetECurrent = AuSt_SetECurrent,
                    AuSt_SetPlatingTime = AuSt_SetPlatingTime,

                    Ni_B_AveECurrent = Ni_B_AveECurrent,
                    Ni_WB_AveECurrent = Ni_WB_AveECurrent,
                    Ni_B_AveVoltage = Ni_B_AveVoltage,
                    Ni_WB_AveVoltage = Ni_WB_AveVoltage,
                    Ni_Temp = Ni_Temp,

                    Ni_B_Err_A = Ni_B_Err_A,
                    Ni_B_Err_V = Ni_B_Err_V,
                    Ni_B_Err_T = Ni_B_Err_T,
                    Ni_WB_Err_A = Ni_WB_Err_A,
                    Ni_WB_Err_V = Ni_WB_Err_V,
                    Ni_WB_Err_T = Ni_WB_Err_T,
                    Ni_StageNo = Ni_StageNo,
                    Ni_DipTime = Ni_DipTime,

                    AuSt_AveECurrent = AuSt_AveECurrent,
                    AuSt_AveVoltage = AuSt_AveVoltage,
                    AuSt_Temp = AuSt_Temp,
                    AuSt_Err_A = AuSt_Err_A,
                    AuSt_Err_V = AuSt_Err_V,
                    AuSt_Err_T = AuSt_Err_T,
                    AuSt_DipTime = AuSt_DipTime,

                    Au_B_AveECurrent = Au_B_AveECurrent,
                    Au_WB_AveECurrent = Au_WB_AveECurrent,
                    Au_B_AveVoltage = Au_B_AveVoltage,
                    Au_WB_AveVoltage = Au_WB_AveVoltage,
                    Au_Temp = Au_Temp,
                    Au_B_Err_A = Au_B_Err_A,
                    Au_B_Err_V = Au_B_Err_V,
                    Au_B_Err_T = Au_B_Err_T,
                    Au_WB_Err_A = Au_WB_Err_A,
                    Au_WB_Err_V = Au_WB_Err_V,
                    Au_WB_Err_T = Au_WB_Err_T,
                    Au_StageNo = Au_StageNo,
                    Au_DipTime = Au_DipTime,
                    RealProcess = RealProcess,
                };

                return new ActResult<UnLoadDataLogDTO>(_rtn);
            }
            catch (Exception Ex)
            {
                return new ActResult<UnLoadDataLogDTO>(Ex);
            }
        }

        public ActResult LightLen(int No_, bool Value_)
        {
            try
            {
                var value = Value_ ? 0 : 1;
                var address = No_ == 1 ? 22003 : 22004;

                var data = new byte[] { (byte)value, (byte)0 };
                var result2 = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.R, address, 1, ref data));
                if (!result2.Result)
                    throw new Exception("Fail Update PCStatuses");
                else
                    return new ActResult(true);
            }
            catch (Exception Ex) { return new ActResult(Ex); }

        }

        public ActResult<PLCStatuses> GetNowPLCStatuses()
        {
            try
            {
                var result = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.R, 22008, 1));

                if (!result.Result)
                    throw new Exception("Fail Ask PLCStatuses");

                PLCStatuses nowStatuses = (PLCStatuses)BitConverter.ToInt16(result.Response, 11);

                return new ActResult<PLCStatuses>(nowStatuses);
            }
            catch (Exception Ex)
            {
                return new ActResult<PLCStatuses>(Ex);
            }
        }

        public ActResult<PCStatuses> GetNowPCStatuses()
        {
            try
            {
                var result = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.R, 22000, 1));

                if (!result.Result)
                    throw new Exception("Fail Ask PCStatuses");

                PCStatuses nowStatuses = (PCStatuses)BitConverter.ToInt16(result.Response, 11);

                return new ActResult<PCStatuses>(nowStatuses);
            }
            catch (Exception Ex)
            {
                return new ActResult<PCStatuses>(Ex);
            }
        }

        public ActResult UpdatePCStatuses(PCStatuses Status_, bool Value_)
        {
            try
            {
                var result1 = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.R, 22000, 1));

                if (!result1.Result)
                    throw new Exception("Fail Ask PCStatuses");

                PCStatuses nowStatuses = (PCStatuses)BitConverter.ToInt16(result1.Response, 11);

                PCStatuses newStatuses = nowStatuses;
                if (Value_)
                    newStatuses |= Status_;
                else
                    newStatuses &= ~Status_;

                var bytes = BitConverter.GetBytes((UInt16)newStatuses);
                var result2 = PLC1SendCommand(new ME_QSeriesCmdBuilder(ME_QSeriesCmdBuilder.Elements.R, 22000, 1, ref bytes));

                if (!result2.Result)
                    throw new Exception("Fail Update PCStatuses");

                return new ActResult(true);
            }
            catch (Exception Ex)
            {
                return new ActResult(Ex);
            }
        }


        protected override void DisposeManagedObject()
        {
            Enabled = false;
        }

    }

}
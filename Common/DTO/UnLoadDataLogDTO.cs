using Common.Attributes;
using Common.Extension;
using Common.Interface;
using System;

namespace Common.DTO
{
    public class UnLoadDataLogDTO : IDTO
    {
        [Display("序列號")]
        public long Rowid { get; set; }
        [Display("編號")]
        public string Code { get; set; }
        [Display("掛架編號")]
        public string ShelfCode { get; set; }
        [Display()]
        public long LogTimeTicks{ get; set; }
        [Display()]
        public DateTime LogDateTime => new DateTime(LogTimeTicks);
        [Display("紀錄時間")]
        public string LogDateTimeString => LogDateTime.GetString();
        [Display("上料時間")]
        public string LoadTimeString { get; set; }
        [Display("下料時間")]
        public string UpLoadTimeString { get; set; }

        [Display("批號")]
        public string LotNo { get; set; }
        [Display("參數")]
        public string PanelCode { get; set; }
        [Display()]
        public string PMode { get; set; }
        [Display("上掛數量")]
        public int Quantity { get; set; }
        [Display()]
        public string RealProcess { get; set; }


        [Display("Ni B 設定電流值")]
        public double Ni_B_SetECurrent { get; set; }
        [Display("Ni B 平均電流值")]
        public double Ni_B_AveECurrent { get; set; }
        [Display("Ni B 平均電壓值")]
        public double Ni_B_AveVoltage { get; set; }
        [Display("Ni WB 設定電流值")]
        public double Ni_WB_SetECurrent { get; set; }
        [Display("Ni WB 平均電流值")]
        public double Ni_WB_AveECurrent { get; set; }
        [Display("Ni WB 平均電壓值")]
        public double Ni_WB_AveVoltage { get; set; }
        [Display("Ni 設定電鍍時間")]
        public int Ni_SetPlatingTime { get; set; }
        [Display("Ni DipTime")]
        public int Ni_DipTime { get; set; }
        [Display("Ni StageNo")]
        public string Ni_StageNo { get; set; }
        [Display()]
        public double Ni_Temp { get; set; }


        [Display("Au B 設定電流值")]
        public double Au_B_SetECurrent { get; set; }
        [Display("Au B 平均電流值")]
        public double Au_B_AveECurrent { get; set; }
        [Display("Au B 平均電壓值")]
        public double Au_B_AveVoltage { get; set; }
        [Display("Au WB 設定電流值")]
        public double Au_WB_SetECurrent { get; set; }
        [Display("Au WB 平均電流值")]
        public double Au_WB_AveECurrent { get; set; }
        [Display("Au WB 平均電壓值")]
        public double Au_WB_AveVoltage { get; set; }
        [Display("Au 設定電鍍時間")]
        public int Au_SetPlatingTime { get; set; }
        [Display("Au DipTime")]
        public int Au_DipTime { get; set; }
        [Display("Au StageNo")]
        public string Au_StageNo { get; set; }
        [Display()]
        public double Au_Temp { get; set; }

        [Display("AuSt 設定電流值")]
        public double AuSt_SetECurrent { get; set; }
        [Display("AuSt 平均電流值")]
        public double AuSt_AveECurrent { get; set; }
        [Display("AuSt 平均電壓值")]
        public double AuSt_AveVoltage { get; set; }
        [Display("AuSt 設定電鍍時間")]
        public int AuSt_SetPlatingTime { get; set; }
        [Display("AuSt DipTime")]
        public int AuSt_DipTime { get; set; }
        [Display()]
        public double AuSt_Temp { get; set; }

        [Display("Ni B 電流異常發生")]
        public bool Ni_B_Err_A { get; set; }
        [Display("Ni B 電壓異常發生")]
        public bool Ni_B_Err_T { get; set; }
        [Display("Ni B 電鍍時間異常發生")]
        public bool Ni_B_Err_V { get; set; }
        [Display("Ni WB 電流異常發生")]
        public bool Ni_WB_Err_A { get; set; }
        [Display("Ni WB 電壓異常發生")]
        public bool Ni_WB_Err_T { get; set; }
        [Display("Ni WB 電鍍時間異常發生")]
        public bool Ni_WB_Err_V { get; set; }

        [Display("Au B 電流異常發生")]
        public bool Au_B_Err_A { get; set; }
        [Display("Au B 電壓異常發生")]
        public bool Au_B_Err_T { get; set; }
        [Display("Au B 電鍍時間異常發生")]
        public bool Au_B_Err_V { get; set; }
        [Display("Au WB 電流異常發生")]
        public bool Au_WB_Err_A { get; set; }
        [Display("Au WB 電壓異常發生")]
        public bool Au_WB_Err_T { get; set; }
        [Display("Au WB 電鍍時間異常發生")]
        public bool Au_WB_Err_V { get; set; }

        [Display("AuSt 電流異常發生")]
        public bool AuSt_Err_A { get; set; }
        [Display("AuSt 電壓異常發生")]
        public bool AuSt_Err_T { get; set; }
        [Display("AuSt 電鍍時間異常發生")]
        public bool AuSt_Err_V { get; set; }
    }
}

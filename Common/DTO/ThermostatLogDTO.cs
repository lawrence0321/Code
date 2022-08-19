using Common.Attributes;
using Common.Extension;
using Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{

    public class ThermostatLogDTO : IDTO
    {
        /// <summary>
        /// 序列號
        /// </summary>
        [Display("序列號")]
        public long Rowid { get; set; }
        /// <summary>
        /// 紀錄時間
        /// </summary>
        [Display()]
        public long LogTimeTicks { get; set; }
        /// <summary>
        /// 紀錄時間
        /// </summary>
        [Display()]
        public DateTime LogDateTime => new DateTime(LogTimeTicks);
        /// <summary>
        /// 紀錄時間
        /// </summary>
        [Display("紀錄時間")]
        public string LogDateTimeString => LogDateTime.GetString();

        /// <summary>
        /// Cleaner
        /// </summary>
        [Display("Cleaner")]
        public double TC01 { get; set; }
        /// <summary>
        /// Cleaner
        /// </summary>
        [Display("Cleaner 設定值")]
        public double TC01_Set { get; set; }
        /// <summary>
        /// Cleaner
        /// </summary>
        [Display("Cleaner 上下限")]
        public double TC01_UpLw { get; set; }


        /// <summary>
        /// HotRinse#1
        /// </summary>
        [Display("HotRinse#1")]
        public double TC02 { get; set; }
        /// <summary>
        /// HotRinse#1
        /// </summary>
        [Display("HotRinse#1 設定值")]
        public double TC02_Set { get; set; }
        /// <summary>
        /// HotRinse#1
        /// </summary>
        [Display("HotRinse#1 上下限")]
        public double TC02_UpLw { get; set; }

        /// <summary>
        /// HotRinse#2
        /// </summary>
        [Display("HotRinse#2")]
        public double TC03 { get; set; }
        /// <summary>
        /// HotRinse#2
        /// </summary>
        [Display("HotRinse#2 設定值")]
        public double TC03_Set { get; set; }
        /// <summary>
        /// HotRinse#2
        /// </summary>
        [Display("HotRinse#2 上下限")]
        public double TC03_UpLw { get; set; }

        /// <summary>
        /// Ni.Etch
        /// </summary>
        [Display("Ni.Etch")]
        public double TC04 { get; set; }
        /// <summary>
        /// Ni.Etch
        /// </summary>
        [Display("Ni.Etch 設定值")]
        public double TC04_Set { get; set; }
        /// <summary>
        /// Ni.Etch
        /// </summary>
        [Display("Ni.Etch 上下限")]
        public double TC04_UpLw { get; set; }


        /// <summary>
        /// Ni#01
        /// </summary>
        [Display("Ni#01")]
        public double TC05 { get; set; }
        /// <summary>
        /// Ni#01
        /// </summary>
        [Display("Ni#01 設定值")]
        public double TC05_Set { get; set; }
        /// <summary>
        /// Ni#01
        /// </summary>
        [Display("Ni#01 上下限")]
        public double TC05_UpLw { get; set; }


        /// <summary>
        /// Ni#02
        /// </summary>
        [Display("Ni#02")]
        public double TC06 { get; set; }
        /// <summary>
        /// Ni#02
        /// </summary>
        [Display("Ni#02 設定值")]
        public double TC06_Set { get; set; }
        /// <summary>
        /// Ni#02
        /// </summary>
        [Display("Ni#02 上下限")]
        public double TC06_UpLw { get; set; }


        /// <summary>
        /// Ni#03
        /// </summary>
        [Display("Ni#03")]
        public double TC07 { get; set; }
        /// <summary>
        /// Ni#03
        /// </summary>
        [Display("Ni#03 設定值")]
        public double TC07_Set { get; set; }
        /// <summary>
        /// Ni#03
        /// </summary>
        [Display("Ni#03 上下限")]
        public double TC07_UpLw { get; set; }


        /// <summary>
        /// Ni#04
        /// </summary>
        [Display("Ni#04")]
        public double TC08 { get; set; }
        /// <summary>
        /// Ni#04
        /// </summary>
        [Display("Ni#04 設定值")]
        public double TC08_Set { get; set; }
        /// <summary>
        /// Ni#04
        /// </summary>
        [Display("Ni#04 上下限")]
        public double TC08_UpLw { get; set; }


        /// <summary>
        /// AuSt
        /// </summary>
        [Display("AuSt")]
        public double TC09 { get; set; }
        /// <summary>
        /// AuSt
        /// </summary>
        [Display("AuSt 設定值")]
        public double TC09_Set { get; set; }
        /// <summary>
        /// AuSt
        /// </summary>
        [Display("AuSt 上下限")]
        public double TC09_UpLw { get; set; }


        /// <summary>
        /// Au#01
        /// </summary>
        [Display("Au#01")]
        public double TC10 { get; set; }
        /// <summary>
        /// Au#01
        /// </summary>
        [Display("Au#01 設定值")]
        public double TC10_Set { get; set; }
        /// <summary>
        /// Au#01
        /// </summary>
        [Display("Au#01 上下限")]
        public double TC10_UpLw { get; set; }


        /// <summary>
        /// Au#02
        /// </summary>
        [Display("Au#02")]
        public double TC11 { get; set; }
        /// <summary>
        /// Au#02
        /// </summary>
        [Display("Au#02 設定值")]
        public double TC11_Set { get; set; }
        /// <summary>
        /// Au#02
        /// </summary>
        [Display("Au#02 上下限")]
        public double TC11_UpLw { get; set; }


        /// <summary>
        /// H.D.I.R#1
        /// </summary>
        [Display("H.D.I.R#1")]
        public double TC12 { get; set; }
        /// <summary>
        /// H.D.I.R#1
        /// </summary>
        [Display("H.D.I.R#1 設定值")]
        public double TC12_Set { get; set; }
        /// <summary>
        /// H.D.I.R#1
        /// </summary>
        [Display("H.D.I.R#1 上下限")]
        public double TC12_UpLw { get; set; }


        /// <summary>
        /// H.D.I.R#2
        /// </summary>
        [Display("H.D.I.R#2")]
        public double TC13 { get; set; }
        /// <summary>
        /// H.D.I.R#2
        /// </summary>
        [Display("H.D.I.R#2 設定值")]
        public double TC13_Set { get; set; }
        /// <summary>
        /// H.D.I.R#2
        /// </summary>
        [Display("H.D.I.R#2 上下限")]
        public double TC13_UpLw { get; set; }


        /// <summary>
        /// Ni Dummy
        /// </summary>
        [Display("Ni Dummy")]
        public double TC14 { get; set; }
        /// <summary>
        /// Ni Dummy
        /// </summary>
        [Display("Ni Dummy 設定值")]
        public double TC14_Set { get; set; }
        /// <summary>
        /// Ni Dummy
        /// </summary>
        [Display("Ni Dummy 上下限")]
        public double TC14_UpLw { get; set; }


        /// <summary>
        /// Carbon#1
        /// </summary>
        [Display("Carbon#1")]
        public double TC15 { get; set; }
        /// <summary>
        /// Carbon#1
        /// </summary>
        [Display("Carbon#1 設定值")]
        public double TC15_Set { get; set; }
        /// <summary>
        /// Carbon#1
        /// </summary>
        [Display("Carbon#1 上下限")]
        public double TC15_UpLw { get; set; }


        /// <summary>
        /// Carbon#2
        /// </summary>
        [Display("Carbon#2")]
        public double TC16 { get; set; }
        /// <summary>
        /// Carbon#2
        /// </summary>
        [Display("Carbon#2 設定值")]
        public double TC16_Set { get; set; }
        /// <summary>
        /// Carbon#2
        /// </summary>
        [Display("Carbon#2 上下限")]
        public double TC16_UpLw { get; set; }
    }

}

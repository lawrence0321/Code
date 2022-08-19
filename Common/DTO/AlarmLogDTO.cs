using Common.Attributes;
using Common.Extension;
using Common.Interface;
using System;

namespace Common.DTO
{
    public class AlarmLogDTO : IDTO
    {
        /// <summary>
        /// 發生紀錄時間
        /// </summary>
        [Display()]
        public long StartLogTimeTicks { get; set; }

        /// <summary>
        /// 解除紀錄時間
        /// </summary>
        [Display()]
        public long FinishLogTimeTicks { get; set; }

        /// <summary>
        /// 發生紀錄時間
        /// </summary>
        [Display()]
        public DateTime StartLogDateTime => new DateTime(StartLogTimeTicks);

        /// <summary>
        /// 解除紀錄時間
        /// </summary>
        [Display()]
        public DateTime FinishDateTime => new DateTime(FinishLogTimeTicks);

        /// <summary>
        /// 發生紀錄時間
        /// </summary>
        [Display("發生紀錄時間")]
        public string StartLogDateTimeString => new DateTime(StartLogTimeTicks).GetString();

        /// <summary>
        /// 解除紀錄時間
        /// </summary>
        [Display("解除紀錄時間")]
        public string FinishDateTimeString => this.FinishLogTimeTicks != 0 ? new DateTime(FinishLogTimeTicks).GetString() : "-";

        /// <summary>
        /// AlarmCode
        /// </summary>
        [Display("AlarmCode")]
        public string Code { get; set; }

        /// <summary>
        /// Alarm說明
        /// </summary>
        [Display("Alarm說明")]
        public string Name { get; set; }

        /// <summary>
        /// Alarm中文說明
        /// </summary>
        [Display("Alarm中文說明")]
        public string ZhName { get; set; }
    }
}

using Common.Attributes;

namespace Common.ExConfig
{
    public class LoadDataConfig
    {
        /// <summary>
        /// LoadData結束警報秒數
        /// </summary>
        [Display("LoadData結束警報秒數")]
        public int LoadDataFinishAlarmSec { get; set; }
    }

}

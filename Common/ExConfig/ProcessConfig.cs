using Common.Attributes;

namespace Common.ExConfig
{
    public class ProcessConfig
    {
        /// <summary>
        /// A流程 Ni 秒數
        /// </summary>
        [Display("A流程Ni秒數")]
        public int ProcessA_Ni { get; set; }
        /// <summary>
        /// A流程 Au 秒數
        /// </summary>
        [Display("A流程Au秒數")]
        public int ProcessA_Au { get; set; }
        /// <summary>
        /// A流程 Aust 秒數
        /// </summary>
        [Display("A流程Aust秒數")]
        public int ProcessA_AuSt { get; set; }

        /// <summary>
        /// B流程 Ni 秒數
        /// </summary>
        [Display("B流程Ni秒數")]
        public int ProcessB_Ni { get; set; }
        /// <summary>
        /// B流程 Au 秒數
        /// </summary>
        [Display("B流程Au秒數")]
        public int ProcessB_Au { get; set; }
        /// <summary>
        /// B流程 Aust 秒數
        /// </summary>
        [Display("B流程Aust秒數")]
        public int ProcessB_AuSt { get; set; }

        /// <summary>
        /// C流程 Ni 秒數
        /// </summary>
        [Display("C流程Ni秒數")]
        public int ProcessC_Ni { get; set; }
        /// <summary>
        /// C流程 Au 秒數
        /// </summary>
        [Display("C流程Au秒數")]
        public int ProcessC_Au { get; set; }
        /// <summary>
        /// C流程Aust秒數
        /// </summary>
        [Display("C流程Aust秒數")]
        public int ProcessC_AuSt { get; set; }
    }

}

using System;

namespace Common.Attributes
{
    /// <summary>
    /// 顯示設定    
    /// </summary>
    public class DisplayAttribute : Attribute
    {
        /// <summary>
        /// 是否要顯示
        /// </summary>
        public bool Visible { get; private set; }
        /// <summary>
        /// 繁體中文
        /// </summary>
        public string ZHTW { get; private set; }
        /// <summary>
        /// 簡體中文
        /// </summary>
        public string ZHCN { get; private set; }
        /// <summary>
        /// 英文
        /// </summary>
        public string ENG { get; private set; }

        /// <summary>
        /// 自行設定是否要顯示
        /// <para>Visible_ : 是否要顯示</para>
        /// <para>ZHTW_ : 繁體中文</para>
        /// <para>ZHCN_ : 簡體中文(選填)</para>
        /// <para>ENG_  : 英文(選填)</para>
        /// </summary>
        /// <param name="ZHTW_">繁體中文</param>
        /// <param name="ZHCN_">簡體中文(選填)</param>
        /// <param name="ENG_">英文(選填)</param>
        public DisplayAttribute(bool Visible_, string ZHTW_, string ZHCN_ = "-", string ENG_ = "-")
        {
            this.Visible = Visible_;
            this.ZHTW = ZHTW_;
            this.ZHCN = ZHCN_;
            this.ENG = ENG_;
        }

        /// <summary>
        /// 不顯示
        /// </summary>
        public DisplayAttribute() : this(false, "-", "-", "-") { }

        /// <summary>
        /// 需顯示
        /// </summary>
        /// <param name="ZHTW_">繁體中文</param>
        /// <param name="ZHCN_">簡體中文</param>
        /// <param name="ENG_">英文</param>
        public DisplayAttribute(string ZHTW_, string ZHCN_ = "-", string ENG_ = "-") : this(true, ZHTW_, ZHCN_, ENG_) { }

    }

}

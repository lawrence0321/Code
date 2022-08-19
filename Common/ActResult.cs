using Common.Enums;
using Common.Extension;
using System;

namespace Common
{
    public class ActResult : ActResult<bool>
    {
        /// <summary>
        /// 建構子
        /// <para>若建構子時,給予布林值作為參數</para>
        /// <para>僅接受 True, 若參數為False 跳 Exception</para>
        /// <para>Result = True</para>
        /// </summary>
        public ActResult(bool Bol_)
            : base(Bol_) { }

        /// <summary>
        /// 建構子(發生錯誤)
        /// <para>Result = false</para>
        /// </summary>
        /// <param name="Ex_">錯誤資訊</param>
        /// <param name="Source_">錯誤出處</param>       
        public ActResult(Exception Ex_)
            : base(Ex_) { }

        /// <summary>
        /// 建構子(發生錯誤)
        /// <para>Result = false</para>
        /// </summary>
        /// <param name="Ex_">錯誤類型</param>
        public ActResult(ExceptionTypes ExceptionType_, string ExceptionMessage_ = "",string Remarks_ = "")
            : base(ExceptionType_, ExceptionMessage_, Remarks_) { }

    }

    /// <summary>
    /// 執行結果
    /// </summary>
    public class ActResult<T>
    {
        /// <summary>
        /// 執行結果(T/F)
        /// </summary>
        public bool Result { get; private set; }
        /// <summary>
        /// 錯誤類別
        /// </summary>
        public ExceptionTypes ExceptionType { get; private set; }
        /// <summary>
        /// 錯誤資訊
        /// </summary>
        public Exception Exception { get; private set; }
        /// <summary>
        /// 錯誤來源
        /// </summary>
        public string ExceptionSource { get; private set; }
        /// <summary>
        /// 回傳值
        /// </summary>
        public T Value { get; private set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Remarks { get; private set; }

        /// <summary>
        /// 建構子(發生錯誤)
        /// <para>Result = false</para>
        /// </summary>
        /// <param name="ExceptionType_">錯誤類型</param>
        /// <param name="ExceptionMessage_">錯誤訊息</param>
        public ActResult(ExceptionTypes ExceptionType_, string ExceptionMessage_ = "", string Remarks_ = "")
        {
            this.Result = false;
            this.ExceptionType = ExceptionType_;
            this.Exception = new Exception(String.Format("{0}-{1}", ExceptionType_.ToString(), ExceptionMessage_));
            this.Remarks = Remarks_;
        }

        /// <summary>
        /// 建構子(發生錯誤)
        /// 程式流程發生錯誤，跳至cath
        /// <para>Result = false</para>
        /// </summary>
        /// <param name="Ex_">錯誤資訊</param>
        public ActResult(Exception Ex_)
        {
            this.Result = false;
            this.ExceptionType = ExceptionTypes.ProgramError;
            this.Exception = new Exception(Ex_.ToJson());
            this.ExceptionSource = Ex_.Source;
        }

        /// <summary>
        /// 建構子(執行成功)
        /// <para>若建構子時,給予 非Exception之物件 作為參數</para>
        /// <para>Result = True</para>
        /// </summary>
        /// <param name="Obj_">回傳值</param>
        /// <param name="Remarks_">備註</param>
        public ActResult(T Obj_, string Remarks_ = "")
        {
            this.Result = true;
            this.Value = Obj_;
            this.Remarks = Remarks_;
        }

        /// <summary>
        /// 建構子(特殊用途)
        /// <para>建構時,給予 非Exception之物件 及 自訂Result值</para>
        /// </summary>
        /// <param name="Obj_">回傳值</param>
        /// <param name="Bol_">Result值</param>
        /// <param name="ExceptionType_">錯誤狀態類型</param>
        public ActResult(T Obj_, bool Bol_, ExceptionTypes ExceptionType_ = ExceptionTypes.none)
        {
            this.Result = Bol_;
            this.Value = Obj_;
            this.ExceptionType = ExceptionType_;
        }

        /// <summary>
        /// 建構子
        /// <para>若建構子時,給予布林值作為參數</para>
        /// <para>僅接受 True, 若參數為False 跳 Exception</para>
        /// <para>Result = True</para>
        /// </summary>
        /// <param name="Obj_">回傳值</param>
        public ActResult(bool Bol_)
        {
            if (!Bol_) throw new Exception("If you wanna use false ,Please use `ActResult(Exception Ex_)`, Tell User Reason why Method's Working Fail.");
            this.Result = Bol_;
            this.ExceptionType = ExceptionTypes.none;
        }
    }

}

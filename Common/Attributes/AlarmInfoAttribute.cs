using System;

namespace Common.Attributes
{
    public class AlarmInfoAttribute : Attribute
    {
        
        public int No { get; set; }

        public int Code { get; set; }

        public bool Enabled { get; set; }
        public AlarmInfoAttribute(int No_ , int Code_)
        {
            this.No = No_;
            this.Code = Code_;
            this.Enabled = true;
        }

        public AlarmInfoAttribute(int No_)
        {
            this.No = No_;
            this.Code = 0;
            this.Enabled = true;
        }
    }

}

using System;
using System.Collections.Generic;

namespace WebApplication1.NJCQModel
{
    public partial class TZrhjTfljxx
    {
        public TZrhjTfljxx()
        {
            TZrhjTfygdxx = new HashSet<TZrhjTfygdxx>();
        }

        public string Id { get; set; }
        public string Glycbtid { get; set; }
        public string Ycdsjid { get; set; }
        public string Pid { get; set; }
        public string Fsnf { get; set; }
        public DateTime? Fssj { get; set; }
        public string Tflx { get; set; }
        public double? Jd { get; set; }
        public double? Wd { get; set; }
        public int? Fl { get; set; }
        public int? Fs { get; set; }
        public int? Qy { get; set; }
        public int? Ydsd { get; set; }
        public string Ydfx { get; set; }
        public double? Fq7 { get; set; }
        public double? Fq10 { get; set; }
        public double? Fq12 { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public string Shrid { get; set; }
        public DateTime? Shsj { get; set; }
        public sbyte? Shzt { get; set; }
        public sbyte? Sfkdj { get; set; }
        public string Djrid { get; set; }
        public DateTime? Djsj { get; set; }
        public sbyte? Sfydj { get; set; }
        public string Shyc { get; set; }
        public DateTime? Tjsj { get; set; }
        public DateTime? Rksj { get; set; }

        public virtual TZrhjTf P { get; set; }
        public virtual ICollection<TZrhjTfygdxx> TZrhjTfygdxx { get; set; }
    }
}

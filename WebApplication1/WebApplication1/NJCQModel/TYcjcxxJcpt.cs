using System;
using System.Collections.Generic;

namespace WebApplication1.NJCQModel
{
    public partial class TYcjcxxJcpt
    {
        public string Id { get; set; }
        public string Glycbtid { get; set; }
        public string Jssj { get; set; }
        public string Cjdw { get; set; }
        public string Xtxx { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public string Wdmc { get; set; }
        public string Wdlx { get; set; }
        public string Wdbb { get; set; }
        public string Shrid { get; set; }
        public string Shsj { get; set; }
        public string Shzt { get; set; }
        public string Shbtgsm { get; set; }
        public DateTime? Wdcjsj { get; set; }
        public string Wdzz { get; set; }
        public string Wdbzdw { get; set; }
        public string Sjmj { get; set; }
        public string Fbfw { get; set; }
        public int? Lycs { get; set; }
        public DateTime? Rksj { get; set; }
        public string Jcgzqkid { get; set; }

        public virtual TYcjcxxJcgzqk Jcgzqk { get; set; }
    }
}

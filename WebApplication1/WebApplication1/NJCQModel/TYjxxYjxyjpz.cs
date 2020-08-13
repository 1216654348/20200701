using System;
using System.Collections.Generic;

namespace WebApplication1.NJCQModel
{
    public partial class TYjxxYjxyjpz
    {
        public string Id { get; set; }
        public string Pzid { get; set; }
        public int? Yjdj { get; set; }
        public string Sjbm { get; set; }
        public string Yjtzrid { get; set; }
        public string Yjyaid { get; set; }
        public sbyte? Sjlx { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }

        public virtual TYjxxYjya Yjya { get; set; }
    }
}

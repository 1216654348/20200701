using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class GlyjcYcysqdCopy1
    {
        public string Id { get; set; }
        public string Onlyid { get; set; }
        public string Ycysmc { get; set; }
        public string Ycysms { get; set; }
        public string Ycyslx { get; set; }
        public string Ycyslxdl { get; set; }
        public string Gm { get; set; }
        public string Wzms { get; set; }
        public double? Jd { get; set; }
        public double? Wd { get; set; }
        public double? Gc { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public string Shrid { get; set; }
        public DateTime? Shsj { get; set; }
        public sbyte? Shzt { get; set; }
        public string Shbtgsm { get; set; }
        public sbyte? Sfkdj { get; set; }
        public string Djrid { get; set; }
        public DateTime? Djsj { get; set; }
        public sbyte? Sfydj { get; set; }
        public string Shyc { get; set; }
        public DateTime? Tjsj { get; set; }
        public string Bizid { get; set; }
        public string Ysbm { get; set; }
        public string Wbdwid { get; set; }
        public string Zszp { get; set; }
        public string YcysmcEn { get; set; }
        public string YcysmsEn { get; set; }

        public virtual GlyjcYcdhgjwbdwddygx Wbdw { get; set; }
    }
}

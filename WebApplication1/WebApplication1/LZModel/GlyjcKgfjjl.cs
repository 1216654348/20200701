﻿using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class GlyjcKgfjjl
    {
        public GlyjcKgfjjl()
        {
            HltKgfjYcys = new HashSet<HltKgfjYcys>();
        }

        public string Id { get; set; }
        public string Kgfjxmid { get; set; }
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
        public int? Djcfj { get; set; }
        public DateTime? Kssj { get; set; }
        public DateTime? Jssj { get; set; }
        public double? Fjmj { get; set; }
        public double? Htmj { get; set; }
        public string Tjrid { get; set; }
        public string Htqk { get; set; }
        public string Xczp { get; set; }
        public string Ycysid { get; set; }
        public string Sfwg { get; set; }
        public string Jlmc { get; set; }
        public string Kgfjjlmc { get; set; }

        public virtual ICollection<HltKgfjYcys> HltKgfjYcys { get; set; }
    }
}

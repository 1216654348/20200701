﻿using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class GlyjcXgdgljl
    {
        public GlyjcXgdgljl()
        {
            HltXgdYcys = new HashSet<HltXgdYcys>();
        }

        public string Id { get; set; }
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
        public string Tjrid { get; set; }
        public DateTime? Tjsj { get; set; }
        public string Mc { get; set; }
        public string Szfw { get; set; }
        public string Fjyc { get; set; }
        public string Wzms { get; set; }
        public string Bz { get; set; }
        public string Xczp { get; set; }
        public string Ewm { get; set; }
        public string Point { get; set; }
        public string Qyid { get; set; }
        public string Lx { get; set; }
        public string Rwid { get; set; }
        public string Sx { get; set; }

        public virtual ICollection<HltXgdYcys> HltXgdYcys { get; set; }
    }
}

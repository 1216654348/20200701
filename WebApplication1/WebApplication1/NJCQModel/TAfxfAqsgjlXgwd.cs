﻿using System;
using System.Collections.Generic;

namespace WebApplication1.NJCQModel
{
    public partial class TAfxfAqsgjlXgwd
    {
        public string Id { get; set; }
        public string Aqsgjlid { get; set; }
        public string Wdmc { get; set; }
        public string Sm { get; set; }
        public string Lj { get; set; }
        public string Sfydj { get; set; }
        public string Djrid { get; set; }
        public DateTime? Djsj { get; set; }
        public string Wdlx { get; set; }
        public string Wdbb { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public string Shrid { get; set; }
        public DateTime? Shsj { get; set; }
        public sbyte? Shzt { get; set; }
        public string Shbtgsm { get; set; }
        public string Shyc { get; set; }
        public string Sjmj { get; set; }
        public string Fbfw { get; set; }
        public int? Xzcs { get; set; }
        public DateTime? Rksj { get; set; }

        public virtual TAfxfAqsgjl Aqsgjl { get; set; }
    }
}

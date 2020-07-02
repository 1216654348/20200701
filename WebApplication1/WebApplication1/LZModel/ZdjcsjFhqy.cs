﻿using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class ZdjcsjFhqy
    {
        public string Id { get; set; }
        public string Fhqyid { get; set; }
        public DateTime? Jcsj { get; set; }
        public string Zplj { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public DateTime? Shsj { get; set; }
        public string Shzt { get; set; }
        public sbyte? Sfydj { get; set; }

        public virtual ZdjcdxFhqy Fhqy { get; set; }
    }
}

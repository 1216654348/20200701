﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class GlyjcXxghzxqkjl
    {
        public string Id { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public string Shrid { get; set; }
        public DateTime? Shsj { get; set; }
        public int? Shzt { get; set; }
        public string Shbtgsm { get; set; }
        public sbyte? Sfkdj { get; set; }
        public string Djrid { get; set; }
        public DateTime? Djsj { get; set; }
        public sbyte? Sfydj { get; set; }
        public string Shyc { get; set; }
        public DateTime? Tjsj { get; set; }
        public string Jqghxm { get; set; }
        public string Sszt { get; set; }
        public string Wssyy { get; set; }
        public string Zxqkzhpj { get; set; }
        public string Rwid { get; set; }
        public string Bhglghbzid { get; set; }
        public string Tjrid { get; set; }

        public virtual GlyjcBhglghbzjl Bhglghbz { get; set; }
    }
}

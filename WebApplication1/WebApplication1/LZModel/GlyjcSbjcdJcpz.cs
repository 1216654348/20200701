using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class GlyjcSbjcdJcpz
    {
        public string Id { get; set; }
        public string Jcpzid { get; set; }
        public string Sbid { get; set; }
        public string Jcdbid { get; set; }
        public string Jcdid { get; set; }
        public string Jcsjbid { get; set; }
        public string Ysjcdid1 { get; set; }
        public string Ysjcdid2 { get; set; }
        public double? Csjl { get; set; }

        public virtual GlyjcJcpz Jcpz { get; set; }
    }
}

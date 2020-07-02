using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class GlyjcSblxjcx
    {
        public string Id { get; set; }
        public string Sblxid { get; set; }
        public string Jcxid { get; set; }
        public string Jcpzsjgid { get; set; }

        public virtual GlyjcSblx Sblx { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class GlyjcYddcjd
    {
        public string Id { get; set; }
        public string Jcpzid { get; set; }
        public string Cjdmc { get; set; }
        public string Cjdsyt { get; set; }
        public string Cjdzb { get; set; }
        public string Cjdms { get; set; }

        public virtual GlyjcJcpz Jcpz { get; set; }
    }
}

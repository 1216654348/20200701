using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class GlyjcRwbCopy20200320
    {
        public string Id { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public string Shyc { get; set; }
        public DateTime? Tjsj { get; set; }
        public string Wdfj { get; set; }
        public string Rwmc { get; set; }
        public string Jcpzfaid { get; set; }
        public DateTime? Rwkssj { get; set; }
        public DateTime? Rwjssj { get; set; }
        public string Rwzt { get; set; }
        public string Sjzt { get; set; }

        public virtual GlyjcJcpz Jcpzfa { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class GlyjcXxjlb
    {
        public string Id { get; set; }
        public string Fromuser { get; set; }
        public string Touser { get; set; }
        public DateTime? Sendtime { get; set; }
        public string Msg { get; set; }
        public sbyte? Isread { get; set; }
    }
}

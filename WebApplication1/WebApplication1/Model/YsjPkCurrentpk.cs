using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class YsjPkCurrentpk
    {
        public string Id { get; set; }
        public string Bid { get; set; }
        public string Qz { get; set; }
        public int? Dqz { get; set; }

        public virtual YsjPkConfig B { get; set; }
    }
}

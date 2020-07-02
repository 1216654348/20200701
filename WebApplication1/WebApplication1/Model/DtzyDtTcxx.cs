using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class DtzyDtTcxx
    {
        public string Id { get; set; }
        public string Dtxxid { get; set; }
        public string Tcid { get; set; }
        public sbyte? Mrkj { get; set; }
        public int? Zxxsjb { get; set; }
        public int? Zdxsjb { get; set; }
        public int? Px { get; set; }

        public virtual DtzyDtJbxx Dtxx { get; set; }
    }
}

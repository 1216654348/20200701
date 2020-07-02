using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class DtzyDtJbxx
    {
        public DtzyDtJbxx()
        {
            DtzyDtTcxx = new HashSet<DtzyDtTcxx>();
        }

        public string Id { get; set; }
        public string Mc { get; set; }
        public string Bm { get; set; }
        public string Fz { get; set; }
        public string Zxxsblc { get; set; }
        public string Zdxsblc { get; set; }
        public double? Xsfwz { get; set; }
        public double? Xsfwy { get; set; }
        public double? Xsfws { get; set; }
        public double? Xsfwx { get; set; }
        public string Xsblc { get; set; }
        public double? Zxdx { get; set; }
        public double? Zxdy { get; set; }
        public string Bz { get; set; }

        public virtual ICollection<DtzyDtTcxx> DtzyDtTcxx { get; set; }
    }
}

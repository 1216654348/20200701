using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class ZdjcdxSsqy
    {
        public ZdjcdxSsqy()
        {
            ZdjcsjSsqy = new HashSet<ZdjcsjSsqy>();
        }

        public string Id { get; set; }
        public string Mc { get; set; }
        public string Sm { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public double? Z { get; set; }
        public string Bz { get; set; }
        public int? Px { get; set; }
        public string Kjgsbdid { get; set; }
        public string Rhwsbdid { get; set; }
        public string Wzms { get; set; }
        public string Jczq { get; set; }
        public string Ycysid { get; set; }
        public string Yxsjwc { get; set; }
        public string Wcdw { get; set; }

        public virtual ICollection<ZdjcsjSsqy> ZdjcsjSsqy { get; set; }
    }
}

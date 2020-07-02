using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class ZdjcdxCjjcd
    {
        public ZdjcdxCjjcd()
        {
            ZdjcsjCjjcd = new HashSet<ZdjcsjCjjcd>();
        }

        public string Id { get; set; }
        public string Mc { get; set; }
        public string Sm { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public double? Z { get; set; }
        public double? Csgd { get; set; }
        public string Bz { get; set; }
        public int? Px { get; set; }
        public string Sbdid { get; set; }
        public string Wzms { get; set; }
        public string Ycysid { get; set; }

        public virtual ICollection<ZdjcsjCjjcd> ZdjcsjCjjcd { get; set; }
    }
}

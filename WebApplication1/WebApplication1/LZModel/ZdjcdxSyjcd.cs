using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class ZdjcdxSyjcd
    {
        public ZdjcdxSyjcd()
        {
            ZdjcsjSyjcd = new HashSet<ZdjcsjSyjcd>();
        }

        public string Id { get; set; }
        public string Mc { get; set; }
        public decimal? X { get; set; }
        public decimal? Y { get; set; }
        public string Yhdid { get; set; }
        public string Wzms { get; set; }
        public string Sjzdid { get; set; }
        public string Ybid { get; set; }
        public decimal? Jczq { get; set; }
        public decimal? Px { get; set; }
        public decimal? Ssszjczq { get; set; }
        public string Zplj { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public string Ycysid { get; set; }
        public string Sbdid { get; set; }

        public virtual ICollection<ZdjcsjSyjcd> ZdjcsjSyjcd { get; set; }
    }
}

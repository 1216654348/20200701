using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class YsjPkConfig
    {
        public YsjPkConfig()
        {
            YsjPkCurrentpk = new HashSet<YsjPkCurrentpk>();
        }

        public string Id { get; set; }
        public string Bm { get; set; }
        public int? Qzc { get; set; }
        public int? Sxmc { get; set; }
        public int? Qssxm { get; set; }
        public string Bz { get; set; }

        public virtual ICollection<YsjPkCurrentpk> YsjPkCurrentpk { get; set; }
    }
}

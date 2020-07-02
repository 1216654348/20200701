using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class YsjSeqConfig
    {
        public YsjSeqConfig()
        {
            YsjSeqCurrentseq = new HashSet<YsjSeqCurrentseq>();
        }

        public string Id { get; set; }
        public string Bm { get; set; }
        public int? Sxmc { get; set; }
        public int? Qssxm { get; set; }
        public string Bz { get; set; }

        public virtual ICollection<YsjSeqCurrentseq> YsjSeqCurrentseq { get; set; }
    }
}

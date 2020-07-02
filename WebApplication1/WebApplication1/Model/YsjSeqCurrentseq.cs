using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class YsjSeqCurrentseq
    {
        public string Id { get; set; }
        public string Sxmpzid { get; set; }
        public string Qz { get; set; }
        public int? Dqz { get; set; }

        public virtual YsjSeqConfig Sxmpz { get; set; }
    }
}

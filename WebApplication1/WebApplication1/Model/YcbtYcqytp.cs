using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class YcbtYcqytp
    {
        public string Id { get; set; }
        public string Ycqyid { get; set; }
        public string Tpmc { get; set; }
        public string Tplj { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public int? Px { get; set; }
        public string Tpsm { get; set; }
        public string Bz { get; set; }

        public virtual YcbtYcqy Ycqy { get; set; }
    }
}

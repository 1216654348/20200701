using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class YcbtYcdtp
    {
        public string Id { get; set; }
        public string Ycdid { get; set; }
        public string Tpmc { get; set; }
        public string Tplj { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public int? Px { get; set; }
        public string Tpsm { get; set; }
        public string Bz { get; set; }

        public virtual YcbtYcd Ycd { get; set; }
    }
}

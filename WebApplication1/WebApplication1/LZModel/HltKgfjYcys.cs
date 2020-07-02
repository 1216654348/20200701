using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class HltKgfjYcys
    {
        public string Id { get; set; }
        public string Kgfjid { get; set; }
        public string Ycysid { get; set; }
        public string Ycysmc { get; set; }
        public DateTime? Cjsj { get; set; }

        public virtual GlyjcKgfjjl Kgfj { get; set; }
        public virtual GlyjcYcysqd Ycys { get; set; }
    }
}

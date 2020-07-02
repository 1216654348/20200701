using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class HltBhzsyhjzzgcjlYcysqd
    {
        public string Id { get; set; }
        public string Bhzsyhjzzgcjlid { get; set; }
        public string Ycysid { get; set; }
        public string Ycysmc { get; set; }
        public DateTime? Cjsj { get; set; }

        public virtual GlyjcBhzsyhjzzgcjl Bhzsyhjzzgcjl { get; set; }
        public virtual GlyjcYcysqd Ycys { get; set; }
    }
}

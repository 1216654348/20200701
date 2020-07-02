using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class GlyjcJrycjl
    {
        public string Id { get; set; }
        public DateTime? Jrycsj { get; set; }
        public DateTime? Jcsj { get; set; }
        public int? Jrzq { get; set; }
        public string Jcjlid { get; set; }

        public virtual GlyjcJrjcjl Jcjl { get; set; }
    }
}

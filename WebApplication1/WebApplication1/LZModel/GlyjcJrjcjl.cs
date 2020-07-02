using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class GlyjcJrjcjl
    {
        public GlyjcJrjcjl()
        {
            GlyjcJrycjl = new HashSet<GlyjcJrycjl>();
        }

        public string Id { get; set; }
        public int? Sjlxid { get; set; }
        public string Sjlxname { get; set; }
        public DateTime? Jcsj { get; set; }
        public string Tjzdmc { get; set; }
        public string Thzdz { get; set; }
        public sbyte? Sfyyc { get; set; }

        public virtual ICollection<GlyjcJrycjl> GlyjcJrycjl { get; set; }
    }
}

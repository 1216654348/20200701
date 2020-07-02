using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class GlyjcYjjsxx
    {
        public string Id { get; set; }
        public string Yjszid { get; set; }
        public string Yjdj { get; set; }
        public string Yjjsrid { get; set; }
        public string Yjjsrname { get; set; }
        public string Tel { get; set; }

        public virtual GlyjcYjszzb Yjsz { get; set; }
    }
}

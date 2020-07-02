using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class GlyjcYjxx
    {
        public GlyjcYjxx()
        {
            GlyjcYjczgz = new HashSet<GlyjcYjczgz>();
            GlyjcYjczxx = new HashSet<GlyjcYjczxx>();
        }

        public string Id { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public sbyte? Sfkdj { get; set; }
        public string Shyc { get; set; }
        public DateTime? Djsj { get; set; }
        public string Yjpzfaid { get; set; }
        public string Cjsjid { get; set; }
        public DateTime? Fbsj { get; set; }
        public string Yjdj { get; set; }
        public string Cjsjbid { get; set; }
        public string Yjxxsm { get; set; }
        public string Yjyaid { get; set; }
        public string Yjsfjc { get; set; }
        public sbyte? Sfydj { get; set; }
        public string Djrid { get; set; }
        public string Yjslzt { get; set; }
        public string Slsm { get; set; }

        public virtual ICollection<GlyjcYjczgz> GlyjcYjczgz { get; set; }
        public virtual ICollection<GlyjcYjczxx> GlyjcYjczxx { get; set; }
    }
}

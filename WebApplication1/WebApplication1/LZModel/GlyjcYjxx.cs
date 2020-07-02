using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
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
        public sbyte? Sfydj { get; set; }
        public string Djrid { get; set; }
        public DateTime? Djsj { get; set; }
        public string Yjpzfaid { get; set; }
        public DateTime? Fbsj { get; set; }
        public string Yjdj { get; set; }
        public string Cjsjid { get; set; }
        public string Cjsjbid { get; set; }
        public string Yjxxsm { get; set; }
        public string Yjyaid { get; set; }
        public string Yjsfjc { get; set; }
        public DateTime? Yjjcsj { get; set; }
        public string Yjjcrid { get; set; }
        public string Yjslzt { get; set; }
        public string Slsm { get; set; }
        public DateTime? Slsj { get; set; }
        public string Yjbz { get; set; }
        public string Yjfswz { get; set; }
        public string Yjdx { get; set; }
        public double? Jd { get; set; }
        public double? Wd { get; set; }
        public string Fzrmc { get; set; }
        public string Qyid { get; set; }
        public string Zpdw { get; set; }
        public string Yjslrid { get; set; }
        public sbyte? Ly { get; set; }
        public sbyte? Lx { get; set; }
        public sbyte? Yjzt { get; set; }
        public string Fl { get; set; }
        public string Ms { get; set; }
        public int? Sort { get; set; }

        public virtual ICollection<GlyjcYjczgz> GlyjcYjczgz { get; set; }
        public virtual ICollection<GlyjcYjczxx> GlyjcYjczxx { get; set; }
    }
}

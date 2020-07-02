using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class YcbtYcqy
    {
        public YcbtYcqy()
        {
            InverseFj = new HashSet<YcbtYcqy>();
            YcbtYcqytp = new HashSet<YcbtYcqytp>();
            YcbtYcys = new HashSet<YcbtYcys>();
        }

        public string Id { get; set; }
        public string Ycdid { get; set; }
        public string Mc { get; set; }
        public string Qsndbm { get; set; }
        public string Jzndbm { get; set; }
        public string Wzsm { get; set; }
        public string Gk { get; set; }
        public double? Jd { get; set; }
        public double? Wd { get; set; }
        public string Dbxtplj { get; set; }
        public string Fjid { get; set; }
        public string Hcqbjx { get; set; }
        public string Hxqbjx { get; set; }
        public string Gldwmc { get; set; }
        public string Jcdwmc { get; set; }
        public string Ywlx { get; set; }
        public string Bz { get; set; }
        public string Tjrid { get; set; }
        public DateTime? Tjsj { get; set; }
        public string Shrid { get; set; }
        public DateTime? Shsj { get; set; }
        public sbyte? Sfshtg { get; set; }
        public string Shsm { get; set; }
        public string Djrid { get; set; }
        public DateTime? Djsj { get; set; }
        public sbyte? Sfydj { get; set; }
        public string Xhrid { get; set; }
        public DateTime? Xhsj { get; set; }
        public string Zt { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }

        public virtual YcbtYcqy Fj { get; set; }
        public virtual YcbtYcd Ycd { get; set; }
        public virtual ICollection<YcbtYcqy> InverseFj { get; set; }
        public virtual ICollection<YcbtYcqytp> YcbtYcqytp { get; set; }
        public virtual ICollection<YcbtYcys> YcbtYcys { get; set; }
    }
}

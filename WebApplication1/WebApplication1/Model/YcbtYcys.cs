using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class YcbtYcys
    {
        public YcbtYcys()
        {
            InverseFj = new HashSet<YcbtYcys>();
            YcbtYcystp = new HashSet<YcbtYcystp>();
        }

        public string Id { get; set; }
        public string Mc { get; set; }
        public string Wzsm { get; set; }
        public string Gk { get; set; }
        public double? Jd { get; set; }
        public double? Wd { get; set; }
        public string Dpxtplj { get; set; }
        public string Bjx { get; set; }
        public string Fjid { get; set; }
        public string Yclx { get; set; }
        public string Qsndbm { get; set; }
        public string Jzndbm { get; set; }
        public string Ycqyid { get; set; }
        public string Bm { get; set; }
        public string Bcxz { get; set; }
        public string Hjxz { get; set; }
        public string Gbnf { get; set; }
        public string Gljgmc { get; set; }
        public string Jjurl { get; set; }
        public string Ywlx { get; set; }
        public string Bhjbych { get; set; }
        public string Bz { get; set; }
        public double? Xdwzx { get; set; }
        public double? Xdwzy { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
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
        public sbyte? Zyxjb { get; set; }

        public virtual YcbtYcys Fj { get; set; }
        public virtual YcbtYcqy Ycqy { get; set; }
        public virtual ICollection<YcbtYcys> InverseFj { get; set; }
        public virtual ICollection<YcbtYcystp> YcbtYcystp { get; set; }
    }
}

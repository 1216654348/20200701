using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class YcbtYcd
    {
        public YcbtYcd()
        {
            YcbtYcdtp = new HashSet<YcbtYcdtp>();
            YcbtYcqy = new HashSet<YcbtYcqy>();
        }

        public string Id { get; set; }
        public string Ywm { get; set; }
        public string Zwm { get; set; }
        public string Wzsm { get; set; }
        public string Gk { get; set; }
        public string Xzqbm { get; set; }
        public string Qsndbm { get; set; }
        public string Jzndbm { get; set; }
        public double? Jd { get; set; }
        public double? Wd { get; set; }
        public string Dbxtplj { get; set; }
        public string Bhxzms { get; set; }
        public string Zyycxzms { get; set; }
        public string Xzgnsm { get; set; }
        public string Bhchyjb { get; set; }
        public string Bhgljg { get; set; }
        public string Rxnf { get; set; }
        public string Kznf { get; set; }
        public string Lxbz { get; set; }
        public string Ycpj { get; set; }
        public string Ycjz { get; set; }
        public string Gbwh { get; set; }
        public string Gbjg { get; set; }
        public DateTime? Gbsj { get; set; }
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

        public virtual ICollection<YcbtYcdtp> YcbtYcdtp { get; set; }
        public virtual ICollection<YcbtYcqy> YcbtYcqy { get; set; }
    }
}

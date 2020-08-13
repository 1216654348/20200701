using System;
using System.Collections.Generic;

namespace WebApplication1.NJCQModel
{
    public partial class TXjxmXjxmjl
    {
        public TXjxmXjxmjl()
        {
            TXjxmSgxchjzp = new HashSet<TXjxmSgxchjzp>();
            TXjxmWzt = new HashSet<TXjxmWzt>();
        }

        public string Id { get; set; }
        public string Glycbtid { get; set; }
        public string Xjxmbh { get; set; }
        public string Xmmc { get; set; }
        public string Jsmd { get; set; }
        public string Wzsm { get; set; }
        public decimal? Jd { get; set; }
        public decimal? Wd { get; set; }
        public DateTime? Kgrq { get; set; }
        public DateTime? Jhjgrq { get; set; }
        public DateTime? Jgsj { get; set; }
        public string Wwbmpzxkwh { get; set; }
        public string Xmsm { get; set; }
        public decimal? Zdmj { get; set; }
        public decimal? Gd { get; set; }
        public string Sgdw { get; set; }
        public string Jldw { get; set; }
        public string Xgycbtid { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public string Shrid { get; set; }
        public DateTime? Shsj { get; set; }
        public string Shzt { get; set; }
        public string Shbtgsm { get; set; }
        public string Sfydj { get; set; }
        public string Djrid { get; set; }
        public DateTime? Djsj { get; set; }
        public string Shyc { get; set; }
        public DateTime? Rksj { get; set; }
        public sbyte? Sfyzp { get; set; }
        public string Xmwz { get; set; }
        public string Xmwzsl { get; set; }
        public sbyte? Sfwj { get; set; }
        public string Spyq { get; set; }
        public string Rwid { get; set; }

        public virtual ICollection<TXjxmSgxchjzp> TXjxmSgxchjzp { get; set; }
        public virtual ICollection<TXjxmWzt> TXjxmWzt { get; set; }
    }
}

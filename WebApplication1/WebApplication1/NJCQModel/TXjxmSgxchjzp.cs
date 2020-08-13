using System;
using System.Collections.Generic;

namespace WebApplication1.NJCQModel
{
    public partial class TXjxmSgxchjzp
    {
        public string Id { get; set; }
        public string Glycbtid { get; set; }
        public string Xjxmid { get; set; }
        public string Mc { get; set; }
        public string Sm { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public string Lj { get; set; }
        public string Shrid { get; set; }
        public DateTime? Shsj { get; set; }
        public string Shbtgsm { get; set; }
        public sbyte? Shzt { get; set; }
        public string Cjdzbxx { get; set; }
        public string Sjmj { get; set; }
        public string Fbfw { get; set; }
        public int? Xzcs { get; set; }
        public string Djrid { get; set; }
        public DateTime? Djsj { get; set; }
        public string Sfydj { get; set; }
        public string Rwid { get; set; }
        public string Jcwzid { get; set; }
        public string Pg { get; set; }
        public string Xjxmkzqk { get; set; }
        public sbyte? Sfwg { get; set; }
        public DateTime? Rksj { get; set; }
        public DateTime? Txsj { get; set; }
        public DateTime? Sjwgsj { get; set; }
        public sbyte? Lrfs { get; set; }

        public virtual TXjxmXjxmjl Xjxm { get; set; }
    }
}

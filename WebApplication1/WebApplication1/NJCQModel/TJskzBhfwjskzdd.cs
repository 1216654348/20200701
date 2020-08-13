using System;
using System.Collections.Generic;

namespace WebApplication1.NJCQModel
{
    public partial class TJskzBhfwjskzdd
    {
        public TJskzBhfwjskzdd()
        {
            TJskzBhfw = new HashSet<TJskzBhfw>();
            TJskzJskzdd = new HashSet<TJskzJskzdd>();
        }

        public string Id { get; set; }
        public string Glycbtid { get; set; }
        public string Bhfwjx { get; set; }
        public double? Bhfwmj { get; set; }
        public string Bhfwglgd { get; set; }
        public string Jskzddjx { get; set; }
        public double? Jskzddmj { get; set; }
        public string Jskzddglgd { get; set; }
        public string Gbdx { get; set; }
        public string Rwid { get; set; }
        public sbyte? Shzt { get; set; }
        public string Shbtgsm { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public int? Bbh { get; set; }
        public string Bbid { get; set; }
        public bool? Sfxbb { get; set; }
        public string Shrid { get; set; }
        public DateTime? Shsj { get; set; }
        public string Djrid { get; set; }
        public DateTime? Djsj { get; set; }
        public string Shyc { get; set; }
        public DateTime? Rksj { get; set; }
        public string Bhfwbm { get; set; }
        public string Jskzddbm { get; set; }
        public string Bz { get; set; }
        public int? Lycs { get; set; }
        public string Dydqhmc { get; set; }
        public string Dydwwbhdwmc { get; set; }

        public virtual ICollection<TJskzBhfw> TJskzBhfw { get; set; }
        public virtual ICollection<TJskzJskzdd> TJskzJskzdd { get; set; }
    }
}

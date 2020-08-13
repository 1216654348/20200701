using System;
using System.Collections.Generic;

namespace WebApplication1.NJCQModel
{
    public partial class TJskzJskzdd
    {
        public TJskzJskzdd()
        {
            TJskzBhfw = new HashSet<TJskzBhfw>();
        }

        public string Id { get; set; }
        public string Glycbtid { get; set; }
        public string Ycqhcqid { get; set; }
        public string Sfyhcqyz { get; set; }
        public string Dyhcqid { get; set; }
        public string Dyhcqmc { get; set; }
        public string Gbdwid { get; set; }
        public string Gbdwmc { get; set; }
        public string Jskzddjx { get; set; }
        public double? Jskzddmj { get; set; }
        public string Jskzddglgd { get; set; }
        public string Gbdx { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public string Shrid { get; set; }
        public DateTime? Shsj { get; set; }
        public string Djrid { get; set; }
        public DateTime? Djsj { get; set; }
        public string Shyc { get; set; }
        public DateTime? Rksj { get; set; }
        public string Jskzddbm { get; set; }
        public string Jskzddmc { get; set; }
        public string Bhqhjxmsyglgdid { get; set; }
        public string Shzt { get; set; }
        public string Bz { get; set; }
        public string Qhlx { get; set; }
        public string Dydwwbhdw { get; set; }
        public int? Sort { get; set; }

        public virtual TJskzBhfwjskzdd Bhqhjxmsyglgd { get; set; }
        public virtual ICollection<TJskzBhfw> TJskzBhfw { get; set; }
    }
}

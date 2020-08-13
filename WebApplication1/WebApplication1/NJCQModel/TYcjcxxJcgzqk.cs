using System;
using System.Collections.Generic;

namespace WebApplication1.NJCQModel
{
    public partial class TYcjcxxJcgzqk
    {
        public TYcjcxxJcgzqk()
        {
            TYcjcxxJcfa = new HashSet<TYcjcxxJcfa>();
            TYcjcxxJcpt = new HashSet<TYcjcxxJcpt>();
            TYcjcxxQtjcyjzd = new HashSet<TYcjcxxQtjcyjzd>();
        }

        public string Id { get; set; }
        public string Glycbtid { get; set; }
        public DateTime? Rksj { get; set; }
        public DateTime? Shsj { get; set; }
        public string Rwid { get; set; }
        public sbyte? Shzt { get; set; }
        public string Shbtgsm { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public string Shrid { get; set; }
        public string Fbfw { get; set; }
        public string Sjmj { get; set; }
        public string Bz { get; set; }
        public string Djrid { get; set; }
        public DateTime? Djsj { get; set; }
        public int? Sfydj { get; set; }
        public string Shyc { get; set; }
        public string Bbid { get; set; }
        public int? Bbh { get; set; }
        public bool? Sfxbb { get; set; }

        public virtual ICollection<TYcjcxxJcfa> TYcjcxxJcfa { get; set; }
        public virtual ICollection<TYcjcxxJcpt> TYcjcxxJcpt { get; set; }
        public virtual ICollection<TYcjcxxQtjcyjzd> TYcjcxxQtjcyjzd { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace WebApplication1.NJCQModel
{
    public partial class TJskzHcq
    {
        public TJskzHcq()
        {
            TJskzYcq = new HashSet<TJskzYcq>();
        }

        public string Id { get; set; }
        public string Glycbtid { get; set; }
        public string Hcqmc { get; set; }
        public string Hcqbm { get; set; }
        public string Hcqjx { get; set; }
        public double? Hcqmj { get; set; }
        public string Hcqglgd { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public string Shrid { get; set; }
        public DateTime? Shsj { get; set; }
        public string Djrid { get; set; }
        public DateTime? Djsj { get; set; }
        public string Shyc { get; set; }
        public string Bhqhjxmsyglgdid { get; set; }
        public DateTime? Rksj { get; set; }
        public string Shzt { get; set; }
        public string Bz { get; set; }
        public string Qhlx { get; set; }
        public string Dydwwbhdw { get; set; }
        public int? Sort { get; set; }

        public virtual ICollection<TJskzYcq> TJskzYcq { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace WebApplication1.NJCQModel
{
    public partial class TJskzYcq
    {
        public string Id { get; set; }
        public string Glycbtid { get; set; }
        public string Ycqmc { get; set; }
        public string Ycqbm { get; set; }
        public string Ycqjx { get; set; }
        public double? Ycqmj { get; set; }
        public string Ycqglgd { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public string Shrid { get; set; }
        public DateTime? Shsj { get; set; }
        public string Djrid { get; set; }
        public DateTime? Djsj { get; set; }
        public string Shyc { get; set; }
        public DateTime? Rksj { get; set; }
        public string Hcqid { get; set; }
        public string Bhqhjxmsyglgdid { get; set; }
        public string Shzt { get; set; }
        public string Qhlx { get; set; }
        public string Dydwwbhdw { get; set; }
        public int? Sort { get; set; }

        public virtual TJskzHcq Hcq { get; set; }
    }
}

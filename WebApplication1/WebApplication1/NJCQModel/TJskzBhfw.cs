using System;
using System.Collections.Generic;

namespace WebApplication1.NJCQModel
{
    public partial class TJskzBhfw
    {
        public string Id { get; set; }
        public string Glycbtid { get; set; }
        public string Sfyycqyz { get; set; }
        public string Dyycqid { get; set; }
        public string Dyycqmc { get; set; }
        public string Bhfwjx { get; set; }
        public double? Bhfwmj { get; set; }
        public string Bhfwglgd { get; set; }
        public string Gbdx { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public string Shrid { get; set; }
        public DateTime? Shsj { get; set; }
        public string Djrid { get; set; }
        public DateTime? Djsj { get; set; }
        public string Shyc { get; set; }
        public DateTime? Rksj { get; set; }
        public string Bhqhjxmsyglgdid { get; set; }
        public string Bhfwbm { get; set; }
        public string Bhfwmc { get; set; }
        public string Jskzddid { get; set; }
        public string Shzt { get; set; }
        public string Qhlx { get; set; }
        public string Dydwwbhdw { get; set; }
        public int? Sort { get; set; }

        public virtual TJskzBhfwjskzdd Bhqhjxmsyglgd { get; set; }
        public virtual TJskzJskzdd Jskzdd { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace WebApplication1.NJCQModel
{
    public partial class TStatisticTask
    {
        public string Id { get; set; }
        public string Jcx { get; set; }
        public string Jcxmc { get; set; }
        public string Datatype { get; set; }
        public string Cjrid { get; set; }
        public string Cjrmc { get; set; }
        public DateTime? Cjsj { get; set; }
        public int? Cjsjsl { get; set; }
        public int? Cjrwsl { get; set; }
        public int? Shsjsl { get; set; }
        public string Bz { get; set; }
        public DateTime? Rksj { get; set; }
    }
}

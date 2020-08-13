using System;
using System.Collections.Generic;

namespace WebApplication1.NJCQModel
{
    public partial class TStatisticCjronlinetime
    {
        public string Id { get; set; }
        public string Cjrid { get; set; }
        public string Cjrmc { get; set; }
        public double? Onlinetime { get; set; }
        public DateTime? Cjsj { get; set; }
        public DateTime? Rksj { get; set; }
    }
}

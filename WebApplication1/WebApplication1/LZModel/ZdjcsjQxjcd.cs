using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class ZdjcsjQxjcd
    {
        public string Id { get; set; }
        public string Qxjcdid { get; set; }
        public DateTime? Jcsj { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public DateTime? Shsj { get; set; }
        public string Shzt { get; set; }
        public sbyte? Sfydj { get; set; }

        public virtual ZdjcdxQxjcd Qxjcd { get; set; }
    }
}

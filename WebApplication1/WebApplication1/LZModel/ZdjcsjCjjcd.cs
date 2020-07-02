using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class ZdjcsjCjjcd
    {
        public string Id { get; set; }
        public string Cjjcdid { get; set; }
        public DateTime? Jcsj { get; set; }
        public double? Cjl { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public DateTime? Shsj { get; set; }
        public string Shzt { get; set; }
        public sbyte? Sfydj { get; set; }

        public virtual ZdjcdxCjjcd Cjjcd { get; set; }
    }
}

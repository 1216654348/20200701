using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class ZdjcsjSyjcd
    {
        public string Id { get; set; }
        public string Szjcdid { get; set; }
        public DateTime? Jcsj { get; set; }
        public double? Ph { get; set; }
        public double? Ddl { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public DateTime? Shsj { get; set; }
        public string Shzt { get; set; }
        public sbyte? Sfydj { get; set; }

        public virtual ZdjcdxSyjcd Szjcd { get; set; }
    }
}

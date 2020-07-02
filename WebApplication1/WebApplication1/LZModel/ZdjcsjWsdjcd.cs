using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class ZdjcsjWsdjcd
    {
        public string Id { get; set; }
        public string Wsdjcdid { get; set; }
        public DateTime? Jcsj { get; set; }
        public double? Wd { get; set; }
        public double? Sd { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public DateTime? Shsj { get; set; }
        public string Shzt { get; set; }
        public sbyte? Sfydj { get; set; }
        public DateTime? Rksj { get; set; }

        public virtual ZdjcdxWsdjcd Wsdjcd { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class ZdjcsjSwlsjcd
    {
        public string Id { get; set; }
        public string Swlsjcd { get; set; }
        public DateTime? Jcsj { get; set; }
        public double? Sw { get; set; }
        public double? Ls { get; set; }
        public double? Jd { get; set; }
        public string Fx { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public DateTime? Shsj { get; set; }
        public string Shzt { get; set; }
        public sbyte? Sfydj { get; set; }
        public double? SwJcz { get; set; }

        public virtual ZdjcdxSwlsjcd SwlsjcdNavigation { get; set; }
    }
}

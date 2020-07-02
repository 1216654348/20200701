using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class ZdjcsjSsqy
    {
        public string Id { get; set; }
        public string Ssqyid { get; set; }
        public DateTime? Jcsj { get; set; }
        public string Kjgzplj { get; set; }
        public string Rhwzplj { get; set; }
        public string Wdzsjlj { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public DateTime? Shsj { get; set; }
        public string Shzt { get; set; }
        public sbyte? Sfydj { get; set; }

        public virtual ZdjcdxSsqy Ssqy { get; set; }
    }
}

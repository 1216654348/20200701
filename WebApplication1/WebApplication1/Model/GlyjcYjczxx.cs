using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class GlyjcYjczxx
    {
        public string Id { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public sbyte? Sfkdj { get; set; }
        public string Djrid { get; set; }
        public DateTime? Djsj { get; set; }
        public string Yjxxid { get; set; }
        public DateTime? Czsj { get; set; }
        public string Czgzcyr { get; set; }
        public string Czsm { get; set; }
        public string Zplj { get; set; }
        public string Czr { get; set; }
        public string Sfydj { get; set; }

        public virtual GlyjcYjxx Yjxx { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class GlyjcYjczgz
    {
        public string Id { get; set; }
        public string Yjxxid { get; set; }
        public string Userid { get; set; }
        public DateTime? Cjsj { get; set; }
        public string Czsm { get; set; }
        public string Remark { get; set; }
        public string Picname { get; set; }
        public string Filename { get; set; }
        public string Yjsfjc { get; set; }
        public sbyte? Sfydj { get; set; }
        public DateTime? Djsj { get; set; }
        public string Djrid { get; set; }

        public virtual OrgUserinfo User { get; set; }
        public virtual GlyjcYjxx Yjxx { get; set; }
    }
}

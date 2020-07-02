using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class GlyjcMjlyjyzsz
    {
        public string Id { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public string Shyc { get; set; }
        public DateTime? Tjsj { get; set; }
        public string Yjpzfaid { get; set; }
        public string Yjdj { get; set; }
        public string Mjz { get; set; }

        public virtual GlyjcYjszzb Yjpzfa { get; set; }
    }
}

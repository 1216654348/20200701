using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class GlyjcSzlyjyzsz
    {
        public string Id { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public string Shyc { get; set; }
        public DateTime? Tjsj { get; set; }
        public string Yjpzfaid { get; set; }
        public string Yjdj { get; set; }
        public string Yzxz { get; set; }
        public string Yzdz { get; set; }
        public string Ljyjlx { get; set; }

        public virtual GlyjcYjszzb Yjpzfa { get; set; }
    }
}

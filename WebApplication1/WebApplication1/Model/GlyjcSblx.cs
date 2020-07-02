using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class GlyjcSblx
    {
        public GlyjcSblx()
        {
            GlyjcSbqd = new HashSet<GlyjcSbqd>();
        }

        public string Id { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public string Shyc { get; set; }
        public DateTime? Tjsj { get; set; }
        public string Mc { get; set; }
        public string Fl { get; set; }
        public string Gg { get; set; }
        public string Sbcs { get; set; }
        public string Yljj { get; set; }
        public string Jksm { get; set; }
        public string Bzsm { get; set; }
        public string Sbtp { get; set; }

        public virtual ICollection<GlyjcSbqd> GlyjcSbqd { get; set; }
    }
}

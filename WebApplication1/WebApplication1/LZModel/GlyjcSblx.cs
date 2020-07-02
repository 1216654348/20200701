using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class GlyjcSblx
    {
        public GlyjcSblx()
        {
            GlyjcSblxjcx = new HashSet<GlyjcSblxjcx>();
            GlyjcSbqd = new HashSet<GlyjcSbqd>();
            GlyjcSbqd0716 = new HashSet<GlyjcSbqd0716>();
            GlyjcSbqdCopy = new HashSet<GlyjcSbqdCopy>();
            GlyjcSbqdCopy1 = new HashSet<GlyjcSbqdCopy1>();
            GlyjcSbqdCopy20181203Qhx = new HashSet<GlyjcSbqdCopy20181203Qhx>();
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
        public string Sbsjcdx { get; set; }

        public virtual ICollection<GlyjcSblxjcx> GlyjcSblxjcx { get; set; }
        public virtual ICollection<GlyjcSbqd> GlyjcSbqd { get; set; }
        public virtual ICollection<GlyjcSbqd0716> GlyjcSbqd0716 { get; set; }
        public virtual ICollection<GlyjcSbqdCopy> GlyjcSbqdCopy { get; set; }
        public virtual ICollection<GlyjcSbqdCopy1> GlyjcSbqdCopy1 { get; set; }
        public virtual ICollection<GlyjcSbqdCopy20181203Qhx> GlyjcSbqdCopy20181203Qhx { get; set; }
    }
}

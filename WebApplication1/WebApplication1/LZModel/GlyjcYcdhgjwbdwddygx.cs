using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class GlyjcYcdhgjwbdwddygx
    {
        public GlyjcYcdhgjwbdwddygx()
        {
            GlyjcYcysqd = new HashSet<GlyjcYcysqd>();
            GlyjcYcysqdCopy = new HashSet<GlyjcYcysqdCopy>();
            GlyjcYcysqdCopy1 = new HashSet<GlyjcYcysqdCopy1>();
            GlyjcYcysqdCopy2 = new HashSet<GlyjcYcysqdCopy2>();
            GlyjcYcysqdCopy20181015qhx = new HashSet<GlyjcYcysqdCopy20181015qhx>();
            GlyjcYcysqdCopy20200513 = new HashSet<GlyjcYcysqdCopy20200513>();
        }

        public string Id { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public sbyte? Sfkdj { get; set; }
        public string Djrid { get; set; }
        public DateTime? Djsj { get; set; }
        public sbyte? Sfydj { get; set; }
        public string Shyc { get; set; }
        public DateTime? Tjsj { get; set; }
        public string Wwbhdwmc { get; set; }
        public string Wwbhdwlx { get; set; }
        public string Bhjb { get; set; }
        public string Gbpc { get; set; }
        public string Gbwh { get; set; }
        public DateTime? Gbsj { get; set; }
        public string Tjrid { get; set; }

        public virtual ICollection<GlyjcYcysqd> GlyjcYcysqd { get; set; }
        public virtual ICollection<GlyjcYcysqdCopy> GlyjcYcysqdCopy { get; set; }
        public virtual ICollection<GlyjcYcysqdCopy1> GlyjcYcysqdCopy1 { get; set; }
        public virtual ICollection<GlyjcYcysqdCopy2> GlyjcYcysqdCopy2 { get; set; }
        public virtual ICollection<GlyjcYcysqdCopy20181015qhx> GlyjcYcysqdCopy20181015qhx { get; set; }
        public virtual ICollection<GlyjcYcysqdCopy20200513> GlyjcYcysqdCopy20200513 { get; set; }
    }
}

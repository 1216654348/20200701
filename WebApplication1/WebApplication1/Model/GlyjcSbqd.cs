using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class GlyjcSbqd
    {
        public GlyjcSbqd()
        {
            GlyjcCamera = new HashSet<GlyjcCamera>();
        }

        public string Id { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public string Shyc { get; set; }
        public DateTime? Tjsj { get; set; }
        public string Sbmc { get; set; }
        public string Sbbh { get; set; }
        public string Lx { get; set; }
        public string Azdszycdid { get; set; }
        public string Bcjcdxid { get; set; }
        public string Azdwzms { get; set; }
        public double? Azdjd { get; set; }
        public double? Azdwd { get; set; }
        public string Fzr { get; set; }
        public DateTime? Cgrq { get; set; }
        public string Bzsm { get; set; }

        public virtual GlyjcSblx LxNavigation { get; set; }
        public virtual ICollection<GlyjcCamera> GlyjcCamera { get; set; }
    }
}

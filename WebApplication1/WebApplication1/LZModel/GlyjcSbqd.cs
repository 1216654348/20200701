using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
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
        public string Ssqy { get; set; }
        public string Lx { get; set; }
        public string Azdszycdid { get; set; }
        public string Bcjcdxid { get; set; }
        public string Azdwzms { get; set; }
        public double? Azdjd { get; set; }
        public double? Azdwd { get; set; }
        public string Fzr { get; set; }
        public DateTime? Cgrq { get; set; }
        public string Bzsm { get; set; }
        public string Tpfj { get; set; }
        public string Sfkkzq { get; set; }
        public double? Zq { get; set; }
        public string Zqdw { get; set; }
        public string Zqlb { get; set; }
        public string Dmgc { get; set; }

        public virtual GlyjcSblx LxNavigation { get; set; }
        public virtual ICollection<GlyjcCamera> GlyjcCamera { get; set; }
    }
}

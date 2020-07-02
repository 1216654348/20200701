using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class GlyjcYjszzb
    {
        public GlyjcYjszzb()
        {
            GlyjcMjlyjyzsz = new HashSet<GlyjcMjlyjyzsz>();
            GlyjcYjjsxx = new HashSet<GlyjcYjjsxx>();
        }

        public string Id { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public string Shyc { get; set; }
        public DateTime? Tjsj { get; set; }
        public string Yjpzfamc { get; set; }
        public string Jcpzid { get; set; }
        public string Yjyaid { get; set; }
        public string Yj1jjsrbm { get; set; }
        public string Yj1jjsrzw { get; set; }
        public string Yj2jjsrbm { get; set; }
        public string Yj2jjsrzw { get; set; }
        public string Yj3jjsrbm { get; set; }
        public string Yj3jjsrzw { get; set; }
        public string Yj4jjsrbm { get; set; }
        public string Yj4jjsrzw { get; set; }
        public string Czfzrid { get; set; }
        public string Yjxxsm { get; set; }
        public string Yjzd { get; set; }
        public string Yjyjyaid { get; set; }
        public string Ejyjyaid { get; set; }
        public string Sjyjyaid { get; set; }
        public string Sijyjyaid { get; set; }

        public virtual GlyjcJcpz Jcpz { get; set; }
        public virtual ICollection<GlyjcMjlyjyzsz> GlyjcMjlyjyzsz { get; set; }
        public virtual ICollection<GlyjcYjjsxx> GlyjcYjjsxx { get; set; }
    }
}

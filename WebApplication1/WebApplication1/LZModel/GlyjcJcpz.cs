using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class GlyjcJcpz
    {
        public GlyjcJcpz()
        {
            ConJcpzJcd = new HashSet<ConJcpzJcd>();
            GlyjcRwb = new HashSet<GlyjcRwb>();
            GlyjcRwb032615 = new HashSet<GlyjcRwb032615>();
            GlyjcRwbCopy20190125 = new HashSet<GlyjcRwbCopy20190125>();
            GlyjcRwbCopy20200612 = new HashSet<GlyjcRwbCopy20200612>();
            GlyjcSbjcdJcpz = new HashSet<GlyjcSbjcdJcpz>();
            GlyjcYddcjd = new HashSet<GlyjcYddcjd>();
            GlyjcYjszzb = new HashSet<GlyjcYjszzb>();
        }

        public string Id { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public string Shyc { get; set; }
        public DateTime? Tjsj { get; set; }
        public string Jcpzfamc { get; set; }
        public string Zt { get; set; }
        public string Jcx { get; set; }
        public string Jcpzysjid { get; set; }
        public string Ycysid { get; set; }
        public string Jcdxbid { get; set; }
        public string Jcdxid { get; set; }
        public string Jcwzbid { get; set; }
        public string Jcwzid { get; set; }
        public string Jcwzdtxxbid { get; set; }
        public string Lrfs { get; set; }
        public string Sjcjfzrbmid { get; set; }
        public string Sjcjfzrid { get; set; }
        public string Jcsjksyfw { get; set; }
        public string Ssjg { get; set; }
        public string Jcjlbcdd { get; set; }
        public string Jcjlbcsj { get; set; }
        public DateTime? Jcqssj { get; set; }
        public DateTime? Jcjssj { get; set; }
        public string Sfszqxjc { get; set; }
        public string Zq { get; set; }
        public string Zqdw { get; set; }
        public string Ds { get; set; }
        public int? Sc { get; set; }
        public string Yjxq { get; set; }
        public string Bz { get; set; }
        public string Sbids { get; set; }
        public string Rcxcqyid { get; set; }

        public virtual ICollection<ConJcpzJcd> ConJcpzJcd { get; set; }
        public virtual ICollection<GlyjcRwb> GlyjcRwb { get; set; }
        public virtual ICollection<GlyjcRwb032615> GlyjcRwb032615 { get; set; }
        public virtual ICollection<GlyjcRwbCopy20190125> GlyjcRwbCopy20190125 { get; set; }
        public virtual ICollection<GlyjcRwbCopy20200612> GlyjcRwbCopy20200612 { get; set; }
        public virtual ICollection<GlyjcSbjcdJcpz> GlyjcSbjcdJcpz { get; set; }
        public virtual ICollection<GlyjcYddcjd> GlyjcYddcjd { get; set; }
        public virtual ICollection<GlyjcYjszzb> GlyjcYjszzb { get; set; }
    }
}

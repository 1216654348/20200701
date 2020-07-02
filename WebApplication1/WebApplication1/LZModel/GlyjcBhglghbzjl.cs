using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class GlyjcBhglghbzjl
    {
        public GlyjcBhglghbzjl()
        {
            GlyjcXxghzxqkjl = new HashSet<GlyjcXxghzxqkjl>();
        }

        public string Id { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public string Shrid { get; set; }
        public DateTime? Shsj { get; set; }
        public sbyte? Shzt { get; set; }
        public string Shbtgsm { get; set; }
        public sbyte? Sfkdj { get; set; }
        public string Djrid { get; set; }
        public DateTime? Djsj { get; set; }
        public sbyte? Sfydj { get; set; }
        public string Shyc { get; set; }
        public string Tjrid { get; set; }
        public DateTime? Tjsj { get; set; }
        public string Mc { get; set; }
        public string Bzhgbzt { get; set; }
        public string Ghqx { get; set; }
        public string Zzbzdw { get; set; }
        public string Bzdw { get; set; }
        public string Xgwd { get; set; }

        public virtual ICollection<GlyjcXxghzxqkjl> GlyjcXxghzxqkjl { get; set; }
    }
}

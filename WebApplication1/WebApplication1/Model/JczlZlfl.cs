using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class JczlZlfl
    {
        public JczlZlfl()
        {
            InverseFj = new HashSet<JczlZlfl>();
            JczlZljl = new HashSet<JczlZljl>();
        }

        public string Id { get; set; }
        public string Flbm { get; set; }
        public string Xsmc { get; set; }
        public string Bzsm { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public string Fjid { get; set; }

        public virtual JczlZlfl Fj { get; set; }
        public virtual ICollection<JczlZlfl> InverseFj { get; set; }
        public virtual ICollection<JczlZljl> JczlZljl { get; set; }
    }
}

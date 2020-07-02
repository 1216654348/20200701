using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class JczlZljl
    {
        public JczlZljl()
        {
            JczlZljlDzwj = new HashSet<JczlZljlDzwj>();
        }

        public string Id { get; set; }
        public string Jczlflid { get; set; }
        public string Zlbm { get; set; }
        public string Bt { get; set; }
        public string Zlsm { get; set; }
        public string Gjc { get; set; }
        public string Xzqbm { get; set; }
        public string Bgdw { get; set; }
        public sbyte? Sfdzzl { get; set; }
        public sbyte? Sfstzl { get; set; }
        public string Stzlwzbh { get; set; }
        public string Slrxm { get; set; }
        public DateTime? Slsj { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public sbyte? Sfsmtp { get; set; }

        public virtual JczlZlfl Jczlfl { get; set; }
        public virtual ICollection<JczlZljlDzwj> JczlZljlDzwj { get; set; }
    }
}

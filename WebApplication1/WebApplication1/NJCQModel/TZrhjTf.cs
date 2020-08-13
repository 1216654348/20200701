using System;
using System.Collections.Generic;

namespace WebApplication1.NJCQModel
{
    public partial class TZrhjTf
    {
        public TZrhjTf()
        {
            TZrhjTfljxx = new HashSet<TZrhjTfljxx>();
        }

        public string Id { get; set; }
        public string Glycbtid { get; set; }
        public string Ycdsjid { get; set; }
        public string Tfdm { get; set; }
        public string Zwmc { get; set; }
        public string Ywmc { get; set; }
        public string Fsnf { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public string Shrid { get; set; }
        public DateTime? Shsj { get; set; }
        public sbyte? Shzt { get; set; }
        public string Shbtgsm { get; set; }
        public string Djrid { get; set; }
        public DateTime? Djsj { get; set; }
        public string Shyc { get; set; }
        public DateTime? Tjsj { get; set; }
        public DateTime? Rksj { get; set; }

        public virtual ICollection<TZrhjTfljxx> TZrhjTfljxx { get; set; }
    }
}

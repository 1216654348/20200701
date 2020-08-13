using System;
using System.Collections.Generic;

namespace WebApplication1.NJCQModel
{
    public partial class TYjxxYjya
    {
        public TYjxxYjya()
        {
            TYjxxYjxyjpz = new HashSet<TYjxxYjxyjpz>();
        }

        public string Id { get; set; }
        public string Yamc { get; set; }
        public string Wjmc { get; set; }
        public string Wjlj { get; set; }
        public string Ms { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public int? Yjdj { get; set; }

        public virtual ICollection<TYjxxYjxyjpz> TYjxxYjxyjpz { get; set; }
    }
}

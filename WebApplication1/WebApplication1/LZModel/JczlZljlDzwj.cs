using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class JczlZljlDzwj
    {
        public string Id { get; set; }
        public string Zljlid { get; set; }
        public string Wjmc { get; set; }
        public string Wjgs { get; set; }
        public string Scrid { get; set; }
        public DateTime? Scsj { get; set; }
        public string Wjlj { get; set; }

        public virtual JczlZljl Zljl { get; set; }
    }
}

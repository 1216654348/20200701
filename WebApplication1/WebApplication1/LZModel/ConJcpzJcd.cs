using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class ConJcpzJcd
    {
        public string Id { get; set; }
        public string Jcpzfaid { get; set; }
        public string Jcdid { get; set; }
        public string Mc { get; set; }

        public virtual GlyjcJcpz Jcpzfa { get; set; }
    }
}

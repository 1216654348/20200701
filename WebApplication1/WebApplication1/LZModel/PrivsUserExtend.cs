using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class PrivsUserExtend
    {
        public string Id { get; set; }
        public string Userid { get; set; }
        public string Skinpath { get; set; }

        public virtual PrivsUser User { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class PrivsUserClientid
    {
        public string Id { get; set; }
        public string Userid { get; set; }
        public string Clientid { get; set; }

        public virtual PrivsUser User { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class YddRw
    {
        public string Id { get; set; }
        public string Yhid { get; set; }
        public string Cjdxbh { get; set; }
        public string Rwmc { get; set; }
        public string Rwsm { get; set; }
        public string Ycysid { get; set; }
        public string Jclbid { get; set; }
        public DateTime? Jzsj { get; set; }
        public DateTime? Tjsj { get; set; }
        public string Zt { get; set; }

        public virtual YsjYwbysj Jclb { get; set; }
    }
}

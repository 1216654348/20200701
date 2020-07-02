using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class HltXgdYcys
    {
        public string Id { get; set; }
        public string Xgdid { get; set; }
        public string Ycysid { get; set; }
        public string Ycysmc { get; set; }
        public DateTime? Cjsj { get; set; }

        public virtual GlyjcXgdgljl Xgd { get; set; }
        public virtual GlyjcYcysqd Ycys { get; set; }
    }
}

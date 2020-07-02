using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class PrivsFuncprivsCopy
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Aliasname { get; set; }
        public string Description { get; set; }
        public string Accesstype { get; set; }
        public string Accessid { get; set; }
        public string Operation { get; set; }
        public string Pid { get; set; }
        public string Systemcode { get; set; }
        public int? Indexoforder { get; set; }
        public string Args { get; set; }
        public string Groupname { get; set; }

        public virtual PrivsFuncprivs3 P { get; set; }
    }
}

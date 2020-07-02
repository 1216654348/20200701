using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class PrivsUsergrroup
    {
        public PrivsUsergrroup()
        {
            InverseP = new HashSet<PrivsUsergrroup>();
            PrivsUser = new HashSet<PrivsUser>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Aliasname { get; set; }
        public string Description { get; set; }
        public string Pid { get; set; }

        public virtual PrivsUsergrroup P { get; set; }
        public virtual ICollection<PrivsUsergrroup> InverseP { get; set; }
        public virtual ICollection<PrivsUser> PrivsUser { get; set; }
    }
}

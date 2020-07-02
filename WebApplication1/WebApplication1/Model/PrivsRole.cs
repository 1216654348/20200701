using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class PrivsRole
    {
        public PrivsRole()
        {
            PrivsRoleDataprivs = new HashSet<PrivsRoleDataprivs>();
            PrivsRoleFuncprivs = new HashSet<PrivsRoleFuncprivs>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Aliasname { get; set; }
        public string Description { get; set; }
        public string Systemcode { get; set; }

        public virtual ICollection<PrivsRoleDataprivs> PrivsRoleDataprivs { get; set; }
        public virtual ICollection<PrivsRoleFuncprivs> PrivsRoleFuncprivs { get; set; }
    }
}

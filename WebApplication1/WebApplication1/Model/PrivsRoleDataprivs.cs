using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class PrivsRoleDataprivs
    {
        public string Roleid { get; set; }
        public string Privsid { get; set; }

        public virtual PrivsDataprivs Privs { get; set; }
        public virtual PrivsRole Role { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class PrivsRoleFuncprivs
    {
        public string Roleid { get; set; }
        public string Privsid { get; set; }

        public virtual PrivsFuncprivs1 Privs { get; set; }
        public virtual PrivsRole Role { get; set; }
    }
}

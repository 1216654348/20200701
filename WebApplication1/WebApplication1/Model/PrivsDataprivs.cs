using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class PrivsDataprivs
    {
        public PrivsDataprivs()
        {
            PrivsFuncprivsDataprivs = new HashSet<PrivsFuncprivsDataprivs>();
            PrivsRoleDataprivs = new HashSet<PrivsRoleDataprivs>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Aliasname { get; set; }
        public string Datasourcetype { get; set; }
        public string Datasourcetext { get; set; }
        public string Dataoperation { get; set; }
        public string Description { get; set; }
        public string Argstext { get; set; }
        public string Groupname { get; set; }
        public string Columntext { get; set; }
        public string Wheretext { get; set; }
        public string Argsappend { get; set; }

        public virtual ICollection<PrivsFuncprivsDataprivs> PrivsFuncprivsDataprivs { get; set; }
        public virtual ICollection<PrivsRoleDataprivs> PrivsRoleDataprivs { get; set; }
    }
}

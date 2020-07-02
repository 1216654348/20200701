using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class OrgLeader
    {
        public string Id { get; set; }
        public string Departmentid { get; set; }
        public string Userid { get; set; }
        public string Rolename { get; set; }
        public string Responsibility { get; set; }
        public sbyte? Leaderlevel { get; set; }
        public string Description { get; set; }

        public virtual OrgDepartment Department { get; set; }
        public virtual OrgUserinfo User { get; set; }
    }
}

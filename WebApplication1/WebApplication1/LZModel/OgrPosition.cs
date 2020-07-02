using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class OgrPosition
    {
        public OgrPosition()
        {
            OrgUserinfo = new HashSet<OrgUserinfo>();
            OrgUserinfoCopy = new HashSet<OrgUserinfoCopy>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Aliasname { get; set; }
        public string Responsibility { get; set; }
        public string Descreiption { get; set; }
        public string Requirement { get; set; }
        public string Departmentid { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<OrgUserinfo> OrgUserinfo { get; set; }
        public virtual ICollection<OrgUserinfoCopy> OrgUserinfoCopy { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class OrgDepartment
    {
        public OrgDepartment()
        {
            InverseParent = new HashSet<OrgDepartment>();
            OrgDepartmentCopy = new HashSet<OrgDepartmentCopy>();
            OrgLeader = new HashSet<OrgLeader>();
            OrgUserinfo = new HashSet<OrgUserinfo>();
            OrgUserinfoCopy = new HashSet<OrgUserinfoCopy>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Aliasname { get; set; }
        public string Description { get; set; }
        public string Parentid { get; set; }
        public string Duty { get; set; }
        public DateTime? Createdate { get; set; }
        public string Address { get; set; }
        public string Url { get; set; }
        public string Contacts { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Departmentcode { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public string Remark { get; set; }
        public DateTime? Cxrq { get; set; }
        public string Xzqbm { get; set; }
        public sbyte? Isdepartment { get; set; }

        public virtual OrgDepartment Parent { get; set; }
        public virtual ICollection<OrgDepartment> InverseParent { get; set; }
        public virtual ICollection<OrgDepartmentCopy> OrgDepartmentCopy { get; set; }
        public virtual ICollection<OrgLeader> OrgLeader { get; set; }
        public virtual ICollection<OrgUserinfo> OrgUserinfo { get; set; }
        public virtual ICollection<OrgUserinfoCopy> OrgUserinfoCopy { get; set; }
    }
}

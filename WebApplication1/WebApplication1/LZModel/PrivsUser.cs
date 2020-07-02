using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class PrivsUser
    {
        public PrivsUser()
        {
            InverseLeader = new HashSet<PrivsUser>();
            PrivsUserClientid = new HashSet<PrivsUserClientid>();
            PrivsUserExtend = new HashSet<PrivsUserExtend>();
        }

        public string Id { get; set; }
        public string Departmentid { get; set; }
        public string Name { get; set; }
        public string Realname { get; set; }
        public string Idcard { get; set; }
        public string Sex { get; set; }
        public string Usercode { get; set; }
        public string Photopath { get; set; }
        public string Mobile { get; set; }
        public string Qq { get; set; }
        public string Email { get; set; }
        public DateTime? Careerentry { get; set; }
        public DateTime? Leavedate { get; set; }
        public string Leaderid { get; set; }
        public string Positionid { get; set; }
        public string Password { get; set; }
        public string Namepassword { get; set; }
        public string Token { get; set; }
        public string Issystem { get; set; }
        public string Islocked { get; set; }
        public string Remark { get; set; }
        public string Bgwz { get; set; }
        public string Bgdh { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public string Gn { get; set; }
        public string Clientid { get; set; }
        public string Sfyxgmm { get; set; }

        public virtual PrivsDepartment Department { get; set; }
        public virtual PrivsUser Leader { get; set; }
        public virtual ICollection<PrivsUser> InverseLeader { get; set; }
        public virtual ICollection<PrivsUserClientid> PrivsUserClientid { get; set; }
        public virtual ICollection<PrivsUserExtend> PrivsUserExtend { get; set; }
    }
}

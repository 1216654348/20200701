using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class OrgUserinfo
    {
        public OrgUserinfo()
        {
            GlyjcYjczgz = new HashSet<GlyjcYjczgz>();
            InverseLeader = new HashSet<OrgUserinfo>();
            OrgLeader = new HashSet<OrgLeader>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Realname { get; set; }
        public string Description { get; set; }
        public string Departmentid { get; set; }
        public string Leaderid { get; set; }
        public DateTime? Careerentry { get; set; }
        public DateTime? Leavedate { get; set; }
        public string Photo { get; set; }
        public string Positionid { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Qq { get; set; }
        public sbyte? Sex { get; set; }
        public string Idcard { get; set; }
        public sbyte? Ishangposition { get; set; }
        public string Remark { get; set; }
        public string Systemuserid { get; set; }
        public string Loginname { get; set; }
        public string Password { get; set; }
        public string Maploginname { get; set; }
        public string Mappassword { get; set; }
        public bool Sfsystem { get; set; }
        public bool Sfauto { get; set; }
        public bool Sfjr { get; set; }
        public string Sfgly { get; set; }

        public virtual OrgDepartment Department { get; set; }
        public virtual OrgUserinfo Leader { get; set; }
        public virtual OgrPosition Position { get; set; }
        public virtual ICollection<GlyjcYjczgz> GlyjcYjczgz { get; set; }
        public virtual ICollection<OrgUserinfo> InverseLeader { get; set; }
        public virtual ICollection<OrgLeader> OrgLeader { get; set; }
    }
}

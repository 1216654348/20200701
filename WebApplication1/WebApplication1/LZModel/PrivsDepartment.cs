using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class PrivsDepartment
    {
        public PrivsDepartment()
        {
            PrivsUser = new HashSet<PrivsUser>();
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
        public decimal? X { get; set; }
        public decimal? Y { get; set; }
        public DateTime? Cxrq { get; set; }
        public string Xzqbm { get; set; }
        public string Isdepartment { get; set; }
        public string Remark { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }

        public virtual ICollection<PrivsUser> PrivsUser { get; set; }
    }
}

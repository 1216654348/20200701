using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class PrivsUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Aliasname { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public sbyte? Issystem { get; set; }
        public string Usergroupid { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Photopath { get; set; }
        public string Remark { get; set; }

        public virtual PrivsUsergrroup Usergroup { get; set; }
    }
}

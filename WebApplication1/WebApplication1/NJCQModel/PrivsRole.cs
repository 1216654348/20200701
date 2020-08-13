using System;
using System.Collections.Generic;

namespace WebApplication1.NJCQModel
{
    public partial class PrivsRole
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RoleType { get; set; }
        public int? Sort { get; set; }
        public DateTime? Rksj { get; set; }
        public string Province { get; set; }
        public int? Sfksc { get; set; }
    }
}

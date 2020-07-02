using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class YsjDomainEnumitem20191227
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Enumid { get; set; }
        public string Name { get; set; }
        public string Aliasname { get; set; }
        public string Description { get; set; }
        public sbyte? Isabstract { get; set; }
        public string Kz1 { get; set; }
        public string Kz2 { get; set; }
        public string Kz3 { get; set; }
        public string Kz4 { get; set; }
        public string Kz5 { get; set; }

        public virtual YsjDomainEnum Enum { get; set; }
    }
}

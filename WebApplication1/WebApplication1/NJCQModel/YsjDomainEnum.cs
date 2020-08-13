using System;
using System.Collections.Generic;

namespace WebApplication1.NJCQModel
{
    public partial class YsjDomainEnum
    {
        public YsjDomainEnum()
        {
            YsjDomainEnumitem = new HashSet<YsjDomainEnumitem>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Aliasname { get; set; }
        public string Description { get; set; }
        public string Namespace { get; set; }
        public string Mjxbt { get; set; }

        public virtual ICollection<YsjDomainEnumitem> YsjDomainEnumitem { get; set; }
    }
}

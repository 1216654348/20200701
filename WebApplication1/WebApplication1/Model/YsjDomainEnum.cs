using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class YsjDomainEnum
    {
        public YsjDomainEnum()
        {
            YsjDomainEnumitem = new HashSet<YsjDomainEnumitem>();
            YsjDomainEnumitem20191227 = new HashSet<YsjDomainEnumitem20191227>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Aliasname { get; set; }
        public string Description { get; set; }
        public string Namespace { get; set; }
        public string Mjxbt { get; set; }

        public virtual ICollection<YsjDomainEnumitem> YsjDomainEnumitem { get; set; }
        public virtual ICollection<YsjDomainEnumitem20191227> YsjDomainEnumitem20191227 { get; set; }
    }
}

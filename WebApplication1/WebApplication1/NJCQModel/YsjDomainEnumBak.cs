using System;
using System.Collections.Generic;

namespace WebApplication1.NJCQModel
{
    public partial class YsjDomainEnumBak
    {
        public YsjDomainEnumBak()
        {
            YsjDomainEnumitemBak = new HashSet<YsjDomainEnumitemBak>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Aliasname { get; set; }
        public string Description { get; set; }
        public string Namespace { get; set; }
        public string Mjxbt { get; set; }

        public virtual ICollection<YsjDomainEnumitemBak> YsjDomainEnumitemBak { get; set; }
    }
}

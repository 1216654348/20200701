using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class YcbtDomainEnum
    {
        public YcbtDomainEnum()
        {
            YcbtDomainEnumitem = new HashSet<YcbtDomainEnumitem>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Aliasname { get; set; }
        public string Description { get; set; }
        public string Namespace { get; set; }
        public string Mjxbt { get; set; }

        public virtual ICollection<YcbtDomainEnumitem> YcbtDomainEnumitem { get; set; }
    }
}

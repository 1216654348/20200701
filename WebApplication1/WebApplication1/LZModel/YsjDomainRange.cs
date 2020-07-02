using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class YsjDomainRange
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Aliasname { get; set; }
        public string Description { get; set; }
        public string Namespace { get; set; }
        public sbyte? Iscontainmin { get; set; }
        public sbyte? Iscontainmax { get; set; }
        public double? MinValue { get; set; }
        public sbyte? MaxValue { get; set; }
        public sbyte? Isbetweenmintomax { get; set; }
    }
}

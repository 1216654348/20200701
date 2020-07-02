using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class TabCategory
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
        public sbyte? Clickable { get; set; }
        public string Code { get; set; }
        public sbyte? TaskType { get; set; }
        public sbyte? ElmentType { get; set; }
        public string Jcwzbmc { get; set; }
        public string Jcdxbmc { get; set; }
    }
}

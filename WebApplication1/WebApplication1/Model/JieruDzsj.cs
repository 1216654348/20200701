using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class JieruDzsj
    {
        public string Id { get; set; }
        public DateTime? Time { get; set; }
        public string Title { get; set; }
        public string Power { get; set; }
        public string Depth { get; set; }
        public string Lon { get; set; }
        public string Lat { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public string Shrid { get; set; }
        public DateTime? Shsj { get; set; }
        public sbyte? Shzt { get; set; }
        public sbyte? Sfkdj { get; set; }
        public string Djrid { get; set; }
        public DateTime? Djsj { get; set; }
        public sbyte? Sfydj { get; set; }
        public string Shyc { get; set; }
        public DateTime? Tjsj { get; set; }
    }
}

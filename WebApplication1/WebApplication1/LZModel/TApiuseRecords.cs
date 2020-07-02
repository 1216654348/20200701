using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class TApiuseRecords
    {
        public string Id { get; set; }
        public string Ip { get; set; }
        public string Route { get; set; }
        public string Method { get; set; }
        public string Protocol { get; set; }
        public string Userid { get; set; }
        public string Username { get; set; }
        public sbyte? Ishttps { get; set; }
        public DateTime? Cjsj { get; set; }
        public DateTime? Rksj { get; set; }
    }
}

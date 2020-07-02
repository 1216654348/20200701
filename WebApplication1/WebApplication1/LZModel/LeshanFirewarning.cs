using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class LeshanFirewarning
    {
        public string Id { get; set; }
        public DateTime? Firetime { get; set; }
        public string Fireaddr { get; set; }
        public string Basestaionnumber { get; set; }
        public string Partitioncode { get; set; }
        public string Partitionname { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public string SensorNo { get; set; }
        public string Isrescindsign { get; set; }
        public string Prekind { get; set; }
        public string Signimagepath { get; set; }
        public string Signmean { get; set; }
        public string Signtitle { get; set; }
        public string Warnsign { get; set; }
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

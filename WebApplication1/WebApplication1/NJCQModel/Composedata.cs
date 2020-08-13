using System;
using System.Collections.Generic;

namespace WebApplication1.NJCQModel
{
    public partial class Composedata
    {
        public int Id { get; set; }
        public DateTime? CollectTime { get; set; }
        public int? Flag { get; set; }
        public string ParaId { get; set; }
        public string ParaTypeCode { get; set; }
        public float? ParaValue { get; set; }
        public string RtuCode { get; set; }
        public DateTime? SystemTime { get; set; }
    }
}

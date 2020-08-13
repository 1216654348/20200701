using System;
using System.Collections.Generic;

namespace WebApplication1.NJCQModel
{
    public partial class TDockRecord
    {
        public int Id { get; set; }
        public string FunId { get; set; }
        public string TableName { get; set; }
        public string Sjid { get; set; }
        public int? Djzt { get; set; }
        public DateTime? Rksj { get; set; }
        public int? Shzt { get; set; }
    }
}

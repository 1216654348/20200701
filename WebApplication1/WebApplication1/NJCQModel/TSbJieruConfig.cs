using System;
using System.Collections.Generic;

namespace WebApplication1.NJCQModel
{
    public partial class TSbJieruConfig
    {
        public string Id { get; set; }
        public string Grabtype { get; set; }
        public string Remark { get; set; }
        public int? Grabcycle { get; set; }
        public string Grabcycleunit { get; set; }
        public string Isactive { get; set; }
        public DateTime? Lastgrabtime { get; set; }
        public string Fkey { get; set; }
        public string Fkeytype { get; set; }
        public int? Graberror { get; set; }
        public string Grabmainurl { get; set; }
        public string Managerid { get; set; }
        public string Alertjudgeurl { get; set; }
        public sbyte Isstorage { get; set; }
        public string Jcdxmc { get; set; }
        public string Jcwzmc { get; set; }
    }
}

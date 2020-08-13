using System;
using System.Collections.Generic;

namespace WebApplication1.NJCQModel
{
    public partial class TAqiReportDay
    {
        public string Id { get; set; }
        public DateTime? ReportDate { get; set; }
        public string So2AvgDensity { get; set; }
        public string No2AvgDensity { get; set; }
        public string CoAvgDensity { get; set; }
        public string O3AvgDensity { get; set; }
        public string Aqi { get; set; }
        public string MajorPollutant { get; set; }
        public string AqiClass { get; set; }
        public string AqiLbLb { get; set; }
        public string AqiLbColor { get; set; }
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
        public string Jcdid { get; set; }
    }
}

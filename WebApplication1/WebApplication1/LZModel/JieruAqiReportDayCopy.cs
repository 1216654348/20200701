using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class JieruAqiReportDayCopy
    {
        public string Id { get; set; }
        public DateTime? ReportDate { get; set; }
        public string So224hDensity { get; set; }
        public string So224hSubindex { get; set; }
        public string No224hDensity { get; set; }
        public string No224hSubindex { get; set; }
        public string Klw24hDensity { get; set; }
        public string Klw24hSubindex { get; set; }
        public string Co24hDensity { get; set; }
        public string Co24hSubindex { get; set; }
        public string O31hDensity { get; set; }
        public string O31hSubindex { get; set; }
        public string O38hpjDensity { get; set; }
        public string O38hpjSubindex { get; set; }
        public string Klw2d524hDensity { get; set; }
        public string Klw2d524hSubindex { get; set; }
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
    }
}

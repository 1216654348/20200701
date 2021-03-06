﻿using System;
using System.Collections.Generic;

namespace WebApplication1.NJCQModel
{
    public partial class TAqiReportHour
    {
        public string Id { get; set; }
        public DateTime? ReportDate { get; set; }
        public string So2AvgDensity { get; set; }
        public string No2AvgDensity { get; set; }
        public string CoAvgDensity { get; set; }
        public string O3AvgDensity { get; set; }
        public string Pm10AvgDensity { get; set; }
        public string Pm25AvgDensity { get; set; }
        public string AqiClass { get; set; }
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
        public string AqiDay { get; set; }
        public string Jcdid { get; set; }
    }
}

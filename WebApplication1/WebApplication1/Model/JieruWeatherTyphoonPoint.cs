using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class JieruWeatherTyphoonPoint
    {
        public string Id { get; set; }
        public string Pid { get; set; }
        public string Year { get; set; }
        public DateTime? Time { get; set; }
        public string Type { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public int? Windpower { get; set; }
        public int? Windspeed { get; set; }
        public int? Airpressure { get; set; }
        public int? Movespeed { get; set; }
        public string Movedirection { get; set; }
        public double? Windradius7 { get; set; }
        public double? Windradius10 { get; set; }
        public double? Windradius12 { get; set; }
        public DateTime? Fbtime { get; set; }
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

        public virtual JieruWeatherTyphoonPath P { get; set; }
    }
}

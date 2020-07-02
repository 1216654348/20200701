using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class JieruWeatherLive
    {
        public string Id { get; set; }
        public string StationNum { get; set; }
        public string StationName { get; set; }
        public DateTime? Time { get; set; }
        public string Temp { get; set; }
        public string TempMin { get; set; }
        public string TempMax { get; set; }
        public string Rain { get; set; }
        public string Rain3 { get; set; }
        public string Rain6 { get; set; }
        public string Rain12 { get; set; }
        public string Rain24 { get; set; }
        public string WindDesc { get; set; }
        public string WindDirection { get; set; }
        public string WindSpeed { get; set; }
        public string WindJdspeed { get; set; }
        public string WindJdspeedMax24 { get; set; }
        public string Humidity { get; set; }
        public string Pressure { get; set; }
        public string Visibility { get; set; }
        public string VisibilityMin24h { get; set; }
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

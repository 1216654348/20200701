using System;
using System.Collections.Generic;

namespace WebApplication1.NJCQModel
{
    public partial class TWeatherLive
    {
        public string Id { get; set; }
        public DateTime? Time { get; set; }
        public string Temp { get; set; }
        public string WindDesc { get; set; }
        public string WindDirection { get; set; }
        public string WindPower { get; set; }
        public string Humidity { get; set; }
        public string Precipitation { get; set; }
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

using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class JieruWeatherTyphoon
    {
        public JieruWeatherTyphoon()
        {
            JieruWeatherTyphoonPath = new HashSet<JieruWeatherTyphoonPath>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Enname { get; set; }
        public int? Code { get; set; }
        public string Happenyear { get; set; }
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

        public virtual ICollection<JieruWeatherTyphoonPath> JieruWeatherTyphoonPath { get; set; }
    }
}

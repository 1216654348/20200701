using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class WaterInfo
    {
        public string Id { get; set; }
        public string Address { get; set; }
        public DateTime? ObservationTime { get; set; }
        public double? Level { get; set; }
        public double? Velocity { get; set; }
        public double? Angle { get; set; }
        public string Direction { get; set; }
        public int? Signal { get; set; }
        public double? Coltage { get; set; }
    }
}

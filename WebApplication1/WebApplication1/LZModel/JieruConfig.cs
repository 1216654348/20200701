using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class JieruConfig
    {
        public string Id { get; set; }
        public string GrabType { get; set; }
        public string Remark { get; set; }
        public string RemarkName { get; set; }
        public int? GrabCycle { get; set; }
        public string GrabCycleUnit { get; set; }
        public string IsActive { get; set; }
        public DateTime? LastGrabTime { get; set; }
        public string Fkey { get; set; }
        public string Fkeytype { get; set; }
        public int? GrabError { get; set; }
        public string GrabMainUrl { get; set; }
        public string ManagerId { get; set; }
        public string AlertJudgeUrl { get; set; }
        public sbyte IsStorage { get; set; }
    }
}

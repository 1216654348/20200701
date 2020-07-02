using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class JieruConfigCopy删掉无用配置之前
    {
        public string Id { get; set; }
        public string GrabType { get; set; }
        public string Remark { get; set; }
        public int GrabTime { get; set; }
        public int? GrabCycle { get; set; }
        public string AlertJudgeUrl { get; set; }
        public string GrabMainUrl { get; set; }
        public sbyte IsStorage { get; set; }
    }
}

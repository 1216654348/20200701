﻿using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class JieruConfigCopy
    {
        public string GrabType { get; set; }
        public int GrabTime { get; set; }
        public int? GrabCycle { get; set; }
        public string AlertJudgeUrl { get; set; }
        public string GrabMainUrl { get; set; }
        public string Remark { get; set; }
        public string Id { get; set; }
        public sbyte IsStorage { get; set; }
    }
}
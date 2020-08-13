using System;
using System.Collections.Generic;

namespace WebApplication1.NJCQModel
{
    public partial class TXjxmWzt
    {
        public string Id { get; set; }
        public string Xjxmid { get; set; }
        public bool? Sfydtfw { get; set; }
        public string Tzmc { get; set; }
        public string Tzlj { get; set; }
        public string Tzgs { get; set; }
        public string Blc { get; set; }
        public string Chrid { get; set; }
        public string Chzrdw { get; set; }
        public DateTime? Ctsj { get; set; }
        public string Shrid { get; set; }
        public DateTime? Shsj { get; set; }
        public string Sjmj { get; set; }
        public string Fbfw { get; set; }
        public int? Xzcs { get; set; }
        public string Djrid { get; set; }
        public DateTime? Djsj { get; set; }
        public string Sfydj { get; set; }
        public string Shyc { get; set; }
        public string Shzt { get; set; }
        public string Shbtgsm { get; set; }
        public string Cjrid { get; set; }
        public DateTime? Cjsj { get; set; }
        public string Xmwz { get; set; }
        public string Glycbtid { get; set; }
        public string Rwid { get; set; }

        public virtual TXjxmXjxmjl Xjxm { get; set; }
    }
}

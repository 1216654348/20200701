﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class YsjYwbysj
    {
        public YsjYwbysj()
        {
            InverseFj = new HashSet<YsjYwbysj>();
            YddRw = new HashSet<YddRw>();
        }

        public string Id { get; set; }
        public string Bmc { get; set; }
        public string Bbm { get; set; }
        public string Fjid { get; set; }
        public int? Px { get; set; }
        public int? Sfyfj { get; set; }
        public string Ftp { get; set; }
        public string Ccxdlj { get; set; }
        public string Wjccwldz { get; set; }
        public int? Yjyzlx { get; set; }
        public int? Sfwjcx { get; set; }
        public string Ywzj { get; set; }
        public string Ysjbbm { get; set; }
        public string Fwffqz { get; set; }
        public int? Sfrwxjc { get; set; }
        public string Zstmc { get; set; }
        public string Kz1 { get; set; }
        public string Kz2 { get; set; }
        public string Kz3 { get; set; }
        public string Kz4 { get; set; }
        public string Kz5 { get; set; }
        public string Yjlx { get; set; }
        public int? Sfbbgd { get; set; }
        public int? Bbgdzq { get; set; }

        public virtual YsjYwbysj Fj { get; set; }
        public virtual ICollection<YsjYwbysj> InverseFj { get; set; }
        public virtual ICollection<YddRw> YddRw { get; set; }
    }
}
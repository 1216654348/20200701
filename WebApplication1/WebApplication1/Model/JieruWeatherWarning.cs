﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class JieruWeatherWarning
    {
        public string Id { get; set; }
        public DateTime? Pretimesign { get; set; }
        public string Title { get; set; }
        public string Bz { get; set; }
        public string Cont { get; set; }
        public string Contensign { get; set; }
        public string Dept { get; set; }
        public string ForecasterSign { get; set; }
        public string Fy { get; set; }
        public bool? Isrescindsign { get; set; }
        public string Prekind { get; set; }
        public string Signimagepath { get; set; }
        public string Signmean { get; set; }
        public string Signtitle { get; set; }
        public string TitleJx { get; set; }
        public string Warnsign { get; set; }
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
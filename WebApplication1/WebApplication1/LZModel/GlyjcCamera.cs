using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class GlyjcCamera
    {
        public string Id { get; set; }
        public string Cameraid { get; set; }
        public string Name { get; set; }
        public string Dll { get; set; }
        public string Ip { get; set; }
        public string Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Channel { get; set; }
        public string Param { get; set; }
        public double? Lat { get; set; }
        public double? Lon { get; set; }
        public string Locadesc { get; set; }
        public string Remark { get; set; }
        public string Sourceid { get; set; }
        public string Videourl { get; set; }
        public int? Cancontrol { get; set; }
        public string Statedesc { get; set; }

        public virtual GlyjcSbqd Source { get; set; }
    }
}

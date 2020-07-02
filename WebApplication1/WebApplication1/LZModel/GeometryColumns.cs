using System;
using System.Collections.Generic;

namespace WebApplication1.LZModel
{
    public partial class GeometryColumns
    {
        public string FTableCatalog { get; set; }
        public string FTableSchema { get; set; }
        public string FTableName { get; set; }
        public string FGeometryColumn { get; set; }
        public int? CoordDimension { get; set; }
        public int? Srid { get; set; }
        public string Type { get; set; }
    }
}

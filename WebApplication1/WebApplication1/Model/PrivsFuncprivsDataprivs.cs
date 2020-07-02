using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class PrivsFuncprivsDataprivs
    {
        public string Funcprivsid { get; set; }
        public string Dataprivsid { get; set; }

        public virtual PrivsDataprivs Dataprivs { get; set; }
        public virtual PrivsFuncprivs3 Funcprivs { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TagFin.Domain
{
    public class MainAccCategories
    {
        public string? name { get; set; }
        public string? code { get; set; }
    }

    public class SubAccCategories
    {
        public int? id { get; set; }
        public string? code { get; set; }
        public string? mainAccCode { get; set; }
        public string? mainAccCategory { get; set; }
        public string? name { get; set; }
        public int? NextNo { get; set; }
        public int userId { get; set; }
    }

}





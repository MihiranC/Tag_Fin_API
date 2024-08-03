using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TagFin.Domain
{
    public class Product
    {
        public int? id { get; set; }
        public string? code { get; set; }
        public string? name { get; set; }
        public int? userId { get; set; }
    }

    public class ProductWiseChargers
    {
        public int? id { get; set; }
        public string? chargeCode { get; set; }
        public string? productCode { get; set; }
        public bool? isFixed { get; set; }
        public string? amount { get; set; }
        public string? percentage { get; set; }
        public bool? isCapitalized { get; set; }
        public bool? isActive { get; set; }
        public string? chargeName { get; set; }
        public string? productName { get; set; }
        public int? userId { get; set; }

    }

    public class CalMethdFrequency
    {
        public int? id { get; set; }
        public string? code { get; set; }
        public string? name { get; set; }
        public bool? isActive { get; set; }
        public int? userId { get; set; }

    }

    public class ProductWiseCalMethods
    {
        public int? id { get; set; }
        public string? productcode { get; set; }
        public string? code { get; set; }
        public string? name { get; set; }
        public bool? isActive { get; set; }
        public int? userId { get; set; }

    }
}





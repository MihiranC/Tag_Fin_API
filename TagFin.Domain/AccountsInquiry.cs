using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TagFin.Domain
{
    public class SearchAccountsInquiry
    {
        public int? userId { get; set; }
        public string? mainAccCode { get; set; }
        public string? subAccCode { get; set; }
        public string? customerCode { get; set; }
        public string? accountNo { get; set; }
        public string? fromAmount { get; set; }
        public string? toAmount { get; set; }
        public string? fromDate { get; set; }
        public string? toDate { get; set; }
        public string? subAccCategory { get; set; }
        public string? mainAccCategory { get; set; }
        public string? customerName { get; set; }
        public string? accountName { get; set; }
        public string? entryNo { get; set; }
        public string? entryDate { get; set; }
        public string? amount { get; set; }
        public string? drCr { get; set; }
    }
}





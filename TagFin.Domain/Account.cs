using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TagFin.Domain
{
    public class Accounts
    {
        public int? id { get; set; }
        public string? code { get; set; }
        public string? subAccCode { get; set; }
        public string? name { get; set; }
        public int userId { get; set; }
        public string? accName { get; set; }
        public string? mainAccCategory { get; set; }
        public string? subAccCategory { get; set; }
        public string? mainAccCode { get; set; }
    }
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

    public class EntryDetails
    {
        public int? id { get; set; }
        public int? headerId { get; set; }
        public int? seqNo { get; set; }
        public string branchCode { get; set; }
        public string accCode { get; set; }
        public string amount { get; set; }
        public string drCr { get; set; }
    }

    public class EntryHeader
    {
        public int? id { get; set; }
        public string? entryNo { get; set; }
        public string entryDate { get; set; }
        public bool isReversal { get; set; }
        public string amount { get; set; }
        public string? reversalEntryNo { get; set; }
        public string narration { get; set; }
        public string? payMethod { get; set; }
        public int userId { get; set; }
        public string entryType { get; set; }
        public string customerCode { get; set; }
        public List<EntryDetails> entryDetails { get; set; }
    }
}





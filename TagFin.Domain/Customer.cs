using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagFin.Domain
{
    public class Customer
    {
        public int? id { get; set; }
        public string? code { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string nIC { get; set; }
        public string telNo { get; set; }
        public string email { get; set; }
        public string nICAddressLine01 { get; set; }
        public string? nICAddressLine02 { get; set; }
        public string? nICAddressLine03 { get; set; }
        public string? nICAddressLine04 { get; set; }
        public string permentAddressLine01 { get; set; }
        public string? permentAddressLine02 { get; set; }
        public string? permentAddressLine03 { get; set; }
        public string? permentAddressLine04 { get; set; }
        public string mailingAddressLine01 { get; set; }
        public string? mailingAddressLine02 { get; set; }
        public string? mailingAddressLine03 { get; set; }
        public string? mailingAddressLine04 { get; set; }
        public int userId { get; set; }
    }
}

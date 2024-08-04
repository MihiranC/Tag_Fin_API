using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TagFin.Domain
{
    public class CalDetails
    {
        public int? id { get; set; }
        public string? code { get; set; }
        public string? productCode { get; set; }
        public string? calMethod { get; set; }
        public string? calFrequency { get; set; }
        public string? loanAmount { get; set; }
        public string? period { get; set; }
        public string? rate { get; set; }
        public string? totalInterest { get; set; }
        public string? totalChargeCapital { get; set; }
        public string? totalInterestCharge { get; set; }
        public string? newRate { get; set; }
        public string? totalReceivable { get; set; }
        public int? userId { get; set; }

        public List<CalWiseChargers> calWiseChargers { get; set; }
        public List<CapitalizedBreakup> capitalizedBreakup { get; set; }
        public List<CalSchedule> calSchedule { get; set; }

    }


    public class CalWiseChargers
    {
        public int? id { get; set; }
        public int? calId { get; set; }
        public string? chargeCode { get; set; }
        public string? amount { get; set; }
        public bool? isCapitalized { get; set; }
        public int? userId { get; set; }

    }

    public class CapitalizedBreakup
    {
        public int? id { get; set; }
        public int? calId { get; set; }
        public string? ChargeCode { get; set; }
        public string? RentalNo { get; set; }
        public string? NetRental { get; set; }
        public string? Capital { get; set; }
        public string? CapitalBalance { get; set; }
        public string? Interest { get; set; }
        public string? InterestBalance { get; set; }
        public int userId { get; set; }

    }

    public class CalSchedule
    {
        public int? id { get; set; }
        public int? calId { get; set; }
        public string? rentalNo { get; set; }
        public string? netRental { get; set; }
        public string? capital { get; set; }
        public string? capitalBalance { get; set; }
        public string? interest { get; set; }
        public string? interestBalance { get; set; }
        public string? chargeCapital { get; set; }
        public string? chargeCapitalBalance { get; set; }
        public string? chargeInterest { get; set; }
        public string? chargeCapitalInterest { get; set; }
        public int userId { get; set; }

    }

}





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagFin.Domain
{
    public class Schedule
    {
        public string rentalNumber { get; set; }
        public string netRental { get; set; }
        public string capital { get; set; }
        public string capitalBalance { get; set; }
        public string interestPortion { get; set; }
        public string interestBalance { get; set; }
        public string chargePortionPrincipal { get; set; }
        public string chargePortionInterest { get; set; }
        public string interestBalanceOnCharges { get; set; }
        public string chargePortionPrincipalBalance { get; set; }
        public string effectiveInterestRate { get; set; }
    }

    public class ScheduleInputs
    {
        public string loanAmount { get; set; }
        public string numberOfMonths { get; set; }
        public string annualInterestRate { get; set; }
        public List<CapitalizedCharges>? capitalizedCharges { get; set; }
        public bool isACapitalizedCharge { get; set; }
        public string calMethodCode { get; set; }
    }

    public class CapitalizedCharges
    {
        public string code { get; set; }
        public string amount { get; set; }
    }
}

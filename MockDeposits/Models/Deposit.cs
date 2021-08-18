using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockDeposits.Models
{
    public class Deposit
    {
        public double Principal { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double InterestRate { get; set; }
        public int TermInYears { get; set; }
        public double MaturityAmount { get; set; }
    }
}

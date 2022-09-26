using System;
using System.Collections.Generic;

#nullable disable

namespace Challenge.Models
{
    public partial class Currencyindicator
    {
        public int Id { get; set; }
        public int Sourcecurrencyid { get; set; }
        public int Destinationcurrencyid { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Requestdate { get; set; }
        public double Ask { get; set; }
        public double Bid { get; set; }

        public virtual Currency Destinationcurrency { get; set; }
        public virtual Currency Sourcecurrency { get; set; }
    }
}

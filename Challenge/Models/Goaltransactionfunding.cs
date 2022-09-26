using System;
using System.Collections.Generic;

#nullable disable

namespace Challenge.Models
{
    public partial class Goaltransactionfunding
    {
        public double Percentage { get; set; }
        public double? Amount { get; set; }
        public double? Quotas { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public int Fundingid { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int? Transactionid { get; set; }
        public string State { get; set; }
        public string Type { get; set; }
        public int Goalid { get; set; }
        public int Ownerid { get; set; }
        public double Cost { get; set; }

        public virtual Funding Funding { get; set; }
        public virtual Goal Goal { get; set; }
        public virtual User Owner { get; set; }
        public virtual Goaltransaction Transaction { get; set; }
    }
}

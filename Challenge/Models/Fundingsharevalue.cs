using System;
using System.Collections.Generic;

#nullable disable

namespace Challenge.Models
{
    public partial class Fundingsharevalue
    {
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public int Fundingid { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public virtual Funding Funding { get; set; }
    }
}

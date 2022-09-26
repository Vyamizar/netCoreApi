using System;
using System.Collections.Generic;

#nullable disable

namespace Challenge.Models
{
    public partial class Risklevel
    {
        public Risklevel()
        {
            Goals = new HashSet<Goal>();
            Portfolios = new HashSet<Portfolio>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public virtual ICollection<Goal> Goals { get; set; }
        public virtual ICollection<Portfolio> Portfolios { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace Challenge.Models
{
    public partial class Portfolio
    {
        public Portfolio()
        {
            Goals = new HashSet<Goal>();
            Portfoliocompositions = new HashSet<Portfoliocomposition>();
            Portfoliofundings = new HashSet<Portfoliofunding>();
        }

        public double Maxrangeyear { get; set; }
        public double Minrangeyear { get; set; }
        public string Uuid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public int Financialentityid { get; set; }
        public int Risklevelid { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public bool Isdefault { get; set; }
        public string Profitability { get; set; }
        public int? Investmentstrategyid { get; set; }
        public string Version { get; set; }
        public string Extraprofitabilitycurrencycode { get; set; }
        public double Estimatedprofitability { get; set; }
        public double Bpcomission { get; set; }

        public virtual Financialentity Financialentity { get; set; }
        public virtual Investmentstrategy Investmentstrategy { get; set; }
        public virtual Risklevel Risklevel { get; set; }
        public virtual ICollection<Goal> Goals { get; set; }
        public virtual ICollection<Portfoliocomposition> Portfoliocompositions { get; set; }
        public virtual ICollection<Portfoliofunding> Portfoliofundings { get; set; }
    }
}

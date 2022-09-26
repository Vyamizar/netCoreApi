using System;
using System.Collections.Generic;

#nullable disable

namespace Challenge.Models
{
    public partial class Investmentstrategytype
    {
        public Investmentstrategytype()
        {
            Investmentstrategies = new HashSet<Investmentstrategy>();
        }

        public int Id { get; set; }
        public string Iconurl { get; set; }
        public string Title { get; set; }
        public string Shorttitle { get; set; }
        public string Description { get; set; }
        public string Recommendedfor { get; set; }
        public bool Isvisible { get; set; }
        public bool Isdefault { get; set; }
        public int Displayorder { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int? Financialentityid { get; set; }

        public virtual Financialentity Financialentity { get; set; }
        public virtual ICollection<Investmentstrategy> Investmentstrategies { get; set; }
    }
}

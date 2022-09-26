using System;
using System.Collections.Generic;

#nullable disable

namespace Challenge.Models
{
    public partial class Goaltransaction
    {
        public Goaltransaction()
        {
            Goaltransactionfundings = new HashSet<Goaltransactionfunding>();
        }

        public string Type { get; set; }
        public double? Amount { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public int? Goalid { get; set; }
        public int Ownerid { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public bool Isprocessed { get; set; }
        public bool All { get; set; }
        public string State { get; set; }
        public int? Financialentityid { get; set; }
        public int Currencyid { get; set; }
        public double Cost { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual Financialentity Financialentity { get; set; }
        public virtual Goal Goal { get; set; }
        public virtual User Owner { get; set; }
        public virtual ICollection<Goaltransactionfunding> Goaltransactionfundings { get; set; }
    }
}

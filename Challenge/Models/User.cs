using System;
using System.Collections.Generic;

#nullable disable

namespace Challenge.Models
{
    public partial class User
    {
        public User()
        {
            Goals = new HashSet<Goal>();
            Goaltransactionfundings = new HashSet<Goaltransactionfunding>();
            Goaltransactions = new HashSet<Goaltransaction>();
            InverseAdvisor = new HashSet<User>();
        }

        public string Firstname { get; set; }
        public string Surname { get; set; }
        public int Id { get; set; }
        public int? Advisorid { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int? Currencyid { get; set; }

        public virtual User Advisor { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual ICollection<Goal> Goals { get; set; }
        public virtual ICollection<Goaltransactionfunding> Goaltransactionfundings { get; set; }
        public virtual ICollection<Goaltransaction> Goaltransactions { get; set; }
        public virtual ICollection<User> InverseAdvisor { get; set; }
    }
}

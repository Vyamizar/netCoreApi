using System;
using System.Collections.Generic;

#nullable disable

namespace Challenge.Models
{
    public partial class Goalcategory
    {
        public Goalcategory()
        {
            Goals = new HashSet<Goal>();
        }

        public string Code { get; set; }
        public string Uuid { get; set; }
        public string Title { get; set; }
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public virtual ICollection<Goal> Goals { get; set; }
    }
}

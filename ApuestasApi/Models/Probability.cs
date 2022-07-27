using System;
using System.Collections.Generic;

#nullable disable

namespace ApuestasApi.Models
{
    public partial class Probability
    {
        public Probability()
        {
            Detailplays = new HashSet<Detailplay>();
            Games = new HashSet<Game>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Detailplay> Detailplays { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}

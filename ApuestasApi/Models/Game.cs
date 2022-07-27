using System;
using System.Collections.Generic;

#nullable disable

namespace ApuestasApi.Models
{
    public partial class Game
    {
        public Game()
        {
            Detailplays = new HashSet<Detailplay>();
            Products = new HashSet<Product>();
            Typegames = new HashSet<Typegame>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ProbabilityId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Probability Probability { get; set; }
        public virtual ICollection<Detailplay> Detailplays { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Typegame> Typegames { get; set; }
    }
}

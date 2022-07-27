using System;
using System.Collections.Generic;

#nullable disable

namespace ApuestasApi.Models
{
    public partial class Product
    {
        public Product()
        {
            Animalwins = new HashSet<Animalwin>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ProbabilityId { get; set; }
        public int GameId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Number { get; set; }

        public virtual Game Game { get; set; }
        public virtual Probability Probability { get; set; }
        public virtual ICollection<Animalwin> Animalwins { get; set; }
    }
}

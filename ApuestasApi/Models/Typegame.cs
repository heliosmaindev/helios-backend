using System;
using System.Collections.Generic;

#nullable disable

namespace ApuestasApi.Models
{
    public partial class Typegame
    {
        public Typegame()
        {
            Animalwins = new HashSet<Animalwin>();
            Detailplays = new HashSet<Detailplay>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int GameId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual Game Game { get; set; }
        public virtual ICollection<Animalwin> Animalwins { get; set; }
        public virtual ICollection<Detailplay> Detailplays { get; set; }
    }
}

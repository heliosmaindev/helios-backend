using System;
using System.Collections.Generic;

#nullable disable

namespace ApuestasApi.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            Animalwins = new HashSet<Animalwin>();
            Plays = new HashSet<Play>();
        }

        public int Id { get; set; }
        public DateTime GameDate { get; set; }
        public TimeSpan Hour { get; set; }
        public int Estatus { get; set; }

        public virtual ICollection<Animalwin> Animalwins { get; set; }
        public virtual ICollection<Play> Plays { get; set; }
    }
}

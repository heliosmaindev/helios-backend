using System;
using System.Collections.Generic;

#nullable disable

namespace ApuestasApi.Models
{
    public partial class Animalwin
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public DateTime DateDay { get; set; }
        public int ScheduleId { get; set; }
        public string AnimalName { get; set; }
        public string AnimalNumber { get; set; }
        public int? AnimalId { get; set; }

        public virtual Product Animal { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual Typegame Type { get; set; }
    }
}

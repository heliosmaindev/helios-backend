using System;
using System.Collections.Generic;

#nullable disable

namespace ApuestasApi.Models
{
    public partial class Play
    {
        public Play()
        {
            Bills = new HashSet<Bill>();
            Detailplays = new HashSet<Detailplay>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int Estatus { get; set; }
        public float Amount { get; set; }
        public float WinAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int ScheduleId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Detailplay> Detailplays { get; set; }
    }
}

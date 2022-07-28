using System;
using System.Collections.Generic;

#nullable disable

namespace ApuestasApi.Models
{
    public partial class Client
    {
        public Client()
        {
            Bills = new HashSet<Bill>();
            Payments = new HashSet<Payment>();
            Plays = new HashSet<Play>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Play> Plays { get; set; }
    }
}

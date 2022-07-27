using System;
using System.Collections.Generic;

#nullable disable

namespace ApuestasApi.Models
{
    public partial class Bill
    {
        public Bill()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int AccountId { get; set; }
        public int PaymentId { get; set; }
        public string Description { get; set; }
        public int PlayId { get; set; }
        public float Rate { get; set; }
        public float GrossAmount { get; set; }
        public float NetAmount { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Account Account { get; set; }
        public virtual Client Client { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Play Play { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}

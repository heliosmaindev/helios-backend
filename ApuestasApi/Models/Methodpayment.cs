using System;
using System.Collections.Generic;

#nullable disable

namespace ApuestasApi.Models
{
    public partial class Methodpayment
    {
        public Methodpayment()
        {
            Accounts = new HashSet<Account>();
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}

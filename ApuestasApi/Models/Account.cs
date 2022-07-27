using System;
using System.Collections.Generic;

#nullable disable

namespace ApuestasApi.Models
{
    public partial class Account
    {
        public Account()
        {
            Bills = new HashSet<Bill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string NAccount { get; set; }
        public string Description { get; set; }
        public int MethodId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Methodpayment Method { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}

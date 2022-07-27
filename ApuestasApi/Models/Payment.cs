using System;
using System.Collections.Generic;

#nullable disable

namespace ApuestasApi.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Bills = new HashSet<Bill>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int BillId { get; set; }
        public int MethodId { get; set; }
        public int? ClientId { get; set; }

        public virtual Bill Bill { get; set; }
        public virtual Client Client { get; set; }
        public virtual Methodpayment Method { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}

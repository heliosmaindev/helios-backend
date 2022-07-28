using System;
using System.Collections.Generic;

#nullable disable

namespace ApuestasApi.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string PhoneNumber { get; set; }
        public int RangeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual Range Range { get; set; }
    }
}

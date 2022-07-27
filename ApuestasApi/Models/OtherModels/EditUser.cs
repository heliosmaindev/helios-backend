using System;
using System.Collections.Generic;

namespace ApuestasApi.Models.OtherModels
{
    public class EditUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string PhoneNumber { get; set; }
        public int RangeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

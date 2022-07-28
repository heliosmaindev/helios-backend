using System;
using System.Collections.Generic;
namespace ApuestasApi.Models.OtherModels
{
    public class RefreshToken
    {
        public Guid id { get; set; }
        public string userId { get; set; }
        public string token { get; set; }
    }
}

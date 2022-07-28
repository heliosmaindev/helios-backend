using System;

namespace ApuestasApi.Models.OtherModels
{
    public class EditGame
    {
        public string Name { get; set; }
        public int ProbabilityId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

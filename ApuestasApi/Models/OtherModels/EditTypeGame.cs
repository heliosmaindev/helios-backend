using System;

namespace ApuestasApi.Models.OtherModels
{
    public class EditTypeGame
    {
        public string Name { get; set; }
        public int GameId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}

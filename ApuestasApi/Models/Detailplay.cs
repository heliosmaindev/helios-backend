using System;
using System.Collections.Generic;
using ApuestasApi.Models;
using ApuestasApi.Models;

#nullable disable

namespace ApuestasApi.Models
{
    public partial class Detailplay
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ProbabilityId { get; set; }
        public float Amount { get; set; }
        public float WinAmount { get; set; }
        public int PlayId { get; set; }
        public int GameId { get; set; }
        public int Estatus { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? TypeGameId { get; set; }

        public virtual Game Game { get; set; }
        public virtual Play Play { get; set; }
        public virtual Probability Probability { get; set; }
        public virtual Typegame TypeGame { get; set; }
    }
}

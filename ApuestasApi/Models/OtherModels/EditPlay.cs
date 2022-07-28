using System.Collections.Generic;

namespace ApuestasApi.Models.OtherModels
{
    public class EditPlay
    {
        public int ClientId { get; set; }
        public int Estatus { get; set; }
        public float Amount { get; set; }
        public float WinAmount { get; set; }
        public int ScheduleId { get; set; }
    }
}

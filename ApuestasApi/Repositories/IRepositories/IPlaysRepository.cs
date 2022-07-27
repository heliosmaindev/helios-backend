using System.Collections.Generic;
using ApuestasApi.Models;
using ApuestasApi.Models.OtherModels;

namespace ApuestasApi.Repositories.IRepositories
{
    public interface IPlaysRepository
    {
        public List<Play> GetPlays();
        public Play GetPlayById(int id);
        public int EditPlay(int id, EditPlay editPlay);
        public int DeletePlay(int id);
        public int PostPlay(EditPlay editPlay);
    }
}

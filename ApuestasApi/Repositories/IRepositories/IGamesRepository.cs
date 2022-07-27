using System.Collections.Generic;
using ApuestasApi.Models;
using ApuestasApi.Models.OtherModels;

namespace ApuestasApi.Repositories.IRepositories
{
    public interface IGamesRepository
    {
        public List<Game> GetGames();
        public Game GetGameById(int id);
        public int EditGame(int id, EditGame editGame);
        public int DeleteGame(int id);
        public int PostGame(EditGame editGame);
    }
}

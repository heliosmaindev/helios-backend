using System.Collections.Generic;
using ApuestasApi.Models;
using ApuestasApi.Models.OtherModels;

namespace ApuestasApi.Repositories.IRepositories
{
    public interface ITypeGameRepository
    {
        public List<Typegame> GetTypegames();
        public Typegame GetTypegameById(int id);
        public int EditTypegame(int id, EditTypeGame editTypeGame);
        public int DeleteTypegame(int id);
        public int PostTypegame(EditTypeGame editTypeGame);
    }
}


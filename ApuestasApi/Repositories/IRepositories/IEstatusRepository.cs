using System.Collections.Generic;
using ApuestasApi.Models;
using ApuestasApi.Models.OtherModels;

namespace ApuestasApi.Repositories.IRepositories
{
    public interface IEstatusRepository
    {
        public List<Estatus> GetEstatus();
        public Estatus GetEstatusById(int id);
        public int EditEstatus(int id, EditEstatus editStatus);
        public int DeleteStatus(int id);
        public int PostStatus(EditEstatus estatus);
    }
}

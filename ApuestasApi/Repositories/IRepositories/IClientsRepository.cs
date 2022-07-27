using System.Collections.Generic;
using ApuestasApi.Models;
using ApuestasApi.Models.OtherModels;

namespace ApuestasApi.Repositories.IRepositories
{
    public interface IClientsRepository
    {
        public List<Client> GetClients();
        public Client GetClientById(int id);
        public int EditClient(int id, EditClient editClient);
        public int DeleteClient(int id);
        public int PostClient(EditClient editClient);
    }
}

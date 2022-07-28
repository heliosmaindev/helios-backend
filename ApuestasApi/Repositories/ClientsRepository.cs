using ApuestasApi.Models;
using ApuestasApi.Models.OtherModels;
using ApuestasApi.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApuestasApi.Repositories
{
    public class ClientsRepository : IClientsRepository
    {

        private readonly LottoContext _lottoContext;

        public ClientsRepository(LottoContext lottoContext)
        {
            _lottoContext = lottoContext;
        }

        public List<Client> GetClients()
        {
            try
            {
                var data = _lottoContext.Clients.ToList();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Client GetClientById(int id)
        {
            try
            {
                Client data = (from t in _lottoContext.Clients
                                where t.Id == id
                                select t).SingleOrDefault();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int EditClient(int id, EditClient editClient)
        {
            try
            {
                Client client = (from t in _lottoContext.Clients
                                   where t.Id == id
                                   select t).SingleOrDefault();
                client.FirstName = editClient.FirstName;
                client.LastName = editClient.LastName;
                client.Document = editClient.Document;
                client.PhoneNumber = editClient.PhoneNumber;
                client.UpdatedAt = DateTime.Now;
                _lottoContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int DeleteClient(int id)
        {
            try
            {
                Client client = (from t in _lottoContext.Clients
                              where t.Id == id
                              select t).FirstOrDefault();
                _lottoContext.Clients.Remove(client);
                _lottoContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int PostClient(EditClient editClient)
        {
            try
            {
                Client client = new Client();
                client.FirstName = editClient.FirstName;
                client.LastName = editClient.LastName;
                client.Document = editClient.Document;
                client.PhoneNumber = editClient.PhoneNumber;
                client.UpdatedAt = DateTime.Now;
                _lottoContext.Clients.Add(client);
                _lottoContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}



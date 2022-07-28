using ApuestasApi.Models;
using ApuestasApi.Models.OtherModels;
using ApuestasApi.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApuestasApi.Repositories 
{
    public class EstatusRepository : IEstatusRepository
    {

        private readonly LottoContext _lottoContext;

        public EstatusRepository(LottoContext lottoContext)
        {
            _lottoContext = lottoContext;
        }

        public List<Estatus> GetEstatus()
        {
            try 
            {
                var data = _lottoContext.Estatuses.ToList();
                return data;
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        public Estatus GetEstatusById(int id)
        {
            try
            {
                Estatus data = (from e in _lottoContext.Estatuses
                                   where e.Id == id
                                   select e).SingleOrDefault();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int EditEstatus(int id, EditEstatus editStatus) 
        {
            try 
            {
                Estatus estatus = (from e in _lottoContext.Estatuses 
                                   where e.Id == id 
                                   select e).SingleOrDefault();
                estatus.Description = editStatus.Description;
                _lottoContext.SaveChanges();

                return 1;
            } 
            catch(Exception ex) 
            {
                return 0;
            }
        }

        public int DeleteStatus(int id) 
        {
            try
            {
                var status = (from e in _lottoContext.Estatuses 
                              where e.Id == id 
                              select e).FirstOrDefault();
                _lottoContext.Estatuses.Remove(status);
                _lottoContext.SaveChanges();
                return 1;
            }
            catch (Exception ex) 
            {
                return 0;
            }
        }

        public int PostStatus(EditEstatus estatus)
        {
            try
            {
                Estatus status = new Estatus();
                status.Description = estatus.Description;
                _lottoContext.Estatuses.Add(status);
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



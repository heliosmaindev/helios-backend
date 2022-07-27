using ApuestasApi.Models.OtherModels;
using ApuestasApi.Models;
using ApuestasApi.Repositories.IRepositories;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ApuestasApi.Repositories
{
    public class TypeGameRepository : ITypeGameRepository
    {
        private readonly LottoContext _lottoContext;

        public TypeGameRepository(LottoContext lottoContext)
        {
            _lottoContext = lottoContext;
        }

        public List<Typegame> GetTypegames()
        {
            try
            {
                var data = _lottoContext.Typegames.ToList();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Typegame GetTypegameById(int id)
        {
            try
            {
                Typegame data = (from t in _lottoContext.Typegames
                                 where t.Id == id
                                select t).SingleOrDefault();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int EditTypegame(int id, EditTypeGame editTypeGame)
        {
            try
            {
                Typegame typeGame = (from t in _lottoContext.Typegames
                                 where t.Id == id
                                 select t).SingleOrDefault();
                typeGame.Name = editTypeGame.Name;
                typeGame.GameId = editTypeGame.GameId;
                typeGame.UpdateAt = DateTime.Now;
                _lottoContext.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int DeleteTypegame(int id)
        {
            try
            {
                Typegame typegame = (from t in _lottoContext.Typegames
                                    where t.Id == id
                                    select t).FirstOrDefault();
                _lottoContext.Typegames.Remove(typegame);
                _lottoContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int PostTypegame(EditTypeGame editTypeGame)
        {
            try
            {
                Typegame typeGame = new Typegame();
                typeGame.Name = editTypeGame.Name;
                typeGame.GameId = editTypeGame.GameId;
                typeGame.UpdateAt = DateTime.Now;
                typeGame.CreatedAt = DateTime.Now;
                _lottoContext.Typegames.Add(typeGame);
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


using ApuestasApi.Models.OtherModels;
using ApuestasApi.Models;
using ApuestasApi.Repositories.IRepositories;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ApuestasApi.Repositories
{
    public class GamesRepository : IGamesRepository
    {
        private readonly LottoContext _lottoContext;

        public GamesRepository(LottoContext lottoContext)
        {

            _lottoContext = lottoContext;
        }

        public List<Game> GetGames()
        {
            try
            {
                var data = _lottoContext.Games.ToList();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Game GetGameById(int id)
        {
            try
            {
                Game data = (from t in _lottoContext.Games
                             where t.Id == id
                             select t).SingleOrDefault();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int EditGame(int id, EditGame editGame)
        {
            try
            {
                Game game = (from t in _lottoContext.Games
                             where t.Id == id
                             select t).SingleOrDefault();
                game.Name = editGame.Name;
                game.ProbabilityId = editGame.ProbabilityId;
                game.UpdatedAt = DateTime.Now;
                _lottoContext.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int DeleteGame(int id)
        {
            try
            {
                var game = (from t in _lottoContext.Games
                            where t.Id == id
                            select t).FirstOrDefault();
                _lottoContext.Games.Remove(game);
                _lottoContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int PostGame(EditGame editGame)
        {
            try
            {
                Game game = new Game();
                game.Name = editGame.Name;
                game.ProbabilityId = editGame.ProbabilityId;
                game.CreatedAt = DateTime.Now;
                game.UpdatedAt = DateTime.Now;
                _lottoContext.Games.Add(game);
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

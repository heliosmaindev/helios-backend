using ApuestasApi.Models.OtherModels;
using ApuestasApi.Models;
using ApuestasApi.Repositories.IRepositories;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ApuestasApi.Repositories
{
    public class PlaysRepository : IPlaysRepository
    {
        private readonly LottoContext _lottoContext;

        public PlaysRepository(LottoContext lottoContext)
        {
            _lottoContext = lottoContext;
        }

        public List<Play> GetPlays()
        {
            try
            {
                var data = _lottoContext.Plays.ToList();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Play GetPlayById(int id)
        {
            try
            {
                Play data = (from p in _lottoContext.Plays
                             where p.Id == id
                             select p).SingleOrDefault();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int EditPlay(int id, EditPlay editPlay)
        {
            try
            {
                Play play = (from p in _lottoContext.Plays
                             where p.Id == id
                             select p).SingleOrDefault();
                play.ClientId = editPlay.ClientId;
                play.Estatus = editPlay.Estatus;
                play.Amount = editPlay.Amount;
                play.WinAmount = editPlay.WinAmount;
                play.ScheduleId = editPlay.ScheduleId;
                play.UpdatedAt = DateTime.Now;
                _lottoContext.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int DeletePlay(int id)
        {
            try
            {
                var play = (from p in _lottoContext.Plays
                              where p.Id == id
                              select p).FirstOrDefault();
                _lottoContext.Plays.Remove(play);
                _lottoContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int PostPlay(EditPlay editPlay)
        {
            try
            {
                Play play = new Play();
                play.ClientId = editPlay.ClientId;
                play.Estatus = editPlay.Estatus;
                play.Amount = editPlay.Amount;
                play.WinAmount = editPlay.WinAmount;
                play.ScheduleId = editPlay.ScheduleId;
                play.CreatedAt = DateTime.Now;
                play.UpdatedAt = DateTime.Now;
                _lottoContext.Plays.Add(play);
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


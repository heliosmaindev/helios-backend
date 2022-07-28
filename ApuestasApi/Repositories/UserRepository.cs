using ApuestasApi.Models;
using ApuestasApi.Models.OtherModels;
using ApuestasApi.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApuestasApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LottoContext _lottoContext;

        public UserRepository(LottoContext lottoContext)
        {
            _lottoContext = lottoContext;
        }

        public List<User> GetUsers()
        {
            try
            {
                var data = _lottoContext.Users.ToList();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public User GetUserById(int id)
        {
            try
            {
                var data = (from u in _lottoContext.Users
                            where u.Id == id
                            select u).SingleOrDefault();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public User GetUserByDocument(string document)
        {
            try
            {
                var data = (from u in _lottoContext.Users
                            where u.Document == document
                            select u).SingleOrDefault();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int EditUser(int id, EditUser editUser)
        {
            try
            {
                User user = (from u in _lottoContext.Users
                                   where u.Id == id
                                   select u).SingleOrDefault();
                user.FirstName = editUser.FirstName;
                user.LastName = editUser.LastName;
                user.PhoneNumber = editUser.PhoneNumber;
                user.Document = editUser.Document;
                user.RangeId = editUser.RangeId;
                user.UpdatedAt = DateTime.Now;
                _lottoContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int DeleteUser(int id)
        {
            try
            {
                var user = (from u in _lottoContext.Users
                              where u.Id == id
                              select u).FirstOrDefault();
                _lottoContext.Users.Remove(user);
                _lottoContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int PostUser(EditUser editUser)
        {
            try
            {
                User user = new User();
                user.FirstName = editUser.FirstName;
                user.LastName = editUser.LastName;
                user.PhoneNumber = editUser.PhoneNumber;
                user.Document = editUser.Document;
                user.RangeId = editUser.RangeId;
                user.Email = editUser.Email;
                user.Password = editUser.Password;
                user.CreatedAt = DateTime.Now;
                user.UpdatedAt = DateTime.Now;
                
                _lottoContext.Users.Add(user);
                _lottoContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public User FindLogin(LoginInfo loginInfo) 
        {
            try
            {
                User user = _lottoContext.Users.Where(u => u.Email == loginInfo.Email && u.Password == loginInfo.Password).SingleOrDefault();
                if(user != null) 
                {
                    return user;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}




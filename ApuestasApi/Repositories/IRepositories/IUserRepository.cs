using ApuestasApi.Models.OtherModels;
using ApuestasApi.Models;
using System.Collections.Generic;

namespace ApuestasApi.Repositories.IRepositories
{
    public interface IUserRepository
    {
        public List<User> GetUsers();
        public User GetUserById(int id);
        public User GetUserByDocument(string document);
        public int EditUser(int id, EditUser editStatus);
        public int DeleteUser(int id);
        public int PostUser(EditUser estatus);
        public User FindLogin(LoginInfo loginInfo);
    }
}

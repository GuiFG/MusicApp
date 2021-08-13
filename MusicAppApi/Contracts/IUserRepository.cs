using System.Collections.Generic;
using System.Threading.Tasks;
using MusicAppApi.Model;

namespace MusicAppApi.Contracts
{
    public interface IUserRepository 
    {
        Task<List<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> Add(User user);
        Task<User> GetByCredentials(string username, string password);
    }
}
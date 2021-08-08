using System.Threading.Tasks;
using MusicAppWeb.Model;

namespace MusicAppWeb.Contracts
{
    public interface IUserRepository 
    {
        Task<User> Authenticate(User user);
        Task<User> SignUp(User user);
    }
}
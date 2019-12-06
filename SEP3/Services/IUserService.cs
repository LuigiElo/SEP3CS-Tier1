using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEP3.Services
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserAsync(int id);
    }
}
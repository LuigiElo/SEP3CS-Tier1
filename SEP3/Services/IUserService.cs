using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3.Models;

namespace SEP3.Services
{
    public interface IUserService
    {
        void SetPerson(Person p);
        Person GetPerson();
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserAsync(int id);
    }
}
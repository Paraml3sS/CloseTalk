using CloseTalk.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloseTalk.Persistence.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAsync();
        Task<User> GetAsync(int id);
        Task<int> AddUserAsync(User user);
        Task<int> UpdateUserAsync(User user);
        Task<int> DeleteUserAsync(int id);
    }
}

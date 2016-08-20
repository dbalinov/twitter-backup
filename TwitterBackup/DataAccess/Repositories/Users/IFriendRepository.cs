using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repositories.Users
{
    public interface IFriendRepository
    {
        Task<User> GetByScreenNameAsync(string screenName);

        IEnumerable<User> GetAll();

        Task<IEnumerable<User>> GetAllAsync();
    }
}

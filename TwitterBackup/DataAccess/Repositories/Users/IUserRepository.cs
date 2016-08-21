using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repositories.Users
{
    public interface IUserRepository
    {
        IEnumerable<User> Search(string query);

        IEnumerable<User> GetUsersFromIds(IEnumerable<string> ids);

        Task<User> GetByScreenNameAsync(string screenName);
    }
}

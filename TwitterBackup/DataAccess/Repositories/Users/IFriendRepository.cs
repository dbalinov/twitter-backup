using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repositories.Users
{
    public interface IFriendRepository
    {
        IEnumerable<User> GetAll();

        Task<IEnumerable<User>> GetAllAsync();
    }
}

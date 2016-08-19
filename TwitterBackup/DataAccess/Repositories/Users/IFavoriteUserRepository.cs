using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repositories.Users
{
    public interface IFavoriteUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
    }
}

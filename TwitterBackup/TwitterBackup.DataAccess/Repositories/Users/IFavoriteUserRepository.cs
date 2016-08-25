using DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Users
{
    public interface IFavoriteUserRepository
    {
        Task<IEnumerable<string>> GetFavoriteUserIds(string sourceUserId);

        Task AddAsync(FavoriteUserRelation relation);

        Task RemoveAsync(FavoriteUserRelation relation);
    }
}
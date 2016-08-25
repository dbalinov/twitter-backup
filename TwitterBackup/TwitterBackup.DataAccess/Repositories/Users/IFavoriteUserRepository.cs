using TwitterBackup.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterBackup.DataAccess.Repositories.Users
{
    public interface IFavoriteUserRepository
    {
        Task<IEnumerable<string>> GetFavoriteUserIds(string sourceUserId);

        Task AddAsync(FavoriteUserRelation relation);

        Task RemoveAsync(FavoriteUserRelation relation);
    }
}
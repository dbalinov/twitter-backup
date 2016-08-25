using TwitterBackup.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterBackup.Business.Services.Users
{
    public interface IFavoriteUserService
    {
        Task<IEnumerable<UserModel>> GetFavoriteUsers(string sourceUserId);

        Task AddAsync(FavoriteUserRelationModel relation);

        Task RemoveAsync(FavoriteUserRelationModel relation);
    }
}
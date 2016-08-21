using DataAccess.Entities;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Users
{
    public interface IFavoriteUserRepository
    {
        Task AddAsync(FavoriteUserRelation relation);

        Task RemoveAsync(FavoriteUserRelation relation);
    }
}
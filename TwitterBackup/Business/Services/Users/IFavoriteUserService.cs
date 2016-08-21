using Business.Models;
using System.Threading.Tasks;

namespace Business.Services.Users
{
    public interface IFavoriteUserService
    {
        Task AddAsync(FavoriteUserRelationModel relation);

        Task RemoveAsync(FavoriteUserRelationModel relation);
    }
}
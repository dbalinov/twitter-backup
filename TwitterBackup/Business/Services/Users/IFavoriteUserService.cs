using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.Users
{
    public interface IFavoriteUserService
    {
        Task<IEnumerable<UserModel>> GetAllAsync();
    }
}
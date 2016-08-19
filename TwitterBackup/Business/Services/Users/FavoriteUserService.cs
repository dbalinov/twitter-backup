using System.Collections.Generic;
using System.Linq;
using Business.Models;
using Business.Models.Mapping;
using DataAccess.Repositories.Users;
using System.Threading.Tasks;

namespace Business.Services.Users
{
    public class FavoriteUserService : IFavoriteUserService
    {
        private IFavoriteUserRepository favoriteUserRepository;

        public FavoriteUserService(IFavoriteUserRepository favoriteUserRepository)
        {
            this.favoriteUserRepository = favoriteUserRepository;
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            var mapper = new UserMapper();
            var users = await this.favoriteUserRepository.GetAllAsync();
            return users.Select(x => mapper.Map(x, new UserModel()));
        }
    }
}

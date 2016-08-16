using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Models;
using Business.Models.Mapping;
using DataAccess.Repositories.Users;

namespace Business.Services.Users
{
    public class FavoriteUserService : IFavoriteUserService
    {
        private IFavoriteUserRepository favoriteUserRepository;

        public FavoriteUserService(string oAuthToken, string oAuthTokenSecret, string userId)
        {
            this.favoriteUserRepository = new FavoriteUserRepository(oAuthToken, oAuthTokenSecret, userId);
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            var mapper = new UserMapper();
            var users = await this.favoriteUserRepository.GetAllAsync();

            return users.Select(x => mapper.Map(x, new UserModel()));
        }
    }
}

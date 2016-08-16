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

        public IEnumerable<UserModel> GetAll()
        {
            var mapper = new UserMapper();
            var users = this.favoriteUserRepository.GetAll()
                .Select(x => mapper.Map(x, new UserModel()));
            return users;
        }
    }
}

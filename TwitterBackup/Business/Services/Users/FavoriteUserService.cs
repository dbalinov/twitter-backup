using System.Collections.Generic;
using System.Linq;
using Business.Models;
using Business.Models.Mapping;
using DataAccess.Repositories.Users;

namespace Business.Services.Users
{
    public class FavoriteUserService : IFavoriteUserService
    {
        private IFavoriteUserRepository favoriteUserRepository;

        public FavoriteUserService(IFavoriteUserRepository favoriteUserRepository)
        {
            this.favoriteUserRepository = favoriteUserRepository;
        }

        public IEnumerable<UserModel> GetAll()
        {
            var mapper = new UserMapper();
            var users = this.favoriteUserRepository.GetAll();
            return users.Select(x => mapper.Map(x, new UserModel()));
        }

        public void UpdateFriendship(string screenName, bool deviceNotificationsEnabled)
        {
            this.favoriteUserRepository.UpdateDeviceNotificationsStatus(
                screenName, deviceNotificationsEnabled);
        }
    }
}

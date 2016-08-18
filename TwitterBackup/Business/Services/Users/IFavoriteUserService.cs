using Business.Models;
using System.Collections.Generic;

namespace Business.Services.Users
{
    public interface IFavoriteUserService
    {
        IEnumerable<UserModel> GetAll();

        void UpdateFriendship(string screenName, bool deviceNotificationsEnabled);
    }
}
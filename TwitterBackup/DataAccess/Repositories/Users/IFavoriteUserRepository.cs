using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Repositories.Users
{
    public interface IFavoriteUserRepository
    {
        IEnumerable<User> GetAll();

        void UpdateDeviceNotificationsStatus(string screenName, bool deviceNotificationsEnabled);
    }
}

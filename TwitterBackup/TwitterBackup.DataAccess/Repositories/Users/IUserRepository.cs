using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterBackup.DataAccess.Entities;

namespace TwitterBackup.DataAccess.Repositories.Users
{
    public interface IUserRepository
    {
        IEnumerable<User> Search(string query);

        IEnumerable<User> GetUsersFromIds(IEnumerable<string> ids);

        Task<User> GetAsync(string userId);

        Task RegisterUserAsync(string userId);

        Task<IEnumerable<UserRegister>> GetRegisterUsersAsync();

        IEnumerable<Tuple<string, int>> GetFavoriteUserCount(IEnumerable<string> userIds);
    }
}

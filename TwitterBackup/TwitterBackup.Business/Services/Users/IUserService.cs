using System.Threading.Tasks;
using TwitterBackup.Business.Models;
using System.Collections.Generic;

namespace TwitterBackup.Business.Services.Users
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> SearchAsync(string query);

        Task<UserModel> GetAsync(string userId);

        Task RegisterUserAsync(string userId);

        Task<IList<DashboardUserModel>> GetDashboardUsersAsync();
    }
}
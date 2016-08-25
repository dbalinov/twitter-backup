using System.Threading.Tasks;
using TwitterBackup.Business.Models;
using System.Collections.Generic;

namespace TwitterBackup.Business.Services.Users
{
    public interface IUserService
    {
        Task<UserModel> GetAsync(string userId);

        Task<IEnumerable<UserModel>> SearchAsync(string query);
        
        Task<IEnumerable<UserModel>> GetRecommendedUsersAsync();

        Task RegisterUserAsync(string userId);

        Task<IList<DashboardUserModel>> GetDashboardUsersAsync();
    }
}
using System.Threading.Tasks;
using Business.Models;
using System.Collections.Generic;

namespace Business.Services.Users
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> SearchAsync(string query);

        Task<UserModel> GetAsync(string userId);

        Task RegisterUserAsync(string userId);

        Task<IList<DashboardUserModel>> GetDashboardUsersAsync();
    }
}
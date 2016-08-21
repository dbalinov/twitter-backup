using System.Threading.Tasks;
using Business.Models;
using System.Collections.Generic;

namespace Business.Services.Users
{
    public interface IUserService
    {
        IEnumerable<UserModel> Search(string query);

        Task<UserModel> GetByScreenNameAsync(string screenName);
    }
}
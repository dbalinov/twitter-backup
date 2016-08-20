using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.Users
{
    public interface IFriendService
    {
        IEnumerable<UserModel> GetAll();

        Task<IEnumerable<UserModel>> GetAllAsync();

        Task<UserModel> GetByScreenNameAsync(string screenName);
    }
}
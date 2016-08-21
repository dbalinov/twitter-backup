using Business.Models;
using System.Threading.Tasks;

namespace Business.Services.Users
{
    public interface IFriendService
    {
        Task<UserModel> GetByScreenNameAsync(string screenName);
    }
}
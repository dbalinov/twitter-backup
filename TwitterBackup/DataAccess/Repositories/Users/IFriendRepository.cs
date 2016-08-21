using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repositories.Users
{
    public interface IFriendRepository
    {
        Task<User> GetByScreenNameAsync(string screenName);
    }
}

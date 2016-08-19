using System.Threading.Tasks;
using Business.Models;

namespace Business.Services.Users
{
    public interface IFriendshipService
    {
        Task<FriendshipModel> GetAsync(string screenName);

        Task UpdateAsync(FriendshipModel friendship);
    }
}

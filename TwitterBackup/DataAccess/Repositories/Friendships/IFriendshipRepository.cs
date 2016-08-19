using DataAccess.Entities;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Friendships
{
    public interface IFriendshipRepository
    {
        Task<Friendship> GetAsync(string screenName);

        Task UpdateAsync(Friendship friendship);
    }
}
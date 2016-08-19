using System.Threading.Tasks;
using Business.Models;
using DataAccess.Repositories.Friendships;
using Business.Models.Mapping;
using DataAccess.Entities;

namespace Business.Services.Users
{
    public class FriendshipService : IFriendshipService
    {
        private readonly IFriendshipRepository friendshipRepository;

        public FriendshipService(IFriendshipRepository friendshipRepository)
        {
            this.friendshipRepository = friendshipRepository;
        }

        public async Task<FriendshipModel> GetAsync(string screenName)
        {
            var friendshipMapper = new FriendshipMapper();
            var friendship = await this.friendshipRepository.GetAsync(screenName);
            return friendshipMapper.Map(friendship, new FriendshipModel());
        }

        public async Task UpdateAsync(FriendshipModel friendshipModel)
        {
            var friendshipMapper = new FriendshipMapper();
            var friendship = friendshipMapper.Map(friendshipModel, new Friendship());
            await this.friendshipRepository.UpdateAsync(friendship);
        }
    }
}

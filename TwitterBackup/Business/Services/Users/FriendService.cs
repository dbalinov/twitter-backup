using Business.Models;
using Business.Models.Mapping;
using DataAccess.Repositories.Users;
using System.Threading.Tasks;

namespace Business.Services.Users
{
    public class FriendService : IFriendService
    {
        private IFriendRepository friendRepository;

        public FriendService(IFriendRepository friendRepository)
        {
            this.friendRepository = friendRepository;
        }

        public async Task<UserModel> GetByScreenNameAsync(string screenName)
        {
            var mapper = new UserMapper();
            var user = await this.friendRepository.GetByScreenNameAsync(screenName);
            return  mapper.Map(user, new UserModel());
        }
    }
}

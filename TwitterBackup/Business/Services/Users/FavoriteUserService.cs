using System.Collections.Generic;
using System.Linq;
using Business.Models;
using Business.Models.Mapping;
using DataAccess.Repositories.Users;
using System.Threading.Tasks;

namespace Business.Services.Users
{
    public class FavoriteUserService : IFavoriteUserService
    {
        private IFriendRepository friendRepository;

        public FavoriteUserService(IFriendRepository friendRepository)
        {
            this.friendRepository = friendRepository;
        }

        public IEnumerable<UserModel> GetAll()
        {
            var mapper = new UserMapper();
            var users = this.friendRepository.GetAll();
            return users.Select(x => mapper.Map(x, new UserModel()));
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            var mapper = new UserMapper();
            var users = await this.friendRepository.GetAllAsync();
            return users.Select(x => mapper.Map(x, new UserModel()));
        }
    }
}

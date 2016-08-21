using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Models;
using Business.Models.Mapping;
using DataAccess.Repositories.Users;

namespace Business.Services.Users
{
    internal class UserService : IUserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserModel> GetByScreenNameAsync(string screenName)
        {
            var mapper = new UserMapper();
            var user = await this.userRepository.GetByScreenNameAsync(screenName);
            return mapper.Map(user, new UserModel());
        }

        public IEnumerable<UserModel> Search(string query)
        {
            // TODO: merge with saved users

            var mapper = new UserMapper();
            var users = this.userRepository.Search(query);
            return users.Select(user => mapper.Map(user, new UserModel()));
        }
    }
}

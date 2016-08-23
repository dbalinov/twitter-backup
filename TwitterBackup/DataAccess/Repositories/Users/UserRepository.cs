using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Credentials;
using DataAccess.Entities;
using Tweetinvi;
using Tweetinvi.Models;
using User = Tweetinvi.User;

namespace DataAccess.Repositories.Users
{
    internal class UserRepository : IUserRepository
    {
        private readonly ITwitterCredentials credentials;
        private readonly IDbContext dbContext;
        
        public UserRepository(ITwitterCredentialsFactory credentialsFactory, IDbContext dbContext)
        {
            this.credentials = credentialsFactory.Create();
            this.dbContext = dbContext;
        }

        public IEnumerable<Entities.User> Search(string query)
        {
            var users = Auth.ExecuteOperationWithCredentials(
                this.credentials, () => Tweetinvi.Search.SearchUsers(query, 9));

            return users.Select(friend => Map(friend));
        }

        public IEnumerable<Entities.User> GetUsersFromIds(IEnumerable<string> ids)
        {
            var users = Auth.ExecuteOperationWithCredentials(
                this.credentials, () => User.GetUsersFromIds(ids.Select(long.Parse)));

            return users.Select(user => Map(user));
        }

        public async Task<Entities.User> GetAsync(string userId)
        {
            var user = await Auth.ExecuteOperationWithCredentials(
                this.credentials, () => UserAsync.GetUserFromId(long.Parse(userId)));

            return Map(user);
        }

        private DataAccess.Entities.User Map(IUser friend)
        {
            return new DataAccess.Entities.User
            {
                Id = friend.IdStr,
                Name = friend.Name,
                Description = friend.Description,
                ProfileImageUrl = friend.ProfileImageUrl.Replace("_normal", "_bigger"),
                ProfileBackgroundColor = friend.ProfileBackgroundColor,
                ProfileBannerUrl = friend.ProfileBannerURL,
                FollowersCount = friend.FollowersCount,
                StatusesCount = friend.StatusesCount,
                FriendsCount = friend.FriendsCount,
                ScreenName = friend.ScreenName,
                Verified = friend.Verified
            };
        }

        public async Task RegisterUserAsync(string userId)
        {
            var userRegister = new UserRegister { UserId = userId };
            await this.dbContext.UserRegisters.InsertOneAsync(userRegister);
        }
    }
}

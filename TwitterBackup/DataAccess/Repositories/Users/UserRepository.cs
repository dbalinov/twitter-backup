using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Credentials;
using DataAccess.Entities;
using MongoDB.Driver;
using Tweetinvi;
using Tweetinvi.Models;
using User = Tweetinvi.User;
using DataAccess.Entities.Mappers;

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

            var mapper = new UserMap();
            return users.Select(user => mapper.Map(user, new Entities.User()));
        }

        public IEnumerable<Entities.User> GetUsersFromIds(IEnumerable<string> ids)
        {
            var users = Auth.ExecuteOperationWithCredentials(
                this.credentials, () => User.GetUsersFromIds(ids.Select(long.Parse)));

            var mapper = new UserMap();
            return users.Select(user => mapper.Map(user, new Entities.User()));
        }

        public async Task<Entities.User> GetAsync(string userId)
        {
            var user = await Auth.ExecuteOperationWithCredentials(
                this.credentials, () => UserAsync.GetUserFromId(long.Parse(userId)));

            var mapper = new UserMap();
            return mapper.Map(user, new Entities.User());
        }

        public async Task RegisterUserAsync(string userId)
        {
            var userRegister = new UserRegister { UserId = userId };
            await this.dbContext.UserRegisters.InsertOneAsync(userRegister);
        }

        public async Task<IEnumerable<UserRegister>> GetRegisterUsersAsync()
        {
            var users = await this.dbContext.UserRegisters.FindAsync(
                FilterDefinition<UserRegister>.Empty);

            return users.ToEnumerable();
        }

        public IEnumerable<Tuple<string, int>> GetFavoriteUserCount(IEnumerable<string> userIds)
        {
            var favoriteUserCount = this.dbContext.FavriteUserRelations
                .Aggregate(new AggregateOptions { AllowDiskUse = true })
                .Group(x => x.SourceUserId, x => new Tuple<string, int>(x.Key, x.Count()))
                .ToEnumerable();

            return favoriteUserCount;
        }
    }
}

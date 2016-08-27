using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterBackup.DataAccess.Credentials;
using TwitterBackup.DataAccess.Entities;
using TwitterBackup.Infrastructure.Cacheing;

namespace TwitterBackup.DataAccess.Repositories.Users
{
    internal class CachedUserRepository : UserRepository
    {
        private readonly ICacheProvider cacheProvider;

        public CachedUserRepository(ITwitterCredentialsFactory credentialsFactory, IDbContext dbContext, ICacheProvider cacheProvider)
            : base(credentialsFactory, dbContext)
        {
            this.cacheProvider = cacheProvider;
        }

        public override async Task<User> GetAsync(string userId)
        {
            var key = "user_" + userId;
            var cachedUser = this.cacheProvider.Get<User>(key);
            if (cachedUser != null)
            {
                return cachedUser;
            }

            var user = await base.GetAsync(userId);
            this.cacheProvider.Set(key, user);
            return user;
        }

        public override IEnumerable<User> GetUsersFromIds(IEnumerable<string> ids)
        {
            var users = new List<User>();
            var nonCachedUserIds = new List<string>();
            foreach (var id in ids)
            {
                var key = "user_" + id;
                var user = this.cacheProvider.Get<User>(key);
                if (user != null)
                {
                    users.Add(user);
                }
                else
                {
                    nonCachedUserIds.Add(id);
                }
            }

            var nonCachedUsers = base.GetUsersFromIds(nonCachedUserIds);
            users.AddRange(nonCachedUsers);
            return users;
        }
    }
}

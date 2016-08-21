using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using MongoDB.Driver;

namespace DataAccess.Repositories.Users
{
    public class FavoriteUserRepository : IFavoriteUserRepository
    {
        private IDbContext dbContext;

        public FavoriteUserRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<string>> GetFavoriteUserIds(string sourceUserId)
        {
            var favoriteUsers = await this.dbContext.FavriteUserRelations
                .FindAsync(x => x.SourceUserId == sourceUserId);

            return favoriteUsers.ToEnumerable().Select(x => x.TargetUserId);
        }

        public async Task AddAsync(FavoriteUserRelation relation)
        {
            await this.dbContext.FavriteUserRelations.InsertOneAsync(relation);
        }

        public async Task RemoveAsync(FavoriteUserRelation relation)
        {
            await this.dbContext.FavriteUserRelations.DeleteOneAsync(
                x => x.SourceUserId == relation.SourceUserId &&
                     x.TargetUserId == relation.TargetUserId);
        }
    }
}


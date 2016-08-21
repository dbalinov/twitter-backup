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


using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using MongoDB.Driver;
using MongoDB.Bson;

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
            var filter = Builders<FavoriteUserRelation>.Filter.Eq(x => x.SourceUserId, sourceUserId);

            var projection = Builders<FavoriteUserRelation>.Projection
                .Include(b => b.TargetUserId)
                .Exclude("_id"); // _id is special and needs to be explicitly excluded if not needed

            var options = new FindOptions<FavoriteUserRelation, BsonDocument> { Projection = projection };

            var favoriteUsers = await this.dbContext.FavriteUserRelations.FindAsync(filter, options);

            var result = favoriteUsers.ToEnumerable()
                .ToList()
                .Select(x => x.GetValue("TargetUserId").AsString);

            return result;
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


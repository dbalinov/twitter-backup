using System.Linq;
using System.Threading.Tasks;
using TwitterBackup.DataAccess.Entities;
using TwitterBackup.DataAccess.Repositories.Users;
using Xunit;

namespace TwitterBackup.DataAccess.Tests.Repositories.Users
{
    public class FavoriteUserRepositoryTests
    {
        private readonly IDbContext dbContext;
        private readonly IFavoriteUserRepository favoriteUserRepository;

        public FavoriteUserRepositoryTests()
        {
            this.dbContext = TestUtils.GetDbContext();
            this.favoriteUserRepository = new FavoriteUserRepository(this.dbContext);
        }

        [Fact]
        public async Task CrudTest()
        {
            var relation = new FavoriteUserRelation
            {
                SourceUserId = "1",
                TargetUserId = "2"
            };

            await this.favoriteUserRepository.AddAsync(relation);

            var relationIds = await this.favoriteUserRepository.GetFavoriteUserIds(relation.SourceUserId);

            Assert.True(relationIds.Contains(relation.TargetUserId));

            await this.favoriteUserRepository.RemoveAsync(relation);
        }
    }
}

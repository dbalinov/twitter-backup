using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterBackup.Business.Models;
using TwitterBackup.Business.Services.Users;
using TwitterBackup.DataAccess.Entities;
using TwitterBackup.DataAccess.Repositories.Users;
using Xunit;

namespace TwitterBackup.Business.Tests.Services.Users
{
    public class FavoriteUserServiceTests
    {
        private readonly IFavoriteUserRepository favoriteUserRepository;
        private readonly IUserRepository userRepository;

        private readonly IFavoriteUserService favoriteUserService;

        public FavoriteUserServiceTests()
        {
            this.favoriteUserRepository = Substitute.For<IFavoriteUserRepository>();
            this.userRepository = Substitute.For<IUserRepository>();

            this.favoriteUserService = new FavoriteUserService(this.favoriteUserRepository, this.userRepository);
        }

        [Fact]
        public async Task GetFavoriteUsersTest()
        {
            // Arrange
            var sourceUserId = "source user id";
            var favoriteUserIds = new List<string>();
            var favoriteUsers = new List<User> { new User { Id = "id" } };

            this.favoriteUserRepository.GetFavoriteUserIds(sourceUserId)
                .Returns(favoriteUserIds);

            this.userRepository.GetUsersFromIds(favoriteUserIds)
                .Returns(favoriteUsers);

            // Act
            var result = await this.favoriteUserService.GetFavoriteUsers(sourceUserId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(favoriteUsers.Count, result.Count());
            Assert.Equal(favoriteUsers.First().Id, result.First().Id);
            Assert.All(result, x => Assert.True(x.IsFavorite));
        }

        [Fact]
        public async Task AddAsyncTest()
        {
            // Arrange

            // Act
            await this.favoriteUserService.AddAsync(new FavoriteUserRelationModel());

            // Assert
            await this.favoriteUserRepository.Received().AddAsync(Arg.Any<FavoriteUserRelation>());
        }

        [Fact]
        public async Task RemoveAsyncTest()
        {
            // Arrange

            // Act
            await this.favoriteUserService.RemoveAsync(new FavoriteUserRelationModel());
            
            // Assert
            await this.favoriteUserRepository.Received().RemoveAsync(Arg.Any<FavoriteUserRelation>());
        }
    }
}

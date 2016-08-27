using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using NSubstitute;
using TwitterBackup.Business.Models;
using TwitterBackup.Business.Services.Users;
using TwitterBackup.Infrastructure.Identity.Claims;
using TwitterBackup.Web.Controllers;
using Xunit;
using TwitterBackup.Web.Models.User;

namespace TwitterBackup.Web.Tests.Controllers
{
    public class FavoriteUserControllerTests
    {
        private readonly IFavoriteUserService favoriteUserService;
        private readonly ITwitterClaimsHelper claimsHelper;

        private readonly FavoriteUserController favoriteUserController;
  
        public FavoriteUserControllerTests()
        {
            this.favoriteUserService = Substitute.For<IFavoriteUserService>();
            this.claimsHelper = Substitute.For<ITwitterClaimsHelper>();

            this.favoriteUserController = new FavoriteUserController(this.favoriteUserService, this.claimsHelper);
        }

        [Fact]
        public async Task GetFavoriteUsersTest()
        {
            // Arrange
            var userId = "user id";
            var users = new List<UserModel>();

            this.claimsHelper.GetUserId().Returns(userId);
            this.favoriteUserService.GetFavoriteUsers(userId).Returns(users);

            // Act
            var resultRaw = await this.favoriteUserController.GetFavoriteUsers();
            var result = resultRaw as OkNegotiatedContentResult<IEnumerable<UserModel>>;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Content);
            Assert.Equal(users, result.Content);
        }

        [Fact]
        public async Task PutTest()
        {
            // Arrange
            var request = new FavoriteUserRequest();

            // Act
            var resultRaw = await this.favoriteUserController.Put(request);
            var result = resultRaw as OkResult;

            // Assert
            Assert.NotNull(result);

            await this.favoriteUserService.Received()
                .AddAsync(Arg.Any<FavoriteUserRelationModel>());
        }

        [Fact]
        public async Task DeleteTest()
        {
            // Arrange
            var request = new FavoriteUserRequest();

            // Act
            var resultRaw = await this.favoriteUserController.Delete(request);
            var result = resultRaw as OkResult;

            // Assert
            Assert.NotNull(result);

            await this.favoriteUserService.Received()
                .RemoveAsync(Arg.Any<FavoriteUserRelationModel>());
        }
    }
}

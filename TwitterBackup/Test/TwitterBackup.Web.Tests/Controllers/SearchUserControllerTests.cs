using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using NSubstitute;
using TwitterBackup.Business.Models;
using TwitterBackup.Business.Services.Users;
using TwitterBackup.Web.Controllers;
using TwitterBackup.Web.Models.User;
using Xunit;

namespace TwitterBackup.Web.Tests.Controllers
{
    public class SearchUserControllerTests
    {
        private readonly IUserService userService;

        private readonly SearchUserController searchUserController;

        public SearchUserControllerTests()
        {
            this.userService = Substitute.For<IUserService>(); ;

            this.searchUserController = new SearchUserController(this.userService);
        }

        [Fact]
        public async Task GetFriendsTest()
        {
            // Arrange 
            var users = new List<UserModel>();
            this.userService.GetRecommendedUsersAsync().Returns(users);
            // Act
            var resultRaw = await this.searchUserController.GetFriends();
            var result = resultRaw as OkNegotiatedContentResult<IEnumerable<UserModel>>;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Content);
            Assert.Equal(users, result.Content);
        }

        [Fact]
        public async Task PostSearchTest()
        {
            // Arrange 
            var query = string.Empty;
            var request = new SearchUserRequest {Query = query};
            var users = new List<UserModel>();

            this.userService.SearchAsync(query).Returns(users);

            // Act
            var resultRaw = await this.searchUserController.PostSearch(request);
            var result = resultRaw as OkNegotiatedContentResult<IEnumerable<UserModel>>;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Content);
            Assert.Equal(users, result.Content);
        }
    }
}

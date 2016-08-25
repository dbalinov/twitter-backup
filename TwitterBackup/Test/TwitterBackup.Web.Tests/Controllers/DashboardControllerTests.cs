using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using TwitterBackup.Business.Models;
using TwitterBackup.Business.Services.Users;
using NSubstitute;
using TwitterBackup.Web.Controllers;
using TwitterBackup.Web.Models.User;
using Xunit;

namespace TwitterBackup.Web.Tests.Controllers
{
    public class DashboardControllerTests
    {
        private readonly IUserService userService;
        private readonly DashboardController dashboardController;

        public DashboardControllerTests()
        {
            this.userService = Substitute.For<IUserService>();
            this.dashboardController = new DashboardController(this.userService);
        }

        [Fact]
        public async Task GetDataTest()
        {
            // Arrange 
            var users = new List<DashboardUserModel>();
            this.userService.GetDashboardUsersAsync().Returns(users);
            
            // Act
            var resultRaw = await this.dashboardController.GetData();
            var result = resultRaw as OkNegotiatedContentResult<DashboardResponse>;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Content);
            Assert.NotNull(result.Content.Users);
            Assert.Equal(result.Content.Users, users);
        }
    }
}

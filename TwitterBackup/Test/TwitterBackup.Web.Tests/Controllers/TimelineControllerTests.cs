using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;
using NSubstitute;
using TwitterBackup.Business.Models;
using TwitterBackup.Business.Services.Statuses;
using TwitterBackup.Business.Services.Users;
using TwitterBackup.Infrastructure.Identity.Claims;
using TwitterBackup.Web.Controllers;
using TwitterBackup.Web.Models.Status;
using Xunit;

namespace TwitterBackup.Web.Tests.Controllers
{
    public class TimelineControllerTests
    {
        private readonly IStatusService statusService;
        private readonly IUserService userService;
        private readonly ITwitterClaimsHelper claimsHelper;

        private readonly TimelineController timelineController;

        public TimelineControllerTests()
        {
            this.statusService = Substitute.For<IStatusService>();
            this.userService = Substitute.For<IUserService>(); ;
            this.claimsHelper = Substitute.For<ITwitterClaimsHelper>();

            this.timelineController = new TimelineController(this.statusService, this.userService, this.claimsHelper);
        }

        [Fact]
        public async Task GetTestEmptyRequestShouldThrowException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(
                () => this.timelineController.Get(null));
        }

        [Fact]
        public async Task GetTestInvalidRequestShouldThrowException()
        {
            // Arrange
            var request = new TimelineRequest { UserId = null };

            // Act
            await Assert.ThrowsAsync<ArgumentException>(
                () => this.timelineController.Get(request));
        }

        [Fact]
        public async Task GetWithUserTest()
        {
            // Arrange
            var userId = "userId";
            var request = new TimelineRequest
            {
                UserId = userId,
                SavedOnly = false
            };

            var user = new UserModel();
            this.userService.GetAsync(userId).Returns(user);
            this.statusService.GetUserTimelineAsync(Arg.Any<StatusListParamsModel>())
                .Returns(Enumerable.Empty<StatusModel>());

            // Act
            var resultRaw = await this.timelineController.Get(request);
            var result = resultRaw as OkNegotiatedContentResult<TimelineResponse>;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Content);
            Assert.NotNull(result.Content.User);
            Assert.Equal(user, result.Content.User);
        }

        [Fact]
        public async Task GetWithTrimmedUserTest()
        {
            // Arrange
            var request = new TimelineRequest
            {
                UserId = "userId",
                TrimUser = true,
                SavedOnly = false
            };
            
            this.statusService.GetUserTimelineAsync(Arg.Any<StatusListParamsModel>())
                .Returns(Enumerable.Empty<StatusModel>());

            // Act
            var resultRaw = await this.timelineController.Get(request);
            var result = resultRaw as OkNegotiatedContentResult<TimelineResponse>;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Content);
            Assert.Null(result.Content.User);
        }

        [Fact]
        public async Task GetUserTimelineTest()
        {
            // Arrange
            var request = new TimelineRequest
            {
                UserId = "userId",
                TrimUser = true,
                SavedOnly = false
            };

            var statuses = Enumerable.Empty<StatusModel>();
            this.statusService.GetUserTimelineAsync(Arg.Any<StatusListParamsModel>())
                .Returns(statuses);

            // Act
            var resultRaw = await this.timelineController.Get(request);
            var result = resultRaw as OkNegotiatedContentResult<TimelineResponse>;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Content);
            Assert.NotNull(result.Content.Statuses);
            Assert.Equal(statuses, result.Content.Statuses);
        }

        [Fact]
        public async Task GetSavedOnlyTest()
        {
            // Arrange
            var request = new TimelineRequest
            {
                UserId = "userId",
                TrimUser = true,
                SavedOnly = true
            };

            var statuses = Enumerable.Empty<StatusModel>();
            this.statusService.GetAllSavedAsync(Arg.Any<StatusListParamsModel>())
                .Returns(statuses);

            // Act
            var resultRaw = await this.timelineController.Get(request);
            var result = resultRaw as OkNegotiatedContentResult<TimelineResponse>;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Content);
            Assert.NotNull(result.Content.Statuses);
            Assert.Equal(statuses, result.Content.Statuses);
        }
    }
}

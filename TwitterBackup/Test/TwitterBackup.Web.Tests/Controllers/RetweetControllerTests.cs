using System.Threading.Tasks;
using System.Web.Http.Results;
using NSubstitute;
using TwitterBackup.Business.Services.Statuses;
using TwitterBackup.Web.Controllers;
using TwitterBackup.Web.Models.Status;
using Xunit;

namespace TwitterBackup.Web.Tests.Controllers
{
    public class RetweetControllerTests
    {
        private readonly IStatusService statusService;

        private readonly RetweetController retweetController;
        
        public RetweetControllerTests()
        {
            this.statusService = Substitute.For<IStatusService>();

            this.retweetController = new RetweetController(this.statusService);
        }

        [Fact]
        public async Task PostRewteetTest()
        {
            // Arrange 
            var request = new StatusIdRequest { StatusId = "status id" };

            // Act
            var resultRaw = await this.retweetController.PostRewteet(request);
            var result = resultRaw as OkResult;

            // Assert
            Assert.NotNull(result);
            await this.statusService.Received().RetweetAsync(request.StatusId);
        }
    }
}

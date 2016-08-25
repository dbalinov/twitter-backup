using System.Threading.Tasks;
using System.Web.Http.Results;
using NSubstitute;
using TwitterBackup.Business.Services.Statuses;
using TwitterBackup.Web.Controllers;
using TwitterBackup.Web.Models.Status;
using Xunit;

namespace TwitterBackup.Web.Tests.Controllers
{
    public class StatusStoreControllerTests
    {
        private readonly IStatusService statusService;

        private readonly StatusStoreController statusStoreController;

        public StatusStoreControllerTests()
        {
            this.statusService = Substitute.For<IStatusService>();

            this.statusStoreController = new StatusStoreController(this.statusService);
        }

        [Fact]
        public async Task PostTest()
        {
            // Arrange 
            var request = new StatusIdRequest { StatusId = "id" };

            // Act
            var resultRaw = await this.statusStoreController.Post(request);
            var result = resultRaw as OkResult;

            // Assert
            Assert.NotNull(result);
            await this.statusService.Received().SaveAsync(request.StatusId);
        }

        [Fact]
        public async Task DeleteTest()
        {
            // Arrange 
            var request = new StatusIdRequest { StatusId = "id" };

            // Act
            var resultRaw = await this.statusStoreController.Delete(request);
            var result = resultRaw as OkResult;

            // Assert
            Assert.NotNull(result);
            await this.statusService.Received().UnsaveAsync(request.StatusId);
        }
    }
}

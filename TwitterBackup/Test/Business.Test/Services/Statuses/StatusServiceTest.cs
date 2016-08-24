using System.Threading.Tasks;
using Business.Services.Statuses;
using DataAccess.Entities;
using DataAccess.Repositories.Statuses;
using NSubstitute;
using Xunit;

namespace Business.Test.Services.Statuses
{
    public class StatusServiceTest
    {
        private readonly IStatusRepository statusRepository;
        private readonly IStatusStoreRepository statusStoreRepository;

        private readonly StatusService statusService;

        public StatusServiceTest()
        {
            this.statusRepository = Substitute.For<IStatusRepository>();
            this.statusStoreRepository = Substitute.For<IStatusStoreRepository>();

            this.statusService = new StatusService(this.statusRepository, this.statusStoreRepository);
        }

        //Task<IEnumerable<StatusModel>> GetUserTimelineAsync(StatusListParamsModel statusListParams);

        //Task<IEnumerable<StatusModel>> GetAllSavedAsync(StatusListParamsModel statusListParams);
        
        [Fact]
        public async Task RetweetAsync()
        {
            // Arrange
            const string statusId = "1";

            // Act
            await this.statusService.RetweetAsync(statusId);

            // Assert
            await this.statusRepository.Received().RetweetAsync(statusId);
        }

        [Fact]
        public async Task SaveAsyncTest()
        {
            // Arrange
            const string statusId = "1";
            var status = new Status();

            this.statusRepository.GetAsync(statusId).Returns(Task.FromResult(status));

            // Act
            await this.statusService.SaveAsync(statusId);

            // Assert
            await this.statusStoreRepository.Received().SaveAsync(status);
        }

        [Fact]
        public async Task SaveAsyncNonExistingStatusTest()
        {
            // Arrange
            const string statusId = "1";
            Status status = null;

            this.statusRepository.GetAsync(statusId).Returns(status);

            // Act
            await this.statusService.SaveAsync(statusId);

            // Assert
            await this.statusStoreRepository.DidNotReceive().SaveAsync(status);
        }

        [Fact]
        public async Task UnsaveAsyncTest()
        {
            // Arrange
            string statusId = "1";
            
            // Act
            await this.statusService.UnsaveAsync(statusId);

            // Assert
            await this.statusStoreRepository.Received().UnsaveAsync(statusId);
        }
    }
}

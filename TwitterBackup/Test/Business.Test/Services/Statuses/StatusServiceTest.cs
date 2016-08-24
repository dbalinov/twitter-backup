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

        // TODO: add regions

        // 1. null params
        // 2. null  statuses.
        // 3. valid,  saved status test
        //public async Task<IEnumerable<StatusModel>> GetUserTimelineAsync(StatusListParamsModel statusListParams)
        //{
        //    var mapper = new StatusMapper();
        //    var paramsMapper = new StatusListParamsMapper();
        //    var paramsModel = paramsMapper.Map(statusListParams, new StatusListParams());
        //    var statuses = await this.statusRepository.GetUserTimelineAsync(paramsModel);

        //    var statusModels = statuses
        //        .Select(x => mapper.Map(x, new StatusModel()))
        //        .ToList();

        //    var savedStatusIds = await this.statusStoreRepository.GetSavedStatusIdsAsync();
        //    var savedStatusIdsList = savedStatusIds.ToList();

        //    statusModels.ForEach(x => x.IsSaved = savedStatusIdsList.Contains(x.Id));

        //    return statusModels;
        //}

        // 1. null params test
        // 2. saved statuses null
        // 3. valid, all are saved.
        //public async Task<IEnumerable<StatusModel>> GetAllSavedAsync(StatusListParamsModel statusListParams)
        //{
        //    var mapper = new StatusMapper();
        //    var paramsMapper = new StatusListParamsMapper();
        //    var paramsModel = paramsMapper.Map(statusListParams, new StatusListParams());
        //    var savedStatuses = await this.statusStoreRepository.GetAllSavedAsync(paramsModel);

        //    var statusModels = savedStatuses.Select(x => mapper.Map(x, new StatusModel())).ToList();
        //    statusModels.ForEach(x =>
        //    {
        //        x.IsSaved = true;
        //        x.CreatedAt = x.CreatedAt.ToLocalTime();
        //    });

        //    return statusModels;
        //}

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

using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterBackup.Business.Models;
using TwitterBackup.Business.Services.Statuses;
using TwitterBackup.DataAccess.Entities;
using TwitterBackup.DataAccess.Repositories.Statuses;
using Xunit;

namespace TwitterBackup.Business.Tests.Services.Statuses
{
    public class StatusServiceTests
    {
        private readonly IStatusRepository statusRepository;
        private readonly IStatusStoreRepository statusStoreRepository;

        private readonly StatusService statusService;

        public StatusServiceTests()
        {
            this.statusRepository = Substitute.For<IStatusRepository>();
            this.statusStoreRepository = Substitute.For<IStatusStoreRepository>();

            this.statusService = new StatusService(this.statusRepository, this.statusStoreRepository);
        }

        [Fact]
        public async Task GetUserTimelineAsyncNullArgumentTest()
        {
            // Act
            await Assert.ThrowsAsync<ArgumentNullException>(
                () => this.statusService.GetUserTimelineAsync(null));
        }

        [Fact]
        public async Task GetUserTimelineAsyncTest()
        {
            // Arrange
            var statuses = new List<Status>
            {
                new Status { StatusId = "statusId 1" },
                new Status { StatusId = "statusId 2" }
            };

            this.statusRepository.GetUserTimelineAsync(Arg.Any<StatusListParams>())
                .Returns(statuses);

            this.statusStoreRepository.GetSavedStatusIdsAsync()
                .Returns(new List<string> { "statusId 1" });

            // Act
            var resut = await this.statusService.GetUserTimelineAsync(
                new StatusListParamsModel());

            // Assert
            Assert.NotNull(resut);
            Assert.Equal(resut.Count(), statuses.Count);
            Assert.Equal(resut.First().Id, statuses.First().StatusId);
            Assert.True(resut.First().IsSaved);
            Assert.False(resut.Last().IsSaved);
        }
        
        [Fact]
        public async Task GetAllSavedAsyncNullArgumentTest()
        {
            // Act
            await Assert.ThrowsAsync<ArgumentNullException>(
                () => this.statusService.GetAllSavedAsync(null));
        }

        [Fact]
        public async Task GetAllSavedAsyncTest()
        {
            // Arrange
            var statuses = new List<Status>
            {
                new Status { StatusId = "statusId 1" },
                new Status { StatusId = "statusId 2" }
            };

            this.statusStoreRepository.GetAllSavedAsync(Arg.Any<StatusListParams>())
                .Returns(statuses);

            this.statusStoreRepository.GetSavedStatusIdsAsync()
                .Returns(new List<string> { "statusId 1" });

            // Act
            var resut = await this.statusService.GetAllSavedAsync(
                new StatusListParamsModel());

            // Assert
            Assert.NotNull(resut);
            Assert.Equal(resut.Count(), statuses.Count);
            Assert.Equal(resut.First().Id, statuses.First().StatusId);
            Assert.All(resut, x => Assert.True(x.IsSaved));
        }
        
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

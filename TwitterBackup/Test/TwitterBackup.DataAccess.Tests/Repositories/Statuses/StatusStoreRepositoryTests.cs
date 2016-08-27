using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using TwitterBackup.DataAccess.Repositories.Statuses;
using TwitterBackup.Infrastructure.Identity.Claims;
using System.Web.Configuration;
using MongoDB.Driver;
using TwitterBackup.DataAccess.Entities;
using Xunit;

namespace TwitterBackup.DataAccess.Tests.Repositories.Statuses
{
    public class StatusStoreRepositoryTests
    {
        private readonly ITwitterClaimsHelper claimsHelper;
        private readonly IStatusStoreRepository statusStoreRepository;

        public StatusStoreRepositoryTests()
        {
            var mongoConnectionString = WebConfigurationManager.AppSettings["mongodb:ConnectionString"];
            var mongoClient = new MongoClient(mongoConnectionString);
            var dbContext = new DbContext(mongoClient);

            this.claimsHelper = Substitute.For<ITwitterClaimsHelper>();
            this.statusStoreRepository =new StatusStoreRepository(dbContext, claimsHelper);
        }

        [Fact]
        public async Task CrudTest()
        {
            var statusId = "1";
            var createdById = "2";
            var userId = "74286566";
            var status = new Status {StatusId = statusId, Text = "Text", CreatedById = createdById };
            this.claimsHelper.GetUserId().Returns(userId);

            await this.statusStoreRepository.SaveAsync(status);

            var savedStatusIds = await this.statusStoreRepository.GetSavedStatusIdsAsync();
            Assert.True(savedStatusIds.Contains(statusId));

            var savedByParams = new StatusListParams
            {
                SavedByUserId = claimsHelper.GetUserId(),
                CreatedByUserId = createdById
            };

            var savedPosts = await this.statusStoreRepository.GetAllSavedAsync(savedByParams);
            Assert.True(savedPosts.Select(x => x.StatusId).Contains(statusId));

            var userIds = new List<string> { userId };
            var downloadedStatusesCount = this.statusStoreRepository.GetDownloadStatusCount(userIds)
                .FirstOrDefault(x => x.Item1 == userId)
                .Item2;

            Assert.Equal(downloadedStatusesCount, 1);

            // Count
            await this.statusStoreRepository.UnsaveAsync(statusId);
        }
    }
}

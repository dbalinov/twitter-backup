using System.Linq;
using System.Threading.Tasks;
using System.Web.Configuration;
using NSubstitute;
using Tweetinvi.Models;
using TwitterBackup.DataAccess.Credentials;
using TwitterBackup.DataAccess.Entities;
using TwitterBackup.DataAccess.Repositories.Statuses;
using Xunit;

namespace TwitterBackup.DataAccess.Tests.Repositories.Statuses
{
    public class StatusRepositoryTests
    {
        private readonly StatusRepository statusRepository;

        public StatusRepositoryTests()
        {
            var credentials = new TwitterCredentials(
                WebConfigurationManager.AppSettings["twitter:ConsumerKey"],
                WebConfigurationManager.AppSettings["twitter:ConsumerSecret"],
                "3656340495-Bu8Wak5cCQYXBFKdklhVbvH3AvJXrGRfn3m2YPf",
                "ZfNMcX6JW4lAnaVj6pJ38FZYxM00vcCqHUwCaUurW1hoq");

            var credentialsFactory = Substitute.For<ITwitterCredentialsFactory>();
            credentialsFactory.Create().Returns(credentials);
            this.statusRepository = new StatusRepository(credentialsFactory);
        }

        [Fact]
        public async Task GetAsyncTest()
        {
            // Arrange
            var statusId = "769470778668646400";

            // Act
            var status = await this.statusRepository.GetAsync(statusId);

            // Assert
            Assert.NotNull(status);
            Assert.Equal(statusId, status.StatusId);
            Assert.NotNull(status.Text);
        }

        [Fact]
        public async Task GetUserTimelineAsyncTest()
        {
            // Arrange
            var count = 5;
            var statusListParams = new StatusListParams
            {
                CreatedByUserId = "74286565",
                Count = count,
                MaxId = "768228028291751936"
            };

            // Act
            var statuses = await this.statusRepository.GetUserTimelineAsync(statusListParams);

            // Assert
            Assert.NotNull(statuses);
            Assert.Equal(count, statuses.Count());
        }

        [Fact(Skip = "Tweets on user timeline.")]
        public async Task RetweetAsyncTest()
        {
            // Arrange
            var statusId = "768228028291751936";

            // Act
            await this.statusRepository.RetweetAsync(statusId);

            // Assert
            // View twitter https://twitter.com/dnbalinov
        }

        [Fact]
        public void GetRetweetsCountForUserTest()
        {
            // Arrange
            var userId = "74286565";

            // Act
            var result = this.statusRepository.GetRetweetsCountForUser(userId);

            // Assert
            Assert.True(result > 0);
        }
    }
}

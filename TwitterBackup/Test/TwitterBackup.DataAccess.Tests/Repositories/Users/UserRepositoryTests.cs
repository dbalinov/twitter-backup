using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using TwitterBackup.DataAccess.Credentials;
using TwitterBackup.DataAccess.Repositories.Users;
using Xunit;

namespace TwitterBackup.DataAccess.Tests.Repositories.Users
{
    public class UserRepositoryTests
    {
        private readonly UserRepository userRepository;

        public UserRepositoryTests()
        {
            var credentialsFactory = Substitute.For<ITwitterCredentialsFactory>();
            var credentials = TestUtils.GetCredentials();
            credentialsFactory.Create().Returns(credentials);

            var dbContext = TestUtils.GetDbContext();

            this.userRepository = new UserRepository(credentialsFactory, dbContext);
        }

        [Fact]
        public void SearchTest()
        {
            // Arrange
            var query = "dnbalinov";

            // Act
            var result = this.userRepository.Search(query);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Any());
        }

        [Fact]
        public void GetUsersFromIdsTest()
        {
            // Arrange
            var userIds = new List<string> { "3656340495" };

            // Act
            var result = this.userRepository.GetUsersFromIds(userIds);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result.Count(), 1);
            Assert.Equal(result.First().Id, userIds[0]);
        }

        [Fact]
        public async Task GetFriendsAsyncTest()
        {
            // Arrange
            var userId = "3656340495";

            // Act
            var result = await this.userRepository.GetFriendsAsync(userId);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Any());
        }
        
        [Fact]
        public async Task GetAsyncTest()
        {
            // Arrange
            var userId =  "3656340495";

            // Act
            var result = await this.userRepository.GetAsync(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result.Id, userId);
        }
    }
}

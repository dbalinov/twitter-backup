using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using TwitterBackup.DataAccess.Entities;
using TwitterBackup.DataAccess.Repositories.Users;
using TwitterBackup.DataAccess.Repositories.Statuses;
using TwitterBackup.Business.Services.Users;
using TwitterBackup.Infrastructure.Identity.Claims;
using Xunit;

namespace TwitterBackup.Business.Tests.Services.Users
{
    public class UserServiceTests
    {
        private readonly IUserRepository userRepository;
        private readonly IFavoriteUserRepository favoriteUserRepository;
        private readonly IStatusStoreRepository statusStoreRepository;
        private readonly IStatusRepository statusRepository;
        private readonly ITwitterClaimsHelper claimsHelper;

        private readonly IUserService userService;

        public UserServiceTests()
        {
            this.userRepository = Substitute.For<IUserRepository>();
            this.favoriteUserRepository = Substitute.For<IFavoriteUserRepository>();
            this.statusStoreRepository = Substitute.For<IStatusStoreRepository>();
            this.statusRepository = Substitute.For<IStatusRepository>();
            this.claimsHelper = Substitute.For<ITwitterClaimsHelper>();

            this.userService = new UserService(
                userRepository,
                favoriteUserRepository,
                statusStoreRepository,
                statusRepository,
                claimsHelper);
        }

        [Fact]
        public async Task GetAsyncTest()
        {
            // Arrange
            var userId = "userId";
            var user = new User {Id = "userId 1"};

            SetupFavoriteUserIds();

            this.userRepository.GetAsync(userId).Returns(user);

            // Act
            var result = await this.userService.GetAsync(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Id, result.Id);
            Assert.True(result.IsFavorite);
        }

        [Fact]
        public async Task SearchAsyncTest()
        {
            // Arrange
            var query = "query";
            var users = new List<User>
            {
                new User {Id = "userId 1"},
                new User {Id = "userId 2"}
            };

            SetupFavoriteUserIds();

            this.userRepository.Search(query).Returns(users);

            // Act
            var result = await this.userService.SearchAsync(query);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Count() == 2);
            Assert.Equal(users.First().Id, result.First().Id);
            Assert.Equal(users.ElementAt(1).Id, result.ElementAt(1).Id);
            Assert.True(result.First().IsFavorite);
        }
        
        [Fact]
        public async Task GetRecommendedUsersAsyncTest()
        {
            // Arrange
            var userId = "userId";
            var users = new List<User>
            {
                new User {Id = "userId 1"},
                new User {Id = "userId 2"}
            };

            SetupFavoriteUserIds();

            this.claimsHelper.GetUserId().Returns(userId);
            this.userRepository.GetFriendsAsync(userId).Returns(users);
            

            // Act
            var result = await this.userService.GetRecommendedUsersAsync();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Count() == 1);
            Assert.All(result, x => Assert.False(x.IsFavorite));
        }

        [Fact]
        public async Task RegisterUserAsyncTest()
        {
            // Arrange
            var userId = "user id";

            // Act
            await this.userService.RegisterUserAsync(userId);

            // Assert
            await this.userRepository.Received().RegisterUserAsync(userId);
        }

        [Fact]
        public async Task GetDashboardUsersAsyncTest()
        {
            // Arrange
            var userId1 = "userId 1";
            var userId2 = "userId 2";
            var userRegisteres = new List<UserRegister>
            {
                new UserRegister { UserId = userId1 },
                new UserRegister { UserId = userId2 }
            };

            var users = new List<User>
            {
                new User { Id = userId1 },
                new User { Id = userId2 }
            };
            
            this.userRepository.GetRegisterUsersAsync().Returns(userRegisteres);
            this.userRepository.GetUsersFromIds(Arg.Any<IEnumerable<string>>()).Returns(users);

            this.userRepository.GetFavoriteUserCount(Arg.Any<IEnumerable<string>>())
                .Returns(new List<Tuple<string, int>>
                {
                    Tuple.Create(userId1, 1),
                    Tuple.Create(userId2, 2)
                });

            this.statusStoreRepository.GetDownloadStatusCount(Arg.Any<IEnumerable<string>>())
                .Returns(new List<Tuple<string, int>>
                {
                    Tuple.Create(userId1, 3),
                    Tuple.Create(userId2, 4)
                });

            this.statusRepository.GetRetweetsCountForUser(userId2).Returns(201);

            // Act
            var result = await this.userService.GetDashboardUsersAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result.Count, 2);
            Assert.Equal(result.First().FavoriteUsersCount, 1);
            Assert.Equal(result.ElementAt(1).FavoriteUsersCount, 2);
            Assert.Equal(result.First().DownloadsCount, 3);
            Assert.Equal(result.ElementAt(1).DownloadsCount, 4);
            Assert.True(result.First().RetweetsCountIsAccurate);
            Assert.False(result.ElementAt(1).RetweetsCountIsAccurate);
        }
        
        private void SetupFavoriteUserIds()
        {
            var currentUserId = "userId";
            claimsHelper.GetUserId().Returns(currentUserId);
            var userIds = new List<string> {"userId 1"};
            this.favoriteUserRepository.GetFavoriteUserIds(currentUserId).Returns(userIds);
        }
    }
}

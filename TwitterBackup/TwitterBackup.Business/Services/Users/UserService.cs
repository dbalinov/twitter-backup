using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterBackup.Business.Models;
using TwitterBackup.Business.Models.Mapping;
using TwitterBackup.DataAccess.Repositories.Users;
using TwitterBackup.Infrastructure.Identity.Claims;
using TwitterBackup.DataAccess.Repositories.Statuses;

namespace TwitterBackup.Business.Services.Users
{
    internal class UserService : IUserService
    {
        private const int CountOfRecommendedUsers = 9;

        private readonly IUserRepository userRepository;
        private readonly IFavoriteUserRepository favoriteUserRepository;
        private readonly IStatusStoreRepository statusStoreRepository;
        private readonly IStatusRepository statusRepository;
        private readonly ITwitterClaimsHelper claimsHelper;

        public UserService(
            IUserRepository userRepository, 
            IFavoriteUserRepository favoriteUserRepository,
            IStatusStoreRepository statusStoreRepository,
            IStatusRepository statusRepository,
            ITwitterClaimsHelper claimsHelper)
        {
            this.userRepository = userRepository;
            this.favoriteUserRepository = favoriteUserRepository;
            this.statusStoreRepository = statusStoreRepository;
            this.statusRepository = statusRepository;
            this.claimsHelper = claimsHelper;
        }

        public async Task<UserModel> GetAsync(string userId)
        {
            var favoriteUserIds = await FavoriteUserIds();

            var mapper = new UserMapper();
            var user = await this.userRepository.GetAsync(userId);

            var userModel = mapper.Map(user, new UserModel());
            userModel.IsFavorite = favoriteUserIds.Contains(user.Id);
            return userModel;
        }

        public async Task<IEnumerable<UserModel>> SearchAsync(string query)
        {
            var favoriteUserIds = await FavoriteUserIds();

            var mapper = new UserMapper();
            var users = this.userRepository.Search(query);
            var result = users.Select(user => mapper.Map(user, new UserModel())).ToList();

            result.ForEach(user => user.IsFavorite = favoriteUserIds.Contains(user.Id));

            return result;
        }

        public async Task<IEnumerable<UserModel>> GetRecommendedUsersAsync()
        {
            var favoriteUserIds = await FavoriteUserIds();

            var mapper = new UserMapper();
            var userId = claimsHelper.GetUserId();
            var users = await this.userRepository.GetFriendsAsync(userId);

            var result = users
                .Where(user => !favoriteUserIds.Contains(user.Id))
                .OrderBy(x => Guid.NewGuid()) // Randomize
                .Take(CountOfRecommendedUsers)
                .Select(user => mapper.Map(user, new UserModel())).ToList();
            
            return result;
        }

        private async Task<List<string>> FavoriteUserIds()
        {
            var currentUserId = claimsHelper.GetUserId();
            var favoriteUserIds = await this.favoriteUserRepository
                .GetFavoriteUserIds(currentUserId);
            var favoriteUserIdsList = favoriteUserIds.ToList();
            return favoriteUserIdsList;
        }

        public Task RegisterUserAsync(string userId)
        {
            return this.userRepository.RegisterUserAsync(userId);
        }

        public async Task<IList<DashboardUserModel>> GetDashboardUsersAsync()
        {
            var mapper = new UserMapper();
            var registerUsers = await this.userRepository.GetRegisterUsersAsync();
            var userIds = registerUsers.Select(x => x.UserId).ToList();

            var users = this.userRepository.GetUsersFromIds(userIds);

            var userModels = users
                .Select(x => mapper.Map(x, new DashboardUserModel()))
                .ToList();

            var favoriteUserCount = this.userRepository.GetFavoriteUserCount(userIds);
            var downloadStatusCount = this.statusStoreRepository.GetDownloadStatusCount(userIds);

            userModels.ForEach(user =>
            {
                var userCount = favoriteUserCount.FirstOrDefault(x => x.Item1 == user.Id);
                if (userCount != null)
                {
                    user.FavoriteUsersCount = userCount.Item2;
                }

                var statusCount = downloadStatusCount.FirstOrDefault(x => x.Item1 == user.Id);
                if (statusCount != null)
                {
                    user.DownloadsCount = statusCount.Item2;
                }
                
                user.RetweetsCount = this.statusRepository.GetRetweetsCountForUser(user.Id);
                user.RetweetsCountIsAccurate = user.RetweetsCount < 200;
            });

            return userModels;
        }
    }
}

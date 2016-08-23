using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Models;
using Business.Models.Mapping;
using DataAccess.Repositories.Users;
using Infrastructure.Identity.Claims;

namespace Business.Services.Users
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IFavoriteUserRepository favoriteUserRepository;
        private readonly ITwitterClaimsHelper claimsHelper;

        public UserService(
            IUserRepository userRepository, 
            IFavoriteUserRepository favoriteUserRepository,
            ITwitterClaimsHelper claimsHelper)
        {
            this.userRepository = userRepository;
            this.favoriteUserRepository = favoriteUserRepository;
            this.claimsHelper = claimsHelper;
        }

        public async Task<UserModel> GetAsync(string userId)
        {
            var mapper = new UserMapper();
            var user = await this.userRepository.GetAsync(userId);
            return mapper.Map(user, new UserModel());
        }

        public async Task<IEnumerable<UserModel>> SearchAsync(string query)
        {
            var currentUserId = claimsHelper.GetUserId();
            var favoriteUserIds = await this.favoriteUserRepository
                .GetFavoriteUserIds(currentUserId);
            var favoriteUserIdsList = favoriteUserIds.ToList();

            var mapper = new UserMapper();
            var users = this.userRepository.Search(query);
            var result = users.Select(user => mapper.Map(user, new UserModel())).ToList();

            result.ForEach(user => user.IsFavorite = favoriteUserIdsList.Contains(user.Id));

            return result;
        }

        public Task RegisterUserAsync(string userId)
        {
            return this.userRepository.RegisterUserAsync(userId);
        }
    }
}

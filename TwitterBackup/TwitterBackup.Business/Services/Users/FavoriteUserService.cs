using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Models;
using Business.Models.Mapping;
using DataAccess.Entities;
using DataAccess.Repositories.Users;

namespace Business.Services.Users
{
    internal class FavoriteUserService : IFavoriteUserService
    {
        private readonly IFavoriteUserRepository favoriteUserRepository;
        private readonly IUserRepository userRepository;

        public FavoriteUserService(IFavoriteUserRepository favoriteUserRepository, IUserRepository userRepository)
        {
            this.favoriteUserRepository = favoriteUserRepository;
            this.userRepository = userRepository;
        }

        public async Task<IEnumerable<UserModel>> GetFavoriteUsers(string sourceUserId)
        {
            var userIds = await this.favoriteUserRepository.GetFavoriteUserIds(sourceUserId);

            var mapper = new UserMapper();
            var favoriteUsers = this.userRepository.GetUsersFromIds(userIds);

            var favoriteUserModels = favoriteUsers
                .Select(user => mapper.Map(user, new UserModel()))
                .ToList();

            favoriteUserModels.ForEach(x => x.IsFavorite = true);

            return favoriteUserModels;
        }

        public async Task AddAsync(FavoriteUserRelationModel relationModel)
        {
            var mapper = new FavoriteUserRelationMapper();
            var relation = mapper.Map(relationModel, new FavoriteUserRelation());
            await this.favoriteUserRepository.AddAsync(relation);
        }

        public async Task RemoveAsync(FavoriteUserRelationModel relationModel)
        {
            var mapper = new FavoriteUserRelationMapper();
            var relation = mapper.Map(relationModel, new FavoriteUserRelation());
            await this.favoriteUserRepository.RemoveAsync(relation);
        }
    }
}

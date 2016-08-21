using System.Threading.Tasks;
using Business.Models;
using Business.Models.Mapping;
using DataAccess.Entities;
using DataAccess.Repositories.Users;

namespace Business.Services.Users
{
    public class FavoriteUserService : IFavoriteUserService
    {
        private readonly IFavoriteUserRepository favoriteUserRepository;

        public FavoriteUserService(IFavoriteUserRepository favoriteUserRepository)
        {
            this.favoriteUserRepository = favoriteUserRepository;
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

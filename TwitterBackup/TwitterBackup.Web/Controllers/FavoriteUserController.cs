using System.Web.Http;
using TwitterBackup.Business.Models;
using TwitterBackup.Business.Services.Users;
using System.Threading.Tasks;
using TwitterBackup.Infrastructure.Identity.Claims;
using TwitterBackup.Web.Messages.User;

namespace TwitterBackup.Web.Controllers
{
    [Authorize]
    public class FavoriteUserController : ApiController
    {
        private readonly IFavoriteUserService favoriteUserService;
        private readonly ITwitterClaimsHelper claimsHelper;

        public FavoriteUserController(IFavoriteUserService favoriteUserService, ITwitterClaimsHelper claimsHelper)
        {
            this.favoriteUserService = favoriteUserService;
            this.claimsHelper = claimsHelper;
        }

        public async Task<IHttpActionResult> GetFavoriteUsers()
        {
            var userId = claimsHelper.GetUserId();
            var users = await this.favoriteUserService.GetFavoriteUsers(userId);

            return Ok(users);
        }

        public async Task<IHttpActionResult> Put(FavoriteUserRequest request)
        {
            var relation = GetRelation(request);

            await this.favoriteUserService.AddAsync(relation);

            return Ok();
        }

        public async Task<IHttpActionResult> Delete([FromUri]FavoriteUserRequest request)
        {
            var relation = GetRelation(request);

            await this.favoriteUserService.RemoveAsync(relation);

            return Ok();
        }

        private FavoriteUserRelationModel GetRelation(FavoriteUserRequest request)
        {
            return new FavoriteUserRelationModel
            {
                SourceUserId = claimsHelper.GetUserId(),
                TargetUserId = request.UserId
            };
        }
    }
}


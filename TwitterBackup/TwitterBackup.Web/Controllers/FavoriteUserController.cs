using System.Web.Http;
using Business.Models;
using Business.Services.Users;
using System.Threading.Tasks;
using Infrastructure.Identity.Claims;
using TwitterBackup.Web.Messages.FavoriteUser;

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


using System.Collections.Generic;
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
        private readonly IFriendService friendService;
        private readonly IFavoriteUserService favoriteUserService;
        private readonly ITwitterClaimsHelper claimsHelper;

        public FavoriteUserController(IFriendService friendService, IFavoriteUserService favoriteUserService, ITwitterClaimsHelper claimsHelper)
        {
            this.friendService = friendService;
            this.favoriteUserService = favoriteUserService;
            this.claimsHelper = claimsHelper;
        }

        public IEnumerable<UserModel> GetFavoriteUsers()
        {
            var users = this.friendService.GetAll();
            return users;
        }

        public async Task<IHttpActionResult> Put(FavoriteUserRequest request)
        {
            var relation = GetRelation(request);

            await this.favoriteUserService.AddAsync(relation);

            return Ok();
        }

        public async Task<IHttpActionResult> Delete(FavoriteUserRequest request)
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


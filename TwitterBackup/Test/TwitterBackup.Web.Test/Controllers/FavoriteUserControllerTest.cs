using Business.Services.Users;
using NSubstitute;
using TwitterBackup.Web.Controllers;
using TwitterBackup.Infrastructure.Identity.Claims;

namespace TwitterBackup.Web.Test.Controllers
{
    public class FavoriteUserControllerTest
    {
        private readonly IFavoriteUserService favoriteUserService;
        private readonly ITwitterClaimsHelper claimsHelper;

        private readonly FavoriteUserController dashboardController;
  

        public FavoriteUserControllerTest()
        {
            this.favoriteUserService = Substitute.For<IFavoriteUserService>();
            this.claimsHelper = Substitute.For<ITwitterClaimsHelper>();

            this.dashboardController = new FavoriteUserController(this.favoriteUserService, this.claimsHelper);
        }


        //public async Task<IHttpActionResult> GetFavoriteUsers()
        //{
        //    var userId = claimsHelper.GetUserId();
        //    var users = await this.favoriteUserService.GetFavoriteUsers(userId);

        //    return Ok(users);
        //}

        //public async Task<IHttpActionResult> Put(FavoriteUserRequest request)
        //{
        //    var relation = GetRelation(request);

        //    await this.favoriteUserService.AddAsync(relation);

        //    return Ok();
        //}

        //public async Task<IHttpActionResult> Delete([FromUri]FavoriteUserRequest request)
        //{
        //    var relation = GetRelation(request);

        //    await this.favoriteUserService.RemoveAsync(relation);

        //    return Ok();
        //}

        //private FavoriteUserRelationModel GetRelation(FavoriteUserRequest request)
        //{
        //    return new FavoriteUserRelationModel
        //    {
        //        SourceUserId = claimsHelper.GetUserId(),
        //        TargetUserId = request.UserId
        //    };
        //}
    }
}

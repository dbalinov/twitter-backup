using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using NSubstitute;
using TwitterBackup.Business.Models;
using TwitterBackup.Business.Services.Users;
using TwitterBackup.Infrastructure.Identity.Claims;
using TwitterBackup.Web.Controllers;
using TwitterBackup.Web.Models.User;
using Xunit;

namespace TwitterBackup.Web.Tests.Controllers
{
    public class FavoriteUserControllerTests
    {
        private readonly IFavoriteUserService favoriteUserService;
        private readonly ITwitterClaimsHelper claimsHelper;

        private readonly FavoriteUserController dashboardController;
  

        public FavoriteUserControllerTests()
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

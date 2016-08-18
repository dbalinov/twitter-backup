using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Business.Models;
using Business.Services.Users;

namespace TwitterBackup.Web.Controllers
{
    [Authorize]
    public class FriendsController : ApiController
    {
        private IFavoriteUserService favoriteUserService;

        public FriendsController(IFavoriteUserService favoriteUserService)
        {
            this.favoriteUserService = favoriteUserService;
        }

        public IEnumerable<UserModel> Get()
        {
            var users = this.favoriteUserService.GetAll();
            return users;
        }

        public IHttpActionResult Put(FriendshipModel friendship)
        {
            this.favoriteUserService.UpdateFriendship(
                friendship.ScreenName,
                friendship.Notifications);
            return Ok();
        }

        public class FriendshipModel
        {
            public string ScreenName { get; set; }
            public bool Notifications { get; set; }
        }
    }
}


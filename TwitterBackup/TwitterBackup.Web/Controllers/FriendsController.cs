using System.Collections.Generic;
using System.Web.Http;
using Business.Models;
using Business.Services.Users;

namespace TwitterBackup.Web.Controllers
{
    [Authorize]
    public class FriendsController : ApiController
    {
        private readonly IFavoriteUserService favoriteUserService;

        public FriendsController(IFavoriteUserService favoriteUserService)
        {
            this.favoriteUserService = favoriteUserService;
        }

        public IEnumerable<UserModel> Get()
        {
            var users = this.favoriteUserService.GetAll();
            return users;
        }
    }
}


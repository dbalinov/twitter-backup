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
        private readonly IFavoriteUserService favoriteUserService;

        public FriendsController(IFavoriteUserService favoriteUserService)
        {
            this.favoriteUserService = favoriteUserService;
        }

        public async Task<IEnumerable<UserModel>> Get()
        {
            var users = await this.favoriteUserService.GetAllAsync();
            return users;
        }
    }
}


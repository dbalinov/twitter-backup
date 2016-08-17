using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Business.Models;
using Business.Services.Users;

namespace TwitterBackup.Web.Controllers
{
    public class FriendsController : ApiController
    {
        private IFavoriteUserService favoriteUserService;

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

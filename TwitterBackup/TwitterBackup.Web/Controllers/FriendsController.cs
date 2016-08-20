using System.Collections.Generic;
using System.Web.Http;
using Business.Models;
using Business.Services.Users;

namespace TwitterBackup.Web.Controllers
{
    [Authorize]
    public class FriendsController : ApiController
    {
        private readonly IFriendService friendService;

        public FriendsController(IFriendService friendService)
        {
            this.friendService = friendService;
        }

        public IEnumerable<UserModel> Get()
        {
            var users = this.friendService.GetAll();
            return users;
        }
    }
}


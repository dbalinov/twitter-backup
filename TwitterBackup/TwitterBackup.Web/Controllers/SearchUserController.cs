using Business.Services.Users;
using System.Web.Http;
using TwitterBackup.Web.Messages.SearchUser;

namespace TwitterBackup.Web.Controllers
{
    public class SearchUserController : ApiController
    {
        private readonly IUserService userService;

        public SearchUserController(IUserService userService)
        {
            this.userService = userService;
        }

        public IHttpActionResult PostSearch(SearchUserRequest request)
        {
            var users = this.userService.Search(request.Query);
            return Ok(users);
        }
    }
}
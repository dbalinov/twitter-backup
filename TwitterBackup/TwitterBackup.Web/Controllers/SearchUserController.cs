using System.Threading.Tasks;
using System.Web.Http;
using TwitterBackup.Business.Services.Users;
using TwitterBackup.Web.Models.User;

namespace TwitterBackup.Web.Controllers
{
    [Authorize]
    public class SearchUserController : ApiController
    {
        private readonly IUserService userService;

        public SearchUserController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IHttpActionResult> PostSearch(SearchUserRequest request)
        {
            var users = await this.userService.SearchAsync(request.Query);
            return Ok(users);
        }
    }
}
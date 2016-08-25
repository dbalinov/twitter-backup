using System.Web.Http;
using TwitterBackup.Business.Services.Users;
using TwitterBackup.Web.Messages.User;
using System.Threading.Tasks;

namespace TwitterBackup.Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class DashboardController : ApiController
    {
        private readonly IUserService userService;

        public DashboardController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IHttpActionResult> GetData()
        {
            var data = new DashboardResponse
            {
                Users = await userService.GetDashboardUsersAsync()
            };

            return Ok(data);
        }
    }
}

using System.Threading.Tasks;
using System.Web.Http;
using TwitterBackup.Business.Services.Statuses;
using TwitterBackup.Web.Messages.Status;

namespace TwitterBackup.Web.Controllers
{
    [Authorize]
    public class RetweetController : ApiController
    {
        private readonly IStatusService statusService;

        public RetweetController(IStatusService statusService)
        {
            this.statusService = statusService;
        }

        public async Task<IHttpActionResult> PostRewteet(StatusIdRequest request)
        {
            await this.statusService.RetweetAsync(request.StatusId);

            return Ok();
        }
    }
}

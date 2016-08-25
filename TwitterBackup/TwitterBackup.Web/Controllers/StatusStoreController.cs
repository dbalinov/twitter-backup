using System.Threading.Tasks;
using System.Web.Http;
using TwitterBackup.Business.Services.Statuses;
using TwitterBackup.Web.Models.Status;

namespace TwitterBackup.Web.Controllers
{
    [Authorize]
    public class StatusStoreController : ApiController
    {
        private readonly IStatusService statusService;

        public StatusStoreController(IStatusService statusService)
        {
            this.statusService = statusService;
        }

        public async Task<IHttpActionResult> Post(StatusIdRequest request)
        {
            await this.statusService.SaveAsync(request.StatusId);
            return Ok();
        }

        public async Task<IHttpActionResult> Delete([FromUri]StatusIdRequest request)
        {
            await this.statusService.UnsaveAsync(request.StatusId);
            return Ok();
        }
    }
}

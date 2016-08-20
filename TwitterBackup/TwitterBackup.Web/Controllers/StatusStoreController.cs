using System.Threading.Tasks;
using System.Web.Http;
using Business.Services.Statuses;
using TwitterBackup.Web.Messages;

namespace TwitterBackup.Web.Controllers
{
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

using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Business.Models;
using Business.Services.Statuses;
using Business.Services.Users;
using TwitterBackup.Web.Messages.Timeline;

namespace TwitterBackup.Web.Controllers
{
    [Authorize]
    public class TimelineController : ApiController
    {
        private readonly IStatusService statusService;
        private readonly IUserService userService;

        public TimelineController(IStatusService statusService, IUserService userService)
        {
            this.statusService = statusService;
            this.userService = userService;
        }

        public async Task<IHttpActionResult> Get([FromUri]TimelineRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentException(
                    "TimelineRequest.UserId is required.");
            }

            var userTask = request.TrimUser 
                ? Task.FromResult((UserModel)null)
                : this.userService.GetAsync(request.UserId);

            var statusesTask = request.SavedOnly 
                ? this.statusService.GetAllSavedAsync(request.UserId, request.MaxId)
                : this.statusService.GetUserTimelineAsync(request.UserId, request.MaxId);

            await Task.WhenAll(userTask, statusesTask);

            var response = new TimelineResponse
            {
                User = userTask.Result,
                Statuses = statusesTask.Result
            };

            return Ok(response);
        }
    }
}

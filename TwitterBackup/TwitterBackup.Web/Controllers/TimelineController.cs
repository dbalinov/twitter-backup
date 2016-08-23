using System;
using System.Threading.Tasks;
using System.Web.Http;
using Business.Models;
using Business.Services.Statuses;
using Business.Services.Users;
using Infrastructure.Identity.Claims;
using TwitterBackup.Web.Messages.Timeline;

namespace TwitterBackup.Web.Controllers
{
    [Authorize]
    public class TimelineController : ApiController
    {
        private readonly IStatusService statusService;
        private readonly IUserService userService;
        private readonly ITwitterClaimsHelper claimsHelper;

        public TimelineController(IStatusService statusService, IUserService userService, ITwitterClaimsHelper claimsHelper)
        {
            this.statusService = statusService;
            this.userService = userService;
            this.claimsHelper = claimsHelper;
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

            var statusListParams = new StatusListParamsModel
            {
                SavedByUserId = this.claimsHelper.GetUserId(),
                CreatedByUserId = request.UserId,
                MaxId = request.MaxId,
                Count = request.Count
            };

            var statusesTask = request.SavedOnly 
                ? this.statusService.GetAllSavedAsync(statusListParams)
                : this.statusService.GetUserTimelineAsync(statusListParams);

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

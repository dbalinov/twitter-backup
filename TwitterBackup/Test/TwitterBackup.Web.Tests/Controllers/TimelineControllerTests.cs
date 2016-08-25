using TwitterBackup.Business.Services.Statuses;
using TwitterBackup.Business.Services.Users;
using TwitterBackup.Infrastructure.Identity.Claims;
using NSubstitute;
using TwitterBackup.Web.Controllers;

namespace TwitterBackup.Web.Tests.Controllers
{
    public class TimelineControllerTests
    {
        private readonly IStatusService statusService;
        private readonly IUserService userService;
        private readonly ITwitterClaimsHelper claimsHelper;

        private readonly TimelineController timelineController;

        public TimelineControllerTests()
        {
            this.statusService = Substitute.For<IStatusService>();
            this.userService = Substitute.For<IUserService>(); ;
            this.claimsHelper = Substitute.For<ITwitterClaimsHelper>();

            this.timelineController = new TimelineController(this.statusService, this.userService, this.claimsHelper);
        }
    }
}

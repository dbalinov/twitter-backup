using TwitterBackup.Business.Services.Statuses;
using TwitterBackup.Web.Controllers;
using NSubstitute;

namespace TwitterBackup.Web.Tests.Controllers
{
    public class RetweetControllerTests
    {
        private readonly IStatusService statusService;

        private readonly RetweetController retweetController;
        
        public RetweetControllerTests()
        {
            this.statusService = Substitute.For<IStatusService>();

            this.retweetController = new RetweetController(this.statusService);
        }
    }
}

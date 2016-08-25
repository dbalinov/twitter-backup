using Business.Services.Statuses;
using TwitterBackup.Web.Controllers;
using NSubstitute;

namespace TwitterBackup.Web.Test.Controllers
{
    public class RetweetControllerTest
    {
        private readonly IStatusService statusService;

        private readonly RetweetController retweetController;
        
        public RetweetControllerTest()
        {
            this.statusService = Substitute.For<IStatusService>();

            this.retweetController = new RetweetController(this.statusService);
        }
    }
}

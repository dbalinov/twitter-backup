using Business.Services.Statuses;
using NSubstitute;
using TwitterBackup.Web.Controllers;

namespace TwitterBackup.Web.Tests.Controllers
{
    public class StatusStoreControllerTest
    {
        private readonly IStatusService statusService;

        private readonly StatusStoreController statusStoreController;

        public StatusStoreControllerTest()
        {
            this.statusService = Substitute.For<IStatusService>();

            this.statusStoreController = new StatusStoreController(this.statusService);
        }
    }
}

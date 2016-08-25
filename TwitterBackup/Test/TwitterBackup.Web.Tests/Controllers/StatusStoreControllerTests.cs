using TwitterBackup.Business.Services.Statuses;
using NSubstitute;
using TwitterBackup.Web.Controllers;

namespace TwitterBackup.Web.Tests.Controllers
{
    public class StatusStoreControllerTests
    {
        private readonly IStatusService statusService;

        private readonly StatusStoreController statusStoreController;

        public StatusStoreControllerTests()
        {
            this.statusService = Substitute.For<IStatusService>();

            this.statusStoreController = new StatusStoreController(this.statusService);
        }
    }
}

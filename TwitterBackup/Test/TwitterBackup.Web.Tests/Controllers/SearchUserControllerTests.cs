using TwitterBackup.Business.Services.Users;
using NSubstitute;
using TwitterBackup.Web.Controllers;

namespace TwitterBackup.Web.Tests.Controllers
{
    public class SearchUserControllerTests
    {
        private readonly IUserService userService;

        private readonly SearchUserController searchUserController;

        public SearchUserControllerTests()
        {
            this.userService = Substitute.For<IUserService>(); ;

            this.searchUserController = new SearchUserController(this.userService);
        }
    }
}

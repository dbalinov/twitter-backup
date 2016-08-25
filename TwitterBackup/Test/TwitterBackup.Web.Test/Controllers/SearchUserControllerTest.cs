using Business.Services.Users;
using NSubstitute;
using TwitterBackup.Web.Controllers;

namespace TwitterBackup.Web.Test.Controllers
{
    public class SearchUserControllerTest
    {
        private readonly IUserService userService;

        private readonly SearchUserController searchUserController;

        public SearchUserControllerTest()
        {
            this.userService = Substitute.For<IUserService>(); ;

            this.searchUserController = new SearchUserController(this.userService);
        }
    }
}

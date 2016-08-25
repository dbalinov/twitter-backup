using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using TwitterBackup.DataAccess.Repositories.Users;
using TwitterBackup.DataAccess.Repositories.Statuses;
using TwitterBackup.Business.Services.Users;
using TwitterBackup.Infrastructure.Identity.Claims;

namespace TwitterBackup.Business.Tests.Services.Users
{
    public class UserServiceTests
    {
        private readonly IUserRepository userRepository;
        private readonly IFavoriteUserRepository favoriteUserRepository;
        private readonly IStatusStoreRepository statusStoreRepository;
        private readonly IStatusRepository statusRepository;
        private readonly ITwitterClaimsHelper claimsHelper;

        private readonly IUserService userService;

        public UserServiceTests()
        {
            this.userRepository = Substitute.For<IUserRepository>();
            this.favoriteUserRepository = Substitute.For<IFavoriteUserRepository>();
            this.statusStoreRepository = Substitute.For<IStatusStoreRepository>();
            this.statusRepository = Substitute.For<IStatusRepository>();
            this.claimsHelper = Substitute.For<ITwitterClaimsHelper>();

            this.userService = new UserService(
                userRepository,
                favoriteUserRepository,
                statusStoreRepository,
                statusRepository,
                claimsHelper);
        }

    }
}

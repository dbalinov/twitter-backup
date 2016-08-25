using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using TwitterBackup.Business.Services.Users;
using TwitterBackup.DataAccess.Repositories.Users;

namespace TwitterBackup.Business.Tests.Services.Users
{
    public class FavoriteUserServiceTests
    {
        private readonly IFavoriteUserRepository favoriteUserRepository;
        private readonly IUserRepository userRepository;

        private readonly IFavoriteUserService favoriteUserService;

        public FavoriteUserServiceTests()
        {
            this.favoriteUserRepository = Substitute.For<IFavoriteUserRepository>();
            this.userRepository = Substitute.For<IUserRepository>();

            this.favoriteUserService = new FavoriteUserService(this.favoriteUserRepository, this.userRepository);
        }
    }
}

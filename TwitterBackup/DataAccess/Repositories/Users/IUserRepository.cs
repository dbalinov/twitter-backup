using System.Collections.Generic;

namespace DataAccess.Repositories.Users
{
    public interface IUserRepository
    {
        IEnumerable<Entities.User> GetUsersFromIds(IEnumerable<string> ids);
    }
}

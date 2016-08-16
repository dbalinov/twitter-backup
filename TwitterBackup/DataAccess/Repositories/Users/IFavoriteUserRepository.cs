using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repositories.Users
{
    public interface IFavoriteUserRepository
    {
        IEnumerable<User> GetAll();
    }
}

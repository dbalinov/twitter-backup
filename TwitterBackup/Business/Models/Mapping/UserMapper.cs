using DataAccess.Entities;

namespace Business.Models.Mapping
{
    public class UserMapper
    {
        public UserModel Map(User from, UserModel to)
        {
            to.Name = from.Name;

            return to;
        }
    }
}

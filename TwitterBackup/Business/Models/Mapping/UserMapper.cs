using DataAccess.Entities;

namespace Business.Models.Mapping
{
    public class UserMapper
    {
        public UserModel Map(User from, UserModel to)
        {
            to.Id = from.Id;
            to.Name = from.Name;
            to.Description = from.Description;
            to.Notifications = from.Notifications;
            to.ProfileImageUrl = from.ProfileImageUrl;

            return to;
        }
    }
}

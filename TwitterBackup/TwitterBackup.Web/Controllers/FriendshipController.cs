using System.Web.Http;
using Business.Services.Users;
using System.Threading.Tasks;
using TwitterBackup.Web.Messages.Friendship;

namespace TwitterBackup.Web.Controllers
{
    public class FriendshipController : ApiController
    {
        private readonly IFriendshipService friendshipService;

        public FriendshipController(IFriendshipService friendshipService)
        {
            this.friendshipService = friendshipService;
        }

        public async Task<IHttpActionResult> Put(FriendshipUpdateRequest request)
        {
            var friendship = await this.friendshipService.GetAsync(request.ScreenName);
            friendship.NotificationsEnabled = request.Notifications;
            await this.friendshipService.UpdateAsync(friendship);

            return Ok();
        }
    }
}

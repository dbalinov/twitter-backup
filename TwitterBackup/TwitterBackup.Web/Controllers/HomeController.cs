using System.Linq;
using System.Web.Mvc;

namespace TwitterBackup.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var claimsHelper = new TweeterClaimsHelper();
            
            //var auth = new MvcAuthorizer
            //{
            //    CredentialStore = new SessionStateCredentialStore
            //    {
            //        ConsumerKey = "VKVUhPRJal6JnIyqVks4VfsAy",
            //        ConsumerSecret = "FZgmzFJiHkyJct2jOqk9q3zU1pn6z3DbV2nrjOvpL1oFtL4RB6",
            //        OAuthToken = claimsHelper.GetOAuthAccessToken(),
            //        OAuthTokenSecret = claimsHelper.GetOAuthAccessTokenSecret(),
            //        UserID = claimsHelper.GetUserId()
            //    }
            //};

            //var ctx = new TwitterContext(auth);

            //var responseTweet = ctx.Friendship
            //    .FirstOrDefault(x => x.Type == FriendshipType.FriendsList && x.UserID == userId.Value)
            //    .Users
            //    .Select(x => x.Name);

            //return View(responseTweet);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}
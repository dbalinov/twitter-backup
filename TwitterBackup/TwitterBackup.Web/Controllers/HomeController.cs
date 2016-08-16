using Business.Services.Users;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TwitterBackup.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var claimsHelper = new TweeterClaimsHelper();
            var f = new FavoriteUserService(claimsHelper.GetOAuthAccessToken(), claimsHelper.GetOAuthAccessTokenSecret(), claimsHelper.GetUserId().ToString());
            var users = await f.GetAllAsync();
            return View(users);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}
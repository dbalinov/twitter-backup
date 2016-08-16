using Business.Services.Users;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TwitterBackup.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IFavoriteUserService favoriteUserService;

        public HomeController(IFavoriteUserService favoriteUserService)
        {
            this.favoriteUserService = favoriteUserService;
        }

        public async Task<ActionResult> Index()
        { 
            var users = await this.favoriteUserService.GetAllAsync();
            return View(users);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}
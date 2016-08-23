using System.Collections.Generic;
using System.Web.Http;
using Business.Models;
using TwitterBackup.Web.Messages.User;

namespace TwitterBackup.Web.Controllers
{
    [Authorize]
    public class DashboardController : ApiController
    {
        public IHttpActionResult GetData()
        {
            var data = new DashboardResponse();

            data.Users = new List<DashboardUserModel>();

            return Ok(data);
        }
    }
}

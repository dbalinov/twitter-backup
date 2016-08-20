using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business.Models;
using System.Threading.Tasks;
using Business.Services.Statuses;

namespace TwitterBackup.Web.Controllers
{
    [Authorize]
    public class StatusController : ApiController
    {
        private readonly IStatusService statusService;

        public StatusController(IStatusService statusService)
        {
            this.statusService = statusService;
        }

        public async Task<IEnumerable<StatusModel>> Get(string screenName)
        {
            var statuses = await this.statusService.GetUserTimelineAsync(screenName);
            return statuses;
        }
    }
}

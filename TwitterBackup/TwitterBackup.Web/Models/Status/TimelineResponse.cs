using System.Collections.Generic;
using TwitterBackup.Business.Models;

namespace TwitterBackup.Web.Models.Status
{
    public class TimelineResponse
    {
        public UserModel User { get; set; }

        public IEnumerable<StatusModel> Statuses { get; set; }
    }
}
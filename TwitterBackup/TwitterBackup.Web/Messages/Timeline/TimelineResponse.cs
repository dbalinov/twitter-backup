using System.Collections.Generic;
using Business.Models;

namespace TwitterBackup.Web.Messages.Timeline
{
    public class TimelineResponse
    {
        public UserModel User { get; set; }

        public IEnumerable<StatusModel> Statuses { get; set; }
    }
}
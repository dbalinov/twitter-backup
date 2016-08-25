using System.Collections.Generic;
using System.Linq;
using TwitterBackup.Business.Models;

namespace TwitterBackup.Web.Models.User
{
    public class DashboardResponse
    {
        public IList<DashboardUserModel> Users { get; set; }

        public int DownloadsCount
        {
            get
            {
                if (Users == null)
                {
                    return 0;
                }

                return Users.Sum(x => x.DownloadsCount);
            }
        }

        public int RetweetsCount
        {
            get
            {
                if (Users == null)
                {
                    return 0;
                }

                return Users.Sum(x => x.RetweetsCount);
            }
        }

        public bool RetweetsCountIsAccurate
        {
            get
            {
                if (Users == null)
                {
                    return false;
                }

                return Users.All(x => x.RetweetsCountIsAccurate);
            }
        }
    }
}
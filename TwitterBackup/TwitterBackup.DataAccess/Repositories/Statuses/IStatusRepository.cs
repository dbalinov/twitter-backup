using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterBackup.DataAccess.Entities;

namespace TwitterBackup.DataAccess.Repositories.Statuses
{
    public interface IStatusRepository
    {
        Task<Status> GetAsync(string statusId);
        
        Task<IEnumerable<Status>> GetUserTimelineAsync(StatusListParams statusListParams);

        Task RetweetAsync(string statusId);

        int GetRetweetsCountForUser(string userId);
    }
}

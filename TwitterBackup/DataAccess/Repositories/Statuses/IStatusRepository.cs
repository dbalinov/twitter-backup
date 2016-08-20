using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repositories.Statuses
{
    public interface IStatusRepository
    {
        Task<Status> GetAsync(string statusId);
        
        Task<IEnumerable<Status>> GetUserTimelineAsync(string screenName);

        Task RetweetAsync(string statusId);
    }
}

using DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Statuses
{
    public interface IStatusStoreRepository
    {
        Task<IEnumerable<string>> GetSavedStatusIdsAsync();

        Task<IEnumerable<Status>> GetAllSavedAsync(StatusListParams statusListParams);

        Task SaveAsync(Status status);

        Task UnsaveAsync(string statusId);
    }
}
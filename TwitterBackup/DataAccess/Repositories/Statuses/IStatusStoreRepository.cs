using DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Statuses
{
    public interface IStatusStoreRepository
    {
        Task<IEnumerable<Status>> GetAllAsync(long userId);

        Task AddAsync(Status status);

        Task RemoveAsync(long statusId);
    }
}
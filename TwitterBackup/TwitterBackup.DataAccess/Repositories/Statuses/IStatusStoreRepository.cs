using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterBackup.DataAccess.Entities;

namespace TwitterBackup.DataAccess.Repositories.Statuses
{
    public interface IStatusStoreRepository
    {
        Task<IEnumerable<string>> GetSavedStatusIdsAsync();

        Task<IEnumerable<Status>> GetAllSavedAsync(StatusListParams statusListParams);

        Task SaveAsync(Status status);

        Task UnsaveAsync(string statusId);

        IEnumerable<Tuple<string, int>> GetDownloadStatusCount(IEnumerable<string> userIds);
    }
}
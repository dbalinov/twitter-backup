using TwitterBackup.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterBackup.Business.Services.Statuses
{
    public interface IStatusService
    {
        Task<IEnumerable<StatusModel>> GetUserTimelineAsync(StatusListParamsModel statusListParams);

        Task<IEnumerable<StatusModel>> GetAllSavedAsync(StatusListParamsModel statusListParams);

        Task RetweetAsync(string statusId);

        Task SaveAsync(string statusId);

        Task UnsaveAsync(string statusId);
    }
}
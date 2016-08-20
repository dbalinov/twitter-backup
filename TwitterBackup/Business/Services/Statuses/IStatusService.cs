using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.Statuses
{
    public interface IStatusService
    {
        Task<IEnumerable<StatusModel>> GetUserTimelineAsync(string screenName);

        Task RetweetAsync(string statusId);
    }
}
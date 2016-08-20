using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;
using Business.Models.Mapping;
using DataAccess.Repositories.Statuses;
using System.Linq;

namespace Business.Services.Statuses
{
    internal class StatusService : IStatusService
    {
        private readonly IStatusRepository statusRepository;

        public StatusService(IStatusRepository statusRepository)
        {
            this.statusRepository = statusRepository;
        }

        public async Task<IEnumerable<StatusModel>> GetUserTimelineAsync(string screenName)
        {
            var mapper = new StatusMapper();
            var statuses = await this.statusRepository.GetUserTimelineAsync(screenName);
            return statuses.Select(x => mapper.Map(x, new StatusModel()));
        }
    }
}

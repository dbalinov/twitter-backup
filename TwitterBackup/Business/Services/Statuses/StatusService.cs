using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Business.Models;
using Business.Models.Mapping;
using DataAccess.Repositories.Statuses;

namespace Business.Services.Statuses
{
    internal class StatusService : IStatusService
    {
        private readonly IStatusRepository statusRepository;
        private readonly IStatusStoreRepository statusStoreRepository;

        public StatusService(IStatusRepository statusRepository, IStatusStoreRepository statusStoreRepository)
        {
            this.statusRepository = statusRepository;
            this.statusStoreRepository = statusStoreRepository;
        }

        public async Task<IEnumerable<StatusModel>> GetUserTimelineAsync(string userId, string maxId = null)
        {
            var mapper = new StatusMapper();
            var statuses = await this.statusRepository.GetUserTimelineAsync(userId, maxId);

            var statusModels = statuses
                .Select(x => mapper.Map(x, new StatusModel()))
                .ToList();

            var savedStatusIds = await this.statusStoreRepository.GetSavedStatusIdsAsync();
            var savedStatusIdsList = savedStatusIds.ToList();

            statusModels.ForEach(x => x.IsSaved = savedStatusIdsList.Contains(x.Id));

            return statusModels;
        }

        public Task RetweetAsync(string statusId)
        {
            return this.statusRepository.RetweetAsync(statusId);
        }

        public async Task SaveAsync(string statusId)
        {
            var status = await this.statusRepository.GetAsync(statusId);
            await this.statusStoreRepository.SaveAsync(status);
        }

        public async Task UnsaveAsync(string statusId)
        {
            await this.statusStoreRepository.UnsaveAsync(statusId);
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Business.Models;
using Business.Models.Mapping;
using DataAccess.Entities;
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

        public async Task<IEnumerable<StatusModel>> GetUserTimelineAsync(StatusListParamsModel statusListParams)
        {
            var mapper = new StatusMapper();
            var paramsMapper = new StatusListParamsMapper();
            var paramsModel = paramsMapper.Map(statusListParams, new StatusListParams());
            var statuses = await this.statusRepository.GetUserTimelineAsync(paramsModel);

            var statusModels = statuses
                .Select(x => mapper.Map(x, new StatusModel()))
                .ToList();

            var savedStatusIds = await this.statusStoreRepository.GetSavedStatusIdsAsync();
            var savedStatusIdsList = savedStatusIds.ToList();

            statusModels.ForEach(x => x.IsSaved = savedStatusIdsList.Contains(x.Id));

            return statusModels;
        }

        public async Task<IEnumerable<StatusModel>> GetAllSavedAsync(StatusListParamsModel statusListParams)
        {
            var mapper = new StatusMapper();
            var paramsMapper = new StatusListParamsMapper();
            var paramsModel = paramsMapper.Map(statusListParams, new StatusListParams());
            var savedStatuses = await this.statusStoreRepository.GetAllSavedAsync(paramsModel);

            var statusModels = savedStatuses.Select(x => mapper.Map(x, new StatusModel())).ToList();
            statusModels.ForEach(x =>
            {
                x.IsSaved = true;
                x.CreatedAt = x.CreatedAt.ToLocalTime();
            });

            return statusModels;
        }

        public Task RetweetAsync(string statusId)
        {
            return this.statusRepository.RetweetAsync(statusId);
        }

        public async Task SaveAsync(string statusId)
        {
            var status = await this.statusRepository.GetAsync(statusId);
            if (status != null)
            {
                await this.statusStoreRepository.SaveAsync(status);
            }
        }

        public async Task UnsaveAsync(string statusId)
        {
            await this.statusStoreRepository.UnsaveAsync(statusId);
        }
    }
}

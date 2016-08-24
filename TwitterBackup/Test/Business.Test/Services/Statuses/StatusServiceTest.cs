using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Services.Statuses;
using DataAccess.Repositories.Statuses;
using NSubstitute;

namespace Business.Test.Services.Statuses
{
    public class StatusServiceTest
    {
        private readonly IStatusRepository statusRepository;
        private readonly IStatusStoreRepository statusStoreRepository;

        private readonly StatusService statusService;

        public StatusServiceTest()
        {
            this.statusRepository = Substitute.For<IStatusRepository>();
            this.statusStoreRepository = Substitute.For<IStatusStoreRepository>();

            this.statusService = new StatusService(this.statusRepository, this.statusStoreRepository);
        }

        //Task<IEnumerable<StatusModel>> GetUserTimelineAsync(StatusListParamsModel statusListParams);

        //Task<IEnumerable<StatusModel>> GetAllSavedAsync(StatusListParamsModel statusListParams);

        //Task RetweetAsync(string statusId);

        //Task SaveAsync(string statusId);

        //Task UnsaveAsync(string statusId);
    }
}

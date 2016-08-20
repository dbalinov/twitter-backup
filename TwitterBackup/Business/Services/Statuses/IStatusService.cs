﻿using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.Statuses
{
    public interface IStatusService
    {
        Task<IEnumerable<StatusModel>> GetUserTimelineAsync(string screenName, string maxId = null);

        Task RetweetAsync(string statusId);

        Task SaveAsync(string statusId);

        Task UnsaveAsync(string statusId);
    }
}
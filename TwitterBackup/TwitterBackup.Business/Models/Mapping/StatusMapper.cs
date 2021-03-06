﻿using TwitterBackup.DataAccess.Entities;

namespace TwitterBackup.Business.Models.Mapping
{
    internal class StatusMapper
    {
        public StatusModel Map(Status from, StatusModel to)
        {
            to.Id = from.StatusId;
            to.Text = from.Text;
            to.Retweeted = from.Retweeted;
            to.CreatedAt = from.CreatedAt;
            to.CreatedByScreenName = from.CreatedByScreenName;
            to.MediaType = from.MediaType;
            to.MediaUrl = from.MediaUrl;

            return to;
        }
    }
}

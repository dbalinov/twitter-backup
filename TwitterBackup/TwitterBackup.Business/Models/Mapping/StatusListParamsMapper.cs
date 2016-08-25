using TwitterBackup.DataAccess.Entities;

namespace TwitterBackup.Business.Models.Mapping
{
    internal class StatusListParamsMapper
    {
        public StatusListParams Map(StatusListParamsModel from, StatusListParams to)
        {
            to.SavedByUserId = from.SavedByUserId;
            to.CreatedByUserId = from.CreatedByUserId;
            to.MaxId = from.MaxId;
            to.Count = from.Count;

            return to;
        }
    }
}

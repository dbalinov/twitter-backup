using DataAccess.Entities;

namespace Business.Models.Mapping
{
    internal class StatusMapper
    {
        public StatusModel Map(Status from, StatusModel to)
        {
            to.Id = from.StatusId;
            to.Text = from.Text;
            to.Retweeted = from.Retweeted;
            to.CreatedAt = from.CreatedAt;
            to.MediaType = from.MediaType;
            to.MediaUrl = from.MediaUrl;

            return to;
        }
    }
}

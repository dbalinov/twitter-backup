using System.Linq;
using Tweetinvi.Models;

namespace DataAccess.Entities.Mapping
{
    public class StatusMapper
    {
        public Status Map(ITweet from, Status to)
        {
            to.StatusId = from.IdStr;
            to.Text = from.FullText;
            to.Retweeted = from.Retweeted;
            to.CreatedAt = from.CreatedAt;
            to.CreatedById = from.CreatedBy.IdStr;

            var media = from.Entities.Medias.FirstOrDefault();
            if (media != null)
            {
                to.MediaType = media.MediaType;
                to.MediaUrl = media.MediaURL;
            }

            return to;
        }
    }
}

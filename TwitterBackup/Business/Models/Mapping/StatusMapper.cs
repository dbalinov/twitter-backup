using System.Linq;
using DataAccess.Entities;

namespace Business.Models.Mapping
{
    internal class StatusMapper
    {
        public StatusModel Map(Status from, StatusModel to)
        {
            to.Id = from.StatusId;
            to.Text = from.Text;
            //to.RetweetCount = from.RetweetCount;
            to.Retweeted = from.Retweeted;
            //to.FavoriteCount = from.FavoriteCount;
            //to.Favorited = from.Favorited;
            to.CreatedAt = from.CreatedAt;
            to.Entities = new StatusEntitiesModel
            {
                Medias = from.Entities.Medias.Select(x => new MediaEntityModel
                {
                    MediaType = x.MediaType,
                    MediaUrl = x.MediaUrl
                })
            };

            return to;
        }
    }
}

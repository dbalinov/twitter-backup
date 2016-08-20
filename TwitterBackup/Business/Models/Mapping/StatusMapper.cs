using DataAccess.Entities;

namespace Business.Models.Mapping
{
    internal class StatusMapper
    {
        public StatusModel Map(Status from, StatusModel to)
        {
            to.Id = from.Id;
            to.Text = from.Text;
            to.RetweetCount = from.RetweetCount;
            to.Retweeted = from.Retweeted;
            to.FavoriteCount = from.FavoriteCount;
            to.Favorited = from.Favorited;
            to.CreatedAt = from.CreatedAt;

            return to;
        }
    }
}

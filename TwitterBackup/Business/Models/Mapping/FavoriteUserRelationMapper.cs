using DataAccess.Entities;

namespace Business.Models.Mapping
{
    public class FavoriteUserRelationMapper
    {
        public FavoriteUserRelation Map(FavoriteUserRelationModel from, FavoriteUserRelation to)
        {
            to.SourceUserId = from.SourceUserId;
            to.TargetUserId = from.TargetUserId;

            return to;
        }
    }
}

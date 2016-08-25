using TwitterBackup.DataAccess.Entities;

namespace TwitterBackup.Business.Models.Mapping
{
    internal class FavoriteUserRelationMapper
    {
        public FavoriteUserRelation Map(FavoriteUserRelationModel from, FavoriteUserRelation to)
        {
            to.SourceUserId = from.SourceUserId;
            to.TargetUserId = from.TargetUserId;

            return to;
        }
    }
}

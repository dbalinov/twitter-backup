namespace DataAccess.Entities
{
    public class FavoriteUserRelation : MongoEntity
    {
        public string SourceUserId { get; set; }

        public string TargetUserId { get; set; }
    }
}

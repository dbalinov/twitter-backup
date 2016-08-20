using MongoDB.Bson;

namespace DataAccess.Entities
{
    public abstract class MongoEntity
    {
        public ObjectId ObjectId { get; set; }
    }
}

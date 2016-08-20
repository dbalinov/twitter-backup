using MongoDB.Bson;

namespace DataAccess.Entities
{
    public abstract class MongoEntity
    {
        public ObjectId Id { get; set; }
    }
}

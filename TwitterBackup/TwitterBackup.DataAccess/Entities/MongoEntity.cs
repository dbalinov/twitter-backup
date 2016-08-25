using MongoDB.Bson;

namespace TwitterBackup.DataAccess.Entities
{
    public abstract class MongoEntity
    {
        public ObjectId Id { get; set; }
    }
}

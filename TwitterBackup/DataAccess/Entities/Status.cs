using System;

namespace DataAccess.Entities
{
    public class Status : MongoEntity
    {
        public string StatusId { get; set; }

        public string Text { get; set; }

        public bool Retweeted { get; set; }

        public DateTime CreatedAt { get; set; }

        public StatusEntities Entities { get; set; }

        public string CreatedById { get; set; }

        public string SavedByUserId { get; set; }
    }
}
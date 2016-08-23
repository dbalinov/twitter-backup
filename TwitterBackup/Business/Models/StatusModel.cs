using System;

namespace Business.Models
{
    public class StatusModel
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public bool Retweeted { get; set; }

        public DateTime CreatedAt { get; set; }

        public StatusEntitiesModel Entities { get; set; }
        
        public bool IsSaved { get; set; }

        public string CreatedAtFormatted
        {
            get { return CreatedAt.ToString();  }
        }
    }
}

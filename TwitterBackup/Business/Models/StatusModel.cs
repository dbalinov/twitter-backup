using System;

namespace Business.Models
{
    public class StatusModel
    {
        public string Id { get; set; }

        public string Text { get; set; }

        //public int RetweetCount { get; set; }

        public bool Retweeted { get; set; }

        //public int FavoriteCount { get; set; }

        //public bool Favorited { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

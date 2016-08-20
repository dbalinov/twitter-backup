using System;

namespace DataAccess.Entities
{
    public class Status
    {
        public string Id { get; set; }
        public string Text { get; set; }
        //public int RetweetCount { get; set; }
        public bool Retweeted { get; set; }
        //public int FavoriteCount { get; set; }
        //public bool Favorited { get; set; }
        public DateTime CreatedAt { get; set; }

        /*
           "entities": {
             "urls": [
               {
                 "expanded_url": "https://dev.twitter.com/blog/twitter-certified-products",
                 "url": "https://t.co/MjJ8xAnT",
                 "display_url": "dev.twitter.com/blog/twitter-c\u2026"
               }
             ]
           }
        */
    }
}
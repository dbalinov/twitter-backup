﻿namespace Business.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Notifications { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Url { get; internal set; }
        public string ProfileBackgroundColor { get; internal set; }
    }
}

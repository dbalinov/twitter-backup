namespace TwitterBackup.Web.Messages.Timeline
{
    public class TimelineRequest
    {
        public string UserId { get; set; }

        public bool TrimUser { get; set; }

        public string MaxId { get; set; }

        public bool SavedOnly { get; set; }
    }
}
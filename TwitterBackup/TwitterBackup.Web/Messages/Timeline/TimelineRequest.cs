namespace TwitterBackup.Web.Messages.Timeline
{
    public class TimelineRequest
    {
        public string ScreenName { get; set; }

        public bool TrimUser { get; set; }

        public string MaxId { get; set; }
    }
}
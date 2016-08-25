namespace TwitterBackup.Web.Models.Status
{
    public class TimelineRequest
    {
        public string UserId { get; set; }

        public bool TrimUser { get; set; }

        public string MaxId { get; set; }

        public bool SavedOnly { get; set; }

        public int? Count { get; set; }
    }
}
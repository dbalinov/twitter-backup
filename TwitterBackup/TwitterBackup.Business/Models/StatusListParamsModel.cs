namespace Business.Models
{
    public class StatusListParamsModel
    {
        public string SavedByUserId { get; set; }

        public string CreatedByUserId { get; set; }

        public string MaxId { get; set; }

        public int? Count { get; set; }
    }
}

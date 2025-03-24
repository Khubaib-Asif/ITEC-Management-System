namespace ITECApp.Entities
{
    public class EventResult
    {
        public int ResultId { get; set; }
        public int? EventId { get; set; }
        public int? ParticipantId { get; set; }
        public int? TeamId { get; set; }
        public int? Position { get; set; }
        public decimal? Score { get; set; }
        public string? Remarks { get; set; }
    }
}

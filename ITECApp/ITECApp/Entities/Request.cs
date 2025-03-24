namespace ITECApp.Entities
{
    public class Request
    {
        public int RequestId { get; set; }
        public required string RequestType { get; set; }
        public required string RequestStatus { get; set; }
    }
}


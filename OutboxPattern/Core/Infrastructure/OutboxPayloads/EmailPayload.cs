namespace OutboxPattern.Core.Infrastructure.OutboxPayloads
{
    public class EmailPayload : IPayload
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}

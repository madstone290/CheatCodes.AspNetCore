namespace OutboxPattern.Core.Infrastructure.OutboxPayloads
{
    public class NotificationPayload : IPayload
    {
        public string Message { get; set; }
        public string Recipient { get; set; }
        public int RetryCount { get; set; }
        public DateTime Limit { get; set; }
        public NotificationPayload() { }
    }
}

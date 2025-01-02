namespace OutboxPattern.Core.Infrastructure.OutboxPayloads
{
    public class NotificationPayload : IPayload
    {
        public string Message { get; set; }
        public string Recipient { get; set; }
        public int RetryCount { get; set; }
        public DateTime Limit { get; set; }
        /// <summary>
        /// If the notification is in error state
        /// </summary>
        public bool IsError { get; set; }
        public NotificationPayload() { }
    }
}

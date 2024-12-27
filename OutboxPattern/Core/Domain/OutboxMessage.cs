namespace OutboxPattern.Core.Domain
{
    public class OutboxMessage
    {
        public const int MaxRetryCount = 5;

        public int Id { get; private set; }
        public string PayloadType { get; private set; }
        public string Payload { get; private set; }
        public DateTime OccurredDateTime { get; private set; }
        public bool IsProcessed { get; private set; }
        public bool IsSuccessful { get; private set; }
        public int RetryCount { get; private set; }
        public DateTime? ProcessedDateTime { get; private set; }
        public List<string> FailiureReasons { get; private set; } = [];

        protected OutboxMessage()
        {
        }

        public OutboxMessage(string type, string payload)
        {
            PayloadType = type;
            Payload = payload;
            OccurredDateTime = DateTime.UtcNow;
        }

        public void MarkAsProcessed()
        {
            ProcessedDateTime = DateTime.UtcNow;
            IsProcessed = true;
            IsSuccessful = true;
        }

        public void MarkAsFailed(string remark)
        {
            ProcessedDateTime = DateTime.UtcNow;
            FailiureReasons.Add(remark);
            RetryCount++;
            if (RetryCount >= MaxRetryCount)
            {
                IsProcessed = true;
            }
        }
    }
}

namespace OutboxPattern.Core.Domain
{
    public class OutboxMessage
    {
        public const int MaxRetryCount = 5;

        public int Id { get; private set; }
        public Guid Guid { get; private set; } = Guid.NewGuid();
        public string PayloadType { get; private set; }
        public string Payload { get; private set; }
        public DateTime OccurredDateTime { get; private set; }
        public bool IsCompleted { get; private set; }
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

        public void MarkAsSuccess()
        {
            ProcessedDateTime = DateTime.UtcNow;
            IsCompleted = true;
            IsSuccessful = true;
        }

        public void MarkAsFailure(string remark)
        {
            ProcessedDateTime = DateTime.UtcNow;
            FailiureReasons.Add(remark);
            RetryCount++;
            if (RetryCount >= MaxRetryCount)
            {
                IsCompleted = true;
                IsSuccessful = false;
            }
        }
    }
}

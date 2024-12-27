using OutboxPattern.Core.Domain;
using System.Text.Json;

namespace OutboxPattern.Core.Infrastructure
{
    public class OutboxMessagePublisher
    {
        private readonly ApplicationDbContext _dbContext;

        public OutboxMessagePublisher(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void PublishMessage<TPayload>(string type, TPayload payload)
            where TPayload : IPayload
        {
            var message = new OutboxMessage(type, JsonSerializer.Serialize(payload));
            _dbContext.OutboxMessages.Add(message);
        }

    }
}

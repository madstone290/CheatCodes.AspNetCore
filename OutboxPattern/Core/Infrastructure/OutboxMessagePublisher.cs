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

            // 메시지를 저장
            _dbContext.OutboxMessages.Add(message);

            // 즉시 처리할 수 있도록 메시지를 인메모리 버스에 추가
            OutboxBus.Add(message.Guid);

            
        }

    }
}

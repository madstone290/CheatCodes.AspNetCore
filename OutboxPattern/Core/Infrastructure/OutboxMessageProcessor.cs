using OutboxPattern.Core.Domain;
using System.Text.Json;

namespace OutboxPattern.Core.Infrastructure
{
    public class OutboxMessageProcessor
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly IEnumerable<IOutboxMessageHandler> _outboxMessageHandlers;

        public OutboxMessageProcessor(ApplicationDbContext dbContext, IEnumerable<IOutboxMessageHandler> outboxMessageHandlers)
        {
            _dbContext = dbContext;
            _outboxMessageHandlers = outboxMessageHandlers;
        }

        public async Task ProcessUncompletedMessage()
        {
            var messages = _dbContext.OutboxMessages.Where(m => !m.IsCompleted).ToList();
            Console.WriteLine($"Processing {messages.Count} messages...");
            foreach (var message in messages)
            {
                await ProcessMessage(message);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task ProcessMessagesInBus()
        {
            var messageGuids = OutboxBus.Take();
            Console.WriteLine($"Processing {messageGuids.Count} messages from bus...");
            if(messageGuids.Count == 0)
                return;

            var messages = _dbContext.OutboxMessages.Where(m => messageGuids.Contains(m.Guid)).ToList();
            foreach (var message in messages)
            {
                await ProcessMessage(message);
            }
            await _dbContext.SaveChangesAsync();
        }

        async Task ProcessMessage(OutboxMessage message)
        {
            while (!message.IsCompleted)
            {
                foreach (var handler in _outboxMessageHandlers)
                {
                    if (!handler.CanHandle(message))
                        continue;
                    try
                    {
                        await handler.Handle(message);
                        message.MarkAsSuccess();
                    }
                    catch (Exception ex)
                    {
                        message.MarkAsFailure(ex.Message);
                        // 재시도를 위해 1초 대기
                        await Task.Delay(1000);
                    }
                }
            }
        }

    }
}

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

        public async Task ProcessMessages()
        {
            var unprocessedMessages = _dbContext.OutboxMessages.Where(m => !m.IsProcessed).ToList();
            Console.WriteLine($"Processing {unprocessedMessages.Count} messages...");
            foreach (var message in unprocessedMessages)
            {
                foreach (var handler in _outboxMessageHandlers)
                {
                    if (!handler.CanHandle(message))
                        continue;

                    try
                    {
                        await handler.Handle(message);
                        message.MarkAsProcessed();
                    }
                    catch (Exception ex)
                    {
                        message.MarkAsFailed(ex.Message);
                    }
                }
            }
            await _dbContext.SaveChangesAsync();
        }


    }
}

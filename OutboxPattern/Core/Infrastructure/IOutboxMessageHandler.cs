using OutboxPattern.Core.Domain;

namespace OutboxPattern.Core.Infrastructure
{
    public interface IOutboxMessageHandler
    {
        bool CanHandle(OutboxMessage message);

        Task Handle(OutboxMessage message);
    }
}

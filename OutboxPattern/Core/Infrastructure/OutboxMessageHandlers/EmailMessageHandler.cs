using OutboxPattern.Core.Domain;
using OutboxPattern.Core.Infrastructure.OutboxPayloads;
using System.Text.Json;

namespace OutboxPattern.Core.Infrastructure.OutboxMessageHandlers
{
    public class EmailMessageHandler : IOutboxMessageHandler
    {
        bool IOutboxMessageHandler.CanHandle(OutboxMessage message)
        {
            return message.PayloadType == nameof(EmailPayload);
        }

        Task IOutboxMessageHandler.Handle(OutboxMessage message)
        {
            EmailPayload payload = JsonSerializer.Deserialize<EmailPayload>(message.Payload);
            var notificationInfo = $"{payload.To} - {payload.Subject} - {payload.Body}";
            return Task.CompletedTask;
        }
    }
}

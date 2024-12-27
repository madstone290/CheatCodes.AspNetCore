using OutboxPattern.Core.Domain;
using OutboxPattern.Core.Infrastructure.OutboxPayloads;
using System.Text.Json;

namespace OutboxPattern.Core.Infrastructure.OutboxMessageHandlers
{
    public class NotificationMessageHandler : IOutboxMessageHandler
    {
        bool IOutboxMessageHandler.CanHandle(OutboxMessage message)
        {
            return message.PayloadType == nameof(NotificationPayload);
        }

        Task IOutboxMessageHandler.Handle(OutboxMessage message)
        {
            var payload = JsonSerializer.Deserialize<NotificationPayload>(message.Payload);

            if(payload.Limit < DateTime.UtcNow)
            {
                throw new Exception($"Notification limit exceeded for {payload.Recipient}");
            }

            var notificationInfo = $"{payload.Recipient} - {payload.Message} - {payload.RetryCount} - {payload.Limit}";
            Console.WriteLine($"Sending notification... {notificationInfo}");
            return Task.CompletedTask;
        }
    }
}

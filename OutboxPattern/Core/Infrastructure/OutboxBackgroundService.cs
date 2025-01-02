
namespace OutboxPattern.Core.Infrastructure
{
    public class OutboxBackgroundService : BackgroundService
    {
        private const int Period = 1000 * 5;

        private readonly IServiceProvider _serviceProvider;

        public OutboxBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var scope = _serviceProvider.CreateScope();
            var outboxMessageProcessor = scope.ServiceProvider.GetRequiredService<OutboxMessageProcessor>();

            // 최초 실행시 처리되지 않은 메시지를 처리한다.
            await outboxMessageProcessor.ProcessUncompletedMessage();

            while (!stoppingToken.IsCancellationRequested)
            {
                await outboxMessageProcessor.ProcessMessagesInBus();

                await Task.Delay(Period, stoppingToken);
                Console.WriteLine("OutboxBackgroundService is running...");
            }
        }
    }
}

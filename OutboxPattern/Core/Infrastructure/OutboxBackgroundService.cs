
namespace OutboxPattern.Core.Infrastructure
{
    public class OutboxBackgroundService : BackgroundService
    {
        private const int Period = 1000 * 10;

        private readonly IServiceProvider _serviceProvider;

        public OutboxBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var scope = _serviceProvider.CreateScope();
            var outboxMessageProcessor = scope.ServiceProvider.GetRequiredService<OutboxMessageProcessor>();

            while (!stoppingToken.IsCancellationRequested)
            {
                await outboxMessageProcessor.ProcessMessages();

                await Task.Delay(Period, stoppingToken);
            }
        }
    }
}

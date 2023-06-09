using Microsoft.AspNetCore.SignalR;
using PolarC_task.SignalR;

namespace PolarC_task.Workers
{
    public class TimedWorker : BackgroundService
    {
        private readonly ILogger<TimedWorker> _logger;
        private int _executionCount;
        private readonly IHubContext<MessageHub, IMessageHub> _hubContext;


        public TimedWorker(ILogger<TimedWorker> logger, IHubContext<MessageHub, IMessageHub> hubContext)
        {
            _logger = logger;
            _hubContext = hubContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            await DoWork();

            using PeriodicTimer timer = new(TimeSpan.FromSeconds(1));

            try
            {
                while (await timer.WaitForNextTickAsync(stoppingToken) && _executionCount < 11)
                {
                    await DoWork();
                }
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Timed Hosted Service is stopping.");
            }
        }

        private Task DoWork()
        {
            int count = Interlocked.Increment(ref _executionCount);
            _logger.LogInformation("Timed Hosted Service is working. Count: {Count}", count);

            _hubContext.Clients.All.ReceiveAsync($"Timed Hosted Service is working. Count: {count}");
            _hubContext.Clients.All.Receive2Async($"This is second message. Count * 100: {count * 100}");

            return Task.WhenAll();
        }
    }
}

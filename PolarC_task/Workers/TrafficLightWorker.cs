using Microsoft.AspNetCore.SignalR;
using PolarC_task.Mappers;
using PolarC_task.TrafficLight;
using PolarC_task.TrafficLight.Factory;
using PolarC_task.TrafficLight.Hubs;

namespace PolarC_task.Workers
{
    public class TrafficLightWorker : BackgroundService
    {
        private readonly ILogger<TrafficLightWorker> _logger;
        private readonly IHubContext<TrafficLightStatusHub, ITrafficLightStatusHub> _hubContext;
        private readonly ITrafficLightFactory _trafficLightFactory;
        private readonly ITrafficLightCustomMapper _trafficLightCustomMapper;

        private int _duration;
        private Light _trafficLight;

        public TrafficLightWorker(ILogger<TrafficLightWorker> logger, 
            IHubContext<TrafficLightStatusHub, ITrafficLightStatusHub> hubContext, 
            ITrafficLightFactory trafficLightFactory,
            ITrafficLightCustomMapper trafficLightCustomMapper)
        {
            _logger = logger;
            _hubContext = hubContext;
            _trafficLightFactory = trafficLightFactory;
            _trafficLightCustomMapper = trafficLightCustomMapper;

            // initial traffic light
            _trafficLight = _trafficLightFactory.CreateTrafficLight(LightType.RED);
            _duration = _trafficLight.Duration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Traffic light initialized...");

            using PeriodicTimer timer = new(TimeSpan.FromSeconds(1));

            try
            {
                while (await timer.WaitForNextTickAsync(stoppingToken))
                {
                    await AndThereWasALight();
                }
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Worker Service is stopping.");
            }
        }

        private Task AndThereWasALight()
        {
            var count = Interlocked.Decrement(ref _duration);
            

            if (count < 0)
            {
                Interlocked.Exchange<Light>(ref _trafficLight, _trafficLightFactory.CreateNextTrafficLight(_trafficLight.LightType, _trafficLight.IsAfterGreen));
                Interlocked.Exchange(ref _duration, _trafficLight.Duration);
            }
            else
            {
                Interlocked.Exchange(ref _trafficLight.Duration, _duration);
            }

            _logger.LogInformation($"Some basic data: Id: {_trafficLight.LightType}; Color: {_trafficLight.LightType.ToString()}; Duration: {_duration}; Is after green: {_trafficLight.IsAfterGreen}");

            _hubContext.Clients.All.ReceiveStatusAsync(_trafficLightCustomMapper.MapToDto(_trafficLight));

            return Task.WhenAll();
        }

        
    }
}

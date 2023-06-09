using PolarC_task.Dtos;

namespace PolarC_task.TrafficLight.Hubs
{
    public interface ITrafficLightStatusHub
    {
        Task ReceiveStatusAsync(TrafficLightDto trafficLightStatus);
        Task StopGreenLightAsync();
    }
}

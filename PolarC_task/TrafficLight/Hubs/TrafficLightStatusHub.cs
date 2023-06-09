using Microsoft.AspNetCore.SignalR;
using PolarC_task.Dtos;

namespace PolarC_task.TrafficLight.Hubs
{
    public class TrafficLightStatusHub : Hub<ITrafficLightStatusHub>
    {
        public Task SendStatusAsync(TrafficLightDto lightsStatus) 
            => Clients.All.ReceiveStatusAsync(lightsStatus);

        public Task StopGreenLightAsync() => Clients.All.StopGreenLightAsync();
    }
}

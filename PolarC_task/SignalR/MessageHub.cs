using Microsoft.AspNetCore.SignalR;

namespace PolarC_task.SignalR
{
    public class MessageHub : Hub<IMessageHub>
    {
        public Task SendAsync(string message) => Clients.All.ReceiveAsync(message);
        public Task Send2Async(string message) => Clients.All.Receive2Async(message);
        
    }
}

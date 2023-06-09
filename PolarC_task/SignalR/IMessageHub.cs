namespace PolarC_task.SignalR
{
    public interface IMessageHub
    {
        Task ReceiveAsync(string message);
        Task Receive2Async(string message);
    }
}

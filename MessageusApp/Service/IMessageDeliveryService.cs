namespace MessageusApp.Service
{
    public interface IMessageDeliveryService
    {
        Task ProcessScheduledMessagesAsync(CancellationToken stoppingToken);
        
    }
}

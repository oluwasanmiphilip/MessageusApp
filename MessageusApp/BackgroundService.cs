namespace MessageusApp
{
    public class BackgroundService
    {

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Message Delivery Service started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                await ProcessMessagesAsync(stoppingToken);
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}

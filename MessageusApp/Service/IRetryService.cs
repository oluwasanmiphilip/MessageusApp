namespace MessageusApp.Service
{
    public interface IRetryService
    {
        Task<bool> RetryFailedMessageAsync(int messageId);
    }
}

namespace MessageusApp.Service
{
    public interface ISmsService
    {
        Task<bool> SendSmsAsync(string phoneNumber, string message);
    }
}

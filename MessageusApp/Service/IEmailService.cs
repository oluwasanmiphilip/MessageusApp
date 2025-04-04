namespace MessageusApp.Service
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string recipient, string content);
        Task<bool> SendEmailAsync(object recipient, string content);
        
    }
}

using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MessageusApp.Service
{
    public class SmsService : ISmsService
    {
        private readonly ILogger<SmsService> _logger;

        public SmsService(ILogger<SmsService> logger)
        {
            _logger = logger;
        }

        public async Task<bool> SendSmsAsync(string phoneNumber, string message)
        {
            _logger.LogInformation($"Sending SMS to {phoneNumber}...");

            // Simulate SMS sending (replace with Twilio or other SMS API)
            await Task.Delay(500);

            _logger.LogInformation($"SMS sent successfully to {phoneNumber}.");
            return true;
        }
    }
}

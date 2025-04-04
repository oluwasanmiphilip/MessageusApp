using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;


namespace MessageusApp.Service
{
    public class EmailService : IEmailService
    {
        private readonly string _sendGridApiKey;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
        {
            _sendGridApiKey = configuration["SmtpSettings:SendGridApiKey"];
            _logger = logger;
        }

        public async Task<bool> SendEmailAsync(string toEmail, string message)
        {
            var client = new SendGridClient(_sendGridApiKey);
            var from = new EmailAddress("your_verified_email@domain.com", "MessageusApp");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, "Scheduled Message", message, message);

            var response = await client.SendEmailAsync(msg);

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                _logger.LogInformation($"Email sent to {toEmail}");
                return true;
            }
            else
            {
                _logger.LogError($"Failed to send email to {toEmail}. Response: {response.StatusCode}");
                return false;
            }
        }

        public Task<bool> SendEmailAsync(object recipient, string content)
        {
            throw new NotImplementedException();
        }
    }
}

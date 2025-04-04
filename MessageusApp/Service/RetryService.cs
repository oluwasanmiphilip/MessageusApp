using MessageusApp.Data;
using MessageusApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MessageusApp.Service
{
    public class RetryService : IRetryService
    {
        private readonly AppDbContext _dbContext;
        private readonly IEmailService _emailService;
        private readonly ILogger<RetryService> _logger;

        public RetryService(AppDbContext dbContext, IEmailService emailService, ILogger<RetryService> logger)
        {
            _dbContext = dbContext;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<bool> RetryFailedMessageAsync(int messageId)
        {
            var message = await _dbContext.Messages.FindAsync(messageId);
            if (message == null || message.IsSent) return false;

            _logger.LogInformation($"Retrying message ID: {messageId}...");

            bool success = await _emailService.SendEmailAsync(message.Recipient, message.Content);

            if (success)
            {
                message.IsSent = true;
                message.SentAT = DateTime.UtcNow;
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}

using MessageusApp.Data;
using MessageusApp.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MessageusApp.Services
{
    public class MessageDeliveryService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<MessageDeliveryService> _logger;
        private readonly IEmailService _emailService;

        public MessageDeliveryService(
            IServiceScopeFactory scopeFactory,
            ILogger<MessageDeliveryService> logger,
            IEmailService emailService)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
            _emailService = emailService;
        }

        private async Task ProcessMessagesAsync(CancellationToken stoppingToken)
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var now = DateTime.UtcNow;

            var dueMessages = await dbContext.Messages
                .Where(m => !m.IsSent && m.ScheduledTime <= now)
                .ToListAsync(stoppingToken);

            foreach (var message in dueMessages)
            {
                bool sent = await _emailService.SendEmailAsync(message.Recipient, message.Content);
                if (sent)
                {
                    message.IsSent = true;
                    message.SentAT = DateTime.UtcNow;
                }
            }

            await dbContext.SaveChangesAsync(stoppingToken);
        }
    }
}

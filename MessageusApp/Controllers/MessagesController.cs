using MessageusApp.Data;
using MessageusApp.Dtos;
using MessageusApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MessageusApp.Controllers
{
    //[Authorize] // Require authentication
    [Route("api/messages")]
    [ApiController]
    public class MessagesController : Controller
    {
        private readonly AppDbContext _context;

        public MessagesController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/messages/schedule
        [HttpPost("schedule")]
        public async Task<IActionResult> ScheduleMessage([FromBody] Message message)
        {
            // Log all user claims for debugging
            var claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();
            Console.WriteLine("User Claims: " + System.Text.Json.JsonSerializer.Serialize(claims));

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized("Token is missing user ID claim.");
            }

            var userId = int.Parse(userIdClaim.Value);
            message.UserId = userId;

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Message scheduled successfully", messageId = message.Id });
        }



        // GET: api/messages/scheduled
        [HttpGet("scheduled")]
        public async Task<IActionResult> GetScheduledMessages()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            if (userId == 0)
                return Unauthorized("Invalid user token.");

            var messages = await _context.Messages
                .Where(m => m.UserId == userId)
                .ToListAsync();

            return Ok(messages);
        }
    }
}


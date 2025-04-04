using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MessageusApp.Controllers
{
    [Authorize] // Protects all actions in this controller
    [Route("api/[controller]")]
    [ApiController]
    public class ProtectedController : Controller
    {
        [HttpGet("secure-data")]
        public IActionResult GetSecureData()
        {
            return Ok(new { Message = "This is a protected API endpoint." });
        }
    }
}

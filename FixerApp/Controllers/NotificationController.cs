using FixerApp.Models.DTOs;
using FixerApp.Services.Interfaces;
using FixrApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace FixerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NotificationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserNotifications(long userId)
        {
            var notifications = _context.Notifications
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.CreatedAt)
                .Select(n => new NotificationDto
                {
                    Id = n.Id,
                    Message = n.Message,
                    Read = n.Read,
                    CreatedAt = n.CreatedAt
                })
                .ToList();

            return Ok(notifications);
        }
    }
}

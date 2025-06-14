using FixerApp.Models.DTOs;
using FixerApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FixerApp.Controllers
{
    [ApiController]
    [Route("api/support")]
    public class SupportTicketController : ControllerBase
    {
        private readonly ISupportTicketService _supportService;

        public SupportTicketController(ISupportTicketService supportService)
        {
            _supportService = supportService;
        }

        [HttpPost("create")]
        public IActionResult CreateTicket([FromBody] SupportTicketDto dto)
        {
            var result = _supportService.CreateTicket(dto);
            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetUserTickets(long userId)
        {
            var tickets = _supportService.GetTicketsByUser(userId);
            return Ok(tickets);
        }

        [HttpGet("admin/all")]
        public IActionResult GetAllTickets()
        {
            var tickets = _supportService.GetAllTickets();
            return Ok(tickets);
        }

        [HttpPost("admin/respond/{ticketId}")]
        public IActionResult RespondToTicket(long ticketId, [FromBody] RespondTicketDto dto)
        {
            var result = _supportService.RespondToTicket(ticketId, dto.Response ?? string.Empty);
            return Ok(result);
        }
    }
}

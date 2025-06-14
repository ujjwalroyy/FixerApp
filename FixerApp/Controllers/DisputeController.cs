using FixerApp.Models.DTOs;
using FixerApp.Models.Entities.Enums;
using FixerApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FixerApp.Controllers
{
    [ApiController]
    [Route("api/disputes")]
    public class DisputeController : ControllerBase
    {
        private readonly IDisputeService _service;

        public DisputeController(IDisputeService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] DisputeDTO dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Reason))
                return BadRequest("Reason is required.");

            return Ok(_service.CreateDispute(dto));
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetByUser(long userId)
        {
            return Ok(_service.GetDisputesByUser(userId));
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllDisputes());
        }

        [HttpPost("respond/{disputeId}")]
        public IActionResult Respond(long disputeId, [FromQuery] string adminComment, [FromQuery] DisputeStatus status)
        {
            if (string.IsNullOrWhiteSpace(adminComment))
                return BadRequest("Admin comment is required.");

            return Ok(_service.RespondToDispute(disputeId, adminComment, status));
        }
    }
}

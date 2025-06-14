using FixerApp.Models.DTOs;
using FixerApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FixerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobRequestController : ControllerBase
    {
        private readonly IJobRequestService _service;

        public JobRequestController(IJobRequestService service) => _service = service;

        [HttpPost("create")]
        public IActionResult CreateJob([FromBody] JobRequestDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var job = _service.CreateJob(dto);
            return Ok(job);
        }

        [HttpPost("cancel")]
        public IActionResult CancelJob([FromBody] CancelJobRequestDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = _service.CancelJob(dto);
            return Ok(result);
        }

        [HttpGet("refunded")]
        public IActionResult GetRefundedJobs() => Ok(_service.GetRefundedJobs());

        [HttpGet("all")]
        public IActionResult GetAllJobs() => Ok(_service.GetAllJobs());

        [HttpGet("user/{userId}")]
        public IActionResult GetJobsByUser(long userId) => Ok(_service.GetJobsByUserId(userId));
    }
}
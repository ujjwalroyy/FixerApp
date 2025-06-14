using FixerApp.Models.DTOs;
using FixerApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FixerApp.Controllers
{
    [ApiController]
    [Route("api/timeline")]
    public class JobTimelineController : ControllerBase
    {
        private readonly IJobTimelineService _service;

        public JobTimelineController(IJobTimelineService service)
        {
            _service = service;
        }

        [HttpGet("{jobId}")]
        public async Task<IActionResult> GetTimeline(long jobId)
        {
            var result = await _service.GetTimelineAsync(jobId);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddEvent([FromBody] AddTimelineDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.AddEventAsync(dto.JobId, dto.Stage, dto.Description ?? string.Empty);
            return Ok(new { message = "Event added successfully" });
        }
    }
}
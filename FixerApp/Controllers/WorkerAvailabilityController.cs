using FixerApp.Models.DTOs;
using FixerApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FixerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkerAvailabilityController : ControllerBase
    {
        private readonly IWorkerAvailabilityService _availabilityService;

        public WorkerAvailabilityController(IWorkerAvailabilityService availabilityService)
        {
            _availabilityService = availabilityService;
        }

        [HttpPost]
        public async Task<ActionResult<WorkerAvailabilityDto>> SetAvailability([FromBody] WorkerAvailabilityDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _availabilityService.SetAvailabilityAsync(dto);
            return Ok(result);
        }

        [HttpGet("{workerId:long}")]
        public async Task<ActionResult<List<WorkerAvailabilityDto>>> GetAvailabilityByWorker(long workerId)
        {
            var result = await _availabilityService.GetAvailabilityByWorkerAsync(workerId);
            return Ok(result);
        }

        [HttpGet("workers")]
        public async Task<ActionResult<List<WorkerAvailabilityDto>>> GetAvailableWorkers([FromQuery] DateTime? date)
        {
            var result = await _availabilityService.GetAvailableWorkersAsync(date ?? DateTime.UtcNow.Date);
            return Ok(result);
        }
    }
}

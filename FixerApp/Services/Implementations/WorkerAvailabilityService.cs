using FixerApp.Models.DTOs;
using FixerApp.Models.Entities;
using FixerApp.Repositories.Interfaces;
using FixerApp.Services.Interfaces;

namespace FixerApp.Services.Implementations
{
    public class WorkerAvailabilityService : IWorkerAvailabilityService
    {
        private readonly IWorkerAvailabilityRepository _availabilityRepo;

        public WorkerAvailabilityService(IWorkerAvailabilityRepository availabilityRepo)
        {
            _availabilityRepo = availabilityRepo;
        }

        public async Task<WorkerAvailabilityDto> SetAvailabilityAsync(WorkerAvailabilityDto dto)
        {
            var user = await _availabilityRepo.GetByIdAsync(dto.WorkerId);
            if (user == null)
                throw new KeyNotFoundException("Technician not found");

            var availability = new WorkerAvailability
            {
                WorkerId = dto.WorkerId,
                AvailableDate = dto.AvailableDate,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                IsAvailable = dto.IsAvailable
            };

            var saved = await _availabilityRepo.SaveAsync(availability);

            return new WorkerAvailabilityDto
            {
                WorkerId = saved.WorkerId,
                AvailableDate = saved.AvailableDate,
                StartTime = saved.StartTime,
                EndTime = saved.EndTime,
                IsAvailable = saved.IsAvailable
            };
        }

        public async Task<List<WorkerAvailabilityDto>> GetAvailabilityByWorkerAsync(long workerId)
        {
            var items = await _availabilityRepo.GetByWorkerAndDateAsync(workerId, DateTime.UtcNow.Date);

            return items.Select(a => new WorkerAvailabilityDto
            {
                WorkerId = a.WorkerId,
                AvailableDate = a.AvailableDate,
                StartTime = a.StartTime,
                EndTime = a.EndTime,
                IsAvailable = a.IsAvailable
            }).ToList();
        }

        public async Task<List<WorkerAvailabilityDto>> GetAvailableWorkersAsync(DateTime date)
        {
            var items = await _availabilityRepo.GetAvailableByDateAsync(date);

            return items.Select(a => new WorkerAvailabilityDto
            {
                WorkerId = a.WorkerId,
                AvailableDate = a.AvailableDate,
                StartTime = a.StartTime,
                EndTime = a.EndTime,
                IsAvailable = a.IsAvailable
            }).ToList();
        }
    }
}

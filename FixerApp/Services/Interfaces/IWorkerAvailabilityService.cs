using FixerApp.Models.DTOs;

namespace FixerApp.Services.Interfaces
{
    public interface IWorkerAvailabilityService
    {
        Task<WorkerAvailabilityDto> SetAvailabilityAsync(WorkerAvailabilityDto dto);
        Task<List<WorkerAvailabilityDto>> GetAvailabilityByWorkerAsync(long workerId);
        Task<List<WorkerAvailabilityDto>> GetAvailableWorkersAsync(DateTime date);
    }
}

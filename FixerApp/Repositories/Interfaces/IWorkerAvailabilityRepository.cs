using FixerApp.Models.DTOs;
using FixerApp.Models.Entities;

namespace FixerApp.Repositories.Interfaces
{
    public interface IWorkerAvailabilityRepository
    {
        Task<WorkerAvailability> SaveAsync(WorkerAvailability entity);
        Task<List<WorkerAvailability>> GetByWorkerAndDateAsync(long workerId, DateTime date);
        Task<List<WorkerAvailability>> GetAvailableByDateAsync(DateTime date);
        Task<WorkerAvailability?> GetByIdAsync(long id);
    }
}

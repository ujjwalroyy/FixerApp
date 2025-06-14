using FixerApp.Models.Entities;

namespace FixerApp.Repositories.Interfaces
{
    public interface IJobTimelineRepository
    {
        Task AddEventAsync(JobTimeline evt);
        Task<List<JobTimeline>> GetTimelineAsync(long jobId);
    }
}

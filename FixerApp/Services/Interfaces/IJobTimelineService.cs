using FixerApp.Models.Entities;
using FixerApp.Models.Entities.Enums;

namespace FixerApp.Services.Interfaces
{
    public interface IJobTimelineService
    {
        Task AddEventAsync(long jobId, TimelineStage stage, string description);
        Task<List<JobTimeline>> GetTimelineAsync(long jobId);
    }
}

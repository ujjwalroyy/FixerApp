using FixerApp.Models.Entities;
using FixerApp.Models.Entities.Enums;
using FixerApp.Repositories.Interfaces;
using FixerApp.Services.Interfaces;

namespace FixerApp.Services.Implementations
{
    public class JobTimelineService : IJobTimelineService
    {
        private readonly IJobTimelineRepository _repository;

        public JobTimelineService(IJobTimelineRepository repository)
        {
            _repository = repository;
        }

        public async Task AddEventAsync(long jobId, TimelineStage stage, string description)
        {
            var evt = new JobTimeline
            {
                JobId = jobId,
                Stage = stage,
                Description = description,
                Timestamp = DateTime.UtcNow
            };

            await _repository.AddEventAsync(evt);
        }

        public async Task<List<JobTimeline>> GetTimelineAsync(long jobId)
        {
            return await _repository.GetTimelineAsync(jobId);
        }
    }
}

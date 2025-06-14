using FixerApp.Models.Entities;
using FixerApp.Repositories.Interfaces;
using FixrApp.Data;
using Microsoft.EntityFrameworkCore;

namespace FixerApp.Repositories.Implementations
{
    public class JobTimelineRepository : IJobTimelineRepository
    {
        private readonly ApplicationDbContext _context;

        public JobTimelineRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddEventAsync(JobTimeline evt)
        {
            _context.JobTimeline.Add(evt);
            await _context.SaveChangesAsync();
        }

        public async Task<List<JobTimeline>> GetTimelineAsync(long jobId)
        {
            return await _context.JobTimeline
                .Where(e => e.JobId == jobId)
                .OrderBy(e => e.Timestamp)
                .ToListAsync();
        }
    }
}
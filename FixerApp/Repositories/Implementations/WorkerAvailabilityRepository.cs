using FixerApp.Models.Entities;
using FixerApp.Repositories.Interfaces;
using FixrApp.Data;
using Microsoft.EntityFrameworkCore;

namespace FixerApp.Repositories.Implementations
{
    public class WorkerAvailabilityRepository : IWorkerAvailabilityRepository
    {
        private readonly ApplicationDbContext _context;

        public WorkerAvailabilityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<WorkerAvailability> SaveAsync(WorkerAvailability entity)
        {
            _context.WorkerAvailability.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<WorkerAvailability>> GetByWorkerAndDateAsync(long workerId, DateTime date)
        {
            return await _context.WorkerAvailability
                .Where(a => a.WorkerId == workerId && a.AvailableDate.Date == date.Date)
                .ToListAsync();
        }

        public async Task<List<WorkerAvailability>> GetAvailableByDateAsync(DateTime date)
        {
            return await _context.WorkerAvailability
                .Include(w => w.Worker)
                .Where(a => a.AvailableDate.Date == date.Date && a.IsAvailable)
                .ToListAsync();
        }

        public async Task<WorkerAvailability?> GetByIdAsync(long id)
        {
            return await _context.WorkerAvailability
                .Include(w => w.Worker)
                .FirstOrDefaultAsync(w => w.Id == id);
        }
    }
}

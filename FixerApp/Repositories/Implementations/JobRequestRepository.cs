using FixerApp.Data;
using FixerApp.Models.Entities;
using FixerApp.Models.Entities.Enums;
using FixerApp.Repositories.Interfaces;
using FixrApp.Data;

namespace FixerApp.Repositories.Implementations
{
    public class JobRequestRepository : IJobRequestRepository
    {
        private readonly ApplicationDbContext _context;
        public JobRequestRepository(ApplicationDbContext context) => _context = context;

        public JobRequest Add(JobRequest job)
        {
            _context.JobRequests.Add(job);
            _context.SaveChanges();
            return job;
        }

        public JobRequest Update(JobRequest job)
        {
            _context.JobRequests.Update(job);
            _context.SaveChanges();
            return job;
        }

        public JobRequest GetById(long id) => _context.JobRequests.Find(id) ?? throw new InvalidOperationException($"Job Request with ID {id} not found.");

        public List<JobRequest> GetRefundedJobs() => _context.JobRequests.Where(j => j.Refunded).ToList();

        public List<JobRequest> GetAll() => _context.JobRequests.ToList();

        public List<JobRequest> GetByUserId(long userId) => _context.JobRequests.Where(j => j.UserId == userId).ToList();

        public List<JobRequest> GetByWorkerId(long workerId) => _context.JobRequests.Where(j => j.WorkerId == workerId).ToList();

        public List<JobRequest> GetByStatus(JobStatus status) => _context.JobRequests.Where(j => j.Status == status).ToList();
    }
}
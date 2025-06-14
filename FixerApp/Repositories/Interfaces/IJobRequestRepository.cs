using FixerApp.Models.Entities;
using FixerApp.Models.Entities.Enums;

namespace FixerApp.Repositories.Interfaces
{
    public interface IJobRequestRepository
    {
        JobRequest Add(JobRequest job);
        JobRequest Update(JobRequest job);
        JobRequest GetById(long id);
        List<JobRequest> GetRefundedJobs();
        List<JobRequest> GetAll();
        List<JobRequest> GetByUserId(long userId);
        List<JobRequest> GetByWorkerId(long workerId);
        List<JobRequest> GetByStatus(JobStatus status);
    }
}

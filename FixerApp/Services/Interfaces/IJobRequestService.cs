using FixerApp.Models.DTOs;
using FixerApp.Models.Entities;

namespace FixerApp.Services.Interfaces
{
    public interface IJobRequestService
    {
        JobRequest CreateJob(JobRequestDto dto);
        JobRequest CancelJob(CancelJobRequestDto dto);
        List<JobRequest> GetRefundedJobs();
        List<JobRequest> GetAllJobs();
        List<JobRequest> GetJobsByUserId(long userId);
    }

}

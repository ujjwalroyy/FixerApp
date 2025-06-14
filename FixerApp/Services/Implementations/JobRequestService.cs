using System;
using System.Reflection;
using FixerApp.Models.DTOs;
using FixerApp.Models.Entities;
using FixerApp.Repositories.Interfaces;
using FixerApp.Services.Interfaces;
using FixerApp.Models.Entities.Enums;

namespace FixerApp.Services.Implementations
{
    public class JobRequestService : IJobRequestService
    {
        private readonly IJobRequestRepository _repo;

        public JobRequestService(IJobRequestRepository repo) => _repo = repo;

        public JobRequest CreateJob(JobRequestDto dto)
        {
            var job = new JobRequest
            {
                Category = dto.Category,
                SubCategory = dto.SubCategory,
                Description = dto.Description,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                EstimatedPrice = dto.EstimatedPrice,
                UserId = dto.UserId ?? throw new Exception("UserId is required"),
                WorkerId = dto.WorkerId
            };

            return _repo.Add(job);
        }

        public JobRequest CancelJob(CancelJobRequestDto dto)
        {
            var job = _repo.GetById(dto.JobId);
            if (job == null) throw new Exception("Job not found");

            job.Status = JobStatus.CANCELLED;
            job.Refunded = true;
            job.RefundReason = dto.Reason;

            return _repo.Update(job);
        }

        public List<JobRequest> GetRefundedJobs() => _repo.GetRefundedJobs();

        public List<JobRequest> GetAllJobs() => _repo.GetAll();

        public List<JobRequest> GetJobsByUserId(long userId) => _repo.GetByUserId(userId);
    }
}
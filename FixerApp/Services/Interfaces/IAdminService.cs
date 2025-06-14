using System.Data;
using FixerApp.Models.DTOs;
using FixerApp.Models.Entities.Enums;

namespace FixerApp.Services.Interfaces
{
    public interface IAdminService
    {
        List<JobRequestDto> getAllJobs(JobStatus status, long userId);

        List<JobRequestDto> getAllJobs(JobStatus status);

        List<UserDto> getAllUsers(UserRole role);
    }
}

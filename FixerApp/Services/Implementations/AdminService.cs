using FixerApp.Models.DTOs;
using FixerApp.Models.Entities.Enums;
using FixerApp.Repositories.Implementations;
using FixerApp.Services.Interfaces;

namespace FixerApp.Services.Implementations
{
    public class AdminService : IAdminService
    {

        private readonly JobRequestRepository _jobRequestRepository;
        private readonly UserRepository _userRepository;

        public AdminService(JobRequestRepository jobRequestRepository, UserRepository userRepository)
        {
            _jobRequestRepository = jobRequestRepository;
            _userRepository = userRepository;
        }

        public List<JobRequestDto> getAllJobs(JobStatus status, long userId)
        {
            throw new NotImplementedException();

        }

        public List<JobRequestDto> getAllJobs(JobStatus status)
        {
            throw new NotImplementedException();
        }

        public List<UserDto> getAllUsers(UserRole role)
        {
            throw new NotImplementedException();
        }
    }
}

using FixerApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FixerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IJobRequestService _jobRequestService;

        public AdminController(IAdminService adminService, IJobRequestService jobRequestService)
        {
            _adminService = adminService;
            _jobRequestService = jobRequestService;
        }

        
    }
}

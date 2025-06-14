using FixerApp.Models.Entities.Enums;

namespace FixerApp.Models.DTOs
{
    public class RegisterDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public UserRole Role { get; set; } 
    }
}

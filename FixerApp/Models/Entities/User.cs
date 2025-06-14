using FixerApp.Models.Entities.Enums;

namespace FixerApp.Models.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }

        public string? Address { get; set; }
        public UserRole Role { get; set; } = UserRole.USER;
        public string? Phone { get; set; }
        public string? FcmToken { get; set; }
        public bool Verified { get; set; }
        public string? DocumentUrl { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}

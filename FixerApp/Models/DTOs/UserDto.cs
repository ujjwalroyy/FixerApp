using System.ComponentModel.DataAnnotations;
using System.Data;
using FixerApp.Models.Entities.Enums;

namespace FixerApp.Models.DTOs
{
    public class UserDto
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        [Phone]
        public string? Phone { get; set; }

        public string? Address { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public UserRole? Role { get; set; }
    }
}

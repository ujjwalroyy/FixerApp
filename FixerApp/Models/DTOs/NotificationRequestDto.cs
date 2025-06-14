using FixerApp.Models.Entities.Enums;

namespace FixerApp.Models.DTOs
{
    public class NotificationRequestDto
    {
        public long UserId { get; set; }
        public string? Message { get; set; }
        public NotificationType Type { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? FcmToken { get; set; }
    }
}

namespace FixerApp.Models.DTOs
{
    public class NotificationDto
    {
        public long Id { get; set; }
        public string? Message { get; set; }
        public bool Read { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

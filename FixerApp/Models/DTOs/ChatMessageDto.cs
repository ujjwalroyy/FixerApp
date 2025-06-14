namespace FixerApp.Models.DTOs
{
    public class ChatMessageDto
    {
        public long SenderId { get; set; }
        public long ReceiverId { get; set; }
        public long JobId { get; set; }
        public string Text { get; set; } = string.Empty;
        public string? FileUrl { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}

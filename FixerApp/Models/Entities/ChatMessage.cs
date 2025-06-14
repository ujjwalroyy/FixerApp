using System.ComponentModel.DataAnnotations;

namespace FixerApp.Models.Entities
{
    public class ChatMessage
    {
        [Key]
        public int Id { get; set; }
        public long SenderId { get; set; }
        public long ReceiverId { get; set; }
        public long JobId { get; set; }
        public string Text { get; set; } = string.Empty;
        public bool Read { get; set; } = false;
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
        public string? FileUrl { get; set; }

        public User? Sender { get; set; }
        public User? Receiver { get; set; }
    }
}

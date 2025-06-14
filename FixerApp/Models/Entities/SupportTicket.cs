using FixerApp.Models.Entities.Enums;

namespace FixerApp.Models.Entities
{
    public class SupportTicket
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? AdminResponse { get; set; }
        public TicketStatus Status { get; set; } = TicketStatus.Pending;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ResolvedAt { get; set; }

        public User? User { get; set; }
    }
}

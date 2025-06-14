using FixerApp.Models.Entities.Enums;

namespace FixerApp.Models.DTOs
{
    public class SupportTicketDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string? Message { get; set; }
        public string? AdminResponse { get; set; }
        public TicketStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
    }
}

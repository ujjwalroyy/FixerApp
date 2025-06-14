using FixerApp.Models.Entities.Enums;

namespace FixerApp.Models.DTOs
{
    public class DisputeDTO
    {
        public long Id { get; set; }
        public long JobId { get; set; }
        public long UserId { get; set; }
        public string? Reason { get; set; }
        public string? AdminComment { get; set; }
        public DisputeStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

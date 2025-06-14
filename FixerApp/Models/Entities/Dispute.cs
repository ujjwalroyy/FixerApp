using System.ComponentModel.DataAnnotations;
using FixerApp.Models.Entities.Enums;

namespace FixerApp.Models.Entities
{
    public class Dispute
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long JobId { get; set; }

        [Required]
        public long UserId { get; set; }

        [Required, MaxLength(500)]
        public string? Reason { get; set; }

        [MaxLength(500)]
        public string? AdminComment { get; set; }

        [Required]
        public DisputeStatus Status { get; set; } = DisputeStatus.PENDING;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

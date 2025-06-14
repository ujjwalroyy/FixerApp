using System.ComponentModel.DataAnnotations;
using FixerApp.Models.Entities.Enums;

namespace FixerApp.Models.Entities
{
    public class JobTimeline
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long JobId { get; set; }

        [Required]
        public TimelineStage Stage { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
